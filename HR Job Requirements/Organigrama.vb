Public Class Organigrama
    Dim Midataset As New DataSet
    Dim SelectedPuesto As String = ""
    Dim PuestosNo As New Form1
    Public pu As String
    Public descrip As String
    Dim currentNode As TreeNode
    Private Sub Organigrama_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CrearTreeView()
        pu = PuestosNo.PU
        descrip = PuestosNo.descrip
    End Sub

    Private Sub CrearTreeView()
        Try
            TreeView1.Nodes.Clear()
            Dim r As New TreeNode
            If Midataset.Tables("Puestos") IsNot Nothing Then
                Midataset.Tables.Remove("Puestos")
            End If
            Dim taba As New DataTable
            taba = CType(SqlQuery.puestos_Organigrama, DataTable).Copy
            taba.TableName = "Puestos"
            Midataset.Tables.Add(taba)
            Midataset.Tables("Puestos").DefaultView.RowFilter = "PU_CODIGO = '264'"
            r.Text = Midataset.Tables("Puestos").DefaultView.Item(0).Row.ItemArray(2).ToString
            r.Tag = Midataset.Tables("Puestos").DefaultView.Item(0).Row.ItemArray(1).ToString
            r.ContextMenuStrip = ContextMenuStrip1
            TreeView1.Nodes.Add(r)

            If Midataset.Tables("Puestos").Select("PU_PARENT = '264'").Count > 0 Then
                Dim ra = Midataset.Tables("Puestos").Select("PU_PARENT = '264'")
                CargarNodos(ra, r)
            End If
            TreeView1.TopNode.Expand()
            For Each no As TreeNode In TreeView1.TopNode.Nodes
                no.Expand()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub CargarNodos(ByVal tabla As DataRow(), ByVal node As TreeNode)
        Try
            For a = 0 To tabla.Count - 1
                Dim e As New TreeNode
                e.Text = tabla(a).ItemArray(2).ToString
                e.Tag = tabla(a).ItemArray(1).ToString
                e.ContextMenuStrip = ContextMenuStrip1
                node.Nodes.Add(e)
                If Midataset.Tables("Puestos").Select("PU_PARENT = '" & e.Tag & "'").Count > 0 Then
                    Dim ee = Midataset.Tables("Puestos").Select("PU_PARENT = '" & e.Tag & "'")
                    CargarNodos(ee, e)
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

    Private Sub AgregarDependienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarDependienteToolStripMenuItem.Click

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
            SelectedPuesto = e.Node.Tag
            currentNode = e.Node
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
End Class