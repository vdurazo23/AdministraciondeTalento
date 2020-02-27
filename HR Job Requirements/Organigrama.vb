Public Class Organigrama
    Dim Midataset As New DataSet
    Dim SelectedPuesto As String = ""
    Dim PuestosNo As New Form1
    Public pu As String
    Public descrip As String
    Dim currentNode As TreeNode
    Dim cambsup As CambioSupervisor
    Dim mostrar_niveles As Boolean
    Private Sub Organigrama_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CrearTreeView()
        mostrar_niveles = False
        pu = PuestosNo.PU
        descrip = PuestosNo.descrip
        Label1.Text = ""
        TabControl1.ItemSize = New Size(0, 1)
        TabControl1.SizeMode = TabSizeMode.Fixed

    End Sub

    Private Sub cargar_activos_inactivos_relacion()
        Try
            Dim relaciones As DataTable = SqlQuery.Puestos_sin_relacionar(False)
            DataGridView1.DataSource = relaciones
            Dim relaciones_inactivas As DataTable = SqlQuery.Puestos_sin_relacionar(True)
            DataGridView2.DataSource = relaciones_inactivas

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CrearTreeView(ByVal Optional PorNiveles As Boolean = False)
        Try
            TreeView1.Nodes.Clear()
            Dim r As New TreeNode
            If Midataset.Tables("Puestos") IsNot Nothing Then
                Midataset.Tables.Remove("Puestos")
            End If
            Dim taba As New DataTable
            taba = CType(SqlQuery.puestos_Organigrama(True), DataTable).Copy
            taba.TableName = "Puestos"
            Midataset.Tables.Add(taba)
            Midataset.Tables("Puestos").DefaultView.RowFilter = "PU_CODIGO = '264'"
            r.Text = Midataset.Tables("Puestos").DefaultView.Item(0).Row.ItemArray(2).ToString
            r.Tag = Midataset.Tables("Puestos").DefaultView.Item(0).Row.ItemArray(1).ToString
            r.ContextMenuStrip = ContextMenuStrip1
            If PorNiveles Then
                Select Case Midataset.Tables("Puestos").DefaultView.Item(0).Row.ItemArray(4).ToString
                    Case "1" : r.BackColor = Color.PowderBlue
                    Case "2" : r.BackColor = Color.LemonChiffon
                    Case "3" : r.BackColor = Color.Honeydew
                    Case "4" : r.BackColor = Color.MistyRose
                    Case "5" : r.BackColor = Color.LightSteelBlue
                    Case Else
                End Select
            Else
                If Midataset.Tables("Puestos").DefaultView.Item(0).Row.ItemArray(5) <> "S" Then
                    r.BackColor = Color.Red
                End If
            End If
            TreeView1.Nodes.Add(r)

            If Midataset.Tables("Puestos").Select("PU_PARENT = '264'").Count > 0 Then
                Dim ra = Midataset.Tables("Puestos").Select("PU_PARENT = '264'")
                CargarNodos(ra, r, PorNiveles)
            End If
            TreeView1.TopNode.Expand()
            For Each no As TreeNode In TreeView1.TopNode.Nodes
                no.Expand()
            Next
            cargar_activos_inactivos_relacion()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub CargarNodos(ByVal tabla As DataRow(), ByVal node As TreeNode, ByVal Por_nivel As Boolean)
        Try
            For a = 0 To tabla.Count - 1
                Dim e As New TreeNode
                If Por_nivel Then
                    Select Case tabla(a).ItemArray(4).ToString
                        Case "1" : e.BackColor = Color.PowderBlue
                        Case "2" : e.BackColor = Color.LemonChiffon
                        Case "3" : e.BackColor = Color.Honeydew
                        Case "4" : e.BackColor = Color.MistyRose
                        Case "5" : e.BackColor = Color.LightSteelBlue
                        Case Else

                    End Select
                Else
                    If tabla(a).ItemArray(5) <> "S" Then
                        e.BackColor = Color.Red
                    End If
                End If
                e.Text = tabla(a).ItemArray(2).ToString
                e.Tag = tabla(a).ItemArray(1).ToString
                e.ContextMenuStrip = ContextMenuStrip1
                node.Nodes.Add(e)
                If Midataset.Tables("Puestos").Select("PU_PARENT = '" & e.Tag & "'").Count > 0 Then
                    Dim ee = Midataset.Tables("Puestos").Select("PU_PARENT = '" & e.Tag & "'")
                    CargarNodos(ee, e, Por_nivel)
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub AgregarSuperiorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarSuperiorToolStripMenuItem.Click

        Try
            TreeView1.FullRowSelect = True
            If PuestosNo.ShowDialog = DialogResult.OK Then
                pu = PuestosNo.PU
                descrip = PuestosNo.descrip
                Dim res = SqlQuery.Puestos_AgregarSuperior(pu, SelectedPuesto)
                If res = 1 Then
                    CrearTreeView()
                    TreeView1.SelectedNode = currentNode
                End If
            Else
                pu = ""
                descrip = ""
            End If
            Console.WriteLine("")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Agregar Superior")
        End Try
    End Sub

    Private Sub AgregarDependienteToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Try
            If PuestosNo.ShowDialog = DialogResult.OK Then
                pu = PuestosNo.PU
                descrip = PuestosNo.descrip
                Dim res = SqlQuery.Puestos_AgregarDependiente(SelectedPuesto, pu)
                If res = 1 Then
                    Dim r As New TreeNode
                    r.Text = descrip
                    r.Tag = pu
                    currentNode.Nodes.Add(r)
                End If
            Else
                pu = ""
                descrip = ""
            End If
            Console.WriteLine("")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Agregar Dependiente")
        End Try
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Try
            If cambsup.pu_codigo IsNot Nothing Then
                Console.WriteLine("")
                cambsup.pu_parent = e.Node.Tag
                SelectedPuesto = e.Node.Tag
                currentNode = e.Node
                cambiar_supervisor()
            Else
                SelectedPuesto = e.Node.Tag
                currentNode = e.Node
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Al seleccionar nodo de organigrama")
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            SeleccionToolStripMenuItem.Visible = True
            TreeView1.CheckBoxes = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub seleccionar_dependientes(ByVal Nodo As TreeNode)

        Try
            Nodo.Expand()
            Nodo.Checked = True
            If Nodo.Nodes.Count > 0 Then
                For Each no As TreeNode In Nodo.Nodes
                    seleccionar_dependientes(no)
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub SeleccionarDependientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarDependientesToolStripMenuItem.Click
        Try
            seleccionar_dependientes(currentNode)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        Try


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            If cambsup.pu_codigo Is Nothing Then
                currentNode.Collapse()
                cambsup.pu_codigo = SelectedPuesto
                Label1.Text = "Da click en el nuevo supervisor"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub SencilloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SencilloToolStripMenuItem.Click
        Try
            If PuestosNo.ShowDialog = DialogResult.OK Then
                pu = PuestosNo.PU
                descrip = PuestosNo.descrip
                Dim activo = PuestosNo.activo
                Dim res = SqlQuery.Puestos_AgregarDependiente(SelectedPuesto, pu)
                If res = 1 Then
                    Dim r As New TreeNode
                    r.Text = descrip
                    r.Tag = pu
                    r.ContextMenuStrip = ContextMenuStrip1
                    If activo = False Then
                        r.BackColor = Color.Red
                    End If
                    currentNode.Nodes.Add(r)
                End If
                cargar_activos_inactivos_relacion()
            Else
                pu = ""
                descrip = ""
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ComoSupervisorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComoSupervisorToolStripMenuItem.Click
        Try
            Console.WriteLine("")
            If PuestosNo.ShowDialog = DialogResult.OK Then
                pu = PuestosNo.PU
                descrip = PuestosNo.descrip
                Dim activo = PuestosNo.activo

                Dim puestos As New List(Of SeleccionPuestosMultiples.puestos)
                For Each no As TreeNode In currentNode.Nodes
                    Dim r As SeleccionPuestosMultiples.puestos
                    r.pu_codigo = no.Tag
                    r.pu_descripcion = no.Text
                    puestos.Add(r)
                Next
                Console.WriteLine("")
                Dim selmul As New SeleccionPuestosMultiples
                selmul.Puestos_posibles = puestos
                If selmul.ShowDialog = DialogResult.OK Then
                    Console.WriteLine("")
                    Dim puest As List(Of String)
                    puest = selmul.li
                    If SqlQuery.Puestos_AgregarDependiente_Supervisor(SelectedPuesto, pu, puest) > 0 Then
                        CrearTreeView()
                        TreeView1.SelectedNode = currentNode
                    End If
                End If

            Else
                pu = ""
                descrip = ""
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            TreeView1.ExpandAll()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            TreeView1.CollapseAll()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            TreeView1.CollapseAll()
            TreeView1.TopNode.Expand()
            For Each no As TreeNode In TreeView1.TopNode.Nodes
                no.Expand()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cambiar_supervisor()
        Try
            If cambsup.pu_codigo = cambsup.pu_parent Then
                MsgBox("Relacion incorrecta, no se pudo efetuar el cambio.", MsgBoxStyle.Critical)
            Else
                If MsgBox("¿Seguro que desea cambiar el puesto padre del puesto seleccionado?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    SqlQuery.CambioSuperior(cambsup.pu_codigo, cambsup.pu_parent)
                    CrearTreeView()
                    TreeView1.SelectedNode = currentNode
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            cambsup.pu_codigo = Nothing
            cambsup.pu_parent = Nothing
            Label1.Text = ""
        End Try
    End Sub

    Private Structure CambioSupervisor
        Dim pu_codigo As String
        Dim pu_parent As String
    End Structure

    Private Sub EliminarRelaciónDelPuestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarRelaciónDelPuestoToolStripMenuItem.Click
        Try
            If MsgBox("¿Seguro que desea eliminar la relación del puesto?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If SqlQuery.Eliminar_relacion(SelectedPuesto) > 0 Then
                    CrearTreeView()
                    TreeView1.SelectedNode = currentNode
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub EliminarTodoLaRamaDeRelaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarTodoLaRamaDeRelaciónToolStripMenuItem.Click
        Try
            If MsgBox("¿Seguro que desea eliminar la relación del puesto?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim puestos As New List(Of String)
                puestos.Add(SelectedPuesto)
                For Each str As String In seleccionar_puestos_hijos(currentNode)
                    puestos.Add(str)
                Next
                If SqlQuery.Eliminar_relacion_completa(puestos) > 0 Then
                    CrearTreeView()
                    TreeView1.SelectedNode = currentNode
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function seleccionar_puestos_hijos(ByVal Node As TreeNode) As List(Of String)
        Try
            Dim lista As New List(Of String)
            For Each no As TreeNode In Node.Nodes
                lista.Add(no.Tag)
                For Each str As String In seleccionar_puestos_hijos(no)
                    lista.Add(str)
                Next
            Next
            Return lista
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            CrearTreeView()
            mostrar_niveles = False
            Label1.Text = ""
            cambsup.pu_codigo = Nothing
            cambsup.pu_parent = Nothing
            TabControl1.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            CrearTreeView(True)
            Label1.Text = ""
            mostrar_niveles = True
            cambsup.pu_codigo = Nothing
            cambsup.pu_parent = Nothing
            TabControl1.SelectedIndex = 1

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub TodosLosEmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TodosLosEmpleadosToolStripMenuItem.Click, LíderDeProyectoSupervisorToolStripMenuItem.Click, EjecutivoToolStripMenuItem.Click,
            GerenteToolStripMenuItem.Click, SupervisorGerenteToolStripMenuItem.Click
        Try
            SqlQuery.Cambiar_nivel(SelectedPuesto, sender.tag)
            Select Case sender.tag
                Case "1" : currentNode.BackColor = Color.PowderBlue
                Case "2" : currentNode.BackColor = Color.LemonChiffon
                Case "3" : currentNode.BackColor = Color.Honeydew
                Case "4" : currentNode.BackColor = Color.MistyRose
                Case "5" : currentNode.BackColor = Color.LightSteelBlue

            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class