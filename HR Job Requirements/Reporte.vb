Imports Microsoft.Reporting.WinForms

Public Class Reporte
    Public path As String
    Public parametro As List(Of ReportParameter)
    Public midataset As New DataSet

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.Close()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    Private Sub Reporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://mars/ReportServer_SQLMARS")
        Exit Sub

    End Sub



    'Private Sub ModelosToolStripMenuItem_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ModelosToolStripMenuItem.DropDownItemClicked
    '    'Try
    '    '    ReportViewer1.Reset()
    '    '    ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://mars/ReportServer_SQLMARS")
    '    '    ReportViewer1.ShowParameterPrompts = False
    '    '    ReportViewer1.ProcessingMode = ProcessingMode.Remote


    '    '    If My.Settings.MPSBD = "Mars" Then
    '    '        ReportViewer1.ServerReport.ReportPath = "/Cross Section/Cross Section Report"
    '    '    Else
    '    '        ReportViewer1.ServerReport.ReportPath = "/Cross Section/Test/Cross Section Report"
    '    '    End If

    '    '    Dim pa As New ReportParameter("Modelo", e.ClickedItem.Text)
    '    '    ReportViewer1.ServerReport.SetParameters(pa)
    '    '    Me.ReportViewer1.RefreshReport()

    '    '    Console.WriteLine("")
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    '    SQLCon.Save_Error(ex)
    '    'End Try
    'End Sub

    'Private Sub BUSQUEDAPERSONALIZADAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BUSQUEDAPERSONALIZADAToolStripMenuItem.Click
    '    'Try
    '    '    If ReportViewer1.ShowParameterPrompts = True Then
    '    '        ReportViewer1.ShowParameterPrompts = False
    '    '    Else
    '    '        ReportViewer1.ShowParameterPrompts = True
    '    '    End If

    '    '    ReportViewer1.RefreshReport()
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    '    SQLCon.Save_Error(ex)
    '    'End Try
    'End Sub

    'Private Sub ReporteGeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteGeneralToolStripMenuItem.Click
    '    'Try

    '    '    ReportViewer1.Reset()
    '    '    ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://mars/ReportServer_SQLMARS")
    '    '    ReportViewer1.ShowParameterPrompts = False
    '    '    ReportViewer1.ProcessingMode = ProcessingMode.Remote

    '    '    If My.Settings.MPSBD = "Mars" Then
    '    '        ReportViewer1.ServerReport.ReportPath = "/Cross Section/Control de soldadura"
    '    '    Else
    '    '        ReportViewer1.ServerReport.ReportPath = "/Cross Section/Test/Control de soldadura"
    '    '    End If

    '    '    Dim pa As New ReportParameter("Años_atras", My.Settings.Años)
    '    '    Dim pe As New ReportParameter("Fecha", Today)
    '    '    ReportViewer1.ServerReport.SetParameters(pe)
    '    '    ReportViewer1.ServerReport.SetParameters(pa)
    '    '    Me.ReportViewer1.RefreshReport()
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    '    SQLCon.Save_Error(ex)
    '    'End Try
    'End Sub

    Private Sub PruebaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PruebaToolStripMenuItem.Click
        Try
            Dim n As New no_empleado
            n.showdialog()
            Dim cb_codigo = n.cb_codigo

            ReportViewer1.Reset()
            ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://mars/ReportServer_SQLMARS")
            ReportViewer1.ShowParameterPrompts = False
            ReportViewer1.ProcessingMode = ProcessingMode.Remote


            If My.Settings.MPSBD = "Mars" Then
                ReportViewer1.ServerReport.ReportPath = "/HR/Requerimientos de puesto"
            Else
                ReportViewer1.ServerReport.ReportPath = "/HR/Requerimientos de puesto"
            End If

            Dim pa As New ReportParameter("No_empleado", cb_codigo)
            ReportViewer1.ServerReport.SetParameters(pa)
            Me.ReportViewer1.RefreshReport()

            Console.WriteLine("")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Public Sub CargarIdp(ByVal CB_CODIGO As Integer, ByVal Periodo As Integer, ByVal Ambos_lenguajes As Boolean)
        Try
            ReportViewer1.Reset()
            ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://mars/ReportServer_SQLMARS")
            ReportViewer1.ShowParameterPrompts = False
            ReportViewer1.ProcessingMode = ProcessingMode.Remote

            If My.Settings.MPSBD = "Mars" Then
                If Ambos_lenguajes Then
                    ReportViewer1.ServerReport.ReportPath = "/HR/IDPespañol"
                Else
                    ReportViewer1.ServerReport.ReportPath = "/HR/IDP"
                End If
            Else
                If Ambos_lenguajes Then
                    ReportViewer1.ServerReport.ReportPath = "/HR/IDPespañol"
                Else
                    ReportViewer1.ServerReport.ReportPath = "/HR/IDP"
                End If
            End If


            Dim pa As New ReportParameter("No_empleado", CB_CODIGO)
            Dim pe As New ReportParameter("Periodo", Periodo)

            ReportViewer1.ServerReport.SetParameters(pa)
                ReportViewer1.ServerReport.SetParameters(pe)


                Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class