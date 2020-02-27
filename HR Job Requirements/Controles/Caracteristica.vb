Public Class Caracteristica
    Public cb_codigo As Integer
    Public id_ponderacion As Integer
    Public Es_curso As Boolean = False
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_evidencia.Click
        Dim adj As New Adjuntos

        If Me.Tag.ToString <> "" Then
            adj.id_evaluacion = Me.Tag
            adj.cb_codigo = cb_codigo
        End If

        adj.ShowDialog()
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles lbl_niv_req.Click

    End Sub

    Private Sub Caracteristica_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ' calcular()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub calcular()
        Try
            If lbl_niv_req.ImageIndex = -1 Or lbl_niv_actual.ImageIndex = -1 Then Exit Sub
            Console.WriteLine()
            If lbl_niv_actual.ImageIndex >= lbl_niv_req.ImageIndex Then

                lbl_porcentaje.Text = "100%"
            Else

                lbl_porcentaje.Text = (lbl_niv_actual.ImageIndex / lbl_niv_req.ImageIndex) * 100 & "%"

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub lbl_porcentaje_TextChanged(sender As Object, e As EventArgs) Handles lbl_porcentaje.TextChanged
        Try
            Exit Sub
            If sender.text <> "Porcentaje" Then
                Console.WriteLine(")")
                Dim ni As Integer = CType(sender, Label).Text.Split("%")(0).Trim
                If ni >= 0 And ni < 50 Then
                    ' lbl_porcentaje.BackColor = Color.OrangeRed

                ElseIf ni < 49 And ni < 75 Then
                    '      lbl_porcentaje.BackColor = Color.LightGoldenrodYellow

                Else
                    '      lbl_porcentaje.BackColor = Color.LightGreen
                End If
                '  lbl_porcentaje.ImageIndex = Math.Truncate(ni * 4 / 100)
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
