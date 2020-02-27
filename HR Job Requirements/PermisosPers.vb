Public Class PermisosPers
    Dim midataset As New DataSet
    Dim iniciando As Boolean = True
    Dim nuevo As Boolean = True
    Dim Haycambios As Boolean = False
    Dim id_user As Integer = 0
    Dim cambiosTotal As Boolean = False
    Dim cambiosJerarquicos As Boolean = False
    Dim saltar As Boolean = False
    Private Sub PermisosPers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If My.Settings.Permisos.Select("Permiso = 'MP'").Count > 0 Or My.Settings.Permisos.Select("Permiso = 'MP'").Count > 0 Then
                cambiosTotal = True
            ElseIf My.Settings.Permisos.Select("Permiso= 'MPJ'").Count > 0 Then
                cambiosJerarquicos = True
            End If


            FE()
            Dim personal As DataTable

            personal = SqlQuery.PersonalDetail.copy
            personal.TableName = "Personal"
            If midataset.Tables("Personal") IsNot Nothing Then
                midataset.Tables.Remove("Personal")
            End If
            midataset.Tables.Add(personal)

            cmb_nombre.DataSource = midataset.Tables("Personal")
            cmb_nombre.ValueMember = "CB_CODIGO"
            cmb_nombre.DisplayMember = "PRETTYNAME"
            cmb_nombre.SelectedIndex = -1
            iniciando = False
            TabControl1.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub FE()
        Try
            Dim ta As DataTable
            ta = CType(SqlQuery.Permisos_cAT, DataTable).Copy
            ta.TableName = "Perm"
            If midataset.Tables(ta.TableName) IsNot Nothing Then
                midataset.Tables.Remove(ta.TableName)
            End If
            midataset.Tables.Add(ta)
            If midataset.Tables("Perm").Rows.Count > 0 Then
                For a = 0 To TabControl1.TabPages.Count - 1
                    Console.WriteLine(TabControl1.TabPages(a).Text)
                    Dim d As DataTable

                    Select Case TabControl1.TabPages(a).Text.ToLower
                        Case "caracteristicas"
                            d = midataset.Tables("Perm").Select("Categoria = 'Caracteristicas'").CopyToDataTable

                        Case "pestañas"
                            d = midataset.Tables("Perm").Select("Categoria = 'Pestañas'").CopyToDataTable

                        Case "otros"
                            d = midataset.Tables("Perm").Select("Categoria = 'Otros'").CopyToDataTable

                        Case "evaluación"
                            d = midataset.Tables("Perm").Select("Categoria = 'Evaluaciones'").CopyToDataTable

                    End Select

                    If d IsNot Nothing Then
                        For Each ro As DataRow In d.Rows
                            Dim r As New TreeNode
                            r.Name = ro.ItemArray(2).Trim.ToString
                            r.Tag = ro.ItemArray(1).Trim.ToString
                            r.Text = ro.ItemArray(2).Trim.ToString
                            If Not Permiso.Habilitado("ADMIN") Then
                                If My.Settings.Permisos.Select("Permiso='" & r.Tag & "'").Count = 0 And My.Settings.Id_user <> 1 Then
                                    r.BackColor = Color.LightGray : r.ForeColor = Color.Gray
                                Else
                                End If
                            End If
                            CType(TabControl1.TabPages(a).Controls(0), TreeView).Nodes.Add(r)
                        Next
                    End If
                    AddHandler CType(TabControl1.TabPages(a).Controls(0), TreeView).NodeMouseClick, AddressOf cambios
                Next

                For Each ro As DataRow In midataset.Tables("Perm").Rows
                    Dim no As New TreeNode
                    no.Text = ro.ItemArray(2).ToString
                    no.Name = ro.ItemArray(1).ToString
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Cargar_permisos(ByVal Id_user As Integer)
        Try
            Dim ta As DataTable
            ta = CType(SqlQuery.Permisos(Id_user), DataTable).Copy
            ta.TableName = "Permisos"
            If midataset.Tables(ta.TableName) IsNot Nothing Then
                midataset.Tables.Remove(ta.TableName)
            End If
            midataset.Tables.Add(ta)
            If midataset.Tables(ta.TableName).Rows.Count > 0 Then
                For Each t As TabPage In TabControl1.TabPages
                    For Each node As TreeNode In CType(t.Controls(0), TreeView).Nodes
                        If midataset.Tables(ta.TableName).Select("Permiso = '" & node.Tag & "'").Count > 0 Then
                            saltar = True
                            node.Checked = True
                            saltar = False
                        End If
                    Next
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            If Txt_noempleado.Enabled = False Then
                If Haycambios Then
                    If MsgBox("¿Desea regresar sin guardar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Limpiar()
                    End If
                Else
                    Limpiar()
                End If
            Else
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles Txt_noempleado.KeyUp
        Try
            If Txt_noempleado.Text.Trim = "" Then Exit Sub
            If e.KeyData = Keys.Enter Then
                Txt_noempleado.SelectAll()
                cmb_nombre.SelectedValue = Txt_noempleado.Text
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_noempleado.KeyPress
        Try
            If e.KeyChar.ToString <> vbBack Then

                If Not IsNumeric(e.KeyChar) Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Limpiar()
        Try
            saltar = True
            For Each t As TabPage In TabControl1.TabPages
                For Each node As TreeNode In CType(t.Controls(0), TreeView).Nodes
                    node.Checked = False
                Next

            Next
            saltar = False
            cmb_nombre.SelectedIndex = -1
            Txt_noempleado.Focus()
            id_user = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub cmb_nombre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_nombre.SelectedIndexChanged
        Try

            If iniciando Then Exit Sub
            If cmb_nombre.SelectedIndex = -1 Then
                Txt_noempleado.Enabled = True
                Txt_noempleado.Text = ""
                Txt_dpto.Text = ""
                Txt_pto.Text = ""
                TabControl1.Enabled = False

                TabControl1.TabPages(0).Select()
                Limpiar()
                Exit Sub
            End If
            TabControl1.Enabled = True
            Txt_noempleado.Text = CType(sender, ComboBox).SelectedValue
            Txt_noempleado.Enabled = False
            Dim res = midataset.Tables("Personal").Select("CB_CODIGO =" & Txt_noempleado.Text)
            Txt_dpto.Text = res(0).Item(2).ToString
            Txt_pto.Text = res(0).Item(3).ToString
            If cambiosJerarquicos = False And cambiosTotal = False Then
                MsgBox("No tienes permisos para hacer cambios en este empleado", MsgBoxStyle.Critical)
                cmb_nombre.SelectedIndex = -1
                Exit Sub
            End If
            If cambiosTotal = False And cambiosJerarquicos = True Then

                If My.Settings.EmpleadosHijos IsNot Nothing Then
                    If My.Settings.EmpleadosHijos.Rows.Count > 0 Then
                        Dim puesto = SqlQuery.puesto(cmb_nombre.SelectedValue)
                        If My.Settings.EmpleadosHijos.Select("PU_CODIGO = '" & puesto & "'").Count < 1 Then

                            MsgBox("No tienes permisos para hacer cambios en este empleado", MsgBoxStyle.Critical)
                            cmb_nombre.SelectedIndex = -1
                            Exit Sub
                        End If
                    Else
                        MsgBox("No tienes permisos para hacer cambios en este empleado", MsgBoxStyle.Critical)
                        cmb_nombre.SelectedIndex = -1
                        Exit Sub
                    End If
                Else
                    MsgBox("No tienes permisos para hacer cambios en este empleado", MsgBoxStyle.Critical)
                    cmb_nombre.SelectedIndex = -1
                    Exit Sub
                End If

            End If
            id_user = SqlQuery.UserMpsExists(Txt_noempleado.Text)

            If id_user = 0 Then
                MsgBox("Este usuario no cuenta con cuenta de MPS, es necesaria una cuenta para asignar permisos", MsgBoxStyle.Critical)
                cmb_nombre.SelectedIndex = -1
            ElseIf id_user > 0 Then
                Cargar_permisos(id_user)
            Else
                cmb_nombre.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If cmb_nombre.SelectedIndex = -1 Then
                Me.DialogResult = DialogResult.OK
                Exit Sub
            End If

            Dim lii As New List(Of Integer)
            lii.Add(id_user)
            Dim li As New List(Of SqlQuery.Permisos_stru)
            For Each tab As TabPage In TabControl1.TabPages
                For Each ctl As Control In tab.Controls
                    If TypeOf (ctl) Is TreeView Then
                        For Each node As TreeNode In CType(ctl, TreeView).Nodes
                            Dim ere As SqlQuery.Permisos_stru
                            ere.col = node.Tag
                            ere.val = node.Checked
                            li.Add(ere)
                        Next
                    End If
                Next
            Next
            Dim re = SqlQuery.agregarPermisos(lii, li, nuevo)
            MsgBox("Cambios guardados", MsgBoxStyle.Information)
            Limpiar()
            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cambios()
        Haycambios = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If Txt_noempleado.Enabled = False Then
                If Haycambios Then
                    If MsgBox("¿Desea regresar sin guardar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Me.DialogResult = DialogResult.Cancel
                        Me.Close()
                    End If
                Else
                    Me.DialogResult = DialogResult.Cancel
                    Me.Close()
                End If
            Else
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub TreeView1_BeforeCheck(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeCheck, TreeView2.BeforeCheck, TreeView3.BeforeCheck, TreeView4.BeforeCheck
        If saltar Then Exit Sub
        Console.WriteLine("")
        Me.Text = Me.Text + e.Node.BackColor.ToString
        If e.Node.BackColor = Color.LightGray Then

            e.Cancel = True
            If e.Node.BackColor = Color.LightGray Then
                MsgBox("No esta habilitado para modificar este permiso.", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

End Class