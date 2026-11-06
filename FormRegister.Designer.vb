<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRegister
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        lblJudul = New Label()
        txtNama = New TextBox()
        txtEmail = New TextBox()
        txtPassword = New TextBox()
        btnDaftar = New Button()
        btnKeLogin = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Location = New Point(346, 32)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(106, 25)
        lblJudul.TabIndex = 0
        lblJudul.Text = "BUAT AKUN"
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(185, 101)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(458, 31)
        txtNama.TabIndex = 1
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(185, 177)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(458, 31)
        txtEmail.TabIndex = 2
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(185, 247)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(458, 31)
        txtPassword.TabIndex = 3
        ' 
        ' btnDaftar
        ' 
        btnDaftar.Location = New Point(185, 335)
        btnDaftar.Name = "btnDaftar"
        btnDaftar.Size = New Size(458, 34)
        btnDaftar.TabIndex = 4
        btnDaftar.Text = "DAFTAR"
        btnDaftar.UseVisualStyleBackColor = True
        ' 
        ' btnKeLogin
        ' 
        btnKeLogin.Location = New Point(185, 375)
        btnKeLogin.Name = "btnKeLogin"
        btnKeLogin.Size = New Size(458, 34)
        btnKeLogin.TabIndex = 5
        btnKeLogin.Text = "SUDAH PUNYA AKUN?"
        btnKeLogin.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(114, 107)
        Label1.Name = "Label1"
        Label1.Size = New Size(65, 25)
        Label1.TabIndex = 6
        Label1.Text = "NAMA"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(114, 180)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 25)
        Label2.TabIndex = 7
        Label2.Text = "GMAIL"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(71, 253)
        Label3.Name = "Label3"
        Label3.Size = New Size(108, 25)
        Label3.TabIndex = 8
        Label3.Text = "PASSWORD"
        ' 
        ' FormRegister
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnKeLogin)
        Controls.Add(btnDaftar)
        Controls.Add(txtPassword)
        Controls.Add(txtEmail)
        Controls.Add(txtNama)
        Controls.Add(lblJudul)
        Name = "FormRegister"
        Text = "REGISTER"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnDaftar As Button
    Friend WithEvents btnKeLogin As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
