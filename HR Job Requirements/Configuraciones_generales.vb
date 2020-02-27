Public Class Configuraciones_generales
    Dim salto As Boolean = False
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ne As New Agregar_periodo
        ne.nuevo = False
        ne.TextBox1.Text = ComboBox1.SelectedItem.Row.ItemArray(1)
        ne.DateTimePicker1.Value = ComboBox1.SelectedItem.Row.ItemArray(2)
        ne.DateTimePicker2.Value = ComboBox1.SelectedItem.Row.ItemArray(3)
        ne.DateTimePicker3.Value = ComboBox1.SelectedItem.Row.ItemArray(4)
        ne.id = ComboBox1.SelectedItem.Row.ItemArray(0)

        If ne.ShowDialog = DialogResult.OK Then
            cargarTodo()
        End If
    End Sub

    Private Sub Configuraciones_generales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarTodo()
    End Sub
    Private Sub cargarTodo()
        Try
            ComboBox1.DataSource = Nothing
            Dim ta As DataTable = SqlQuery.Periodos
            ComboBox1.DataSource = ta
            ComboBox1.ValueMember = "Id"
            ComboBox1.DisplayMember = "Descripcion"

            salto = True
            CheckBox1.Checked = My.Settings.AlarmaIdp
            CheckBox2.Checked = My.Settings.MostrarIdp
            salto = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim NE As New Agregar_periodo
            NE.nuevo = True
            If NE.ShowDialog = DialogResult.OK Then
                cargarTodo()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        Try
            If salto Then Exit Sub
            SqlQuery.Activar_periodo(ComboBox1.SelectedItem.Row.ItemArray(0), CType(sender, CheckBox).Checked)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try

            If ComboBox1.SelectedIndex = -1 Then
                salto = True
                CheckBox3.Checked = False
                salto = False
                Exit Sub
            End If
            Dim re As Boolean
            re = SqlQuery.esactivo_periodo(ComboBox1.SelectedItem.Row.ItemArray(0))
            salto = True
            CheckBox3.Checked = re
            salto = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If salto Then Exit Sub
        My.Settings.AlarmaIdp = CType(sender, CheckBox).Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If salto Then Exit Sub
        My.Settings.MostrarIdp = CType(sender, CheckBox).Checked
    End Sub
End Class