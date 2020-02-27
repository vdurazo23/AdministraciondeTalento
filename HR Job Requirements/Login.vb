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
                password = SqlQuery.contraseña(txtuser.Text)
            End If


            Dim  parameters As String = txtuser.Text + "," + password
            Dim current_user As SqlQuery.Usuario = SqlQuery.Busqueda_usuario(txtuser.Text, password)

            If current_user.cb_codigo = -1 Then
                MsgBox("No hay conexion a la red", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If current_user.cb_codigo > 0 Then
                If checkGuardar.Checked = True Then
                    My.Settings.Usuario = txtuser.Text
                    My.Settings.Save()
                    My.Settings.Reload()
                Else
                    My.Settings.Usuario = ""
                    My.Settings.Save()
                    My.Settings.Reload()
                End If

                My.Settings.Usuario = txtuser.Text
                My.Settings.CB_CODIGO = current_user.cb_codigo
                My.Settings.Id_user = current_user.id_user
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