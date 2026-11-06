Imports MySql.Data.MySqlClient

Public Class SavedProject
    Public Property Id As Integer
    Public Property Nama As String = "Proyek baru"
    Public Property Foto As Byte()
    Public Property Twibbon As Byte()
    Public Property Zoom As Single = 1.0F
    Public Property PosisiX As Single
    Public Property PosisiY As Single
    Public Property Diperbarui As DateTime
End Class

Public Class ProjectSummary
    Public Property Id As Integer
    Public Property Nama As String
    Public Property Diperbarui As DateTime
    Public Overrides Function ToString() As String
        Return Nama & "   •   " & Diperbarui.ToString("dd MMM yyyy HH:mm")
    End Function
End Class

Public Class HistorySummary
    Public Property NamaProyek As String
    Public Property Aktivitas As String
    Public Property Waktu As DateTime
    Public Overrides Function ToString() As String
        Return Waktu.ToString("dd MMM yyyy HH:mm") & "  •  " & NamaProyek & "  •  " & Aktivitas
    End Function
End Class

Public Module ProjectRepository
    Public Function ListProjects(userId As Integer) As List(Of ProjectSummary)
        EnsureProjectTable()
        Dim projects As New List(Of ProjectSummary)()
        Using conn As MySqlConnection = GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand("SELECT id, nama_proyek, updated_at FROM projects WHERE user_id=@user_id ORDER BY updated_at DESC", conn)
                cmd.Parameters.AddWithValue("@user_id", userId)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        projects.Add(New ProjectSummary With {
                            .Id = Convert.ToInt32(reader("id")),
                            .Nama = reader("nama_proyek").ToString(),
                            .Diperbarui = If(reader.IsDBNull(reader.GetOrdinal("updated_at")), DateTime.Now, Convert.ToDateTime(reader("updated_at")))
                        })
                    End While
                End Using
            End Using
        End Using
        Return projects
    End Function

    Public Function ListHistory(userId As Integer) As List(Of HistorySummary)
        EnsureProjectTable()
        Dim history As New List(Of HistorySummary)()
        Using conn As MySqlConnection = GetConnection()
            conn.Open()
            Dim sql As String = "SELECT p.nama_proyek, h.aktivitas, h.waktu " &
                                "FROM project_history h INNER JOIN projects p ON p.id=h.project_id " &
                                "WHERE p.user_id=@user_id ORDER BY h.waktu DESC LIMIT 200"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@user_id", userId)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        history.Add(New HistorySummary With {
                            .NamaProyek = reader("nama_proyek").ToString(),
                            .Aktivitas = reader("aktivitas").ToString(),
                            .Waktu = If(reader.IsDBNull(reader.GetOrdinal("waktu")), DateTime.Now, Convert.ToDateTime(reader("waktu")))
                        })
                    End While
                End Using
            End Using
        End Using
        Return history
    End Function

    Public Function GetProject(userId As Integer, projectId As Integer) As SavedProject
        EnsureProjectTable()
        Using conn As MySqlConnection = GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand("SELECT id, nama_proyek, foto_path, twibbon_path, zoom, posisi_x, posisi_y, updated_at FROM projects WHERE user_id=@user_id AND id=@id LIMIT 1", conn)
                cmd.Parameters.AddWithValue("@user_id", userId)
                cmd.Parameters.AddWithValue("@id", projectId)
                Using reader = cmd.ExecuteReader()
                    If Not reader.Read() Then Return Nothing
                    Dim fotoPath As String = If(reader.IsDBNull(reader.GetOrdinal("foto_path")), "", reader("foto_path").ToString())
                    Dim twibbonPath As String = If(reader.IsDBNull(reader.GetOrdinal("twibbon_path")), "", reader("twibbon_path").ToString())
                    If fotoPath = "" OrElse twibbonPath = "" OrElse Not IO.File.Exists(fotoPath) OrElse Not IO.File.Exists(twibbonPath) Then
                        Throw New IO.FileNotFoundException("File foto atau Twibbon untuk proyek ini tidak ditemukan di lokasi penyimpanannya.")
                    End If
                    Return New SavedProject With {
                        .Id = Convert.ToInt32(reader("id")),
                        .Nama = reader("nama_proyek").ToString(),
                        .Foto = IO.File.ReadAllBytes(fotoPath),
                        .Twibbon = IO.File.ReadAllBytes(twibbonPath),
                        .Zoom = If(reader.IsDBNull(reader.GetOrdinal("zoom")), 1.0F, Convert.ToSingle(reader("zoom"))),
                        .PosisiX = If(reader.IsDBNull(reader.GetOrdinal("posisi_x")), 0.0F, Convert.ToSingle(reader("posisi_x"))),
                        .PosisiY = If(reader.IsDBNull(reader.GetOrdinal("posisi_y")), 0.0F, Convert.ToSingle(reader("posisi_y"))),
                        .Diperbarui = If(reader.IsDBNull(reader.GetOrdinal("updated_at")), DateTime.Now, Convert.ToDateTime(reader("updated_at")))
                    }
                End Using
            End Using
        End Using
    End Function

    Public Function SaveProject(userId As Integer, project As SavedProject) As Integer
        EnsureProjectTable()
        If project.Foto Is Nothing OrElse project.Twibbon Is Nothing Then Throw New InvalidOperationException("Foto dan Twibbon wajib tersedia untuk menyimpan proyek.")

        Dim newFotoPath As String = Nothing
        Dim newTwibbonPath As String = Nothing
        Dim oldFotoPath As String = Nothing
        Dim oldTwibbonPath As String = Nothing
        Dim wasNew As Boolean = project.Id <= 0

        Using conn As MySqlConnection = GetConnection()
            conn.Open()
            Using transaction As MySqlTransaction = conn.BeginTransaction()
                Try
                    If wasNew Then
                        Dim insertSql As String = "INSERT INTO projects (user_id, nama_proyek, zoom, posisi_x, posisi_y) " &
                                                  "VALUES (@user_id, @nama, @zoom, @x, @y)"
                        Using cmd As New MySqlCommand(insertSql, conn, transaction)
                            AddProjectParameters(cmd, userId, project)
                            cmd.ExecuteNonQuery()
                            project.Id = CInt(cmd.LastInsertedId)
                        End Using
                    Else
                        Using cmd As New MySqlCommand("SELECT foto_path, twibbon_path FROM projects WHERE id=@id AND user_id=@user_id FOR UPDATE", conn, transaction)
                            cmd.Parameters.AddWithValue("@id", project.Id)
                            cmd.Parameters.AddWithValue("@user_id", userId)
                            Using reader = cmd.ExecuteReader()
                                If Not reader.Read() Then Throw New InvalidOperationException("Proyek tidak ditemukan atau bukan milik akun ini.")
                                oldFotoPath = If(reader.IsDBNull(0), Nothing, reader.GetString(0))
                                oldTwibbonPath = If(reader.IsDBNull(1), Nothing, reader.GetString(1))
                            End Using
                        End Using
                    End If

                    Dim folder As String = IO.Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "TwibbonStudio", "Projects", userId.ToString(), project.Id.ToString(), Guid.NewGuid().ToString("N"))
                    IO.Directory.CreateDirectory(folder)
                    newFotoPath = IO.Path.Combine(folder, "foto.png")
                    newTwibbonPath = IO.Path.Combine(folder, "twibbon.png")
                    IO.File.WriteAllBytes(newFotoPath, project.Foto)
                    IO.File.WriteAllBytes(newTwibbonPath, project.Twibbon)

                    Dim updateSql As String = "UPDATE projects SET nama_proyek=@nama, foto_path=@foto_path, twibbon_path=@twibbon_path, " &
                                              "zoom=@zoom, posisi_x=@x, posisi_y=@y WHERE id=@id AND user_id=@user_id"
                    Using cmd As New MySqlCommand(updateSql, conn, transaction)
                        AddProjectParameters(cmd, userId, project)
                        cmd.Parameters.AddWithValue("@foto_path", newFotoPath)
                        cmd.Parameters.AddWithValue("@twibbon_path", newTwibbonPath)
                        cmd.Parameters.AddWithValue("@id", project.Id)
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim aktivitas As String = If(wasNew, "Proyek dibuat", "Proyek diperbarui")
                    Using historyCmd As New MySqlCommand("INSERT INTO project_history (project_id, aktivitas) VALUES (@project_id, @aktivitas)", conn, transaction)
                        historyCmd.Parameters.AddWithValue("@project_id", project.Id)
                        historyCmd.Parameters.AddWithValue("@aktivitas", aktivitas)
                        historyCmd.ExecuteNonQuery()
                    End Using
                    transaction.Commit()
                Catch
                    Try
                        transaction.Rollback()
                    Catch
                    End Try
                    HapusFileAset(newFotoPath)
                    HapusFileAset(newTwibbonPath)
                    Throw
                End Try
            End Using
        End Using

        If Not wasNew Then
            HapusFileAset(oldFotoPath)
            HapusFileAset(oldTwibbonPath)
        End If
        Return project.Id
    End Function

    Private Sub AddProjectParameters(cmd As MySqlCommand, userId As Integer, project As SavedProject)
        cmd.Parameters.AddWithValue("@user_id", userId)
        cmd.Parameters.AddWithValue("@nama", project.Nama)
        cmd.Parameters.AddWithValue("@zoom", project.Zoom)
        cmd.Parameters.AddWithValue("@x", CInt(Math.Round(project.PosisiX, MidpointRounding.AwayFromZero)))
        cmd.Parameters.AddWithValue("@y", CInt(Math.Round(project.PosisiY, MidpointRounding.AwayFromZero)))
    End Sub

    Public Sub DeleteProject(userId As Integer, projectId As Integer)
        EnsureProjectTable()
        Dim fotoPath As String = Nothing
        Dim twibbonPath As String = Nothing
        Using conn As MySqlConnection = GetConnection()
            conn.Open()
            Using transaction As MySqlTransaction = conn.BeginTransaction()
                Using cmd As New MySqlCommand("SELECT foto_path, twibbon_path FROM projects WHERE id=@id AND user_id=@user_id FOR UPDATE", conn, transaction)
                    cmd.Parameters.AddWithValue("@id", projectId)
                    cmd.Parameters.AddWithValue("@user_id", userId)
                    Using reader = cmd.ExecuteReader()
                        If Not reader.Read() Then Return
                        fotoPath = If(reader.IsDBNull(0), Nothing, reader.GetString(0))
                        twibbonPath = If(reader.IsDBNull(1), Nothing, reader.GetString(1))
                    End Using
                End Using
                Using cmd As New MySqlCommand("DELETE FROM projects WHERE id=@id AND user_id=@user_id", conn, transaction)
                    cmd.Parameters.AddWithValue("@id", projectId)
                    cmd.Parameters.AddWithValue("@user_id", userId)
                    cmd.ExecuteNonQuery()
                End Using
                transaction.Commit()
            End Using
        End Using
        HapusFileAset(fotoPath)
        HapusFileAset(twibbonPath)
    End Sub

    Private Sub HapusFileAset(path As String)
        If String.IsNullOrWhiteSpace(path) OrElse Not IO.File.Exists(path) Then Return
        Dim root As String = IO.Path.GetFullPath(IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TwibbonStudio", "Projects")) & IO.Path.DirectorySeparatorChar
        Dim fullPath As String = IO.Path.GetFullPath(path)
        If Not fullPath.StartsWith(root, StringComparison.OrdinalIgnoreCase) Then Return
        Try
            IO.File.Delete(fullPath)
        Catch
        End Try
    End Sub
End Module
