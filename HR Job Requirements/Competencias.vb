Public Class Competencias
    Dim midataset As New DataSet
    Dim combo_seleccionado As String = "Todos los empleados"
    Dim nivel_seleccionado As Integer = 0
    Dim salir As Boolean = False
    Dim cargar As Boolean = True

    Private Sub Competencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton5.Checked = True
        nivel_seleccionado = RadioButton5.Tag
        cargar_Datagrid()
        DGV_COM.AutoScrollOffset = New Point(10000, 10000)

        'Dim competencias As DataTable
        'competencias = SqlQuery.Competencias
        'If competencias.Rows.Count > 0 Then

        'End If
    End Sub

    Private Sub cargar_Datagrid()
        Try

            Dim competencias As DataTable
            competencias = SqlQuery.Competencias

            DGV_COM.Columns.Clear()
            DGV_COM.Rows.Clear()
            DGV_COM.DataSource = Nothing
            If competencias.Rows.Count > 0 Then

                Dim col As New DataGridViewCheckBoxColumn
                col.Name = "Seleccionar"
                col.HeaderText = "Seleccionar"
                DGV_COM.Columns.Add(col)
                DGV_COM.DataSource = competencias

                For Each coll As DataGridViewColumn In DGV_COM.Columns
                    If coll.HeaderText = "Seleccionar" Then
                        coll.ReadOnly = False
                    Else
                        coll.ReadOnly = True
                    End If
                    '    If coll.HeaderText = "Nivel" Then coll.Visible = False
                    '     If coll.HeaderText = "Id" Then coll.Visible = False
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DGV_COM_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_COM.CellFormatting
        Try
            If cargar = False Then Exit Sub
            If e.ColumnIndex = 0 Then
                If String.IsNullOrEmpty(DGV_COM.Item(4, e.RowIndex).Value.ToString) Then
                    DGV_COM.Item(4, e.RowIndex).ReadOnly = False
                    e.CellStyle.BackColor = Color.White
                    exit Sub
                End If

                If DGV_COM.Item(4, e.RowIndex).Value = nivel_seleccionado Then
                    'read only false and color white
                    DGV_COM.Item(e.ColumnIndex, e.RowIndex).ReadOnly = False
                    e.Value = True
                    e.CellStyle.BackColor = Color.White

                ElseIf DGV_COM.Item(4, e.RowIndex).Value > nivel_seleccionado Then
                    'read only true and color gray
                    e.Value = True
                    e.CellStyle.BackColor = Color.LightGray
                    DGV_COM.Item(e.ColumnIndex, e.RowIndex).ReadOnly = True
                Else
                    DGV_COM.Item(e.ColumnIndex, e.RowIndex).ReadOnly = False
                    '  e.Value = False
                    e.CellStyle.BackColor = Color.White

                    'read only = false and color white

                End If

                '  If e.RowIndex = DGV_COM.Rows.Count -1 Then cargar = False
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged, RadioButton4.CheckedChanged, RadioButton5.CheckedChanged
        Try
            If CType(sender, RadioButton).Checked = True Then
                nivel_seleccionado = CType(sender, RadioButton).Tag
                combo_seleccionado = CType(sender, RadioButton).Text
                DGV_COM.Refresh()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DGV_COM_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_COM.CellContentClick
        Try

            If e.ColumnIndex = 0 Then
                If DGV_COM.Item(e.ColumnIndex, e.RowIndex).ReadOnly = True Then Exit Sub
                DGV_COM.Item(e.ColumnIndex + 1, e.RowIndex).Selected = True
                If DGV_COM.Item(e.ColumnIndex, e.RowIndex).Value = True Then
                    DGV_COM.Item(4, e.RowIndex).Value = nivel_seleccionado
                    DGV_COM.Item(3, e.RowIndex).Value = combo_seleccionado
                    SqlQuery.UPDATE_Competencias(DGV_COM.Item(1, e.RowIndex).Value, nivel_seleccionado)
                Else
                    DGV_COM.Item(4, e.RowIndex).Value = DBNull.Value
                    DGV_COM.Item(3, e.RowIndex).Value = ""
                    SqlQuery.UPDATE_Competencias(DGV_COM.Item(1, e.RowIndex).Value, -1)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class