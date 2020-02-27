Imports System.Drawing.Drawing2D
Imports System.IO


Public Class Principal
    Dim logueado As Boolean = False
    Dim completa As Boolean = True
    Dim midataset As New DataSet

    Public m As New Competencias
    Public a As New Consulta
    Public p As New Prueba
    Public c As New Caracteristicas
    Public o As New Organigrama
    Public r As New Reporte
    Public t As New Tickets
    Public Cur As New Cursos

    Private Sub Habilidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_modulos(False)
        m.MdiParent = Me
        a.MdiParent = Me
        p.MdiParent = Me
        c.MdiParent = Me
        o.MdiParent = Me
        t.MdiParent = Me
        Cur.MdiParent = Me
        Dim ctl As Control
        Dim ctlMDI As MdiClient
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
#Region "Pestañas"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click
        If a.Created Then
            a.BringToFront()
            a.completa = completa
            a.Show()
        Else
            a = New Consulta
            a.MdiParent = Me
            a.completa = completa
            a.Show()
        End If

        'm.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btn_Administración.Click
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_Otros.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btn_Soporte.Click
        Try
            Dim soporte As New Soporte
            soporte.ShowDialog()
        Catch ex As Exception
            SqlQuery.Save_Error(ex,)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btn_Configuración.Click
        Dim co As New Configuracion
        Dim bd = My.Settings.MPSBD
        If co.ShowDialog() = DialogResult.OK Then
            If bd <> My.Settings.MPSBD Then LogInOut.PerformClick() : LogInOut.PerformClick()
        End If


    End Sub

    Private Sub btn_organigrama_Click(sender As Object, e As EventArgs) Handles btn_Organigrama.Click
        Try

            If o.Created Then
                o.BringToFront()
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

    Private Sub Btn_reporte_Click(sender As Object, e As EventArgs) Handles Btn_Reportes.Click
        If r.Created Then
            r.BringToFront()
            r.Show()
        Else
            r = New Reporte
            r.MdiParent = Me
            r.Show()
        End If
    End Sub

    Private Sub btn_curso_admin_Click(sender As Object, e As EventArgs) Handles btn_Cursosadmin.Click
        Try
            If Cur.Created Then
                Cur.BringToFront()
                Cur.Show()

            Else
                Cur = New Cursos
                Cur.MdiParent = Me
                Cur.Show()
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btn_permisos_Click(sender As Object, e As EventArgs) Handles btn_Permisos.Click
        Try

            Dim per As New PermisosPers
            per.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btn_Tickets_Click(sender As Object, e As EventArgs) Handles btn_Tickets.Click
        Try
            If t.Created Then
                t.Show()
            Else
                t = New Tickets
                t.MdiParent = Me
                t.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
#End Region

