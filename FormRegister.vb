
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Public Class FormRegister

    ' Membuat hash password yang aman
    Private Function BuatHash(password As String) As String

        Dim salt(15) As Byte

        Using rng As RandomNumberGenerator =
            RandomNumberGenerator.Create()

            rng.GetBytes(salt)
        End Using

        Dim hash As Byte() = Rfc2898DeriveBytes.Pbkdf2(
            password, salt, 100000, HashAlgorithmName.SHA256, 32)
        Return Convert.ToBase64String(salt) & ":" & Convert.ToBase64String(hash)

    End Function

    ' Tombol DAFTAR
    Private Sub btnDaftar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDaftar.Click

        Dim nama As String = txtNama.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text

        ' Validasi input
        If nama = "" OrElse email = "" OrElse password = "" Then

            MessageBox.Show(
                "Nama, email, dan password wajib diisi.",
                "Data Belum Lengkap",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return
        End If

        If Not email.Contains("@") OrElse
           Not email.Contains(".") Then

            MessageBox.Show("Masukkan alamat email yang valid.")
            Return
        End If

        If password.Length < 8 Then

            MessageBox.Show(
                "Password minimal 8 karakter.",
                "Password Tidak Valid",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return
        End If

        Try
            ' Simpan pengguna ke database
            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Dim sql As String =
                    "INSERT INTO users " &
                    "(nama, email, password_hash) " &
                    "VALUES (@nama, @email, @password_hash)"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@nama", nama)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue(
                        "@password_hash",
                        BuatHash(password))

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            ' Registrasi sukses, kembali ke halaman Login
            MessageBox.Show(
                "Registrasi berhasil!" &
                Environment.NewLine &
                "Silakan login menggunakan akun yang baru dibuat.",
                "Registrasi Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Me.Close()

        Catch ex As MySqlException

            If ex.Number = 1062 Then

                MessageBox.Show(
                    "Email sudah terdaftar. Gunakan email lain.",
                    "Email Duplikat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

            Else

                MessageBox.Show(
                    "Gagal menyimpan akun ke database:" &
                    Environment.NewLine & ex.Message,
                    "Kesalahan Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            MessageBox.Show(
                "Terjadi kesalahan:" &
                Environment.NewLine & ex.Message,
                "Kesalahan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    ' Tombol kembali ke Login

    Private Sub btnKeLogin_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnKeLogin.Click

        Me.Close()

    End Sub


End Class
