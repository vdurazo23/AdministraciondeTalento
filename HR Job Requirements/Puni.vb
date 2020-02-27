Public Class Puni
    ' Public puesto As Boolean = False
    Dim ta As New DataTable
    Public pues As String = ""
    Public pu_codigo As String = ""
    Public nuevo As Boolean = True
    Public cargar_todos As Boolean = False
    Public cargar_parents As Boolean = False
    Public cargar_empleados As Boolean = False
    Public seleccionados As New List(Of SqlQuery.Puesto_descripcion)
    Public seleccionados_codigos As New List(Of SqlQuery.empleados)
    Dim rf As String = " 1=1 "
    Dim rf1 As String

    Public personalizada As Boolean = False

    Private Sub Puni_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Size = Me.MinimumSize
           
            rf1 = " 1=1 AND "
            rf = " 1=1 "

            If cargar_parents = True Then
                Button4.Visible = False
                cargarpuestos(pu_codigo)
                If pues IsNot Nothing Then
                    If pues.ToString <> "" Then
                        TextBox1.Text = pues
                    End If
                End If

            ElseIf cargar_empleados = True Then
                cargarempleados()
                If seleccionados_codigos IsNot Nothing Then
                    If seleccionados_codigos.Count > 0 Then
                        If seleccionados_codigos.Count = 1 Then
                            personalizada = False
                            TextBox1.Text = seleccionados_codigos(0).Name
                        Else
                            Button4.PerformClick()
                            For Each s As SqlQuery.empleados In seleccionados_codigos
                                Dim li As New ListViewItem
                                li.Text = s.Name
                                li.Tag = s.cb_codigo
                                ListView1.Items.Add(li)
                            Next
                            crear_rowfilter()
                        End If

                    End If

                End If
            Else
                cargarpuestos()
                'If Debugger.IsAttached Then
                '    rf1 = "(PU_descrip LIKE '%CAPA%' OR PU_descrip LIKE '%PROYECTO y proceso%' OR PU_descrip LIKE '%INGENiERIA%') AND "
                '    ta.DefaultView.RowFilter = rf1 + rf
                '    Button4.PerformClick()
                'End If
                If seleccionados IsNot Nothing Then
                    If seleccionados.Count > 0 Then
                        If seleccionados.Count = 1 Then
                            personalizada = False
                            TextBox1.Text = seleccionados(0).pu_descripcion
                        Else

                            Button4.PerformClick()
                            For Each s As SqlQuery.Puesto_descripcion In seleccionados
                                Dim li As New ListViewItem
                                li.Text = s.pu_descripcion
                                li.Tag = s.pu_codigo
                                ListView1.Items.Add(li)
                            Next
                            crear_rowfilter()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub cargarpuestos(ByVal Optional cb_codigo As String = "")
        Try
            If cargar_todos Then
                ta = CType(SqlQuery.puestos_Organigrama, DataTable).Copy
                ta.TableName = "Puestos"
                ListBox1.DataSource = ta
                ListBox1.DisplayMember = "PU_DESCRIP"
                ListBox1.ValueMember = "Pu_CODIGO"
            ElseIf cargar_parents Then
                ta = CType(SqlQuery.puestos_Organigrama_parents(pu_codigo), DataTable).Copy
                ta.TableName = "Puestos"
                ListBox1.DataSource = ta
                ListBox1.DisplayMember = "PU_DESCRIP"
                ListBox1.ValueMember = "PU_CODIGO"
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub cargarempleados()
        Try
            ta = CType(SqlQuery.Personal, DataTable).Copy
            ta.TableName = "Empleados"
            ListBox1.DataSource = ta
            ListBox1.DisplayMember = "Prettyname"
            ListBox1.ValueMember = "CB_CODIGO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If cargar_empleados = True Then
                If TextBox1.Text <> "" Then
                    rf1 = " Prettyname LIKE '%" & TextBox1.Text & "%' and "
                Else
                    rf1 = " 1=1 and "
                End If
            Else
                If TextBox1.Text <> "" Then
                    rf1 = " PU_descrip LIKE '%" & TextBox1.Text & "%' and "
                Else
                    rf1 = " 1=1 and "
                End If
            End If


            If rf = "" Then rf = "1=1"
                ta.DefaultView.RowFilter = rf1 + rf
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        If keyData = Keys.Enter Then
            seleccionados.Clear()
            seleccionados_codigos.Clear()
            If personalizada Then
                If cargar_empleados Then
                    If ListView1.Items.Count > 0 Then
                        For Each ite As ListViewItem In ListView1.Items
                            Dim we As New SqlQuery.empleados
                            we.cb_codigo = ite.Tag
                            we.Name = ite.Text.ToString
                            seleccionados_codigos.Add(we)
                        Next
                    End If
                Else
                    If ListView1.Items.Count > 0 Then
                        For Each ite As ListViewItem In ListView1.Items
                            Dim we As New SqlQuery.Puesto_descripcion
                            we.pu_codigo = ite.Tag
                            we.pu_descripcion = ite.Text.ToString
                            seleccionados.Add(we)
                        Next
                    End If
                End If
            Else
                If cargar_empleados Then
                    If ListBox1.SelectedItems.Count > 0 Then
                        Dim we As New SqlQuery.empleados
                        we.cb_codigo = ListBox1.SelectedItems(0).Row.ItemArray(0).ToString
                        we.Name = ListBox1.SelectedItems(0).Row.ItemArray(7).ToString
                        seleccionados_codigos.Add(we)
                        Me.DialogResult = DialogResult.OK
                    End If
                Else
                    If ListBox1.SelectedItems.Count > 0 Then
                        Dim we As New SqlQuery.Puesto_descripcion
                        we.pu_descripcion = ListBox1.SelectedItems(0).Row.ItemArray(2).ToString
                        we.pu_codigo = ListBox1.SelectedItems(0).Row.ItemArray(1).ToString
                        seleccionados.Add(we)
                        Me.DialogResult = DialogResult.OK
                    End If

                End If

            End If


        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick

        Try
            If personalizada = True Then
                Dim li As New ListViewItem
                If cargar_empleados Then
                    li.Text = ListBox1.SelectedItems(0).Row.ItemArray(7).ToString
                    li.Tag = ListBox1.SelectedItems(0).Row.ItemArray(0).ToString
                Else
                    li.Text = ListBox1.SelectedItems(0).Row.ItemArray(2).ToString
                    li.Tag = ListBox1.SelectedItems(0).Row.ItemArray(1).ToString
                End If
               
                ListView1.Items.Add(li)
                crear_rowfilter()
                Exit Sub
            Else
                If seleccionados IsNot Nothing Then seleccionados.Clear()
                If seleccionados_codigos IsNot Nothing Then seleccionados_codigos.Clear()
                If cargar_empleados Then
                    Dim we As New SqlQuery.empleados
                    we.Name = ListBox1.SelectedItems(0).Row.ItemArray(7).ToString
                    we.cb_codigo = ListBox1.SelectedItems(0).Row.ItemArray(0).ToString
                    seleccionados_codigos.Add(we)

                Else
                    Dim we As New SqlQuery.Puesto_descripcion
                    we.pu_codigo = ListBox1.SelectedItems(0).Row.ItemArray(1).ToString
                    we.pu_descripcion = ListBox1.SelectedItems(0).Row.ItemArray(2).ToString
                    seleccionados.Add(we)
                End If

                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If seleccionados IsNot Nothing Then seleccionados.Clear()
            If seleccionados_codigos IsNot Nothing Then seleccionados_codigos.Clear()
            If personalizada Then
                If cargar_empleados Then
                    If ListView1.Items.Count > 0 Then
                        For Each ite As ListViewItem In ListView1.Items
                            Dim we As New SqlQuery.empleados
                            we.cb_codigo = ite.Tag
                            we.Name = ite.Text.ToString
                            seleccionados_codigos.Add(we)
                        Next
                    End If
                Else
                    If ListView1.Items.Count > 0 Then
                        For Each ite As ListViewItem In ListView1.Items
                            Dim we As New SqlQuery.Puesto_descripcion
                            we.pu_codigo = ite.Tag
                            we.pu_descripcion = ite.Text.ToString
                            seleccionados.Add(we)
                        Next
                    End If
                End If

            Else
                If cargar_empleados Then
                    Dim we As New SqlQuery.empleados
                    we.cb_codigo = ListBox1.SelectedItems(0).Row.ItemArray(0).ToString
                    we.Name = ListBox1.SelectedItems(0).Row.ItemArray(7).ToString
                    seleccionados_codigos.Add(we)
                Else
                    Dim we As New SqlQuery.Puesto_descripcion
                    we.pu_codigo = ListBox1.SelectedItems(0).Row.ItemArray(1).ToString
                    we.pu_descripcion = ListBox1.SelectedItems(0).Row.ItemArray(2).ToString
                    seleccionados.Add(we)
                End If

            End If

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            pues = "Todos"
            pu_codigo = "Todos"
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception

        End Try
    End Sub

    Public Sub crear_rowfilter()
        Try
            rf = ""
            If cargar_empleados Then
                If ListView1.Items.Count > 0 Then
                    rf = rf + " prettyname not in ('0000000000'"

                    For Each i As ListViewItem In ListView1.Items
                        rf = rf + ", '" & i.Text & "'"

                    Next
                    rf = rf + ")"
                    If rf = "" Then rf = "1=1"
                    ta.DefaultView.RowFilter = rf1 + rf
                End If

            Else
                If ListView1.Items.Count > 0 Then
                    rf = rf + " pu_descrip not in ('0000000000'"

                    For Each i As ListViewItem In ListView1.Items
                        rf = rf + ", '" & i.Text & "'"

                    Next
                    rf = rf + ")"
                    If rf = "" Then rf = "1=1"
                    ta.DefaultView.RowFilter = rf1 + rf
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Size = New Size(900, 500)
        personalizada = True
        Button4.Enabled = False
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Console.WriteLine("")
        ListView1.SelectedItems(0).Remove()
        crear_rowfilter()
    End Sub
End Class