Public Class Soporte
    Private Sub Boton_aceptar(sender As Object, e As EventArgs) Handles btn_acept.Click
        guardar()
    End Sub
    Private Sub Boton_cancelar(sender As Object, e As EventArgs) Handles btn_cancel.Click
        cancelar()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            cancelar()
        End If
        If keyData = Keys.Enter Then
            guardar()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    Private Sub guardar()
        Try
            SqlQuery.Support(TextBox1.Text, TextBox2.Text)
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            SqlQuery.Save_Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub cancelar()
        Try
            Me.DialogResult = DialogResult.Cancel
        Catch ex As Exception
            SqlQuery.Save_Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub Soporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TextBox1.Focus()
        Catch ex As Exception
            SqlQuery.Save_Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class