#Region "Sesion"
    Private Sub LogInOut_Click(sender As Object, e As EventArgs) Handles LogInOut.Click
        Try

            If logueado = False Then
                Dim log As New Login
                If log.ShowDialog = DialogResult.OK Then
                    My.Settings.Usuario = My.Settings.Usuario.ToUpper
                    completa = True
                    cargar_permisos(My.Settings.Id_user)
                    Cargar_modulos(True)
                    logueado = True
                    If My.Settings.Usuario.ToLower <> "admin" Then
                        cargar_foto(My.Settings.CB_CODIGO, logueado)
                    End If

                    LogInOut.Text = "Cerrar sesión"
                    '  LogInOut.Image = My.Resources.icons8_apagar_30__1_

                Else
                    logueado = False
                    Cargar_modulos(False)
                    LogInOut.Text = "Iniciar sesión"
                    '   LogInOut.Image = My.Resources.icons8_apagar_30
                End If
            Else
                For Each children As Form In Me.MdiChildren
                    children.Close()
                Next
                logueado = False
                Cargar_modulos(False)
                cargar_foto(0, logueado)
                LogInOut.Text = "Iniciar sesión"
                ' LogInOut.Image = My.Resources.icons8_apagar_30
            End If


        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Error en Login")

        End Try
    End Sub
    Private Sub cargar_foto(ByVal cb_codigo As Integer, ByVal logueado As Boolean)
        Try
            If logueado Then

                Dim tablaimagen As DataTable = SqlQuery.Imagen(cb_codigo)
                If tablaimagen.Rows.Count > 0 Then
                    Dim myByteArray() As Byte = tablaimagen.Rows(0).Item(0)
                    Dim stream As New MemoryStream(myByteArray)
                    PictureBox2.Image = Image.FromStream(stream)
                End If



            Else
                PictureBox2.Image = My.Resources.user_icon_icons_com_57997
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub cargar_permisos(ByVal cb_codigo As Integer)
        Try

            If My.Settings.Permisos IsNot Nothing Then
                My.Settings.Permisos.Clear()
            End If
            If My.Settings.EmpleadosHijos IsNot Nothing Then
                My.Settings.EmpleadosHijos.Clear()
            End If

            My.Settings.Permisos = SqlQuery.Permisos(cb_codigo)
            My.Settings.Puesto = SqlQuery.puesto(My.Settings.CB_CODIGO)
            If Permiso.Habilitado("ADMIN") = False Then
                If Permiso.Habilitado("CT") = False Or Permiso.Habilitado("RCE") = False Then
                    If My.Settings.Permisos.Select("Identificador = 'MP'").Count < 1 And My.Settings.Permisos.Select("Identificador = 'MPJ'").Count > 0 Then
                        'Buscar jerarquias
                        My.Settings.EmpleadosHijos = CType(SqlQuery.puestos_hijos(My.Settings.Puesto), DataTable).Copy()
                    Else
                        If (My.Settings.Permisos.Select("Identificador = 'RCE'").Count < 1 And My.Settings.Permisos.Select("Identificador = 'REJ'").Count > 0) Or
                           (My.Settings.Permisos.Select("Identificador = 'ECE'").Count < 1 And My.Settings.Permisos.Select("Identificador = 'EEJ'").Count > 0) Or
                           (My.Settings.Permisos.Select("Identificador = 'ELCE'").Count < 1 And My.Settings.Permisos.Select("Identificador = 'ELEJ'").Count > 0) Or
                           (My.Settings.Permisos.Select("Identificador = 'PECONS'").Count > 0 And My.Settings.Permisos.Select("Identificador = 'CT'").Count < 1) Then
                            'Buscar jerarquias
                            My.Settings.EmpleadosHijos = CType(SqlQuery.puestos_hijos(My.Settings.Puesto), DataTable).Copy()
                        Else

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
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
            '  Picture_Box.BackgroundImageLayout = ImageLayout.Zoom
            ' Picture_Box.SizeMode = PictureBoxSizeMode.Zoom
            Picture_Box.BackgroundImageLayout = ImageLayout.Zoom
            ' Picture_Box.BorderStyle = BorderStyle.Fixed3D
        Catch ex As Exception
            SqlQuery.Save_Error(ex, "Al cargar imagenes de usuario")
        End Try
    End Sub

    Private Sub Cargar_modulos(ByVal Optional Mostrar As Boolean = False)
        Try
            If Mostrar Then
                'Revisar a que botones se tiene acceso

                For Each ctl As Control In Panel2.Controls
                    If TypeOf (ctl) Is Button Then
                        If My.Settings.Permisos.Select("Categoria = 'Pestañas' and Detalles = '" & Split(ctl.Name, "_")(1) & "'").Count > 0 Then
                            ctl.Visible = True
                        End If

                    End If
                Next
                btn_help.Visible = True
                btn_consultasencilla.Visible = False
            Else
                For Each ctl As Control In Panel2.Controls
                    If TypeOf (ctl) Is Button Then
                        ctl.Visible = False
                    End If
                Next

                btn_consultasencilla.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Error al cargar modulos")
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Try
            Me.DialogResult = DialogResult.Cancel

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Panel1.Size.Width = PictureBox3.Width Then
            Panel1.Size = New Size(224, Panel1.Height)
            PictureBox3.Image = My.Resources.icons8_doble_izquierda_48
            For Each ctl As Control In Panel2.Controls
                If TypeOf (ctl) Is Button Then
                    ctl.ForeColor = Color.DimGray
                    ctl.Text = Split(ctl.Name, "_")(1).ToString
                    ctl.Text = ctl.Tag
                End If
            Next
            For Each ctl As Control In Panel3.Controls
                If TypeOf (ctl) Is Button Then
                    ctl.ForeColor = Color.DimGray
                    ' ctl.Text = Split(ctl.Name, "_")(1).ToString
                    ctl.Text = ctl.Tag
                End If
            Next
        Else
            Panel1.Size = New Size(PictureBox3.Width, Panel1.Height)
            PictureBox3.Image = My.Resources.icons8_doble_derecha_48
            For Each ctl As Control In Panel2.Controls
                If TypeOf (ctl) Is Button Then
                    ctl.ForeColor = Color.WhiteSmoke
                    ctl.Text = ""
                End If
            Next
            For Each ctl As Control In Panel3.Controls
                If TypeOf (ctl) Is Button Then
                    ctl.ForeColor = Color.WhiteSmoke
                    ctl.Text = ""
                End If
            Next
        End If
    End Sub
    Dim Data As AppData
    Dim verh As Aprobar
    Private Sub btn_consultasencilla_Click_1(sender As Object, e As EventArgs) Handles btn_consultasencilla.Click
        Try
            Dim no_em As New no_empleado
            If no_em.ShowDialog = DialogResult.OK Then
                'Tomar numero de empleado y buscar huella para permitir autentificación
                Dim validacion_usuario As Boolean = Huella(CType(sender, Control), no_em.cb_codigo)
                '   If validacion_usuario = True Then
                If validacion_usuario = True Then
                    completa = False
                    My.Settings.CB_CODIGO = no_em.cb_codigo
                    logueado = True
                    cargar_foto(My.Settings.CB_CODIGO, logueado)
                    btn_Consulta.Visible = True
                    btn_Cursosadmin.Visible = True
                    btn_help.Visible = True
                    LogInOut.Text = "Cerrar sesión"
                    btn_consultasencilla.Visible = False

                Else

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Function Huella(ByVal ctl As Control, No_empleado As Integer) As Boolean

        Try
            Dim cb_codigo_aprobacion As Integer = 0
            Dim supervisor_nombre As DataTable
            Dim usuario_correcto As Boolean = False
            Dim solicitud As DataRow()

            If midataset.Tables("HUELLAS") IsNot Nothing Then
                midataset.Tables.Remove("HUELLAS")
            End If
            Dim ta As DataTable
            ta = SqlQuery.Huellas(No_empleado).Copy
            ta.TableName = "HUELLAS"
            midataset.Tables.Add(ta)
            If midataset.Tables("HUELLAS").DefaultView.Count = 0 Then
                usuario_correcto = False
                MsgBox("No hay huellas registradas para este usuario", MsgBoxStyle.Critical)
                Exit Function
            Else
                Dim i As Integer
                Data = Nothing
                Data = New AppData
                For i = 0 To midataset.Tables("HUELLAS").DefaultView.Count - 1
                    Dim arrpicture() As Byte
                    arrpicture = CType(midataset.Tables("HUELLAS").DefaultView.Item(i).Item("Huella"), Byte())
                    Dim ms As New IO.MemoryStream(arrpicture)
                    Dim template As New DPFP.Template(ms)

                    Data.Templates(midataset.Tables("HUELLAS").DefaultView.Item(i).Item("pos")) = template
                    Data.EnrolledFingersMask = midataset.Tables("HUELLAS").DefaultView.Item(i).Item("mask")
                    arrpicture = Nothing
                    ms = Nothing
                    template = Nothing

                Next

                verh = New Aprobar(Data)
                Try
                    ' If Debugger.IsAttached Then Return True
                    verh.escomedor = True
                    verh.Data = Data
                    '  verh.numemp = a
                    verh.StartPosition = FormStartPosition.CenterScreen
                    verh.ShowDialog()
                    If verh.DialogResult = 1 Then
                        ''HUELLA AUTORIZADA
                        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        usuario_correcto = True
                    Else
                        usuario_correcto = False
                    End If
                Catch ex As Exception

                End Try

            End If
            Return usuario_correcto
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try


    End Function

