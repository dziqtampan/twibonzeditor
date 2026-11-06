<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
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
        Label3 = New Label()
        Label2 = New Label()
        btnKeRegister = New Button()
        btnLogin = New Button()
        txtPassword = New TextBox()
        txtEmail = New TextBox()
        lblJudul = New Label()
        SuspendLayout()
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(114, 213)
        Label3.Name = "Label3"
        Label3.Size = New Size(108, 25)
        Label3.TabIndex = 17
        Label3.Text = "PASSWORD"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(157, 125)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 25)
        Label2.TabIndex = 16
        Label2.Text = "GMAIL"
        ' 
        ' btnKeRegister
        ' 
        btnKeRegister.Location = New Point(228, 380)
        btnKeRegister.Name = "btnKeRegister"
        btnKeRegister.Size = New Size(458, 34)
        btnKeRegister.TabIndex = 14
        btnKeRegister.Text = "BELUM PUNYA AKUN"
        btnKeRegister.UseVisualStyleBackColor = True
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(228, 340)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(458, 34)
        btnLogin.TabIndex = 13
        btnLogin.Text = "LOGIN"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(228, 207)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(458, 31)
        txtPassword.TabIndex = 12
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(228, 119)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(458, 31)
        txtEmail.TabIndex = 11
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Location = New Point(389, 37)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(106, 25)
        lblJudul.TabIndex = 9
        lblJudul.Text = "BUAT AKUN"
        ' 
        ' FormLogin
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(btnKeRegister)
        Controls.Add(btnLogin)
        Controls.Add(txtPassword)
        Controls.Add(txtEmail)
        Controls.Add(lblJudul)
        Name = "FormLogin"
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnKeRegister As Button
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblJudul As Label
End Class
