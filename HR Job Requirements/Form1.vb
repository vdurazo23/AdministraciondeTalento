Public Class Form1
    Public PU As String = ""
    Public descrip As String = ""
    Public activo As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Size = Me.MinimumSize
            Dim ta As DataTable
            ta = SqlQuery.Puestos_sin_relacionar()
            DataGridView1.DataSource = ta
            Dim te As DataTable
            te = SqlQuery.Puestos_sin_relacionar(True)
            DataGridView2.DataSource = te
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Al cargar datos de puestos no relacionados")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            PU = ""
            descrip = ""
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
            activo = True
            Me.DialogResult = DialogResult.OK

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "DobleClickCell")
        End Try
    End Sub

    Private Sub Process1_Exited(sender As Object, e As EventArgs) Handles Process1.Exited
        Console.WriteLine("")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CType(sender, Button).Text = "Mostrar puestos inactivos" Then
            CType(sender, Button).Text = "Mostrar solo puestos activos"
            Me.Size = Me.MaximumSize
        Else
            CType(sender, Button).Text = "Mostrar puestos inactivos"
            Me.Size = Me.MinimumSize
        End If
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        Try

            If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
            PU = DataGridView2.Item(0, e.RowIndex).Value.ToString
            descrip = DataGridView2.Item(1, e.RowIndex).Value.ToString
            activo = False
            Me.DialogResult = DialogResult.OK

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "DobleClickCell")
        End Try
    End Sub


End Class