#End Region

#Region "Eventos diseño"


    Private Sub btn_puesto_MouseEnter(sender As Object, e As EventArgs) Handles btn_Consulta.MouseEnter, Btn_Reportes.MouseEnter, btn_Administración.MouseEnter, btn_Configuración.MouseEnter, btn_Otros.MouseEnter,
            btn_Cursosadmin.MouseEnter, btn_Otros.MouseEnter, btn_Organigrama.MouseEnter, btn_Soporte.MouseEnter, btn_Permisos.MouseEnter, btn_consultasencilla.MouseEnter, btn_Tickets.MouseEnter, btn_cursos.MouseEnter, btn_help.MouseEnter
        Select Case CType(sender, Button).Name
            Case "btn_Consulta"
                CType(sender, Button).Image = My.Resources.searchmagnifierinterfacesymbol1_79893
            Case "Btn_Reportes"
                CType(sender, Button).Image = My.Resources.report_icon_icons_com_58842
            Case "btn_Administración"
                CType(sender, Button).Image = My.Resources._4124854_collaboration_group_management_organization_structure_team_114115
            Case "btn_Configuración"
                CType(sender, Button).Image = My.Resources.settings_cogwheel_button_icon_icons_com_72559
            Case "btn_Otros"
                CType(sender, Button).Image = My.Resources.icons8_más_30
            Case "btn_Cursosadmin"
                CType(sender, Button).Image = My.Resources.icons8_cursos_30
            Case "btn_Organigrama"
                CType(sender, Button).Image = My.Resources.organizationchart_116388
            Case "btn_Soporte"
                CType(sender, Button).Image = My.Resources.OnlineSupport_enline_3976
            Case "btn_Permisos"
                CType(sender, Button).Image = My.Resources.icons8_bloquear_24
            Case "btn_cursos"
                CType(sender, Button).Image = My.Resources._school_90226
            Case "btn_Tickets"
                CType(sender, Button).Image = My.Resources.icons8_dos_entradas_30
            Case "btn_salir"
                CType(sender, Button).Image = My.Resources.icons8_exportar_24
            Case "LogInOut"
                If CType(sender, Button).Text = "Iniciar sesión" Then
                    CType(sender, Button).Image = My.Resources.icons8_apagar_30
                Else
                    CType(sender, Button).Image = My.Resources.icons8_apagar_30__1_
                End If

            Case "btn_help"
                CType(sender, Button).Image = My.Resources.icons8_help_24

        End Select

    End Sub

    Private Sub btn_puesto_MouseLeave(sender As Object, e As EventArgs) Handles btn_Consulta.MouseLeave, Btn_Reportes.MouseLeave, btn_Administración.MouseLeave, btn_Configuración.MouseLeave, btn_Otros.MouseLeave,
            btn_Cursosadmin.MouseLeave, btn_Otros.MouseLeave, btn_Organigrama.MouseLeave, btn_Soporte.MouseLeave, btn_Permisos.MouseLeave, btn_consultasencilla.MouseLeave, btn_Tickets.MouseLeave, btn_cursos.MouseLeave,
            btn_help.MouseLeave

        CType(sender, Button).Image = Nothing
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim v As New VistaPreviaImagen
        v.PictureBox1.Image = CType(sender, PictureBox).Image
        v.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        v.Show()
    End Sub

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try

            If MsgBox("Seguro que desea salir", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                e.Cancel = True
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region
End Class