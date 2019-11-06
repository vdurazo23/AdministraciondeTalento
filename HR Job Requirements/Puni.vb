Public Class Puni
    ' Public puesto As Boolean = False
    Dim ta As New DataTable
    Public pues As String = ""
    Public pu_codigo As String = ""
    Public nuevo As Boolean = True
    Public cargar_todos As Boolean = False
    Public cargar_parents As Boolean = False
    Private Sub Puni_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If cargar_parents = True Then
                cargarpuestos(pu_codigo)
            Else

                cargarpuestos()
            End If




            If nuevo = False Then
                TextBox1.Text = pues
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



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try

            ta.DefaultView.RowFilter = "PU_descrip LIKE '%" & TextBox1.Text & "%'"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        If keyData = Keys.Enter Then
            If ListBox1.SelectedItems.Count > 0 Then
                pues = ListBox1.SelectedItems(0).Row.ItemArray(2).ToString
                pu_codigo = ListBox1.SelectedItems(0).Row.ItemArray(1).ToString

                Me.DialogResult = DialogResult.OK
            End If

        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Try

            If ListBox1.SelectedItems.Count > 0 Then
                pues = ListBox1.SelectedItems(0).Row.ItemArray(2).ToString
                pu_codigo = ListBox1.SelectedItems(0).Row.ItemArray(1).ToString

                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If ListBox1.SelectedItems.Count > 0 Then
                pues = ListBox1.SelectedItems(0).Row.ItemArray(2).ToString
                pu_codigo = ListBox1.SelectedItems(0).Row.ItemArray(1).ToString

                Me.DialogResult = DialogResult.OK
            End If
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
End Class