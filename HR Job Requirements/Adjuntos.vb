Imports System.IO

Public Class Adjuntos

    Dim midataset As New DataSet
    Public id_evaluacion As Integer = 0
    Public cb_codigo As Integer
    Private Sub Adjuntos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If id_evaluacion = 0 Then Exit Sub
            cargardocumentos()
            cargarArchivos()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub cargardocumentos()
        Try
            Dim ta As DataTable
            ta = CType(SqlQuery.Documentos_evaluacion(cb_codigo, id_evaluacion), DataTable).Copy
            ta.TableName = "Evaluaciones_detalles"
            midataset.Tables.Add(ta)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub cargarArchivos()
        Try
            If midataset.Tables("Evaluaciones_detalles") IsNot Nothing Then

                For Each ro As DataRow In midataset.Tables("Evaluaciones_detalles").Rows
                    Dim li As New ListViewItem
                    li.Text = ro(4).ToString & ro(6).ToString
                    li.Tag = ro(0)
                    Select Case ro(6).trim.ToString
                        Case ".pdf"
                            li.ImageIndex = 0

                    End Select

                    ListView1.Items.Add(li)


                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Try
            Dim a = midataset.Tables("Evaluaciones_detalles").Select("Id=" & CType(sender, ListView).SelectedItems.Item(0).Tag)
            Dim nombrearchivo As String = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + a(0).ItemArray(6).ToString.Trim '"Nuevo\" & a(0).ItemArray(4) & a(0).ItemArray(6).ToString.Trim

            Dim aass As FileStream

            aass = File.Create(nombrearchivo)
            aass.Close()
            File.WriteAllBytes(nombrearchivo, a(0).ItemArray(5))
            '      FileOpen(1, nombrearchivo, OpenMode.Append)

            Dim pro As New Process

            pro.StartInfo.FileName = nombrearchivo
            pro.Start()


            '     FileClose(1)
            'Process.Start(nombrearchivo)
            '  pro.Close()
            '   aass.Close()

            '    File.Delete(nombrearchivo)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub
End Class