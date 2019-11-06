Public Class Caracteristica
    Public cb_codigo As Integer
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim adj As New Adjuntos

        If Me.Tag.ToString <> "" Then
            adj.id_evaluacion = Me.Tag
            adj.cb_codigo = cb_codigo
        End If

        adj.ShowDialog()
    End Sub
End Class
