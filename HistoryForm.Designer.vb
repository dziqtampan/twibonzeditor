<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HistoryForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTitle = New Label()
        lstHistory = New ListBox()
        lblEmpty = New Label()
        btnClose = New Button()
        SuspendLayout()
        '
        ' lblTitle
        '
        lblTitle.Dock = DockStyle.Top
        lblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.MidnightBlue
        lblTitle.Location = New Point(0, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Padding = New Padding(20, 0, 0, 0)
        lblTitle.Size = New Size(760, 62)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Riwayat Proyek"
        lblTitle.TextAlign = ContentAlignment.MiddleLeft
        '
        ' lstHistory
        '
        lstHistory.Dock = DockStyle.Fill
        lstHistory.Font = New Font("Segoe UI", 10.0F)
        lstHistory.FormattingEnabled = True
        lstHistory.ItemHeight = 23
        lstHistory.Location = New Point(0, 62)
        lstHistory.Name = "lstHistory"
        lstHistory.Padding = New Padding(12)
        lstHistory.Size = New Size(760, 340)
        lstHistory.TabIndex = 1
        '
        ' lblEmpty
        '
        lblEmpty.Dock = DockStyle.Fill
        lblEmpty.Font = New Font("Segoe UI", 11.0F)
        lblEmpty.ForeColor = Color.Gray
        lblEmpty.Location = New Point(0, 62)
        lblEmpty.Name = "lblEmpty"
        lblEmpty.Size = New Size(760, 340)
        lblEmpty.TabIndex = 2
        lblEmpty.Text = "Belum ada aktivitas proyek."
        lblEmpty.TextAlign = ContentAlignment.MiddleCenter
        lblEmpty.Visible = False
        '
        ' btnClose
        '
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.Location = New Point(630, 415)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 38)
        btnClose.TabIndex = 3
        btnClose.Text = "Tutup"
        btnClose.UseVisualStyleBackColor = True
        '
        ' HistoryForm
        '
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(760, 470)
        Controls.Add(lblEmpty)
        Controls.Add(lstHistory)
        Controls.Add(lblTitle)
        Controls.Add(btnClose)
        MinimumSize = New Size(600, 380)
        Name = "HistoryForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Riwayat Proyek"
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lstHistory As ListBox
    Friend WithEvents lblEmpty As Label
    Friend WithEvents btnClose As Button
End Class
