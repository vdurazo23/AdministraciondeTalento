Imports System.IO

Public Class Prueba
    'Dim iniciando As Boolean = True
    'Private Sub Consulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    '    Try

    '        Dim tabla As DataTable = SqlQuery.Departamentos
    '        Cmb_dpto.DataSource = tabla
    '        Cmb_dpto.ValueMember = "TB_CODIGO"
    '        Cmb_dpto.DisplayMember = "TB_ELEMENT"
    '        Cmb_dpto.SelectedIndex = -1
    '        iniciando = False
    '        If Cmb_dpto.Items.Count > 0 Then Cmb_dpto.SelectedIndex = 0
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    'Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_dpto.SelectedIndexChanged
    '    Try
    '        If iniciando Then Exit Sub
    '        iniciando = True
    '        Cmb_pto.DataSource = Nothing
    '        Dim tabla1 As DataTable = SqlQuery.puestos(Cmb_dpto.SelectedValue)
    '        Cmb_pto.DataSource = tabla1
    '        Cmb_pto.ValueMember = "CB_PUESTO"
    '        Cmb_pto.DisplayMember = "PU_DESCRIP"
    '        Cmb_pto.SelectedIndex = -1
    '        iniciando = False
    '        If Cmb_pto.SelectedIndex = -1 Then Cmb_pto.SelectedIndex = 0
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try

    'End Sub

    'Private Sub Reset()

    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Try
    '        If No_empleado.Enabled = False Then
    '            No_empleado.Enabled = True
    '            Exit Sub
    '        Else
    '            If Not IsNumeric(No_empleado.Text) Then
    '                MsgBox("Digíte un número de empleado correcto", MsgBoxStyle.Critical)
    '                No_empleado.Text = ""
    '                Exit Sub
    '            Else
    '                Buscar_empleado()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    'Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_pto.SelectedIndexChanged
    '    Try
    '        If Cmb_pto.SelectedIndex = -1 Then Exit Sub
    '        If iniciando Then Exit Sub
    '        iniciando = True
    '        Cmb_nom.DataSource = Nothing
    '        Dim tablanom As DataTable = SqlQuery.Personal(Cmb_dpto.SelectedValue, Cmb_pto.SelectedValue.ToString.Trim)
    '        Cmb_nom.DataSource = tablanom
    '        Cmb_nom.ValueMember = "CB_CODIGO"
    '        Cmb_nom.DisplayMember = "Prettyname"
    '        Cmb_nom.SelectedIndex = -1
    '        iniciando = False

    '        If Cmb_nom.Items.Count > 0 Then Cmb_nom.SelectedIndex = 0
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try

    'End Sub

    'Private Sub Cmb_nom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_nom.SelectedIndexChanged
    '    Try
    '        If Cmb_nom.SelectedIndex = -1 Then Exit Sub
    '        If iniciando = True Then Exit Sub
    '        Console.WriteLine("")
    '        No_empleado.Text = CType(sender, ComboBox).SelectedItem.Row.ItemArray(0).ToString
    '        txt_antiguedad.Text = CType(sender, ComboBox).SelectedItem.Row.ItemArray(17)
    '        txt_antiguedad_AÑOS.Text = Math.Truncate(DateDiff(DateInterval.Month, CType(sender, ComboBox).SelectedItem.ROW.ITEMARRAY(17), Today) / 12) & " Años y " & DateDiff(DateInterval.Month, CType(sender, ComboBox).SelectedItem.ROW.ITEMARRAY(17), Today) - (Math.Truncate(DateDiff(DateInterval.Month, CType(sender, ComboBox).SelectedItem.ROW.ITEMARRAY(17), Today) / 12) * 12) & " Meses"
    '        Dim tablaimagen As DataTable = SqlQuery.Imagen(CType(sender, ComboBox).SelectedItem.Row.ItemArray(0))
    '        If tablaimagen.Rows.Count > 0 Then
    '            Dim myByteArray() As Byte = tablaimagen.Rows(0).Item(0)
    '            Dim stream As New MemoryStream(myByteArray)
    '            PictureBox1.Image = Image.FromStream(stream)
    '        End If

    '        cargar_categorias()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub


    'Private Sub cargar_categorias()
    '    Try


    '        'Panel1.Controls.Clear()
    '        'For a = 0 To 100
    '        '    Dim we As New Caracteristica
    '        '    we.Dock = DockStyle.Top
    '        '    we.Label1.Text = "Caracteristica: " & a
    '        '    we.Label2.Text = "Corporativo"
    '        '    we.Label3.Text = a & "%"
    '        '    'we.ProgressBar1.Value = a
    '        '    Panel1.Controls.Add(we)
    '        'Next
    '        'Exit Sub
    '        TableLayoutPanel1.Controls.Clear()
    '        For a = 0 To 30
    '            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
    '            Dim we As New Caracteristica
    '            we.Dock = DockStyle.Top
    '            we.Label1.Text = "Caracteristica: " & a
    '            we.Label2.Text = "Corporativo"
    '            we.Label3.Text = a & "%"
    '            'we.ProgressBar1.Value = a
    '            TableLayoutPanel1.Controls.Add(we)
    '        Next

    '        Chart1.Series(0).Points.Clear()
    '        Chart1.Series(0).LegendText = "Porcentaje"

    '        Chart1.Series(0).Points.Add(92)
    '        Chart1.Series(0).Points.Add(8)
    '        Exit Sub
    '        'For a = 0 To 50
    '        '    Dim we As New Caracteristica
    '        '    we.Dock = DockStyle.Top
    '        '    we.Label1.Text = "Caracteristica: " & a
    '        '    we.Label2.Text = "Corporativo"
    '        '    we.Label3.Text = a & "%"
    '        '    'we.ProgressBar1.Value = a
    '        '    Panel1.Controls.Add(we)
    '        'Next


    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    'Private Sub No_empleado_KeyUp(sender As Object, e As KeyEventArgs) Handles No_empleado.KeyUp
    '    Try
    '        If e.KeyCode = Keys.Enter Then
    '            Buscar_empleado()
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    'Private Sub Buscar_empleado()
    '    Try
    '        Dim datos As DataTable = SqlQuery.PorCodigo(No_empleado.Text)
    '        If datos.Rows.Count > 0 Then

    '            Cmb_dpto.SelectedValue = datos.Rows(0).Item("cb_Nivel1")
    '            Cmb_pto.SelectedValue = datos.Rows(0).Item("cb_puesto")
    '            Cmb_nom.SelectedValue = No_empleado.Text
    '            No_empleado.Enabled = False
    '        Else
    '            MsgBox("Empleado no encontrado", MsgBoxStyle.Information)
    '            No_empleado.Text = ""

    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub
End Class