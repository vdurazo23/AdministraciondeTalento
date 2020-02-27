Public Class SeleccionPuestosMultiples
    Public Puestos_posibles As List(Of puestos)
    Public li As New List(Of String)
    Private Sub SeleccionPuestosMultiples_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each pu As puestos In Puestos_posibles
            Dim no As New TreeNode
            no.Tag = pu.pu_codigo
            no.Text = pu.pu_descripcion
            TreeView1.Nodes.Add(no)
        Next
        TreeView1.CheckBoxes = True

    End Sub
    Public Structure puestos
        Dim pu_codigo As String
        Dim pu_descripcion As String
    End Structure

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Console.WriteLine("")
        For Each no As TreeNode In TreeView1.Nodes
            If no.Checked = True Then
                li.Add(no.Tag)
            End If
        Next
        If li.Count > 0 Then
            Me.DialogResult = DialogResult.OK
        Else
            MsgBox("No se ha seleccionado ningun puesto", MsgBoxStyle.Information)
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class