Public Class Agregar_periodo
    Public nuevo As Boolean = True
    Public id As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ErrorProvider1.Clear()

            If TextBox1.Text.Trim = "" Then
                ErrorProvider1.SetError(TextBox1, "Escriba una descripción")
            Else
                SqlQuery.Agregar_periodo(TextBox1.Text, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date, DateTimePicker3.Value.Date, nuevo, id)
            End If
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If nuevo Then Exit Sub
            SqlQuery.Eliminar_periodo(id)
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class