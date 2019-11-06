Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Aprobar


    Public Data As AppData
    Dim intentos As Integer = 0
    Public escomedor As Boolean = False
    Public conf As Boolean = False
    Sub New(ByVal data As AppData)
        InitializeComponent()
        Me.Data = data
    End Sub
    Sub OnComplete(ByVal Control As Object, ByVal FeatureSet As DPFP.FeatureSet, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles VerificationControl.OnComplete
        Dim ver As New DPFP.Verification.Verification()
        Dim res As New DPFP.Verification.Verification.Result()

        For Each template As DPFP.Template In Data.Templates    ' Compare feature set with all stored templates:
            If Not template Is Nothing Then                     '   Get template from storage.
                ver.Verify(FeatureSet, template, res)           '   Compare feature set with particular template.
                Data.IsFeatureSetMatched = res.Verified         '   Check the result of the comparison
                Data.FalseAcceptRate = res.FARAchieved          '   Determine the current False Accept Rate
                If res.Verified Then
                    EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Success
                    'System.Threading.Thread.Sleep(500)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Exit For ' success
                End If
            End If
        Next
        If Not res.Verified Then EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
        intentos += 1

        'BtnIntentos.Text = principal.leng.traduce(Me.Name, BtnIntentos.Name) & (3 - intentos).ToString
        BtnIntentos.Text = "Tiene " & (3 - intentos).ToString & " intentos disponibles"

        If intentos = 3 And Not res.Verified Then
            If Not escomedor Then
                MsgBox("No se pudo comprobar la huella", MsgBoxStyle.Exclamation, "Huella")
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            ' Me.Close()
        End If
        Data.Update()
    End Sub
    Private Sub VerificationForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub

    Private Sub VerificationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        intentos = 0
        'Me.StartPosition = FormStartPosition.CenterScreen
        'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        ' Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2 + 110
        'BtnIntentos.Text = principal.leng.traduce(Me.Name, BtnIntentos.Name) & " 3 "
        BtnIntentos.Text = "Tiene 3 intentos disponibles"

        If Debugger.IsAttached Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub ButtonX3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnCancelar.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIntentos.Click

    End Sub
    Private Sub ButtonX1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnIntentos.GotFocus
        BtnIntentos.Focus()
    End Sub
    Private Sub ButtonX1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnIntentos.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub lblPrompt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Function GenerateHash(ByVal sourcetext As String)
        Dim ue As UnicodeEncoding = New UnicodeEncoding()
        Dim bytesourcetext As Byte() = ue.GetBytes(sourcetext)
        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
        Dim bytehash As Byte() = md5.ComputeHash(bytesourcetext)
        Return Convert.ToBase64String(bytehash)
    End Function


End Class