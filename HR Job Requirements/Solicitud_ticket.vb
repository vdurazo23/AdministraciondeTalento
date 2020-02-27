Public Class Solicitud_ticket
    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Console.WriteLine("")
        If DataGridView1.Height = 0 Then

            DataGridView1.Size = New Size(DataGridView1.Width, 150)
        Else
            DataGridView1.Size = New Size(DataGridView1.Width, 0)
        End If




    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs)
        Try
            If SplitContainer2.Panel1Collapsed = True Then
                SplitContainer2.Panel1Collapsed = False
            Else
                SplitContainer2.Panel1Collapsed = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class