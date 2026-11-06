Partial Public Class DashboardForm
    Private ReadOnly akun As Session
    Public MintaLogout As Boolean

    Public Sub New(userSession As Session)
        InitializeComponent()
        akun = userSession
        lblWelcome.Text = "Halo, " & akun.Nama
    End Sub

    Private Sub DashboardForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        MuatDaftar()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        MintaLogout = True
        Close()
    End Sub

    Private Sub btnNewProject_Click(sender As Object, e As EventArgs) Handles btnNewProject.Click
        Using editor As New Form1(akun)
            editor.ShowDialog()
        End Using
        MuatDaftar()
    End Sub

    Private Sub btnOpenProject_Click(sender As Object, e As EventArgs) Handles btnOpenProject.Click
        BukaTerpilih()
    End Sub

    Private Sub listProjects_DoubleClick(sender As Object, e As EventArgs) Handles listProjects.DoubleClick
        BukaTerpilih()
    End Sub

    Private Sub btnDeleteProject_Click(sender As Object, e As EventArgs) Handles btnDeleteProject.Click
        Dim item As ProjectSummary = TryCast(listProjects.SelectedItem, ProjectSummary)
        If item Is Nothing Then Return
        If MessageBox.Show("Hapus proyek '" & item.Nama & "'?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            ProjectRepository.DeleteProject(akun.UserId, item.Id)
            MuatDaftar()
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus proyek: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Using history As New HistoryForm(akun.UserId)
            history.ShowDialog(Me)
        End Using
    End Sub

    Private Sub MuatDaftar()
        Try
            listProjects.DataSource = Nothing
            listProjects.DataSource = ProjectRepository.ListProjects(akun.UserId)
        Catch ex As Exception
            MessageBox.Show("Gagal memuat riwayat proyek: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BukaTerpilih()
        Dim item As ProjectSummary = TryCast(listProjects.SelectedItem, ProjectSummary)
        If item Is Nothing Then Return
        Try
            Dim proyek As SavedProject = ProjectRepository.GetProject(akun.UserId, item.Id)
            If proyek Is Nothing Then
                MuatDaftar()
                Return
            End If
            Using editor As New Form1(akun, proyek)
                editor.ShowDialog()
            End Using
            MuatDaftar()
        Catch ex As Exception
            MessageBox.Show("Gagal membuka proyek: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
