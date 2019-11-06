Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = Me.Text + " " + My.Application.Info.Version.ToString + " - Revision " + My.Application.Info.Version.Revision.ToString
        If My.Settings.UPGRADEREQUIRED Then
            My.Settings.Default.Upgrade()
            My.Settings.UPGRADEREQUIRED = False
            My.Settings.Save()
        End If

        txtuser.Text = My.Settings.Usuario
        If My.Settings.Usuario <> "" Then checkGuardar.Checked = True

        Dim str() As String
        str = GetCommandLineArgs()
        If (UBound(str) >= 0) Then
            If str(0) = "c" Or str(0) = "C" Or My.Settings.MPSServer = "" Then 'Or My.Settings.ServerTress = "" Or My.Settings.dsnCMS = "" Then
                'Dim conf As New Configuraciones
                'If conf.ShowDialog() <> DialogResult.OK Then
                '    conf.Dispose()
                '    conf = Nothing
                '    Application.Exit()
                'End If
                'conf.Dispose()
                'conf = Nothing
            End If
        End If


        Me.TabIndex = 0
        txtuser.TabIndex = 1
        txtpass.TabIndex = 2
        btnlogin.TabIndex = 3

        If Debugger.IsAttached Then
            'If My.Settings.MPSBD = "MarsTest" Then
            '    txtuser.Text = "Admin"
            'Else
            '    txtuser.Text = "Aguirree"
            'End If
            txtuser.Text = "Aguirree"
            txtpass.Text = "Mexico01"
            btnlogin.PerformClick()
        End If
    End Sub
    Function GetCommandLineArgs() As String()
        ' Declare variables.
        Dim separators As String = " "
        Dim commands As String = Microsoft.VisualBasic.Command()
        Dim args() As String = commands.Split(separators.ToCharArray)
        Return args
    End Function

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        buscar_usuario()
    End Sub
    Private Sub txtuser_KeyUp(sender As Object, e As KeyEventArgs) Handles txtuser.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtpass.Focus()
        End If
    End Sub
    Private Sub txtpass_KeyUp(sender As Object, e As KeyEventArgs) Handles txtpass.KeyUp
        If e.KeyCode = Keys.Enter Then
            buscar_usuario()
        End If
    End Sub

    Sub buscar_usuario()
        Try

            Dim password As String = GenerateHash(txtpass.Text)

            If Debugger.IsAttached Then
                If My.Settings.MPSBD = "marstest" Then
                    If txtuser.Text = "Admin" Then password = "yZKvSfmVrqz6fVKohy2X3Q=="
                Else
                    If txtuser.Text = "Admin" Then password = "yZKvSfmVrqz6fVKohy2X3Q=="
                End If
                If txtuser.Text = "ceballosa" Then password = "Lsfv+HsALYT870uLVUcp0Q=="
                If txtuser.Text = "Vallejof" Then password = "gkpkBl0z9OOKN5mAUaQvkQ=="
                '  If txtuser.Text = "Admin" Then password = "yZKvSfmVrqz6fVKohy2X3Q=="
                If txtuser.Text = "coronadoa" Then password = "dtNAiKCo7G1A97VmJ26b3A=="
                If txtuser.Text = "Siqueirosn" Then password = "rJ1gGWVtFQGTbgxP5FzZ0w=="
                If txtuser.Text = "moralesa" Then password = "RopIpsAToUuj3QcX7CabiQ=="
                If txtuser.Text = "quiroze" Then password = "Lsfv+HsALYT870uLVUcp0Q=="
                If txtuser.Text = "arriolan" Then password = "aZMAa38YOFAtZsRTItJ71A=="
                If txtuser.Text = "Lediniche" Then password = "Oq2wsYlFGUe+IxAFbHcQxA==" 'Edwin
                If txtuser.Text = "Vallejof" Then password = "gkpkBl0z9OOKN5mAUaQvkQ==" ' Francisca Vallejo
                If txtuser.Text = "Lazcanov" Then password = "dtNAiKCo7G1A97VmJ26b3A==" ' victor
                If txtuser.Text = "Lopezd" Then password = "+sSmyvGbzux1wN80IM7xFg==" 'DulceL
                If txtuser.Text = "clopez" Then password = "ubqcEtMA4a1KjESyYDsHWQ==" 'DulceL
                If txtuser.Text = "ibarrai" Then password = "U+cWiLwMnRAuqAo0042rqw==" 'Isela
                If txtuser.Text = "garciam" Then password = "EE5glNW9g47AetFzB6BRoA==" ' Manuel García
                If txtuser.Text = "lopezd" Then password = "+sSmyvGbzux1wN80IM7xFg=="
                If txtuser.Text = "Mezaj" Then password = "QyFsl0avzZunVJsw+uG77g=="
                If txtuser.Text = "Contrerasc" Then password = "Lsfv+HsALYT870uLVUcp0Q=="
                If txtuser.Text = "Corralf" Then password = "DFtw+ZHspcmTaffRDCrSqA=="
                If txtuser.Text = "castrog" Then password = "DFtw+ZHspcmTaffRDCrSqA=="
                If txtuser.Text = "castellanosc" Then password = "Lsfv+HsALYT870uLVUcp0Q=="

                Select Case txtuser.Text
                    Case "Danielo"
                        password = "Lsfv+HsALYT870uLVUcp0Q=="

                    Case "Iturraldec"
                        password = "Lsfv+HsALYT870uLVUcp0Q=="

                    Case "Riosb"
                        password = "Ohq7dmNQkkxAT2ev3Qf03A=="

                    Case "Graciaj"
                        password = "to4DgulIGAMrCZq9l17r3g=="

                    Case "Tanoril"
                        password = "Lsfv+HsALYT870uLVUcp0Q=="

                    Case "Gomeze"
                        password = "3vPN8oLwCrGMFKMkMvcXcA=="

                    Case "Alcantarh"
                        password = "rJ1gGWVtFQGTbgxP5FzZ0w=="

                    Case "Coronadoa"
                        password = "dtNAiKCo7G1A97VmJ26b3A=="

                    Case "Castrog"


                End Select

            End If


            Dim parameters As String = txtuser.Text + "," + password
            Dim currentuser_CB_CODIGO As Integer = SqlQuery.Busqueda_usuario(txtuser.Text, password)
            If currentuser_CB_CODIGO = -1 Then
                MsgBox("No hay conexion a la red", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If currentuser_CB_CODIGO > 0 Then
                If checkGuardar.Checked = True Then
                    My.Settings.Usuario = txtuser.Text
                    My.Settings.Save()
                    My.Settings.Reload()
                Else
                    My.Settings.Usuario = ""
                    My.Settings.Save()
                    My.Settings.Reload()
                End If


                My.Settings.CB_CODIGO = currentuser_CB_CODIGO
                Me.DialogResult = DialogResult.OK
            Else
                txtuser.Focus()
                MsgBox("El usuario o la contraseña no son correctas, favor de revisar", MsgBoxStyle.Critical, "Error")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function GenerateHash(ByVal sourcetext As String)
        Dim ue As UnicodeEncoding = New UnicodeEncoding()
        Dim bytesourcetext As Byte() = ue.GetBytes(sourcetext)
        Dim MD5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
        Dim bytehash As Byte() = MD5.ComputeHash(bytesourcetext)
        Return Convert.ToBase64String(bytehash)
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.F1 Then
            'Dim conf As New Configuraciones
            'If conf.ShowDialog() <> DialogResult.OK Then
            '    conf.Dispose()
            '    conf = Nothing
            'End If
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function



End Class