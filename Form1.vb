
Public Class Form1



    Private fotoPengguna As Image = Nothing
    Private gambarTwibbon As Image = Nothing

    Private zoomFoto As Single = 1.0F
    Private posisiX As Single = 0
    Private posisiY As Single = 0

    Private sedangGeser As Boolean = False
    Private titikAwalMouse As Point
    Private posisiAwalX As Single
    Private posisiAwalY As Single
    Private pengguna As Session
    Private proyekId As Integer
    Private proyekAwal As SavedProject

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(userSession As Session, Optional project As SavedProject = Nothing)
        Me.New()
        pengguna = userSession
        proyekAwal = project
    End Sub


    Private Sub Form1_Load(
sender As Object,
e As EventArgs
   ) Handles MyBase.Load

        lblStatus.Text = "Pilih foto dan Twibbon untuk mulai mengedit."
        If proyekAwal IsNot Nothing Then
            Try
                fotoPengguna = BacaGambar(proyekAwal.Foto)
                gambarTwibbon = BacaGambar(proyekAwal.Twibbon)
                proyekId = proyekAwal.Id
                txtNamaProyek.Text = proyekAwal.Nama
                zoomFoto = proyekAwal.Zoom
                trkZoom.Value = Math.Max(trkZoom.Minimum, Math.Min(trkZoom.Maximum, CInt(zoomFoto * 100)))
                posisiX = proyekAwal.PosisiX
                posisiY = proyekAwal.PosisiY
                lblZoom.Text = "Zoom Foto: " & trkZoom.Value & "%"
                lblStatus.Text = "Proyek dibuka. Perubahan belum disimpan."
            Catch ex As Exception
                MessageBox.Show("Gagal memuat gambar proyek: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        TampilkanPreview()

    End Sub


    ' =========================
    ' PILIH FOTO
    ' =========================
    Private Sub btnPilihFoto_Click(
    sender As Object,
    e As EventArgs
) Handles btnPilihFoto.Click

        Using dialog As New OpenFileDialog()
            dialog.Title = "Pilih Foto"
            dialog.Filter = "File Gambar|*.jpg;*.jpeg;*.png;*.bmp"

            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    Using gambarSementara As Image =
                    Image.FromFile(dialog.FileName)

                        If fotoPengguna IsNot Nothing Then
                            fotoPengguna.Dispose()
                        End If

                        fotoPengguna = New Bitmap(gambarSementara)
                    End Using

                    ResetPosisiFoto()
                    lblStatus.Text = "Foto berhasil dipilih."
                    TampilkanPreview()

                Catch ex As Exception
                    MessageBox.Show("Gagal membuka foto: " & ex.Message)
                End Try
            End If
        End Using

    End Sub

    ' =========================
    ' PILIH TWIBBON
    ' =========================
    Private Sub btnPilihTwibbon_Click(
    sender As Object,
    e As EventArgs
) Handles btnPilihTwibbon.Click

        Using dialog As New OpenFileDialog()
            dialog.Title = "Pilih Twibbon"
            dialog.Filter = "File Gambar|*.png;*.jpg;*.jpeg;*.bmp"

            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    Using gambarSementara As Image =
                    Image.FromFile(dialog.FileName)

                        If gambarTwibbon IsNot Nothing Then
                            gambarTwibbon.Dispose()
                        End If

                        gambarTwibbon = New Bitmap(gambarSementara)
                    End Using

                    lblStatus.Text = "Twibbon berhasil dipilih."
                    TampilkanPreview()

                Catch ex As Exception
                    MessageBox.Show("Gagal membuka Twibbon: " & ex.Message)
                End Try
            End If
        End Using

    End Sub

    ' =========================
    ' ZOOM FOTO
    ' =========================
    Private Sub trkZoom_Scroll(
    sender As Object,
    e As EventArgs
) Handles trkZoom.Scroll

        zoomFoto = trkZoom.Value / 100.0F
        lblZoom.Text = "Zoom Foto: " & trkZoom.Value & "%"
        TampilkanPreview()

    End Sub

    ' =========================
    ' MULAI GESER FOTO
    ' =========================
    Private Sub picPreview_MouseDown(
    sender As Object,
    e As MouseEventArgs
) Handles picPreview.MouseDown

        If fotoPengguna Is Nothing Then Return
        If e.Button <> MouseButtons.Left Then Return

        sedangGeser = True
        titikAwalMouse = e.Location
        posisiAwalX = posisiX
        posisiAwalY = posisiY

        picPreview.Cursor = Cursors.SizeAll

    End Sub

    ' =========================
    ' GESER FOTO DENGAN MOUSE
    ' =========================
    Private Sub picPreview_MouseMove(
    sender As Object,
    e As MouseEventArgs
) Handles picPreview.MouseMove

        If Not sedangGeser Then Return

        posisiX = posisiAwalX + (e.X - titikAwalMouse.X)
        posisiY = posisiAwalY + (e.Y - titikAwalMouse.Y)

        TampilkanPreview()

    End Sub

    ' =========================
    ' SELESAI GESER FOTO
    ' =========================
    Private Sub picPreview_MouseUp(
    sender As Object,
    e As MouseEventArgs
) Handles picPreview.MouseUp

        sedangGeser = False
        picPreview.Cursor = Cursors.Default

    End Sub

    ' =========================
    ' DOUBLE-CLICK UNTUK RESET
    ' =========================
    Private Sub picPreview_DoubleClick(
    sender As Object,
    e As EventArgs
) Handles picPreview.DoubleClick

        ResetPosisiFoto()
        TampilkanPreview()
        lblStatus.Text = "Posisi foto dikembalikan ke tengah."

    End Sub

    Private Sub ResetPosisiFoto()

        zoomFoto = 1.0F
        posisiX = 0
        posisiY = 0

        trkZoom.Value = 100
        lblZoom.Text = "Zoom Foto: 100%"

    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If fotoPengguna Is Nothing OrElse gambarTwibbon Is Nothing Then
            MessageBox.Show("Pilih foto dan Twibbon terlebih dahulu.", "Belum Siap Disimpan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Title = "Simpan hasil Twibbon"
            dialog.Filter = "Gambar PNG|*.png"
            dialog.FileName = "twibbon-saya.png"
            dialog.DefaultExt = "png"
            dialog.AddExtension = True

            If dialog.ShowDialog() <> DialogResult.OK Then Return

            Try
                Using hasil As Bitmap = BuatHasil(gambarTwibbon.Width, gambarTwibbon.Height)
                    hasil.Save(dialog.FileName, Imaging.ImageFormat.Png)
                End Using
                lblStatus.Text = "Hasil Twibbon berhasil disimpan."
                MessageBox.Show("Gambar berhasil disimpan.", "Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal menyimpan gambar: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnSimpanProyek_Click(sender As Object, e As EventArgs) Handles btnSimpanProyek.Click
        If pengguna Is Nothing Then
            MessageBox.Show("Anda harus masuk untuk menyimpan proyek.", "Login Diperlukan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If fotoPengguna Is Nothing OrElse gambarTwibbon Is Nothing Then
            MessageBox.Show("Pilih foto dan Twibbon terlebih dahulu.", "Proyek Belum Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim nama As String = txtNamaProyek.Text.Trim()
        If nama = "" Then nama = "Proyek Twibbon"
        Try
            Dim proyek As New SavedProject With {
                .Id = proyekId,
                .Nama = nama,
                .Foto = GambarKeByte(fotoPengguna),
                .Twibbon = GambarKeByte(gambarTwibbon),
                .Zoom = zoomFoto,
                .PosisiX = posisiX,
                .PosisiY = posisiY
            }
            proyekId = ProjectRepository.SaveProject(pengguna.UserId, proyek)
            lblStatus.Text = "Proyek berhasil disimpan."
            MessageBox.Show("Proyek berhasil disimpan ke riwayat Anda.", "Tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan proyek: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Shared Function GambarKeByte(gambar As Image) As Byte()
        Using stream As New IO.MemoryStream()
            gambar.Save(stream, Imaging.ImageFormat.Png)
            Return stream.ToArray()
        End Using
    End Function

    Private Shared Function BacaGambar(data As Byte()) As Image
        Using stream As New IO.MemoryStream(data)
            Using gambar As Image = Image.FromStream(stream)
                Return New Bitmap(gambar)
            End Using
        End Using
    End Function

    ' =========================
    ' AUTO FIT DAN GABUNG GAMBAR
    ' =========================
    Private Sub TampilkanPreview()

        Dim lebar As Integer = picPreview.ClientSize.Width
        Dim tinggi As Integer = picPreview.ClientSize.Height

        If lebar <= 0 OrElse tinggi <= 0 Then Return

        Dim hasil As Bitmap = BuatHasil(lebar, tinggi)

        Dim gambarLama As Image = picPreview.Image
        picPreview.Image = hasil

        If gambarLama IsNot Nothing Then
            gambarLama.Dispose()
        End If

    End Sub

    Private Function BuatHasil(lebar As Integer, tinggi As Integer) As Bitmap
        Dim hasil As New Bitmap(lebar, tinggi, Imaging.PixelFormat.Format32bppArgb)

        Using g As Graphics = Graphics.FromImage(hasil)

            g.Clear(Color.White)
            g.InterpolationMode =
            Drawing2D.InterpolationMode.HighQualityBicubic
            g.SmoothingMode =
            Drawing2D.SmoothingMode.HighQuality
            g.PixelOffsetMode =
            Drawing2D.PixelOffsetMode.HighQuality

            ' FOTO: AUTO FIT, ZOOM, DAN POSISI
            If fotoPengguna IsNot Nothing Then

                Dim skalaDasar As Single = Math.Min(
                CSng(lebar) / fotoPengguna.Width,
                CSng(tinggi) / fotoPengguna.Height
            )

                Dim lebarFoto As Single =
                fotoPengguna.Width * skalaDasar * zoomFoto

                Dim tinggiFoto As Single =
                fotoPengguna.Height * skalaDasar * zoomFoto

                Dim x As Single =
                (lebar - lebarFoto) / 2 + posisiX * lebar / Math.Max(1, picPreview.ClientSize.Width)

                Dim y As Single =
                (tinggi - tinggiFoto) / 2 + posisiY * tinggi / Math.Max(1, picPreview.ClientSize.Height)

                g.DrawImage(
                fotoPengguna,
                x,
                y,
                lebarFoto,
                tinggiFoto
            )

            End If

            ' TWIBBON: AUTO FIT, RASIO GAMBAR DIPERTAHANKAN
            If gambarTwibbon IsNot Nothing Then

                Dim skalaTwibbon As Single = Math.Min(
                CSng(lebar) / gambarTwibbon.Width,
                CSng(tinggi) / gambarTwibbon.Height
            )

                Dim lebarTwibbon As Single =
                gambarTwibbon.Width * skalaTwibbon

                Dim tinggiTwibbon As Single =
                gambarTwibbon.Height * skalaTwibbon

                Dim xTwibbon As Single =
                (lebar - lebarTwibbon) / 2

                Dim yTwibbon As Single =
                (tinggi - tinggiTwibbon) / 2

                g.DrawImage(
                gambarTwibbon,
                xTwibbon,
                yTwibbon,
                lebarTwibbon,
                tinggiTwibbon
            )

            End If

        End Using

        Return hasil
    End Function

    ' =========================
    ' BERSIHKAN GAMBAR SAAT FORM DITUTUP
    ' =========================
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)

        If picPreview.Image IsNot Nothing Then
            picPreview.Image.Dispose()
            picPreview.Image = Nothing
        End If

        If fotoPengguna IsNot Nothing Then
            fotoPengguna.Dispose()
            fotoPengguna = Nothing
        End If

        If gambarTwibbon IsNot Nothing Then
            gambarTwibbon.Dispose()
            gambarTwibbon = Nothing
        End If

        MyBase.OnFormClosed(e)

    End Sub


End Class

