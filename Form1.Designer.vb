<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        Label1 = New Label()
        lblTitle = New Label()
        pnlSidebar = New Panel()
        trkZoom = New TrackBar()
        lblZoom = New Label()
        btnPilihTwibbon = New Button()
        btnPilihFoto = New Button()
        btnSimpan = New Button()
        btnSimpanProyek = New Button()
        txtNamaProyek = New TextBox()
        lblPengaturan = New Label()
        pnlPreview = New Panel()
        lblStatus = New Label()
        picPreview = New PictureBox()
        lblPreviewTitle = New Label()
        pnlHeader.SuspendLayout()
        pnlSidebar.SuspendLayout()
        CType(trkZoom, ComponentModel.ISupportInitialize).BeginInit()
        pnlPreview.SuspendLayout()
        CType(picPreview, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.MidnightBlue
        pnlHeader.Controls.Add(Label1)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1078, 150)
        pnlHeader.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(431, 86)
        Label1.Name = "Label1"
        Label1.Size = New Size(231, 28)
        Label1.TabIndex = 1
        Label1.Text = "Twibbon Editor Desktop"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(400, 27)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(300, 45)
        lblTitle.TabIndex = 0
        lblTitle.Text = "TWIBBON STUDIO"
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.White
        pnlSidebar.Controls.Add(trkZoom)
        pnlSidebar.Controls.Add(lblZoom)
        pnlSidebar.Controls.Add(btnPilihTwibbon)
        pnlSidebar.Controls.Add(btnPilihFoto)
        pnlSidebar.Controls.Add(btnSimpan)
        pnlSidebar.Controls.Add(btnSimpanProyek)
        pnlSidebar.Controls.Add(txtNamaProyek)
        pnlSidebar.Controls.Add(lblPengaturan)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 150)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(377, 494)
        pnlSidebar.TabIndex = 1
        ' 
        ' trkZoom
        ' 
        trkZoom.Location = New Point(25, 283)
        trkZoom.Maximum = 200
        trkZoom.Minimum = 25
        trkZoom.Name = "trkZoom"
        trkZoom.Size = New Size(287, 69)
        trkZoom.TabIndex = 3
        trkZoom.Value = 100
        ' 
        ' lblZoom
        ' 
        lblZoom.AutoSize = True
        lblZoom.Location = New Point(45, 250)
        lblZoom.Name = "lblZoom"
        lblZoom.Size = New Size(156, 25)
        lblZoom.TabIndex = 2
        lblZoom.Text = "Zoom Foto: 100%"
        ' 
        ' btnPilihTwibbon
        ' 
        btnPilihTwibbon.AutoSize = True
        btnPilihTwibbon.BackColor = Color.SlateBlue
        btnPilihTwibbon.FlatStyle = FlatStyle.Flat
        btnPilihTwibbon.ForeColor = Color.White
        btnPilihTwibbon.Location = New Point(25, 127)
        btnPilihTwibbon.Name = "btnPilihTwibbon"
        btnPilihTwibbon.Size = New Size(287, 59)
        btnPilihTwibbon.TabIndex = 2
        btnPilihTwibbon.Text = "Pilih Twibbon"
        btnPilihTwibbon.UseVisualStyleBackColor = False
        '
        ' btnSimpan
        '
        btnSimpan.BackColor = Color.MidnightBlue
        btnSimpan.FlatStyle = FlatStyle.Flat
        btnSimpan.ForeColor = Color.White
        btnSimpan.Location = New Point(25, 365)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(287, 52)
        btnSimpan.TabIndex = 4
        btnSimpan.Text = "Download PNG"
        btnSimpan.UseVisualStyleBackColor = False
        '
        ' txtNamaProyek
        '
        txtNamaProyek.Location = New Point(25, 202)
        txtNamaProyek.Name = "txtNamaProyek"
        txtNamaProyek.Size = New Size(287, 31)
        txtNamaProyek.TabIndex = 5
        txtNamaProyek.Text = "Proyek baru"
        '
        ' btnSimpanProyek
        '
        btnSimpanProyek.BackColor = Color.DarkSlateBlue
        btnSimpanProyek.FlatStyle = FlatStyle.Flat
        btnSimpanProyek.ForeColor = Color.White
        btnSimpanProyek.Location = New Point(25, 425)
        btnSimpanProyek.Name = "btnSimpanProyek"
        btnSimpanProyek.Size = New Size(287, 48)
        btnSimpanProyek.TabIndex = 6
        btnSimpanProyek.Text = "Simpan Proyek"
        btnSimpanProyek.UseVisualStyleBackColor = False
        ' 
        ' btnPilihFoto
        ' 
        btnPilihFoto.BackColor = Color.SlateBlue
        btnPilihFoto.FlatStyle = FlatStyle.Flat
        btnPilihFoto.ForeColor = Color.White
        btnPilihFoto.Location = New Point(25, 65)
        btnPilihFoto.Name = "btnPilihFoto"
        btnPilihFoto.Size = New Size(287, 48)
        btnPilihFoto.TabIndex = 1
        btnPilihFoto.Text = "Pilih Foto"
        btnPilihFoto.UseVisualStyleBackColor = False
        ' 
        ' lblPengaturan
        ' 
        lblPengaturan.AutoSize = True
        lblPengaturan.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPengaturan.ForeColor = Color.MidnightBlue
        lblPengaturan.Location = New Point(56, 32)
        lblPengaturan.Name = "lblPengaturan"
        lblPengaturan.Size = New Size(222, 30)
        lblPengaturan.TabIndex = 0
        lblPengaturan.Text = "PENGATURAN FOTO"
        ' 
        ' pnlPreview
        ' 
        pnlPreview.BackColor = Color.Gainsboro
        pnlPreview.Controls.Add(lblStatus)
        pnlPreview.Controls.Add(picPreview)
        pnlPreview.Controls.Add(lblPreviewTitle)
        pnlPreview.Dock = DockStyle.Fill
        pnlPreview.ForeColor = SystemColors.ActiveCaptionText
        pnlPreview.Location = New Point(377, 150)
        pnlPreview.Name = "pnlPreview"
        pnlPreview.Padding = New Padding(15)
        pnlPreview.Size = New Size(701, 494)
        pnlPreview.TabIndex = 2
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(92, 460)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(231, 25)
        lblStatus.TabIndex = 2
        lblStatus.Text = "Belum ada foto yang dipilih"
        ' 
        ' picPreview
        ' 
        picPreview.BorderStyle = BorderStyle.FixedSingle
        picPreview.Location = New Point(71, 55)
        picPreview.Name = "picPreview"
        picPreview.Size = New Size(589, 399)
        picPreview.SizeMode = PictureBoxSizeMode.Zoom
        picPreview.TabIndex = 1
        picPreview.TabStop = False
        ' 
        ' lblPreviewTitle
        ' 
        lblPreviewTitle.AutoSize = True
        lblPreviewTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPreviewTitle.Location = New Point(261, 15)
        lblPreviewTitle.Name = "lblPreviewTitle"
        lblPreviewTitle.Size = New Size(239, 32)
        lblPreviewTitle.TabIndex = 0
        lblPreviewTitle.Text = "PREVIEW TWIBBON"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1078, 644)
        Controls.Add(pnlPreview)
        Controls.Add(pnlSidebar)
        Controls.Add(pnlHeader)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Twibbon Studio"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlSidebar.ResumeLayout(False)
        pnlSidebar.PerformLayout()
        CType(trkZoom, ComponentModel.ISupportInitialize).EndInit()
        pnlPreview.ResumeLayout(False)
        pnlPreview.PerformLayout()
        CType(picPreview, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnPilihTwibbon As Button
    Friend WithEvents btnPilihFoto As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnSimpanProyek As Button
    Friend WithEvents txtNamaProyek As TextBox
    Friend WithEvents lblPengaturan As Label
    Friend WithEvents trkZoom As TrackBar
    Friend WithEvents lblZoom As Label
    Friend WithEvents pnlPreview As Panel
    Friend WithEvents picPreview As PictureBox
    Friend WithEvents lblPreviewTitle As Label
    Friend WithEvents lblStatus As Label

End Class
