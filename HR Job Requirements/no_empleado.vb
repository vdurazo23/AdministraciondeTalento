Public Class no_empleado
    Public cb_codigo As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Else
            cb_codigo = TextBox1.Text
            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Try
            If e.KeyChar.ToString <> vbBack Then

                If Not IsNumeric(e.KeyChar) Then
                    e.Handled = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
        If keyData = Keys.Enter Then
            cb_codigo = TextBox1.Text
            Me.DialogResult = DialogResult.OK
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub no_empleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub
End Class