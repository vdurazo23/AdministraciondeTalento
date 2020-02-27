Public Class Comparacion_control

    Public datos As DataTable
    Public puesto As String
    Public pu_codigo As String
    Public cb_codigo As Integer
    Private Sub Comparacion_control_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            Label1.Text = puesto
            cargar_datos()
            If datos IsNot Nothing Then
                If datos.Rows.Count > 0 Then
                    Cargar_tabla()
                    Cargar_niveles()
                    If DataGridView1.Rows.Count = 0 Then
                        RemoveHandler DataGridView1.CellFormatting, AddressOf DataGridView1_CellFormatting
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub cargar_datos()
        Try
            datos = Nothing
            datos = CType(SqlQuery.Cargar_carac_otropuesto(cb_codigo, pu_codigo), DataTable).Copy
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Cargar_tabla()
        Try

            DataGridView1.DataSource = Nothing
            DataGridView1.Columns.Clear()
            DataGridView1.DataSource = datos

            Dim col_req As New DataGridViewImageColumn
            col_req.HeaderText = "Requerido"
            col_req.Name = "Requerido"

            Dim col_act As New DataGridViewImageColumn
            col_act.HeaderText = "Actual"
            col_act.Name = "Actual"

            Dim calificar As New DataGridViewLinkColumn
            calificar.HeaderText = "Calificar"
            calificar.Name = "Calificar"

            Dim Adjuntos As New DataGridViewLinkColumn
            Adjuntos.HeaderText = "Adjunto"
            Adjuntos.Name = "Adjunto"

            Dim vali As New DataGridViewImageColumn
            vali.HeaderText = "Aprobaciones pendientes"
            vali.Name = "Aprobaciones pendientes"
            vali.DefaultCellStyle.NullValue = Nothing


            DataGridView1.Columns.Add(col_req)
            DataGridView1.Columns.Add(col_act)
            DataGridView1.Columns.Add(calificar)
            DataGridView1.Columns.Add(Adjuntos)
            DataGridView1.Columns.Add(vali)

            DataGridView1.Columns("Porcentaje").DisplayIndex = 7
            DataGridView1.Columns("Porcentaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("Requerido").DisplayIndex = 5
            DataGridView1.Columns("Actual").DisplayIndex = 6
            DataGridView1.Columns("Nivel requerido").Visible = False
            DataGridView1.Columns("Id_evaluacion").Visible = False
            DataGridView1.Columns("Validado").Visible = False
            DataGridView1.Columns("Id_ponderacion").Visible = False
            SetDoubleBuffered.Enabled(DataGridView1)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Cargar_niveles()
        Try
            Dim total As Double = 0
            Dim cant As Integer

            If datos.Select("Tipo = 'Competencia'").Count > 0 Then
                Dim temporal As DataTable = datos.Select("Tipo = 'Competencia'").CopyToDataTable
                cant = temporal.Rows.Count
                For Each ro As DataRow In temporal.Rows
                    If ro.ItemArray(7).ToString <> "" Then
                        total = total + ro.ItemArray(7)
                    End If
                Next
                Progress_competencias.Valor = (total / cant)
            Else
                Progress_competencias.Valor = -1
            End If
            total = 0
            cant = 0

            If datos.Select("Tipo = 'Conocimiento'").Count > 0 Then
                Dim temporal As DataTable = datos.Select("Tipo = 'Conocimiento'").CopyToDataTable
                cant = temporal.Rows.Count
                For Each ro As DataRow In temporal.Rows
                    If ro.ItemArray(7).ToString <> "" Then
                        total = total + ro.ItemArray(7)
                    End If
                Next
                Progress_conocimiento.Valor = (total / cant)
            Else
                Progress_conocimiento.Valor = -1
            End If
            total = 0
            cant = 0

            If datos.Select("Tipo = 'Habilidad'").Count > 0 Then
                Dim temporal As DataTable = datos.Select("Tipo = 'Habilidad'").CopyToDataTable
                cant = temporal.Rows.Count
                For Each ro As DataRow In temporal.Rows
                    If ro.ItemArray(7).ToString <> "" Then
                        total = total + ro.ItemArray(7)
                    End If
                Next
                Progress_habilidades.Valor = (total / cant)
            Else
                Progress_habilidades.Valor = -1
            End If
            total = 0
            cant = 0

            If datos.Select("Tipo = 'Curso'").Count > 0 Then
                Dim temporal As DataTable = datos.Select("Tipo = 'Curso'").CopyToDataTable
                cant = temporal.Rows.Count
                For Each ro As DataRow In temporal.Rows
                    If ro.ItemArray(7).ToString <> "" Then
                        total = total + ro.ItemArray(7)
                    End If
                Next
                Progress_curso.Valor = (total / cant)
            Else
                Progress_curso.Valor = -1
            End If
            total = 0
            cant = 0



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            Select Case DataGridView1.Columns(e.ColumnIndex).HeaderText
                Case "Calificar"
                    If My.Settings.Usuario.ToUpper = "ADMIN" Then
                        MsgBox("Utilice una cuenta de usuario específico para realizar una evaluación")
                        Exit Sub
                    End If
                    If Not Permiso.Habilitado("RCE") Then
                        If Permiso.Habilitado("REJ") Then
                            If My.Settings.EmpleadosHijos.Select("Pu_codigo = '" & pu_codigo & "'").Count = 0 Then
                                MsgBox("No tienes permiso para evaluar a este empleado", MsgBoxStyle.Critical)
                                Exit Sub
                            End If
                        Else
                            MsgBox("No tienes permiso para evaluar a este empleado", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                    End If

                    Dim a As New Agregar_evaluacion
                    a.Caracteristica = CType(sender, DataGridView).Item("Descripcion", e.RowIndex).Value
                    If CType(sender, DataGridView).Item("Tipo", e.RowIndex).Value = "Curso" Then
                        a.es_curso = True
                        a.CU_CODIGO = CType(sender, DataGridView).Item("Id", e.RowIndex).Value
                    Else
                        a.Id_caracteristica = CType(sender, DataGridView).Item("Id", e.RowIndex).Value
                    End If


                    a.nivelrequerido = CType(sender, DataGridView).Item("Nivel requerido", e.RowIndex).Value
                    a.id_ponderacion = CType(sender, DataGridView).Item("Id_ponderacion", e.RowIndex).Value
                    a.cb_codigo = cb_codigo
                    a.nivel_actual = CType(sender, DataGridView).Item("Porcentaje", e.RowIndex).Value
                    a.actual = CType(sender, DataGridView).Item("Porcentaje", e.RowIndex).Value




                    If CType(sender, DataGridView).Item("Id_evaluacion", e.RowIndex).Value.ToString <> "" Then
                        a.id_evaluacion = CType(sender, DataGridView).Item("Id_evaluacion", e.RowIndex).Value
                    End If

                    If a.ShowDialog() = DialogResult.OK Then
                        DataGridView1.DataSource = Nothing
                        cargar_datos()
                        Cargar_tabla()
                        Cargar_niveles()
                    End If



                Case "Adjunto"

                    If CType(sender, DataGridView).Item("Id_evaluacion", e.RowIndex).Value.ToString <> "" Then
                        Dim adj As New Adjuntos
                        adj.id_evaluacion = CType(sender, DataGridView).Item("Id_evaluacion", e.RowIndex).Value
                        adj.cb_codigo = cb_codigo
                        adj.ShowDialog()
                    End If

                Case ""

                Case ""
            End Select


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Try
            Select Case CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText

                Case "Requerido"

                    e.Value = ImageList1.Images(CType(sender, DataGridView).Item("Nivel requerido", e.RowIndex).Value)



                Case "Actual"
                    If (CType(sender, DataGridView).Item("Porcentaje", e.RowIndex).Value.ToString) <> "" Then
                        Dim index As Integer = Math.Truncate((CType(sender, DataGridView).Item("Porcentaje", e.RowIndex).Value * CType(sender, DataGridView).Item("Nivel requerido", e.RowIndex).Value) / 100)
                        e.Value = ImageList1.Images(index)

                    Else
                        e.Value = ImageList1.Images(0)
                    End If


                Case "Calificar"

                    e.Value = "Calificar"


                Case "Adjunto"

                    e.Value = "Ver"


                Case "Aprobaciones pendientes"
                    If CType(sender, DataGridView).Item("Validado", e.RowIndex).Value = True Then
                        '  e.Value = ImageList2.Images(1)
                    
                    Else
                        e.Value = ImageList2.Images(0)
                    End If



            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
