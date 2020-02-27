Public Class Ticket
    Private Sub lbl_status_Click(sender As Object, e As EventArgs) Handles lbl_status.Click
        If CType(sender, Label).Text = "Rechazado" Then
            CType(sender, Label).ForeColor = Color.Red
        End If
    End Sub
End Class
