<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SplashScreen
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        pnlBrand = New Panel()
        lblSubtitle = New Label()
        picLogo = New PictureBox()
        pnlLoading = New Panel()
        lblLoading = New Label()
        prgLoading = New ProgressBar()
        tmrSplash = New Timer(components)
        pnlBrand.SuspendLayout()
        CType(picLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnlLoading.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlBrand
        ' 
        pnlBrand.BackColor = Color.Black
        pnlBrand.Controls.Add(lblSubtitle)
        pnlBrand.Controls.Add(picLogo)
        pnlBrand.Dock = DockStyle.Top
        pnlBrand.Location = New Point(0, 0)
        pnlBrand.Margin = New Padding(4)
        pnlBrand.Name = "pnlBrand"
        pnlBrand.Size = New Size(800, 348)
        pnlBrand.TabIndex = 0
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Dock = DockStyle.Bottom
        lblSubtitle.Font = New Font("Segoe UI", 11F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(220), CByte(224), CByte(255))
        lblSubtitle.Location = New Point(0, 287)
        lblSubtitle.Margin = New Padding(4, 0, 4, 0)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(800, 61)
        lblSubtitle.TabIndex = 2
        lblSubtitle.Text = "Editor kreatif untuk Twibbon Anda"
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' picLogo
        ' 
        picLogo.BackColor = Color.Black
        picLogo.Image = CType(resources.GetObject("picLogo.Image"), Image)
        picLogo.Location = New Point(275, 12)
        picLogo.Margin = New Padding(4)
        picLogo.Name = "picLogo"
        picLogo.Size = New Size(250, 250)
        picLogo.SizeMode = PictureBoxSizeMode.Zoom
        picLogo.TabIndex = 0
        picLogo.TabStop = False
        ' 
        ' pnlLoading
        ' 
        pnlLoading.BackColor = Color.White
        pnlLoading.Controls.Add(lblLoading)
        pnlLoading.Controls.Add(prgLoading)
        pnlLoading.Dock = DockStyle.Fill
        pnlLoading.Location = New Point(0, 348)
        pnlLoading.Margin = New Padding(4)
        pnlLoading.Name = "pnlLoading"
        pnlLoading.Padding = New Padding(55, 25, 55, 25)
        pnlLoading.Size = New Size(800, 152)
        pnlLoading.TabIndex = 1
        ' 
        ' lblLoading
        ' 
        lblLoading.Dock = DockStyle.Top
        lblLoading.Font = New Font("Segoe UI", 9F)
        lblLoading.ForeColor = Color.FromArgb(CByte(72), CByte(76), CByte(104))
        lblLoading.Location = New Point(55, 25)
        lblLoading.Margin = New Padding(4, 0, 4, 0)
        lblLoading.Name = "lblLoading"
        lblLoading.Size = New Size(690, 40)
        lblLoading.TabIndex = 1
        lblLoading.Text = "Menyiapkan aplikasi... 0%"
        lblLoading.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' prgLoading
        ' 
        prgLoading.Dock = DockStyle.Bottom
        prgLoading.Location = New Point(55, 97)
        prgLoading.Margin = New Padding(4)
        prgLoading.Name = "prgLoading"
        prgLoading.Size = New Size(690, 30)
        prgLoading.TabIndex = 0
        ' 
        ' tmrSplash
        ' 
        tmrSplash.Interval = 45
        ' 
        ' SplashScreen
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(800, 500)
        Controls.Add(pnlLoading)
        Controls.Add(pnlBrand)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4)
        Name = "SplashScreen"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Twibbon Studio"
        pnlBrand.ResumeLayout(False)
        CType(picLogo, ComponentModel.ISupportInitialize).EndInit()
        pnlLoading.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlBrand As Panel
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents pnlLoading As Panel
    Friend WithEvents lblLoading As Label
    Friend WithEvents prgLoading As ProgressBar
    Friend WithEvents tmrSplash As Timer
End Class
