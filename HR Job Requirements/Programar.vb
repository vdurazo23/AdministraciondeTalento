Public Class Programar
    Public IDP As Boolean = False
    Public Fecha_limite_1 As Date
    Public Fecha_limite_2 As Date
    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Label2.Text = MonthCalendar1.SelectionStart.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.DialogResult = DialogResult.Cancel
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Programar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IDP Then
            Label1.Text = "Actual"
            MonthCalendar1.MinDate = Fecha_limite_1
            MonthCalendar1.MaxDate = Fecha_limite_2
        End If
    End Sub
End Class