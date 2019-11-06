Public Class Launcher
    Dim contador As Integer = 0
    Dim midataset As DataSet
    Private Sub Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label3.Text = My.Application.Info.Version.ToString
        Label4.Text = My.Application.Info.Version.Revision.ToString

        contador = 0
        INFO_LABEL.Text = "    Actualizando puestos..."
        INFO_LABEL.Size = New Size(INFO_LABEL.Size.Height + 5, INFO_LABEL.Size.Width + 20)
        Dim re = SqlQuery.actualizar_puestos()
        If re = 1 Then
            INFO_LABEL.ImageIndex = 1

        End If


        Timer1.Interval = 1000
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            contador = contador + 1

            If contador = 3 Then

                Timer1.Stop()
                Timer1.Enabled = False

                Dim pri As New Principal
                Me.Visible = False
                pri.ShowDialog()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub puestos()
        Try
            Dim r As DataTable
            r = CType(SqlQuery.relaciones, DataTable).Copy
            r.TableName = "Relaciones"
            midataset.Tables.Add(r)
            Dim a = midataset.Tables("Relaciones").Select("Hereda = 1")


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Cargar puestos")
        End Try
    End Sub

    Private Sub Actualizar_heredados(ByVal tabla As DataRow())
        Try
            For a = 0 To tabla.Count - 1
                'Dim e As New TreeNode
                'e.Text = tabla(a).ItemArray(2).ToString
                'e.Tag = tabla(a).ItemArray(1).ToString
                'e.ContextMenuStrip = ContextMenuStrip1
                'node.Nodes.Add(e)
                'If midataset.Tables("Puestos").Select("PU_PARENT = '" & e.Tag & "'").Count > 0 Then
                '    Dim ee = midataset.Tables("Puestos").Select("PU_PARENT = '" & e.Tag & "'")
                '    CargarNodos(ee, e)
                'End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class