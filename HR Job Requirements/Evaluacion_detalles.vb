Imports System.IO

Public Class Evaluacion_detalles
    Public id_evaluacion_detalles As Integer = 0
    Dim datos As DataTable
    Dim aprobaciones As DataTable
    Private Sub Evaluacion_detalles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If id_evaluacion_detalles > 0 Then
            Cargar_info()
            Cargar_aprobaciones()
            If txt_estatus.Text = "Aprobado" Then
                btn_editar.Visible = False
            End If

        Else
            Me.DialogResult = DialogResult.Cancel
        End If

    End Sub

    Private Sub Cargar_info()
        Try

            datos = CType(SqlQuery.Detalles_evaluacion(id_evaluacion_detalles), DataTable).Copy
            Console.WriteLine("")
            Dim ro As Integer = datos.Rows.Count - 1
            If datos.Rows.Count > 0 Then
                lbl_id.Text = datos.Rows(ro).ItemArray(0).ToString
                txt_evalua.Text = datos.Rows(ro).ItemArray(2).ToString
                txt_tipo.Text = datos.Rows(ro).ItemArray(3).ToString
                txt_carac.Text = datos.Rows(ro).ItemArray(4).ToString
                txt_nivel.Text = datos.Rows(ro).ItemArray(5).ToString
                txt_fecha.Text = datos.Rows(ro).ItemArray(6).ToString 'cambiar formato de fecha
                txt_vence.Text = datos.Rows(ro).ItemArray(7).ToString 'cambair formato de fecha cuando se tenga el dato
                txt_puntos.Text = datos.Rows(ro).ItemArray(8).ToString
                txt_nombre.Text = datos.Rows(ro).ItemArray(9).ToString & datos.Rows(ro).ItemArray(10).ToString
                txt_descripcion.Text = datos.Rows(ro).ItemArray(11).ToString
                txt_estatus.Text = datos.Rows(ro).ItemArray(14).ToString
                Select Case txt_estatus.Text
                    Case "Aprobado"
                        txt_estatus.ForeColor = Color.Red
                    Case "Rechazado"
                        txt_estatus.ForeColor = Color.Green
                    Case "Pendiente"
                        txt_estatus.ForeColor = Color.Yellow
                End Select
                txt_estatus.ReadOnly = True
                If datos.Rows(ro).ItemArray(12).ToString <> "" Then

                    Dim myByteArray() As Byte = datos.Rows(ro).ItemArray(12)
                    Dim stream As New MemoryStream(myByteArray)
                    PictureBox1.Image = Image.FromStream(stream)
                    btn_zoom.Enabled = True
                    btn_zoom.BackColor = Color.White
                ElseIf datos.Rows(ro).ItemArray(13).ToString <> "" Then
                    'sin vista previa
                    PictureBox1.Image = My.Resources.SinVistaPrevia
                    Select Case datos.Rows(ro).ItemArray(10).ToString.ToLower.Trim
                        Case ".pdf"
                            btn_zoom.Enabled = True
                            btn_zoom.BackColor = Color.White
                            btn_open.Enabled = True
                            btn_open.BackColor = Color.White
                        Case Else
                            btn_zoom.BackColor = Color.LightGray
                            btn_zoom.Enabled = False
                            btn_open.Enabled = True
                            btn_open.BackColor = Color.White
                    End Select
                Else
                    'no aplica
                    PictureBox1.Image = My.Resources.na
                    btn_zoom.BackColor = Color.LightGray
                    btn_zoom.Enabled = False
                    btn_open.BackColor = Color.LightGray
                    btn_open.Enabled = False
                End If

            Else
                Me.DialogResult = DialogResult.Cancel
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Cargar_aprobaciones()
        Try

            aprobaciones = CType(SqlQuery.Detalles_aprobaciones(id_evaluacion_detalles), DataTable).Copy
            If aprobaciones.Rows.Count > 0 Then
                DataGridView1.DataSource = Nothing
                DataGridView1.DataSource = aprobaciones
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(DataGridView1.Columns.Count - 1).Visible = False

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btn_zoom_Click(sender As Object, e As EventArgs) Handles btn_zoom.Click
        Try
            Select Case datos.Rows(0).ItemArray(10).ToString.ToLower.Trim
                Case ".pdf"
                    Dim vp As New Visor_pdf
                    vp.documento = datos.Rows(0).ItemArray(13)
                    vp.ShowDialog()

                Case Else
                    Dim vi As New Visor_imagen
                    vi.PictureBox1.Image = PictureBox1.Image
                    vi.ShowDialog()

            End Select


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btn_open_Click(sender As Object, e As EventArgs) Handles btn_open.Click
        Try
            Dim nombrearchivo As String = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + datos.Rows(0).ItemArray(10).ToString.Trim
            Dim aass As FileStream

            aass = File.Create(nombrearchivo)
            aass.Close()
            If datos(0).ItemArray(12).ToString = "" Then
                File.WriteAllBytes(nombrearchivo, datos(0).ItemArray(13))
            Else
                File.WriteAllBytes(nombrearchivo, datos(0).ItemArray(12))
            End If
            Dim pro As New Process
            pro.StartInfo.FileName = nombrearchivo
            pro.Start()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click

        Try
            If MsgBox("¿Seguro que desea eliminar?", MsgBoxStyle.YesNo) Then


                SqlQuery.Eliminar_evaluaciones(id_evaluacion_detalles, txt_estatus.Text)


                Me.DialogResult = DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_editar.Click
        Try
            Dim agev As New Agregar_evaluacion
            agev.id_evaluacion_Detalles = id_evaluacion_detalles
            If agev.ShowDialog() = DialogResult.OK Then
                Cargar_info()
                Cargar_aprobaciones()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class