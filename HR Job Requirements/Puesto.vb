
Public Class Puesto
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Puesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    'Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint
    'End Sub
    'Private Sub Puesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim tabla As DataTable = SqlQuery.Departamentos
    '    ComboBox1.DataSource = tabla
    '    ComboBox1.ValueMember = "TB_CODIGO"
    '    ComboBox1.DisplayMember = "TB_ELEMENT"
    '    Dim tabla1 As DataTable = SqlQuery.puestos(ComboBox1.SelectedValue)
    '    ComboBox2.DataSource = tabla1
    '    ComboBox2.ValueMember = "CB_NIVEL1"
    '    ComboBox2.DisplayMember = "PU_DESCRIP"
    '    Exit Sub
    '    Dim TABLA2 As DataTable = SqlQuery.Personal(ComboBox1.SelectedValue, ComboBox2.SelectedValue)
    '    ComboBox3.DataSource = TABLA2
    '    ComboBox2.ValueMember = "CB_CODIGO"
    '    ComboBox2.DisplayMember = "Prettyname"
    'End Sub
End Class