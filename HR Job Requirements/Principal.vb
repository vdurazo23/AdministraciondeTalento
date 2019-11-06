Imports System.Drawing.Drawing2D

Public Class Principal
    Dim logueado As Boolean = False
    Dim m As New Competencias
    Dim a As New Consulta
    Dim p As New Prueba
    Dim c As New Caracteristicas
    Dim o As New Organigrama
    Private Sub Habilidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Cargar_modulos(False)

        m.MdiParent = Me
        a.MdiParent = Me
        p.MdiParent = Me
        c.MdiParent = Me
        o.MdiParent = Me
        'Imagenes_circulares(PictureBox1)
        'Imagenes_circulares(PictureBox2)


        Dim ctl As Control
        Dim ctlMDI As MdiClient

        ' Loop through all of the form's controls looking
        ' for the control of type MdiClient.
        For Each ctl In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)

                ' Set the BackColor of the MdiClient control.
                ctlMDI.BackColor = Me.BackColor

            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next

        If Debugger.IsAttached Then
            LogInOut.PerformClick()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_puesto.Click
        If a.Created Then
            a.BringToFront()
            a.Show()
        Else
            a = New Consulta
            a.MdiParent = Me
            a.Show()
        End If

        'm.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btn_admin.Click
        'If p.Created Then
        '    p.Show()
        'Else
        '    p = New Prueba
        '    p.MdiParent = Me
        '    p.Show()
        'End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_otro.Click
        Try
            If c.Created Then
                c.BringToFront()
                c.Show()
            Else
                c = New Caracteristicas
                c.MdiParent = Me
                c.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btn_soporte.Click
        Try
            Dim soporte As New Soporte
            soporte.ShowDialog()
        Catch ex As Exception
            SqlQuery.Save_Error(ex,)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btn_config.Click

    End Sub

    Private Sub LogInOut_Click(sender As Object, e As EventArgs) Handles LogInOut.Click
        Try
            If logueado = False Then
                Dim log As New Login
                If log.ShowDialog = DialogResult.OK Then
                    Cargar_modulos(True)
                    logueado = True
                    LogInOut.Text = "Cerrar sesión"
                Else
                    logueado = False
                    Cargar_modulos(False)
                    LogInOut.Text = "Iniciar sesión"
                End If
            Else
                For Each children As Form In Me.MdiChildren
                    children.Close()
                Next
                logueado = False
                Cargar_modulos(False)
                LogInOut.Text = "Iniciar sesión"
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

            SqlQuery.Save_Error(ex, "Error en Login")
        End Try
    End Sub

    Private Sub Cargar_modulos(ByVal Optional Mostrar As Boolean = False)
        Try
            If Mostrar Then
                'Revisar a que botones se tiene acceso
                For Each btn As Button In Panel2.Controls
                    btn.Visible = True
                Next
            Else
                For Each btn As Button In Panel2.Controls
                    btn.Visible = False
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Error al cargar modulos")
        End Try
    End Sub

    Private Sub Imagenes_circulares(Picture_Box As PictureBox)
        Try
            'Get the original image.
            Dim originalImage = Picture_Box.Image
            'Create a new, blank image with the same dimensions.
            Dim croppedImage As New Bitmap(originalImage.Width, originalImage.Height)
            'Dim croppedImage As New Bitmap(80, 78)
            'Prepare to draw on the new image.
            Using g = Graphics.FromImage(croppedImage)
                Dim path As New GraphicsPath

                'Create an ellipse that fills the image in both directions.
                path.AddEllipse(0, 0, croppedImage.Width, croppedImage.Height)
                ' path.AddEllipse(0, 0, 80, 78)
                Dim reg As New Region(path)

                'Draw only within the specified ellipse.
                g.Clip = reg
                g.DrawImage(originalImage, 0, 0, 78, 80)

            End Using

            'Display the new image.
            Picture_Box.Image = Nothing
            Picture_Box.BackgroundImage = croppedImage
            ' Picture_Box.BackgroundImageLayout = ImageLayout.Stretch
            Picture_Box.BackgroundImageLayout = ImageLayout.Zoom
            ' Picture_Box.SizeMode = PictureBoxSizeMode.Zoom
            'Picture_Box.BackgroundImageLayout = ImageLayout.Zoom
            Picture_Box.BorderStyle = BorderStyle.Fixed3D
        Catch ex As Exception
            SqlQuery.Save_Error(ex, "Al cargar imagenes de usuario")
        End Try
    End Sub

    Private Sub btn_organigrama_Click(sender As Object, e As EventArgs) Handles btn_organigrama.Click
        Try

            If o.Created Then
                o.Show()
            Else
                o = New Organigrama
                o.MdiParent = Me
                o.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Btn_reporte_Click(sender As Object, e As EventArgs) Handles Btn_reporte.Click

    End Sub

    Private Sub btn_curso_Click(sender As Object, e As EventArgs) Handles btn_curso.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class