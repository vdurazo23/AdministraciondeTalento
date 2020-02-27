Imports System.IO

Public Class Agregar_evaluacion

    Dim midataset As New DataSet
    Public id_evaluacion_Detalles As Integer = 0
    Public Caracteristica As String
    Public es_curso As Boolean = False
    Public Id_caracteristica As Integer = 0
    Public CU_CODIGO As String = ""
    Public cb_codigo As Integer
    Public nivel_actual As Integer
    Public id_evaluacion As Integer = 0
    Public id_ponderacion As Integer = 0
    Public nivelrequerido As Integer
    Dim nuevo As Boolean
    Dim imagen As Boolean = False
    Public actual As Integer
    Dim estatus As String

    'Para editar
    Dim editar_detalles As Boolean = False
    Dim adjunto_inicial As Boolean = False
    Dim cambio_en_archivo As Boolean = False

    Private Sub Agregar_evaluacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        'LO PRIMERO A REALIZAR ES PREGUNTAR SI YA EXISTE UN ID DE EVALUACION
        Try

            If id_evaluacion_Detalles > 0 Then
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                editar_detalles = True
                Dim valores As DataTable = CType(SqlQuery.Detalles_evaluacion(id_evaluacion_Detalles), DataTable).Copy
                Dim ticket As DataTable = CType(SqlQuery.Datos_para_editar_evaluacion(id_evaluacion_Detalles), DataTable).Copy

                If ticket.Rows.Count > 0 Then
                    estatus = valores.Rows(0).Item("Estatus")
                    id_evaluacion = ticket.Rows(0).Item("Id_evaluacion")
                    If ticket.Rows(0).Item("CU_CODIGO").ToString = "" Then
                        Id_caracteristica = ticket.Rows(0).Item("Id_caracteristica")
                        Caracteristica = ticket.Rows(0).Item("Descripcion")
                    Else
                        es_curso = True
                        CU_CODIGO = ticket.Rows(0).Item("CU_CODIGO")
                        Caracteristica = ticket.Rows(0).Item("CU_NOMBRE")
                    End If
                    cb_codigo = ticket.Rows(0).Item("CB_CODIGO")
                    If ticket.Rows(0).Item("Nivel_actual").ToString <> "" Then
                        nivel_actual = ticket.Rows(0).Item("Nivel_actual")
                    Else
                        nivel_actual = 0
                    End If
                    id_ponderacion = ticket.Rows(0).Item("Id_ponderacion")
                    nivelrequerido = ticket.Rows(0).Item("Nivel_requerido")
                    actual = nivel_actual

                    nivel_actual = Math.Truncate((nivelrequerido * nivel_actual) / 100)
                    cmb_calificacion.SelectedItem = valores.Rows(0).Item("Puntos").ToString
                    If valores.Rows(0).Item("Imagen").ToString <> "" Or valores.Rows(0).Item("Documento").ToString <> "" Then
                        adjunto_inicial = True
                        RD_adjunto.Checked = True
                        Direccion.Text = "Documento en base de datos"
                        txt_nombre.Text = valores.Rows(0).Item("Nombre_documento")
                        txt_ext.Text = valores.Rows(0).Item("Extension")
                        txt_comentario.Text = valores.Rows(0).Item("Descripcion")
                        If valores.Rows(0).Item("Imagen").ToString <> "" Then
                            Dim myByteArray() As Byte = valores.Rows(0).Item("Imagen")
                            Dim stream As New MemoryStream(myByteArray)
                            PictureBox1.Image = Image.FromStream(stream)
                            imagen = True
                        Else
                            PictureBox1.Image = My.Resources.SinVistaPrevia
                        End If

                    Else
                        RD_adjunto.Checked = False
                        txt_descripcion.Text = valores.Rows(0).Item("Descripcion")
                    End If

                End If
                nuevo = False
            Else

                id_evaluacion = SqlQuery.Id_evaluacion(cb_codigo, Id_caracteristica, CU_CODIGO, nivelrequerido, id_ponderacion)

            End If

            Select Case actual
                Case 0
                    PictureBox2.Image = My.Resources._1000
                Case 25
                    PictureBox2.Image = My.Resources._1001
                Case 50
                    PictureBox2.Image = My.Resources._1002
                Case 75
                    PictureBox2.Image = My.Resources._1003
                Case 100
                    PictureBox2.Image = My.Resources._1004
            End Select

            TabControl1.ItemSize = New Size(0, 1)
            TabControl1.SizeMode = TabSizeMode.Fixed
            Label1.Text = Id_caracteristica & " - " & Caracteristica
            If id_evaluacion > 0 Then
                nuevo = False
            Else
                nuevo = True
            End If
            Label14.Text = nivel_actual
            cargarinfo()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub cargarinfo()
        Try
            If es_curso Then

            Else
                Dim tab As DataTable = SqlQuery.info(Id_caracteristica).Copy
                If tab.Rows.Count > 0 Then
                    TextBox1.Text = tab.Rows(0).Item(0).ToString
                    TextBox2.Text = tab.Rows(0).Item(1).ToString
                    TextBox3.Text = tab.Rows(0).Item(2).ToString
                    TextBox4.Text = tab.Rows(0).Item(3).ToString
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'APROBACION
    Dim Data As AppData
    Dim verh As Aprobar
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ErrorProvider1.Clear()
        Dim calificacion As Integer = 0
        If cmb_calificacion.SelectedIndex = -1 Then
            ErrorProvider1.SetError(cmb_calificacion, "Seleccione un valor correcto")
            Exit Sub
        End If

        Dim re
        calificacion = cmb_calificacion.SelectedItem

        If id_evaluacion_Detalles > 0 Then


            'Edicion de registro

            If adjunto_inicial And Direccion.Text.Trim <> "Documento en base de datos" Then
                If MsgBox("Si cambia el archivo adjunto, se perdera el archivo anterior ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.No Then
                    Exit Sub
                Else
                    cambio_en_archivo = True
                End If

            End If

            If RD_Comentario.Checked = True Then
                If adjunto_inicial Then
                    If MsgBox("Al guardarlo como comentario se perdera el archivo anteriormente guardado. ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
                        cambio_en_archivo = True
                        re = SqlQuery.editar_evaluacion(id_evaluacion, id_evaluacion_Detalles, txt_descripcion.Text, Nothing, False, False, Nothing, Nothing,
                                                                     calificacion, cambio_en_archivo, estatus)
                    Else
                        Exit Sub
                    End If
                Else
                    re = SqlQuery.editar_evaluacion(id_evaluacion, id_evaluacion_Detalles, txt_descripcion.Text, Nothing, False, False, Nothing, Nothing,
                                                                    calificacion, cambio_en_archivo, estatus)
                End If
            Else
                If cambio_en_archivo Then
                    Dim myByteArray() As Byte = File.ReadAllBytes(Direccion.Text)
                    re = SqlQuery.editar_evaluacion(id_evaluacion, id_evaluacion_Detalles, txt_comentario.Text, txt_nombre.Text, imagen, Not imagen, myByteArray, "." & txt_ext.Text, calificacion, cambio_en_archivo, estatus)
                Else
                    re = SqlQuery.editar_evaluacion(id_evaluacion, id_evaluacion_Detalles, txt_comentario.Text, txt_nombre.Text, imagen, Not imagen, Nothing, Nothing, calificacion, cambio_en_archivo, estatus)
                End If
            End If

            DialogResult = DialogResult.OK



        Else


            'Registro nuevo

            If es_curso Then
                If RD_Comentario.Checked = True Then
                    re = SqlQuery.agregar_evaluacion_cursos(id_evaluacion, CU_CODIGO, txt_nombre.Text.Trim, txt_descripcion.Text.Trim, False, False, Nothing, "." & txt_ext.Text.Trim, cb_codigo, My.Settings.Id_user, calificacion, nivel_actual, id_ponderacion, nivelrequerido)
                Else
                    Dim myByteArray() As Byte = File.ReadAllBytes(Direccion.Text)
                    'Hay que decidir si es imagen o documento
                    re = SqlQuery.agregar_evaluacion_cursos(id_evaluacion, CU_CODIGO, txt_nombre.Text.Trim, txt_comentario.Text.Trim, imagen, True, myByteArray, "." & txt_ext.Text.Trim, cb_codigo, My.Settings.Id_user, calificacion, nivel_actual, id_ponderacion, nivelrequerido)
                End If
            Else
                If RD_Comentario.Checked = True Then
                    re = SqlQuery.agregar_Evaluacion(id_evaluacion, Id_caracteristica, txt_nombre.Text.Trim, txt_descripcion.Text.Trim, False, False, Nothing, "." & txt_ext.Text.Trim, cb_codigo, My.Settings.Id_user, calificacion, nivel_actual, id_ponderacion, nivelrequerido)
                Else
                    Dim myByteArray() As Byte = File.ReadAllBytes(Direccion.Text)
                    'Hay que decidir si es imagen o documento
                    re = SqlQuery.agregar_Evaluacion(id_evaluacion, Id_caracteristica, txt_nombre.Text.Trim, txt_comentario.Text.Trim, imagen, True, myByteArray, "." & txt_ext.Text.Trim, cb_codigo, My.Settings.Id_user, calificacion, nivel_actual, id_ponderacion, nivelrequerido)
                End If
            End If
        End If

        If re > 0 Then
            id_evaluacion = re
            If calificacion > nivel_actual Then nivel_actual = calificacion
            Me.DialogResult = DialogResult.OK
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            PictureBox1.Image = Nothing
            OpenFileDialog1.Reset()
            OpenFileDialog1.ShowDialog()
            Direccion.Text = OpenFileDialog1.FileName
            Dim nom = Split(OpenFileDialog1.SafeFileName, ".")
            txt_nombre.Text = nom(0)
            txt_ext.Text = nom(1)
            If txt_ext.Text.ToUpper = "BMP" Or txt_ext.Text.ToUpper = "JPG" Or txt_ext.Text.ToUpper = "JPEG" Or txt_ext.Text.ToUpper = "PNG" Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                imagen = True
            Else
                imagen = False
            End If
            If id_evaluacion_Detalles > 0 Then cambio_en_archivo = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RD_Comentario.CheckedChanged
        If CType(sender, RadioButton).Checked = True Then
            TabControl1.SelectedIndex = 0
        Else
            TabControl1.SelectedIndex = 1
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Me.DialogResult = DialogResult.Cancel

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


#Region "Codigo cancelado"

#Region "Huella"
    'Function Huella(ByVal ctl As Control, a As String) As Boolean

    '    Try
    '        Dim cb_codigo_aprobacion As Integer = 0
    '        Dim supervisor_nombre As DataTable
    '        Dim usuario_correcto As Boolean = False
    '        Dim solicitud As DataRow()

    '        If midataset.Tables("HUELLAS") IsNot Nothing Then
    '            midataset.Tables.Remove("HUELLAS")
    '        End If
    '        Dim ta As DataTable
    '        ta = SqlQuery.Huellas(My.Settings.CB_CODIGO).Copy
    '        ta.TableName = "HUELLAS"
    '        midataset.Tables.Add(ta)
    '        If midataset.Tables("HUELLAS").DefaultView.Count = 0 Then
    '            usuario_correcto = False
    '            MsgBox("No hay huellas registradas para este usuario", MsgBoxStyle.Critical)
    '            Exit Function
    '        Else
    '            Dim i As Integer
    '            Data = Nothing
    '            Data = New AppData
    '            For i = 0 To midataset.Tables("HUELLAS").DefaultView.Count - 1
    '                Dim arrpicture() As Byte
    '                arrpicture = CType(midataset.Tables("HUELLAS").DefaultView.Item(i).Item("Huella"), Byte())
    '                Dim ms As New IO.MemoryStream(arrpicture)
    '                Dim template As New DPFP.Template(ms)

    '                Data.Templates(midataset.Tables("HUELLAS").DefaultView.Item(i).Item("pos")) = template
    '                Data.EnrolledFingersMask = midataset.Tables("HUELLAS").DefaultView.Item(i).Item("mask")
    '                arrpicture = Nothing
    '                ms = Nothing
    '                template = Nothing

    '            Next

    '            verh = New Aprobar(Data)
    '            Try
    '                ' If Debugger.IsAttached Then Return True
    '                verh.escomedor = True
    '                verh.Data = Data
    '                '  verh.numemp = a
    '                verh.StartPosition = FormStartPosition.CenterScreen
    '                verh.ShowDialog()
    '                If verh.DialogResult = 1 Then
    '                    ''HUELLA AUTORIZADA
    '                    'Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '                    usuario_correcto = True
    '                Else
    '                    usuario_correcto = False
    '                End If
    '            Catch ex As Exception

    '            End Try

    '        End If
    '        Return usuario_correcto
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try


    'End Function
#End Region




#Region "Load"
    'ME.LOAD
    'TabControl2.ItemSize = New Size(0, 1)
    'TabControl2.SizeMode = TabSizeMode.Fixed
    'Select Case id_ponderacion
    'Case 0
    '                MsgBox("No se ha establecido una escala de evaluación")
    '                Me.Close()
    'Case 1
    '                TabControl2.SelectedIndex = 0

    '            Case 2
    '                TabControl2.SelectedIndex = 1
    '            Case 3
    '                TabControl2.SelectedIndex = 2
    '            Case Else


    'End Select
#End Region
#Region "Button2 click"
    'Select Case id_ponderacion
    'Case 1
    'If ComboBox1.SelectedIndex = -1 Then
    '                MsgBox("Seleccione una calificacion", MsgBoxStyle.Critical)
    '                Exit Sub
    'End If
    '            calificacion = ComboBox1.SelectedItem
    '        Case 2
    'If ComboBox2.SelectedIndex = -1 Then
    '                MsgBox("Seleccione una calificacion", MsgBoxStyle.Critical)
    '                Exit Sub
    'End If
    '            calificacion = ComboBox2.SelectedItem
    '        Case 3
    'If ComboBox3.SelectedIndex = -1 Then
    '                MsgBox("Seleccione una calificacion", MsgBoxStyle.Critical)
    '                Exit Sub
    'End If
    '            calificacion = ComboBox3.SelectedItem
    '    End Select
#End Region




#End Region
End Class