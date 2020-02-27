Public Class Configuraciones
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click
        Dim co As New Configuracion_evaluacion
        Select Case sender.tag
            Case 1
                co.Competencias = True

            Case 2
                co.Habilidades = True

            Case 3
                co.Conocimientos = True

            Case 4

        End Select

        co.ShowDialog()

    End Sub


End Class