Partial Public Class SplashScreen
    Private langkah As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim logoPath As String = IO.Path.Combine(AppContext.BaseDirectory, "Assets", "Twibonze Studio Monogram Logo.png")
        If Not IO.File.Exists(logoPath) Then Return
        Try
            Using sumber As Image = Image.FromFile(logoPath)
                picLogo.Image = New Bitmap(sumber)
            End Using
        Catch
            ' Keep the splash screen usable if the optional logo file is unavailable.
        End Try
    End Sub

    Private Sub SplashScreen_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        tmrSplash.Start()
    End Sub

    Private Sub tmrSplash_Tick(sender As Object, e As EventArgs) Handles tmrSplash.Tick
        langkah = Math.Min(langkah + 4, 100)
        prgLoading.Value = langkah
        lblLoading.Text = If(langkah < 100, "Menyiapkan aplikasi... " & langkah & "%", "Membuka Twibbon Studio...")
        If langkah < 100 Then Return

        tmrSplash.Stop()
        Hide()

        Try
            EnsureProjectTable()
        Catch ex As Exception
            MessageBox.Show("Tidak dapat tersambung ke database. Periksa MySQL lalu coba lagi." & Environment.NewLine & ex.Message,
                            "Koneksi Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
            Return
        End Try

        While True
            Using login As New FormLogin()
                If login.ShowDialog() <> DialogResult.OK OrElse login.LoggedInSession Is Nothing Then Exit While
                Using dashboard As New DashboardForm(login.LoggedInSession)
                    dashboard.ShowDialog()
                    If Not dashboard.MintaLogout Then Exit While
                End Using
            End Using
        End While
        Close()
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        tmrSplash.Stop()
        If picLogo.Image IsNot Nothing Then
            picLogo.Image.Dispose()
            picLogo.Image = Nothing
        End If
        MyBase.OnFormClosed(e)
    End Sub

End Class
