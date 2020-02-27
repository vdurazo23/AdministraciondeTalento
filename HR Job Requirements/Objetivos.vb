Public Class Objetivos
    Public cb_codigo As Integer
    Dim midataset As New DataSet
    Dim añoactual As Integer = Date.Today.Year
    Dim mesactual As Integer = Date.Today.Month
    Dim Obj_ As Agregar_objetivo


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Objetivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            cargarValores()
            cargarAños()
            SetDoubleBuffered.Enabled(DataGridView1)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub cargarAños()
        Try
            Dim año As Integer = 2019
            Dim año_actual As Integer = Date.Today.Year

            While (año <= año_actual)
                ComboBox1.Items.Add(año)
                año = año + 1
            End While

            ComboBox1.SelectedIndex = ComboBox1.Items.Count - 1

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try



            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
            If e.ColumnIndex > 5 Then Exit Sub
            Dim obj_ As New Agregar_objetivo
            obj_.cb_codigo = cb_codigo
            obj_.Nuevo = False
            obj_.Id = CType(sender, DataGridView).Item("Id", e.RowIndex).Value
            If obj_.ShowDialog = DialogResult.OK Then
                Dim ra As New DataTable
                ra = CType(SqlQuery.Objetivos_detalles(DataGridView1.Item(0, e.RowIndex).Value), DataTable).Copy
                DataGridView2.DataSource = ra


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            If CType(sender, ComboBox).SelectedIndex = -1 Then Exit Sub
            midataset.Tables("Objetivos").DefaultView.RowFilter = "Año = " & ComboBox1.SelectedItem
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim obj_ As New Agregar_objetivo
            obj_.cb_codigo = cb_codigo
            If obj_.ShowDialog = DialogResult.OK Then
                Console.WriteLine("")
                Dim puesto = SqlQuery.puesto(cb_codigo)
                Dim descrip As String = obj_.txt_descrip.Text.Trim
                Dim obser As String = obj_.txt_obs.Text.Trim
                Dim obj As Double = obj_.num_obj.Value

                Console.WriteLine("")
                Dim re As Integer = SqlQuery.Objetivo_update(cb_codigo, puesto, descrip, obser, obj, ComboBox1.SelectedItem)
                cargarValores()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cargarValores()
        Try

            DataGridView1.DataSource = Nothing
            Dim cur As New DataTable
            cur = CType(SqlQuery.Objetivos(cb_codigo), DataTable).Copy
            cur.TableName = "Objetivos"
            If midataset.Tables("Objetivos") IsNot Nothing Then
                midataset.Tables.Remove("Objetivos")
            End If
            midataset.Tables.Add(cur)
            DataGridView1.DataSource = cur.DefaultView
            If ComboBox1.SelectedItem IsNot Nothing Then
                midataset.Tables("Objetivos").DefaultView.RowFilter = "Año = " & ComboBox1.SelectedItem
            End If

            For Each col As DataGridViewColumn In DataGridView1.Columns
                If col.Index > 5 And col.Index < 18 Then
                    col.Width = 60
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Try

            If ComboBox1.SelectedItem < Date.Today.Year Then

                Select Case CType(sender, DataGridView).Columns(e.ColumnIndex).Name

                    Case "Enero"
                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Febrero"
                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Marzo"

                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Abril"
                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Mayo"
                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Junio"
                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Julio"
                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Agosto"
                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Septiembre"
                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Octubre"
                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Noviembre"
                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                    Case "Diciembre"

                        If e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf e.Value = 100 Then
                            e.CellStyle.BackColor = Color.Green
                        Else
                            e.CellStyle.BackColor = Color.Red
                        End If

                End Select


            Else

                Select Case CType(sender, DataGridView).Columns(e.ColumnIndex).Name
                    Case "Enero"

                        If 1 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 1 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                                End If
                            Else
                                If e.Value = 100 Then
                                    e.CellStyle.BackColor = Color.Green
                                Else
                                    e.CellStyle.BackColor = Color.Red
                                End If

                            End If

                    Case "Febrero"

                        If 2 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 2 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If

                    Case "Marzo"

                        If 3 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 3 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If

                    Case "Abril"
                        If 4 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 4 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If

                    Case "Mayo"

                        If 5 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 5 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If

                    Case "Junio"

                        If 6 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 6 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If

                    Case "Julio"

                        If 7 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 7 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If

                    Case "Agosto"

                        If 8 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 8 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If

                    Case "Septiembre"

                        If 9 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 9 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If

                    Case "Octubre"

                        If 10 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 10 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If

                    Case "Noviembre"

                        If 11 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 11 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If
                    Case "Diciembre"

                        If 12 > mesactual Then
                            e.CellStyle.BackColor = Color.White
                        ElseIf e.Value.ToString = "" Then
                            e.CellStyle.BackColor = Color.Red
                        ElseIf 12 = mesactual Then
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            If e.Value = 100 Then
                                e.CellStyle.BackColor = Color.Green
                            Else
                                e.CellStyle.BackColor = Color.Red
                            End If

                        End If

                End Select

            End If




        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Or e.ColumnIndex > 18 Then Exit Sub
        If e.ColumnIndex < 6 Then



        ElseIf e.ColumnIndex < 18 Then
            Dim objdet As New Objetivos_acciones
            objdet.año = ComboBox1.SelectedItem
            objdet.mes = e.ColumnIndex - 5
            objdet.id_objetivo = CType(sender, DataGridView).Item("Id", e.RowIndex).Value
            objdet.cb_codigo = cb_codigo
            objdet.puesto = SqlQuery.puesto(cb_codigo)
            objdet.Label1.Text = DataGridView1.Columns(e.ColumnIndex).HeaderText
            If objdet.ShowDialog() = DialogResult.OK Then
                cargarValores()

            End If
        End If
    End Sub
End Class