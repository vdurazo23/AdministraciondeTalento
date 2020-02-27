Public Class Configuracion
    Private Sub btnvalidarmps_Click(sender As Object, e As EventArgs) Handles btnvalidarmps.Click
        Dim cn As New SqlClient.SqlConnection("Data Source=" & txtserver.Text.Trim & ";workstation id=;Persist Security Info=True;User ID=" & txtuser.Text & ";password=" & txtpass.Text & ";initial catalog=" & txtbd.Text)
        Try
            cn.Open()
            btnvalidarmps.Image = ImageList1.Images(0)
            btnvalidarmps.Text = "Correcto"
            btnvalidarmps.TextImageRelation = TextImageRelation.TextAboveImage
            ToolTip1.SetToolTip(Me.btnvalidarmps, "")
        Catch ex As Exception
            btnvalidarmps.Image = ImageList1.Images(1)
            btnvalidarmps.Text = "Incorrecto"
            ToolTip1.SetToolTip(Me.btnvalidarmps, ex.Message)
            btnvalidarmps.TextImageRelation = TextImageRelation.TextAboveImage
        Finally
            cn.Dispose()
            cn = Nothing
        End Try

    End Sub

    Private Sub btnvalidartress_Click(sender As Object, e As EventArgs) Handles btnvalidartress.Click
        Dim cn As New SqlClient.SqlConnection("Data Source=" & txtserverTRESS.Text.Trim & ";workstation id=;Persist Security Info=True;User ID=" & txtuserTRESS.Text & ";password=" & txtpassTRESS.Text & ";initial catalog=" & txtdbTRESS.Text)
        Try
            cn.Open()
            btnvalidartress.Image = ImageList1.Images(0)
            btnvalidartress.Text = "Correcto"
            btnvalidartress.TextImageRelation = TextImageRelation.TextAboveImage
            ToolTip1.SetToolTip(Me.btnvalidartress, "")
        Catch ex As Exception
            btnvalidartress.Image = ImageList1.Images(1)
            btnvalidartress.Text = "Incorrecto"
            ToolTip1.SetToolTip(Me.btnvalidartress, ex.Message)
            btnvalidartress.TextImageRelation = TextImageRelation.TextAboveImage
        Finally
            cn.Dispose()
            cn = Nothing
        End Try
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click

        If btnvalidarmps.Text = "Correcto" AndAlso btnvalidartress.Text = "Correcto" Then
            'Configuracion MPS
            My.Settings.MPSServer = txtserver.Text
            My.Settings.MPSUsuario = txtuser.Text
            My.Settings.MPSContraseña = txtpass.Text
            My.Settings.MPSBD = txtbd.Text

            'Configuracion TRESS
            My.Settings.TRESSServer = txtserverTRESS.Text
            My.Settings.TRESSUsuario = txtuserTRESS.Text
            My.Settings.TRESSContraseña = txtpassTRESS.Text
            My.Settings.TressBD = txtdbTRESS.Text
            My.Settings.Save()
            Me.DialogResult = DialogResult.OK
            'Me.Close()
        Else
            MsgBox("No se han validado todas las conexiones necesarias para el sistema, favor de revisar", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Configuracion_Load(sender As Object, tece As EventArgs) Handles Me.Load
        Try
            Console.WriteLine("")
            txtserver.Text = My.Settings.MPSServer
            txtbd.Text = My.Settings.MPSBD
            txtuser.Text = My.Settings.MPSUsuario
            txtpass.Text = My.Settings.MPSContraseña

            txtserverTRESS.Text = My.Settings.TRESSServer
            txtuserTRESS.Text = My.Settings.TRESSUsuario
            txtdbTRESS.Text = My.Settings.TressBD
            txtpassTRESS.Text = My.Settings.TRESSContraseña
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub
    'Private Sub Configuraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    'txtserver.Focus()
    '    ''Conexion MPS
    '    'txtserver.Text = My.Settings.MPSServer
    '    'txtuser.Text = My.Settings.MPSUsuario
    '    'txtpass.Text = Helper.Decrypt(My.Settings.Password)
    '    'txtbd.Text = My.Settings.BD

    '    ''Conexion TRESS
    '    'txtserverTRESS.Text = My.Settings.ServerTress
    '    'txtuserTRESS.Text = My.Settings.UserTress
    '    'txtpassTRESS.Text = Helper.Decrypt(My.Settings.PwdTress)
    '    'txtdbTRESS.Text = My.Settings.BDTress



    '    ''Conexion CMS
    '    'txtsDSNCMS.Text = My.Settings.dsnCMS
    '    'txtUIDCMS.Text = My.Settings.uidCMS
    '    'txtpassCMS.Text = Helper.Decrypt(My.Settings.pwdCMS)
    'End Sub
    'Private Sub btnvalidarmps_Click(sender As Object, e As EventArgs) Handles btnvalidarmps.Click
    '    'Dim cn As New SqlClient.SqlConnection("Data Source=" & txtserver.Text.Trim & ";workstation id=;Persist Security Info=True;User ID=" & txtuser.Text & ";password=" & txtpass.Text & ";initial catalog=" & txtbd.Text)
    '    'Try
    '    '    cn.Open()
    '    '    btnvalidarmps.Image = ImageList1.Images(0)
    '    '    btnvalidarmps.Text = "Correcto"
    '    '    btnvalidarmps.TextImageRelation = TextImageRelation.TextAboveImage
    '    '    ToolTip1.SetToolTip(Me.btnvalidarmps, "")
    '    'Catch ex As Exception
    '    '    btnvalidarmps.Image = ImageList1.Images(1)
    '    '    btnvalidarmps.Text = "Incorrecto"
    '    '    ToolTip1.SetToolTip(Me.btnvalidarmps, ex.Message)
    '    '    btnvalidarmps.TextImageRelation = TextImageRelation.TextAboveImage
    '    'Finally
    '    '    cn.Dispose()
    '    '    cn = Nothing
    '    'End Try

    'End Sub
    'Private Sub btnvalidartress_Click(sender As Object, e As EventArgs) Handles btnvalidartress.Click
    '    'Dim cn As New SqlClient.SqlConnection("Data Source=" & txtserverTRESS.Text.Trim & ";workstation id=;Persist Security Info=True;User ID=" & txtuserTRESS.Text & ";password=" & txtpassTRESS.Text & ";initial catalog=" & txtdbTRESS.Text)
    '    'Try
    '    '    cn.Open()
    '    '    btnvalidartress.Image = ImageList1.Images(0)
    '    '    btnvalidartress.Text = "Correcto"
    '    '    btnvalidartress.TextImageRelation = TextImageRelation.TextAboveImage
    '    '    ToolTip1.SetToolTip(Me.btnvalidartress, "")
    '    'Catch ex As Exception
    '    '    btnvalidartress.Image = ImageList1.Images(1)
    '    '    btnvalidartress.Text = "Incorrecto"
    '    '    ToolTip1.SetToolTip(Me.btnvalidartress, ex.Message)
    '    '    btnvalidartress.TextImageRelation = TextImageRelation.TextAboveImage
    '    'Finally
    '    '    cn.Dispose()
    '    '    cn = Nothing
    '    'End Try
    'End Sub
    'Private Sub btnvalidarcms_Click(sender As Object, e As EventArgs) Handles btnvalidarcms.Click
    '    'Dim cn As New Odbc.OdbcConnection("DSN=" & txtsDSNCMS.Text.Trim & ";UID=" & txtUIDCMS.Text & ";PWD=" & txtpassCMS.Text)
    '    'Try
    '    '    cn.Open()
    '    '    Dim bm As Bitmap = ImageList1.Images(0)
    '    '    btnvalidarcms.Image = bm
    '    '    btnvalidarcms.Text = "Correcto"
    '    '    btnvalidarcms.TextImageRelation = TextImageRelation.TextAboveImage
    '    '    ToolTip1.SetToolTip(Me.btnvalidarcms, "")
    '    'Catch ex As Exception
    '    '    btnvalidarcms.Image = ImageList1.Images(1)
    '    '    btnvalidarcms.Text = "Incorrecto"
    '    '    ToolTip1.SetToolTip(Me.btnvalidarcms, ex.Message)
    '    '    btnvalidarcms.TextImageRelation = TextImageRelation.TextAboveImage
    '    'Finally
    '    '    cn.Dispose()
    '    '    cn = Nothing
    '    'End Try
    'End Sub
    'Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
    '    ''If btnvalidarmps.Text = "Correcto" AndAlso btnvalidartress.Text = "Correcto" AndAlso btnvalidarcms.Text = "Correcto" Then
    '    'If btnvalidarmps.Text = "Correcto" AndAlso btnvalidartress.Text = "Correcto" Then
    '    '    'Configuracion MPS
    '    '    My.Settings.Server = txtserver.Text
    '    '    My.Settings.User = txtuser.Text
    '    '    My.Settings.Password = Helper.Encrypt(txtpass.Text)
    '    '    My.Settings.BD = txtbd.Text

    '    '    'Configuracion TRESS
    '    '    My.Settings.ServerTress = txtserverTRESS.Text
    '    '    My.Settings.UserTress = txtuserTRESS.Text
    '    '    My.Settings.PwdTress = Helper.Encrypt(txtpassTRESS.Text)
    '    '    My.Settings.BDTress = txtdbTRESS.Text

    '    '    'Configuracion CMS
    '    '    My.Settings.dsnCMS = txtsDSNCMS.Text
    '    '    My.Settings.uidCMS = txtUIDCMS.Text
    '    '    My.Settings.pwdCMS = Helper.Encrypt(txtpassCMS.Text)

    '    '    My.Settings.Historial = True

    '    '    My.Settings.Save()
    '    '    Me.DialogResult = DialogResult.OK
    '    '    'Me.Close()
    '    'Else
    '    '    MsgBox("No se han validado todas las conexiones necesarias para el sistema, favor de revisar", MsgBoxStyle.Critical, "Error")
    '    'End If
    'End Sub

    'Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
    '    Me.DialogResult = DialogResult.Cancel
    'End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        If keyData = Keys.F1 Then
            Dim co As New Configuraciones_generales
            co.ShowDialog()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class