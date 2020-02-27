Public Class Cursos
    Dim rf1 As String = "1 = 1 "
    Dim rf2 As String = "and 1 = 1 "
    Dim midataset As New DataSet
    Private Sub Cursos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            cargar_cursos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    Private Sub cargar_cursos()
        Try
            DataGridView1.DataSource = Nothing
            Dim TA As DataTable
            TA = CType(SqlQuery.lista_cursos(), DataTable).Copy
            TA.TableName = "Cursos"
            If midataset.Tables("Cursos") IsNot Nothing Then
                midataset.Tables.Remove("Cursos")
            End If
            midataset.Tables.Add(TA)
            DataGridView1.DataSource = midataset.Tables("Cursos")
            midataset.Tables("Cursos").DefaultView.RowFilter = rf1 & rf2
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try

            If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
            Dim Relaciones As New Agregar_curso
            Relaciones.CU_CODIGO = DataGridView1.Item("CU_CODIGO", e.RowIndex).Value.ToString
            Relaciones.CU_NOMBRE = DataGridView1.Item("CU_NOMBRE",e.RowIndex).Value.ToString
            Relaciones.ShowDialog()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If CType(sender, TextBox).Text.Trim = "" Then
                rf2 = " and 1 = 1"
            Else
                rf2 = "and CU_NOMBRE like '%" & CType(sender, TextBox).Text.Trim & "%' "
            End If
            midataset.Tables("Cursos").DefaultView.RowFilter = rf1 & rf2
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class