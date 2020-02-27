Imports System.IO

Public Class Adjuntos

    Dim midataset As New DataSet
    Public id_evaluacion As Integer = 0
    Public cb_codigo As Integer
    Private Sub Adjuntos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If id_evaluacion = 0 Then Exit Sub
            cargardocumentos()
            cargarArchivos()

            Me.Size = MinimumSize
            Me.CenterToScreen
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub cargardocumentos()
        Try
            midataset.Tables.Clear()
            dgv_evaluaciones.DataSource = Nothing
            dgv_evaluaciones.Columns.Clear()
            dgv_pendientes.DataSource = Nothing
            dgv_pendientes.Columns.Clear()
            dgv_rechazados.DataSource = Nothing
            dgv_rechazados.Columns.Clear()


            Dim ta As DataTable
            ta = CType(SqlQuery.Documentos_evaluacion(cb_codigo, id_evaluacion), DataTable).Copy
            ta.TableName = "Evaluaciones_detalles"
            midataset.Tables.Add(ta)






            Dim ta_para_rechazados As DataTable
            ta_para_rechazados = CType(SqlQuery.Documentos_evaluacion(cb_codigo, id_evaluacion), DataTable).Copy
            ta_para_rechazados.TableName = "Evaluaciones_detalles_rechazados"
            midataset.Tables.Add(ta_para_rechazados)



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub cargarArchivos()
        Try
            If midataset.Tables("Evaluaciones_detalles") IsNot Nothing Then
                For Each ro As DataRow In midataset.Tables("Evaluaciones_detalles").Rows
                    If ro.Item("Imagen") Is Nothing And ro.Item("Documento") Is Nothing Then
                    Else
                        If ro.Item("Imagen").ToString <> "" Or ro.Item("Documento").ToString <> "" Then
                            Dim li As New ListViewItem
                            li.Text = ro(4).ToString & ro(6).ToString
                            li.Tag = ro(0)
                            Select Case ro(6).trim.ToString
                                Case ".pdf"
                                    li.ImageIndex = 0
                                Case ".docx"
                                    li.ImageIndex = 1
                                Case ".ppt"
                                    li.ImageIndex = 3
                                Case ".xls"
                                    li.ImageIndex = 4
                                Case Else
                                    If ro.Item("Imagen").ToString <> "" Then
                                        li.ImageIndex = 2
                                    Else
                                        li.ImageIndex = 5
                                    End If
                            End Select
                            ListView1.Items.Add(li)
                        End If
                    End If
                Next
            End If
            Dim tabla_aprobado As DataTable
            Dim tabla_pendiente As DataTable
            Dim tabla_rechazado As DataTable
            midataset.Tables("Evaluaciones_detalles").DefaultView.RowFilter = "Imagen is null and Documento is null and Validado = True and Rechazado = False"
            tabla_aprobado = midataset.Tables("Evaluaciones_detalles").DefaultView.ToTable.Copy
            midataset.Tables("Evaluaciones_detalles").DefaultView.RowFilter = "Imagen is null and Documento is null and Validado = False and Rechazado = False"
            tabla_pendiente = midataset.Tables("Evaluaciones_detalles").DefaultView.ToTable.Copy
            midataset.Tables("Evaluaciones_detalles").DefaultView.RowFilter = "Imagen is null and Documento is null and Validado = False and Rechazado = True"
            tabla_rechazado = midataset.Tables("Evaluaciones_detalles").DefaultView.ToTable.Copy
            dgv_evaluaciones.DataSource = tabla_aprobado
            dgv_pendientes.DataSource = tabla_pendiente
            dgv_rechazados.DataSource = tabla_rechazado



            dgv_evaluaciones.Columns("Imagen").Visible = False
            dgv_evaluaciones.Columns("Nombre_documento").Visible = False
            dgv_evaluaciones.Columns("Documento").Visible = False
            dgv_evaluaciones.Columns("Extension").Visible = False
            dgv_evaluaciones.Columns("Validado").Visible = False
            dgv_evaluaciones.Columns("Rechazado").Visible = False
            '     dgv_evaluaciones.Columns("Validado").Visible = False




            dgv_pendientes.Columns("Imagen").Visible = False
            dgv_pendientes.Columns("Nombre_documento").Visible = False
            dgv_pendientes.Columns("Documento").Visible = False
            dgv_pendientes.Columns("Extension").Visible = False
            dgv_pendientes.Columns("Validado").Visible = False
            dgv_pendientes.Columns("Rechazado").Visible = False

            dgv_rechazados.Columns("Imagen").Visible = False
            dgv_rechazados.Columns("Nombre_documento").Visible = False
            dgv_rechazados.Columns("Documento").Visible = False
            dgv_rechazados.Columns("Extension").Visible = False
            dgv_rechazados.Columns("Validado").Visible = False
            dgv_rechazados.Columns("Rechazado").Visible = False


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Try

            Dim vp As New Evaluacion_detalles
            vp.id_evaluacion_detalles = CType(sender, ListView).SelectedItems.Item(0).Tag
            vp.ShowDialog()
            cargardocumentos()
            cargarArchivos()
            Exit Sub



            'Try
            '    Me.Size = MaximumSize
            '    Me.CenterToScreen()
            '    TextBox1.Text = midataset.Tables("Evaluaciones_detalles").Select("Id=" & CType(sender, ListView).SelectedItems.Item(0).Tag)(0).ItemArray(2)
            '    TextBox2.Text = midataset.Tables("Evaluaciones_detalles").Select("Id=" & CType(sender, ListView).SelectedItems.Item(0).Tag)(0).ItemArray(7)
            '    TextBox3.Text = midataset.Tables("Evaluaciones_detalles").Select("Id=" & CType(sender, ListView).SelectedItems.Item(0).Tag)(0).ItemArray(8)
            '    If midataset.Tables("Evaluaciones_detalles").Select("Id=" & CType(sender, ListView).SelectedItems.Item(0).Tag)(0).ItemArray(10) = True Then
            '        TextBox5.Text = "Aprobado"
            '    ElseIf midataset.Tables("Evaluaciones_detalles").Select("Id=" & CType(sender, ListView).SelectedItems.Item(0).Tag)(0).ItemArray(11) = True Then
            '        TextBox5.Text = "Rechazado"
            '    Else
            '        TextBox5.Text = "Pendiente"
            '    End If
            '    TextBox7.Text = midataset.Tables("Evaluaciones_detalles").Select("Id=" & CType(sender, ListView).SelectedItems.Item(0).Tag)(0).ItemArray(2)
            '    TextBox4.Text = ""
            '    TextBox6.Text = ""
            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Critical)
            'End Try



            'Exit Sub

            'Dim a = midataset.Tables("Evaluaciones_detalles").Select("Id=" & CType(sender, ListView).SelectedItems.Item(0).Tag)
            '         Dim nombrearchivo As String = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + a(0).ItemArray(6).ToString.Trim '"Nuevo\" & a(0).ItemArray(4) & a(0).ItemArray(6).ToString.Trim

            '         Dim aass As FileStream

            '         aass = File.Create(nombrearchivo)
            '         aass.Close()
            '         If a(0).ItemArray(5).ToString = "" Then
            '             File.WriteAllBytes(nombrearchivo, a(0).ItemArray(3))
            '         Else
            '             File.WriteAllBytes(nombrearchivo, a(0).ItemArray(5))
            '         End If
            '         '      FileOpen(1, nombrearchivo, OpenMode.Append)
            '         Dim pro As New Process
            '         pro.StartInfo.FileName = nombrearchivo
            '         pro.Start()
            ''     FileClose(1)
            ''Process.Start(nombrearchivo)
            ''  pro.Close()
            ''   aass.Close()
            ''    File.Delete(nombrearchivo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.Close()
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub dgv_evaluaciones_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_evaluaciones.CellContentDoubleClick, dgv_pendientes.CellContentDoubleClick, dgv_rechazados.CellContentDoubleClick
        Try

            Dim vp As New Evaluacion_detalles
            vp.id_evaluacion_detalles = CType(sender,DataGridView).Item(0,e.RowIndex).Value
            vp.ShowDialog()
            cargardocumentos()
            cargarArchivos()
            Exit Sub
            'Me.Size = MaximumSize
            'Me.CenterToScreen()

            'TextBox1.Text = CType(sender, DataGridView).Item("Puntos", e.RowIndex).Value
            'TextBox2.Text = CType(sender, DataGridView).Item("Aprueba_CB_CODIGO", e.RowIndex).Value
            'TextBox3.Text = CType(sender, DataGridView).Item("Fecha", e.RowIndex).Value
            'If CType(sender, DataGridView).Item("Validado", e.RowIndex).Value = True Then
            '    TextBox5.Text = "Aprobado"
            'ElseIf CType(sender, DataGridView).Item("Rechazado", e.RowIndex).Value = True Then
            '    TextBox5.Text = "Rechazado"
            'Else
            '    TextBox5.Text = "Pendiente"
            'End If
            'TextBox7.Text = CType(sender, DataGridView).Item("Descripcion", e.RowIndex).Value
            'PictureBox1.Image = My.Resources.na
            'TextBox4.Text = ""
            'TextBox6.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class