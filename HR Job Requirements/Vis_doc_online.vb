Imports System.Net

Public Class Vis_doc_online
    Private Sub Vis_doc_online_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        Dim d As New Uri("http://10.251.10.21/MASTERWEB/webdocs/X40/201910241020297830.pdf?n=20191108090346")
        IsOnline(d)

        WebBrowser1.Url = New Uri("http://mreamx15/masterweb/view.asp?sesion=202001290917506053&infocard=201902261209473377&d=Y")

        '    d = New Uri("http://10.251.10.21/s")
        IsOnline(d)
        'WebBrowser1.Refresh()
    End Sub



    Public Function IsOnline(ByVal URL As Uri) As Boolean
        Try
            Dim request As WebRequest = WebRequest.Create(URL)
            Dim response As WebResponse = request.GetResponse()
        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function
End Class