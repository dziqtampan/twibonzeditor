<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DashboardForm
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
        pnlHeader = New Panel()
        lblWelcome = New Label()
        lblTitle = New Label()
        btnLogout = New Button()
        pnlContent = New Panel()
        listProjects = New ListBox()
        pnlActions = New Panel()
        btnDeleteProject = New Button()
        btnOpenProject = New Button()
        btnNewProject = New Button()
        btnHistory = New Button()
        lblHeading = New Label()
        pnlHeader.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlActions.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.MidnightBlue
        pnlHeader.Controls.Add(lblWelcome)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(btnLogout)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Margin = New Padding(4, 4, 4, 4)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1125, 156)
        pnlHeader.TabIndex = 0
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Segoe UI", 11.0F)
        lblWelcome.ForeColor = Color.WhiteSmoke
        lblWelcome.Location = New Point(40, 95)
        lblWelcome.Margin = New Padding(4, 0, 4, 0)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(167, 30)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Halo, pengguna"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(35, 25)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(372, 54)
        lblTitle.TabIndex = 0
        lblTitle.Text = "TWIBBON STUDIO"
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.Location = New Point(962, 52)
        btnLogout.Margin = New Padding(4, 4, 4, 4)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(125, 48)
        btnLogout.TabIndex = 2
        btnLogout.Text = "Keluar"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.WhiteSmoke
        pnlContent.Controls.Add(listProjects)
        pnlContent.Controls.Add(pnlActions)
        pnlContent.Controls.Add(lblHeading)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 156)
        pnlContent.Margin = New Padding(4, 4, 4, 4)
        pnlContent.Name = "pnlContent"
        pnlContent.Padding = New Padding(35, 35, 35, 35)
        pnlContent.Size = New Size(1125, 594)
        pnlContent.TabIndex = 1
        ' 
        ' listProjects
        ' 
        listProjects.Dock = DockStyle.Fill
        listProjects.Font = New Font("Segoe UI", 11.0F)
        listProjects.FormattingEnabled = True
        listProjects.Location = New Point(35, 95)
        listProjects.Margin = New Padding(4, 4, 4, 4)
        listProjects.Name = "listProjects"
        listProjects.Size = New Size(1055, 386)
        listProjects.TabIndex = 1
        ' 
        ' pnlActions
        ' 
        pnlActions.Controls.Add(btnDeleteProject)
        pnlActions.Controls.Add(btnOpenProject)
        pnlActions.Controls.Add(btnNewProject)
        pnlActions.Controls.Add(btnHistory)
        pnlActions.Dock = DockStyle.Bottom
        pnlActions.Location = New Point(35, 481)
        pnlActions.Margin = New Padding(4, 4, 4, 4)
        pnlActions.Name = "pnlActions"
        pnlActions.Size = New Size(1055, 78)
        pnlActions.TabIndex = 2
        ' 
        ' btnDeleteProject
        ' 
        btnDeleteProject.Location = New Point(394, 12)
        btnDeleteProject.Margin = New Padding(4, 4, 4, 4)
        btnDeleteProject.Name = "btnDeleteProject"
        btnDeleteProject.Size = New Size(138, 52)
        btnDeleteProject.TabIndex = 2
        btnDeleteProject.Text = "Hapus"
        btnDeleteProject.UseVisualStyleBackColor = True
        ' 
        ' btnOpenProject
        ' 
        btnOpenProject.Location = New Point(206, 12)
        btnOpenProject.Margin = New Padding(4, 4, 4, 4)
        btnOpenProject.Name = "btnOpenProject"
        btnOpenProject.Size = New Size(175, 52)
        btnOpenProject.TabIndex = 1
        btnOpenProject.Text = "Buka Proyek"
        btnOpenProject.UseVisualStyleBackColor = True
        ' 
        ' btnNewProject
        ' 
        btnNewProject.BackColor = Color.SlateBlue
        btnNewProject.FlatStyle = FlatStyle.Flat
        btnNewProject.ForeColor = Color.White
        btnNewProject.Location = New Point(0, 12)
        btnNewProject.Margin = New Padding(4, 4, 4, 4)
        btnNewProject.Name = "btnNewProject"
        btnNewProject.Size = New Size(188, 52)
        btnNewProject.TabIndex = 0
        btnNewProject.Text = "+ Proyek Baru"
        btnNewProject.UseVisualStyleBackColor = False
        ' 
        ' btnHistory
        ' 
        btnHistory.Location = New Point(550, 12)
        btnHistory.Margin = New Padding(4, 4, 4, 4)
        btnHistory.Name = "btnHistory"
        btnHistory.Size = New Size(150, 52)
        btnHistory.TabIndex = 3
        btnHistory.Text = "Riwayat"
        btnHistory.UseVisualStyleBackColor = True
        ' 
        ' lblHeading
        ' 
        lblHeading.Dock = DockStyle.Top
        lblHeading.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblHeading.ForeColor = Color.MidnightBlue
        lblHeading.Location = New Point(35, 35)
        lblHeading.Margin = New Padding(4, 0, 4, 0)
        lblHeading.Name = "lblHeading"
        lblHeading.Size = New Size(1055, 60)
        lblHeading.TabIndex = 0
        lblHeading.Text = "Proyek Saya"
        lblHeading.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' DashboardForm
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1125, 750)
        Controls.Add(pnlContent)
        Controls.Add(pnlHeader)
        Margin = New Padding(4, 4, 4, 4)
        MinimumSize = New Size(944, 611)
        Name = "DashboardForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Dashboard - Twibbon Studio"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlContent.ResumeLayout(False)
        pnlActions.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents listProjects As ListBox
    Friend WithEvents lblHeading As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnDeleteProject As Button
    Friend WithEvents btnOpenProject As Button
    Friend WithEvents btnNewProject As Button
    Friend WithEvents btnHistory As Button
End Class
