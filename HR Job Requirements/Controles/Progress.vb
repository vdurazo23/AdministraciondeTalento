

Public Class Progress

    Public rect As Rectangle = New Rectangle(4, 10, 10, 10)
    Public percentage As Single = 50

    Private Sub Progress_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Progress_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim di As Integer
            Dim progressAngle = CSng(360 / 100 * percentage)
            Dim remainderAngle = 360 - progressAngle
            Dim g As Graphics = e.Graphics
            'create pens to use for the arcs

            Using progressPen As New Pen(Color.LightSeaGreen, 2), remainderPen As New Pen(Color.LightGray, 2)
                'set the smoothing to high quality for better output
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                'draw the blue and white arcs

                If Me.Height < Me.Width Then
                    di = Me.Height
                Else
                    di = Me.Width
                End If

                g.DrawArc(progressPen, New Rectangle(New Point(((Me.Width / 2) - (di / 2)) + 1, ((Me.Height / 2) - (di / 2)) + 1), New Size(di - 3, di - 3)), -90, progressAngle)
                g.DrawArc(remainderPen, New Rectangle(New Point(((Me.Width / 2) - (di / 2)) + 1, ((Me.Height / 2) - (di / 2)) + 1), New Size(di - 3, di - 3)), progressAngle - 90, remainderAngle)
            End Using

            'draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly
            Using fnt As New Font(Me.Font.FontFamily, 14)
                'Dim text As String = percentage.ToString + "%"
                Dim text As String = Valor.ToString + "%"
                Dim textSize = g.MeasureString(text, fnt)
                Dim textPoint As New Point(CInt(1 + (Me.Width / 2) - (textSize.Width / 2)), CInt(1 + (Me.Height / 2) - (textSize.Height / 2)))
                'now we have all the values draw the text
                g.DrawString(text, fnt, Brushes.Black, textPoint)
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Private valueactual As Integer
    <System.ComponentModel.Browsable(True)>
    <System.ComponentModel.Description("Valor inicial del control")>
    <System.ComponentModel.Category("Datos")>
    Public Property Valor As Integer
        Get
            Return valueactual
        End Get
        Set(value As Integer)
            valueactual = value
        End Set
    End Property
End Class
