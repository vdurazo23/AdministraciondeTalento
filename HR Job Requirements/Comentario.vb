Public Class Comentario
    Public Obligatorio = True
    Public tipo As String = "Comentario"
    Private Sub Comentario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = tipo
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ErrorProvider1.Clear()
            If Obligatorio And TextBox1.Text = "" Then
                ErrorProvider1.SetError(TextBox1, tipo & " obligatorio")
                Exit Sub
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Comentario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class