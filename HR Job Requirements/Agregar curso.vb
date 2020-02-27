


Public Class Agregar_curso

    Public CU_CODIGO As String
    Public CU_NOMBRE As String
    Dim midataset As New DataSet
    Dim rowfilter1 As String = "1=1 and"
    Dim rowfilter2 As String = " 1=1"

    Private Sub Agregar_curso_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TextBox1.Text = CU_NOMBRE
            TextBox1.Enabled = False
            Cargar_datos()
            Cargar_relaciones()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub Cargar_datos()
        Try
            Dim datos As New DataTable
            datos = CType(SqlQuery.datos_cursos(CU_CODIGO), DataTable).Copy
            datos.TableName = "DatosCurso"
            If midataset.Tables("DatosCurso") IsNot Nothing Then
                midataset.Tables.Remove("DatosCurso")
            End If
            midataset.Tables.Add(datos)
            If midataset.Tables("DatosCurso").Rows.Count > 0 Then
                TextBox2.Text = midataset.Tables("DatosCurso").Rows(0).Item("Ingles").ToString
                TXT_EXTRA.Text = midataset.Tables("DatosCurso").Rows(0).Item("Detalles").ToString
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try
    End Sub
    Private Sub Cargar_relaciones()
        Try

            Dim TE As New DataTable
            TE = CType(SqlQuery.relaciones_cursos(CU_CODIGO, False), DataTable).Copy

            TE.TableName = "RelacionesCUR"
            If midataset.Tables("RelacionesCUR") IsNot Nothing Then
                midataset.Tables.Remove("RelacionesCUR")
            End If
            midataset.Tables.Add(TE)
            DataGridView1.DataSource = midataset.Tables("RelacionesCUR")
            'DataGridView1.DataSource = TE.DefaultView
          
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False
            DataGridView1.Columns(7).Visible = False
            DataGridView1.Columns(11).Visible = False

            Todo.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Todo.Click, Hereda.Click, Escalona.Click, Por_puesto.Click, Por_empleado.Click, Por_nivel.Click
        Try

            For Each btn As Button In Panel3.Controls
                If btn.Name = CType(sender, Button).Name Then
                    btn.BackColor = Color.Gray
                    btn.Enabled = False
                Else
                    btn.BackColor = Color.White
                    btn.Enabled = True
                End If
            Next
            If midataset.Tables("RelacionesCUR") IsNot Nothing Then
                If midataset.Tables("RelacionesCUR").Rows.Count > 0 Then


                    Select Case CType(sender, Button).Name
                        Case "Todo"
                            rowfilter1 = "1=1 and"
                            midataset.Tables("RelacionesCUR").DefaultView.RowFilter = rowfilter1 & rowfilter2
                        Case "Por_puesto"
                            rowfilter1 = "Por_puesto = True and Escalona = False and Hereda = False   and "
                            midataset.Tables("RelacionesCUR").DefaultView.RowFilter = rowfilter1 & rowfilter2
                            DataGridView1.Columns(4).Visible = False
                        Case Else
                            rowfilter1 = CType(sender, Button).Name.ToString & " = True and"
                            midataset.Tables("RelacionesCUR").DefaultView.RowFilter = rowfilter1 & rowfilter2
                            If CType(sender, Button).Name <> "Por_nivel" Then
                                DataGridView1.Columns(4).Visible = False
                            Else
                                DataGridView1.Columns(4).Visible = True
                            End If

                    End Select
                    If CType(sender, Button).Name <> "Todo" Then
                        If CType(sender, Button).Name = "Por_empleado" Then
                            DataGridView1.Columns(12).Visible = True
                            DataGridView1.Columns(13).Visible = True
                        Else
                            DataGridView1.Columns(12).Visible = False
                            DataGridView1.Columns(13).Visible = False
                        End If
                        If CType(sender, Button).Name = "Por_nivel" Then
                            DataGridView1.Columns(4).Visible = True
                        Else
                            DataGridView1.Columns(4).Visible = False
                        End If
                        If CType(sender, Button).Name = "Escalona" Then
                            DataGridView1.Columns(9).Visible = True
                        Else
                            DataGridView1.Columns(9).Visible = False
                        End If
                        If (CType(sender, Button).Name = "Hereda" Or CType(sender, Button).Name = "Escalona" Or CType(sender, Button).Name = "Por_puesto") Then
                            DataGridView1.Columns(8).Visible = True
                        Else
                            DataGridView1.Columns(8).Visible = False
                        End If

                    Else
                        DataGridView1.Columns(12).Visible = True
                        DataGridView1.Columns(13).Visible = True
                        DataGridView1.Columns(4).Visible = True
                        DataGridView1.Columns(9).Visible = True
                        DataGridView1.Columns(8).Visible = True
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            If Not Permiso.Habilitado("RCC") Then
                MsgBox("No tiene permisos para relacionar esta caracteristica", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If midataset.Tables("DatosCurso").Rows.Count > 0 Then
                If TextBox2.Text <> midataset.Tables("DatosCurso").Rows(0).Item("Ingles").ToString Or TXT_EXTRA.Text <> midataset.Tables("DatosCurso").Rows(0).Item("Detalles").ToString Then
                    Dim RE = SqlQuery.agregar_detalles_CURSOS(CU_CODIGO, TextBox1.Text, TXT_EXTRA.Text)
                End If
            Else
                If TextBox2.Text <> "" Or TXT_EXTRA.Text <> "" Then
                    Dim RE = SqlQuery.agregar_detalles_CURSOS(CU_CODIGO, TextBox1.Text, TXT_EXTRA.Text)
                End If
            End If

            Dim s As New Relacion_curso
            s.CU_CODIGO = CU_CODIGO
            s.tipo = "Cur"

            s.ShowDialog()

            'Actualizar relaciones
            Cargar_relaciones()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Al querer agregar relación")
        End Try

    End Sub

    Private Sub btn_borrar_Click(sender As Object, e As EventArgs) Handles btn_borrar.Click
        Try
            If Not Permiso.Habilitado("RCC") Then
                MsgBox("No tiene permisos para agregar, eliminar o editar alguna relacion a esta caracteristica", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("¿Seguro que desea eliminar esta relacion?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If SqlQuery.eliminar_instruccion(DataGridView1.CurrentRow.Cells("id").Value) = True Then
                    Cargar_relaciones()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Delete Then
            btn_borrar.PerformClick()
        End If
        If keyData = Keys.Control + Keys.Alt + Keys.C Then
            Dim co As New Configuraciones
            co.ShowDialog()
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub btn_nivelrequerido_Click(sender As Object, e As EventArgs) Handles btn_nivelrequerido.Click
        Try
            SqlQuery.modificar_calificaciones_curso(CU_CODIGO)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try



            If TextBox2.Text <> midataset.Tables("DatosCurso").Rows(0).Item("Ingles").ToString Or TXT_EXTRA.Text <> midataset.Tables("DatosCurso").Rows(0).Item("Detalles").ToString Then
                Dim RE = SqlQuery.agregar_detalles_CURSOS(CU_CODIGO, TextBox1.Text, TXT_EXTRA.Text)
            End If
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Error al aceptar")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.DialogResult = DialogResult.Cancel

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class