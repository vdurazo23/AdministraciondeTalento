Public Class Launcher
    Dim contador As Integer = 0
    Dim midataset As DataSet
    Private Sub Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If My.Settings.UPGRADEREQUIRED Then
            My.Settings.Default.Upgrade()
            My.Settings.UPGRADEREQUIRED = False
            My.Settings.Save()
        End If
        Dim str() As String
        str = GetCommandLineArgs()
        If (UBound(str) >= 0) Then
            If str(0) = "c" Or str(0) = "C" Or My.Settings.MPSServer = "" Or My.Settings.TRESSServer = "" Then
                Dim conf As New Configuracion
                If conf.ShowDialog() <> DialogResult.OK Then
                    conf.Dispose()
                    conf = Nothing
                    Application.Exit()
                    Exit Sub
                End If
                conf.Dispose()
                conf = Nothing
            End If
        End If
        If My.Settings.Permisos IsNot Nothing Then
            My.Settings.Permisos.Clear()
        End If
        Label3.Text = My.Application.Info.Version.ToString
        Label4.Text = My.Application.Info.Version.Revision.ToString

        contador = 0
        INFO_LABEL.Text = "    Actualizando puestos..."
        INFO_LABEL.Size = New Size(INFO_LABEL.Size.Height + 5, INFO_LABEL.Size.Width + 20)
        If Debugger.IsAttached Then
            Dim re = SqlQuery.actualizar_puestos()
            If re = 1 Then
                INFO_LABEL.ImageIndex = 1
            End If
        End If
        INFO_LABEL.ImageIndex = 1
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


    Function GetCommandLineArgs() As String()
        ' Declare variables.
        Dim separators As String = " "
        Dim commands As String = Microsoft.VisualBasic.Command()
        Dim args() As String = commands.Split(separators.ToCharArray)
        Return args
    End Function


End Class