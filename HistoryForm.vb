Partial Public Class HistoryForm
    Private ReadOnly userId As Integer

    Public Sub New(accountId As Integer)
        InitializeComponent()
        userId = accountId
    End Sub

    Private Sub HistoryForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            lstHistory.DataSource = ProjectRepository.ListHistory(userId)
            If lstHistory.Items.Count = 0 Then lblEmpty.Visible = True
        Catch ex As Exception
            MessageBox.Show("Gagal memuat riwayat: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
