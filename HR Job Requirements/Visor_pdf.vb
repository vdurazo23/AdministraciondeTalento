Imports System.IO

Public Class Visor_pdf


    Public documento As System.Byte()

    Dim aass As FileStream
    Private Sub Visor_pdf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxAcroPDF1.LoadFile(Nothing)
        cargarDocumento()
    End Sub

    Private Sub cargarDocumento()
        Try
            Dim nombre As String = "Generico.pdf"
            aass = File.Create(nombre)
            aass.Close()
            File.WriteAllBytes(nombre, documento)
            AxAcroPDF1.LoadFile(nombre)
            File.Delete(nombre)
            AxAcroPDF1.setShowToolbar(False)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class