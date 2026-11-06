
Imports MySql.Data.MySqlClient

Module DbConfig

    Public ReadOnly ConnectionString As String =
        "Server=127.0.0.1;" &
        "Port=3307;" &
        "Database=twibbon_studio;" &
        "Uid=root;" &
        "Pwd=;" &
        "SslMode=Disabled;"

    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(ConnectionString)
    End Function

    Public Function TestConnection() As String
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Return "Koneksi ke database berhasil!"
            End Using

        Catch ex As Exception
            Return "Koneksi gagal: " & ex.Message
        End Try
    End Function

    Public Sub EnsureProjectTable()
        Using conn As MySqlConnection = GetConnection()
            conn.Open()
            Dim usersSql As String = "CREATE TABLE IF NOT EXISTS users (" &
                "id INT NOT NULL AUTO_INCREMENT PRIMARY KEY," &
                "nama VARCHAR(100) NOT NULL," &
                "email VARCHAR(150) NOT NULL UNIQUE," &
                "password_hash VARCHAR(255) NOT NULL," &
                "created_at TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP) ENGINE=InnoDB"
            Using usersCmd As New MySqlCommand(usersSql, conn)
                usersCmd.ExecuteNonQuery()
            End Using
            Dim sql As String = "CREATE TABLE IF NOT EXISTS projects (" &
                "id INT NOT NULL AUTO_INCREMENT PRIMARY KEY," &
                "user_id INT NOT NULL," &
                "nama_proyek VARCHAR(150) NOT NULL," &
                "foto_path VARCHAR(500) NULL," &
                "twibbon_path VARCHAR(500) NULL," &
                "hasil_path VARCHAR(500) NULL," &
                "zoom DECIMAL(6,2) NULL DEFAULT 1.00," &
                "posisi_x INT NULL DEFAULT 0," &
                "posisi_y INT NULL DEFAULT 0," &
                "created_at TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP," &
                "updated_at TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," &
                "INDEX idx_projects_user_updated (user_id, updated_at)) ENGINE=InnoDB"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.ExecuteNonQuery()
            End Using
            Dim historySql As String = "CREATE TABLE IF NOT EXISTS project_history (" &
                "id INT NOT NULL AUTO_INCREMENT PRIMARY KEY," &
                "project_id INT NOT NULL," &
                "aktivitas VARCHAR(100) NOT NULL," &
                "waktu TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP," &
                "INDEX idx_project_history_project (project_id)) ENGINE=InnoDB"
            Using historyCmd As New MySqlCommand(historySql, conn)
                historyCmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
