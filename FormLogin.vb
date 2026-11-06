
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Public Class FormLogin

    Public LoggedInSession As Session

    ' Verifikasi password dengan hash yang tersimpan di database
    Private Function VerifikasiPassword(
        password As String,
        passwordHash As String
    ) As Boolean

        Try
            Dim bagian As String() = passwordHash.Split(":"c)

            If bagian.Length <> 2 Then Return False

            Dim salt As Byte() =
                Convert.FromBase64String(bagian(0))

            Dim hashAsli As Byte() =
                Convert.FromBase64String(bagian(1))

            Dim hashInput As Byte() = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, 100000, HashAlgorithmName.SHA256, 32)
            Return CryptographicOperations.FixedTimeEquals(hashAsli, hashInput)

        Catch
            Return False
        End Try

    End Function

    ' Tombol LOGIN
    Private Sub btnLogin_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnLogin.Click

        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text

        If email = "" OrElse password = "" Then
            MessageBox.Show("Email dan password wajib diisi.")
            Return
        End If

        Try
            Dim userId As Integer = 0
            Dim namaUser As String = ""
            Dim hashTersimpan As String = ""

            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Dim sql As String =
                    "SELECT id, nama, password_hash " &
                    "FROM users WHERE email = @email LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@email", email)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            userId = Convert.ToInt32(reader("id"))
                            namaUser = reader("nama").ToString()
                            hashTersimpan =
                                reader("password_hash").ToString()
                        End If
                    End Using
                End Using
            End Using

            If userId = 0 OrElse
               Not VerifikasiPassword(password, hashTersimpan) Then

                MessageBox.Show(
                    "Email atau password salah.",
                    "Login Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                Return
            End If

            ' Simpan data akun pada form ini
            Me.LoggedInSession = New Session With {
                .UserId = userId,
                .Nama = namaUser,
                .Email = email
            }

            MessageBox.Show(
                "Selamat datang, " & namaUser & "!",
                "Login Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(
                "Gagal login: " & ex.Message,
                "Kesalahan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnKeRegister_Click(
    sender As Object,
    e As EventArgs
) Handles btnKeRegister.Click

        Me.Hide()

        Using halamanRegister As New FormRegister()
            halamanRegister.ShowDialog()
        End Using

        Me.Show()
        Me.Activate()

    End Sub


End Class
