Imports System.Reflection

Public Class Tickets
    Dim todos As Boolean = False
    Dim midataset As New DataSet
    Dim dbu As New SetDoubleBuffered
    Dim vp As Evaluacion_detalles
    Private Sub Tickets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarTodo()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Sub BFEnabled(ByVal dgv As DataGridView)
        Dim dgvType As Type = dgv.[GetType]()

        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance Or BindingFlags.NonPublic)

        pi.SetValue(dgv, True, Nothing)

    End Sub

    Private Sub CargarTodo()
        Try
            cargar_Tickets()
            lbl_requerido.Text = DataGridView2.Rows.Count
            lbl_solicitados.Text = DataGridView3.Rows.Count
            lbl_aprobados.Text = midataset.Tables("Tickets").Select("Aprobado = True").Count
            lbl_reachazados.Text = midataset.Tables("Tickets").Select("Rechazado = True").Count
            lbl_pendientes.Text = midataset.Tables("Tickets").Select("Aprobado = False and Rechazado = False and Usuario='" & My.Settings.Usuario & "'").Count
            lbl_total.Text = midataset.Tables("Tickets").Rows.Count
            dbu.Enabled(DataGridView2)
            dbu.Enabled(DataGridView3)
            Exit Sub
            'If Permiso.Habilitado("VTT") = True Then
            ' todos = True
            ' End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cargar_Tickets()
        Try
            DataGridView2.DataSource = Nothing
            DataGridView3.DataSource = Nothing
            DataGridView2.Columns.Clear()
            DataGridView3.Columns.Clear()

            If midataset.Tables("Tickets") IsNot Nothing Then
                midataset.Tables.Remove("Tickets")
            End If

            Dim ticke As DataTable
            ticke = CType(SqlQuery.Get_tickets(todos), DataTable).Copy
            ticke.TableName = "Tickets"
            midataset.Tables.Add(ticke)

            'LLenar datagridview 1

            midataset.Tables("Tickets").DefaultView.RowFilter = "Pendiente = '" & My.Settings.Usuario & "'"
            Dim solicitudes As DataTable = midataset.Tables("Tickets").DefaultView.ToTable
            DataGridView2.DataSource = solicitudes
            Dim pedidas As DataTable
            midataset.Tables("Tickets").DefaultView.RowFilter = "Usuario = '" & My.Settings.Usuario & "'"
            pedidas = midataset.Tables("Tickets").DefaultView.ToTable
            DataGridView3.DataSource = pedidas

            Ocultar_columnas()
            Dim ver_column As New DataGridViewLinkColumn
            ver_column.HeaderText = "Reporte"
            ver_column.Name = "Ver"

            Dim ver_column_dos As New DataGridViewLinkColumn
            ver_column_dos.HeaderText = "Aprobar con comentario"
            ver_column_dos.Name = "AprobComentario"

            Dim aprobar_column As New DataGridViewLinkColumn
            aprobar_column.HeaderText = "Aprobar"
            aprobar_column.Name = "Aprobar"

            Dim rechazar_column As New DataGridViewLinkColumn
            rechazar_column.HeaderText = "Rechazar"
            rechazar_column.Name = "Rechazar"

            DataGridView2.Columns.Add(ver_column)
            DataGridView2.Columns.Add(aprobar_column)
            DataGridView2.Columns.Add(ver_column_dos)
            DataGridView2.Columns.Add(rechazar_column)


            Dim ver_column_2 As New DataGridViewLinkColumn
            ver_column_2.HeaderText = "Reporte"
            ver_column_2.Name = "Ver"

            DataGridView3.Columns.Add(ver_column_2)

            'Dim limite As Integer = midataset.Tables("Tickets").Columns.Count

            'For a = 0 To DataGridView2.Rows.Count - 1
            '    CType(DataGridView2.Rows(a).Cells(limite), DataGridViewLinkCell).Value = "VER"
            '    DataGridView2.Rows(a).Cells(limite + 1).Value = "Aprobar"
            '    DataGridView2.Rows(a).Cells(limite + 2).Value = "Rechazar"
            'Next

            'For a = 0 To DataGridView3.Rows.Count - 1
            '    DataGridView3.Rows(a).Cells(limite).Value = "VER"
            '    '   DataGridView3.Rows(a).Cells(limite + 1).Value = "Aprobar"
            '    '   DataGridView3.Rows(a).Cells(limite + 2).Value = "Rechazar"
            'Next

            ''For Each ro As DataGridViewRow In DataGridView2.Rows
            ''    ro.Cells(limite).Value = "VER"
            ''    ro.Cells(limite + 1).Value = "Aprobar"
            ''    ro.Cells(limite + 2).Value = "Rechazar"
            ''Next
            ''For Each ro As DataGridViewRow In DataGridView3.Rows
            ''    ro.Cells(limite).Value = "VER"
            ''    ro.Cells(limite + 1).Value = "Aprobar"
            ''    ro.Cells(limite + 2).Value = "Rechazar"
            ''Next



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Ocultando columnas de tablas tickets")
        End Try
    End Sub

    Private Sub Ocultar_columnas()
        Try
            If todos Then
                For Each ro As DataGridViewRow In DataGridView2.Rows
                    ro.Visible = True
                Next
                For Each ro As DataGridViewRow In DataGridView3.Rows
                    ro.Visible = True
                Next
            Else
                DataGridView2.Columns("Solicitado por").Visible = False
                DataGridView2.Columns("Evaluacion").Visible = False
                DataGridView2.Columns("Id_evaluacion").Visible = False
                DataGridView2.Columns("Id_evaluacion_detalle").Visible = False
                DataGridView2.Columns("Agregar caracteristica").Visible = False
                DataGridView2.Columns("Id_caracteristica").Visible = False
                DataGridView2.Columns("Comentario").Visible = False
                DataGridView2.Columns("Aprobado").Visible = False
                DataGridView2.Columns("Rechazado").Visible = False
                DataGridView2.Columns("Aprobado por").Visible = False
                DataGridView2.Columns("Aprueba").Visible = False
                DataGridView2.Columns("Ultima fecha update").Visible = False
                DataGridView2.Columns("Pendiente").Visible = False
                DataGridView2.Columns("Id_detalles").Visible = False


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Ocultando columnas de tablas tickets")
        End Try
    End Sub


    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        Try
            If DataGridView2.Columns(e.ColumnIndex).HeaderText = "Reporte" Then
                e.Value = "Ver"
            End If

            If DataGridView2.Columns(e.ColumnIndex).HeaderText = "Aprobar" Or DataGridView2.Columns(e.ColumnIndex).HeaderText = "Aprobar con comentario" Then
                e.Value = "Aprobar"
            End If

            If DataGridView2.Columns(e.ColumnIndex).HeaderText = "Rechazar" Then
                e.Value = "Rechazar"
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub DataGridView3_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView3.CellFormatting
        Try
            If DataGridView3.Columns(e.ColumnIndex).HeaderText = "Reporte" Then
                e.Value = "Ver"
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Try
            If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
            If DataGridView2.Columns(e.ColumnIndex).HeaderText = "Reporte" Then
                vp = New Evaluacion_detalles
                vp.id_evaluacion_detalles = CType(sender, DataGridView).Item("Id_evaluacion_detalle", e.RowIndex).Value
                vp.ShowDialog()
            End If
            If DataGridView2.Columns(e.ColumnIndex).HeaderText = "Aprobar" Then
                Dim res = SqlQuery.aprobar(DataGridView2.Rows(e.RowIndex).Cells("Id").Value, True, "")
                If res = 1 Then
                    DataGridView2.Rows.RemoveAt(e.RowIndex)
                    lbl_requerido.Text = lbl_requerido.Text - 1
                End If
            End If
            If DataGridView2.Columns(e.ColumnIndex).HeaderText = "Aprobar con comentario" Then
                Dim com As New Comentario
                com.Obligatorio = False
                If com.ShowDialog = DialogResult.OK Then
                    Dim comen = com.TextBox1.Text.Trim
                    Dim res = SqlQuery.aprobar(DataGridView2.Rows(e.RowIndex).Cells("Id").Value, True, comen)
                    If res = 1 Then
                        DataGridView2.Rows.RemoveAt(e.RowIndex)
                        lbl_requerido.Text = lbl_requerido.Text - 1
                    End If
                End If


            End If
            If DataGridView2.Columns(e.ColumnIndex).HeaderText = "Rechazar" Then
                Dim com As New Comentario
                com.Obligatorio = True
                If com.ShowDialog = DialogResult.OK Then
                    Dim comen As String = com.TextBox1.Text.Trim
                    Dim res = SqlQuery.aprobar(DataGridView2.Rows(e.RowIndex).Cells("Id").Value, False, comen)
                    If res = 1 Then
                        DataGridView2.Rows.RemoveAt(e.RowIndex)
                        lbl_requerido.Text = lbl_requerido.Text - 1
                    End If
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        Try

            If DataGridView2.Columns(e.ColumnIndex).HeaderText = "Reporte" Then
                Dim vp As New Evaluacion_detalles
                vp.id_evaluacion_detalles = CType(sender, DataGridView).Item("Id_evaluacion_detalle", e.RowIndex).Value
                vp.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub lbl_requerido_TextChanged(sender As Object, e As EventArgs) Handles lbl_requerido.TextChanged
        Try
            Dim r As Integer = lbl_requerido.Text
            r = r + lbl_solicitados.Text
            lbl_total.Text = r
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim quelimpiar As New LimpiarTickets
            If quelimpiar.ShowDialog() = DialogResult.OK Then
                Dim aprobados As Boolean = False
                Dim rechazados As Boolean = False
                aprobados = quelimpiar.CheckBox1.Checked
                rechazados = quelimpiar.CheckBox2.Checked
                SqlQuery.limpiar_tickets(aprobados, rechazados)
                CargarTodo()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class