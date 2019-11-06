Public Class Form1
    Public PU As String = ""
    Public descrip As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim ta As DataTable
            ta = SqlQuery.Puestos_sin_relacionar()
            DataGridView1.DataSource = ta

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Al cargar datos de puestos no relacionados")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            PU = ""
            Me.DialogResult = DialogResult.Cancel
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Console.WriteLine("")
            If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
            PU = DataGridView1.Item(0, e.RowIndex).Value.ToString
            descrip = DataGridView1.Item(1, e.RowIndex).Value.ToString
            Me.DialogResult = DialogResult.OK

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "DobleClickCell")
        End Try
    End Sub

    Private Sub Process1_Exited(sender As Object, e As EventArgs) Handles Process1.Exited
        Console.WriteLine("")
    End Sub
End Class