
Imports System.Data.SqlClient
Imports System.IO
Imports gdiplus
Imports System.Drawing.Drawing2D

Public Class Consulta
    Dim midataset As New DataSet
    Dim iniciando As Boolean = True
    Dim d As Graphics
    Dim habili_y As Integer
    Dim conocimi_y As Integer
    Private Sub Consulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim tabla As DataTable = SqlQuery.Departamentos
            Cmb_dpto.DataSource = tabla
            Cmb_dpto.ValueMember = "TB_CODIGO"
            Cmb_dpto.DisplayMember = "TB_ELEMENT"


            Dim puestos As DataTable
            puestos = SqlQuery.puestos.copy
            puestos.TableName = "Puesto"
            If midataset.Tables("Puesto") IsNot Nothing Then
                midataset.Tables.Remove("Puesto")
            End If
            midataset.Tables.Add(puestos)
            Cmb_pto.DataSource = midataset.Tables("Puesto")
            Cmb_pto.ValueMember = "CB_PUESTO"
            Cmb_pto.DisplayMember = "PU_DESCRIP"
            puestos.DefaultView.RowFilter = "CB_NIVEL1=" & Cmb_dpto.SelectedValue


            Dim personal As DataTable

            personal = SqlQuery.Personal.copy
            If midataset.Tables("Personal") IsNot Nothing Then
                midataset.Tables.Remove("Personal")
            End If
            personal.TableName = "Personal"
            midataset.Tables.Add(personal)
            Cmb_nom.DataSource = midataset.Tables("Personal")
            Cmb_nom.ValueMember = "CB_CODIGO"
            Cmb_nom.DisplayMember = "Prettyname"


            iniciando = False
            Cmb_dpto.SelectedIndex = -1




        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Reset()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If No_empleado.Enabled = False Then
                No_empleado.Enabled = True
              
                No_empleado.Focus()
                Exit Sub
            Else
                If Not IsNumeric(No_empleado.Text) Then
                    MsgBox("Digíte un número de empleado correcto", MsgBoxStyle.Critical)
                    No_empleado.Text = ""
                    No_empleado.Focus()
                    Exit Sub
                Else
                    Buscar_empleado()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cargar_categorias(ByVal cb_codigo As Integer)
        Try

            Caracteristica1.Label1.Font = New Font("Microsoft Sans Serif", "15.75")
            TableLayoutPanel1.Controls.Clear()
            TableLayoutPanel1.RowStyles.Clear()

            If Cmb_nom.Items.Count = 0 Then
                TLP_Requerimientos.Visible = False
                Exit Sub
            End If
            If cb_codigo = 0 Then Exit Sub
            'TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            'Dim titulo As New Label
            'titulo.AutoSize = True
            'titulo.BackColor = Color.DarkBlue
            'titulo.ForeColor = Color.White
            'titulo.Padding = New Padding(15, 20, 0, 20)
            'titulo.Dock = DockStyle.Fill
            'titulo.Text = "Caracteristicas"
            'titulo.Font = New Font("Microsoft Sans Serif", "15.75")
            'TableLayoutPanel1.Controls.Add(titulo)
            If midataset.Tables("Caracteristicas") IsNot Nothing Then
                midataset.Tables.Remove("Caracteristicas")
            End If
            Dim tabla As DataTable
            tabla = CType(SqlQuery.Cargar_carac_porpuesto(cb_codigo), DataTable).Copy
            tabla.TableName = "Caracteristicas"

            midataset.Tables.Add(tabla)
            Dim a = midataset.Tables("Caracteristicas").Select("Competencia = 1")
            For l = 0 To a.Length - 1
                TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                Dim we As New Caracteristica
                we.cb_codigo = cb_codigo
                we.Dock = DockStyle.Top
                we.Label1.Text = a(l).ItemArray(3).ToString
                we.Label2.Text = "Corporativo"
                we.Label3.Text = a(l).ItemArray(7).ToString & "%"
                If a(l).ItemArray(8).ToString = "" Then we.Label4.Text = 0 Else we.Label4.Text = a(l).ItemArray(8)
                we.btn_adjunto.Tag = a(l).ItemArray(2)
                we.Tag = a(l).ItemArray(9)
                AddHandler we.btn_adjunto.Click, AddressOf Agregar_Adjunto
                TableLayoutPanel1.Controls.Add(we)
            Next
            habili_y = TableLayoutPanel1.Size.Height
            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            Dim titulo2 As New Label
            titulo2.AutoSize = True
            titulo2.BackColor = Color.LightGray
            titulo2.Dock = DockStyle.Top
            titulo2.Padding = New Padding(15, 15, 0, 15)
            titulo2.ForeColor = Color.White
            titulo2.Text = "Habilidad"
            titulo2.Font = New Font("Microsoft Sans Serif", "15")
            TableLayoutPanel1.Controls.Add(titulo2)
            Dim aa = midataset.Tables("Caracteristicas").Select("Habilidad = 1")
            For l = 0 To aa.Length - 1
                TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                Dim we As New Caracteristica
                we.cb_codigo = cb_codigo
                we.Dock = DockStyle.Top
                we.Label1.Text = aa(l).ItemArray(3).ToString
                we.Label2.Text = "Corporativo"
                we.Label3.Text = aa(l).ItemArray(7).ToString & "%"
                If aa(l).ItemArray(8).ToString = "" Then we.Label4.Text = 0 Else we.Label4.Text = aa(l).ItemArray(8)
                we.btn_adjunto.Tag = aa(l).ItemArray(2)
                we.Tag = aa(l).ItemArray(9)
                AddHandler we.btn_adjunto.Click, AddressOf Agregar_Adjunto
                TableLayoutPanel1.Controls.Add(we)
            Next

            conocimi_y = TableLayoutPanel1.Size.Height
            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            Dim titulo3 As New Label
            titulo3.Padding = New Padding(15, 15, 0, 15)
            titulo3.AutoSize = True
            titulo3.BackColor = Color.LightGray
            titulo3.ForeColor = Color.White
            titulo3.Dock = DockStyle.Top
            titulo3.Text = "Conocimiento"
            titulo3.Font = New Font("Microsoft Sans Serif", "15")
            TableLayoutPanel1.Controls.Add(titulo3)
            Dim aaa = midataset.Tables("Caracteristicas").Select("Conocimiento = 1")
            For l = 0 To aaa.Length - 1
                TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                Dim we As New Caracteristica
                we.cb_codigo = cb_codigo
                we.Dock = DockStyle.Top
                we.Label1.Text = aaa(l).ItemArray(3).ToString
                we.Label2.Text = "Corporativo"
                we.Label3.Text = aaa(l).ItemArray(7).ToString & "%"
                If aaa(l).ItemArray(8).ToString = "" Then we.Label4.Text = 0 Else we.Label4.Text = aaa(l).ItemArray(8)
                we.btn_adjunto.Tag = aaa(l).ItemArray(2)
                we.Tag = aaa(l).ItemArray(9)
                AddHandler we.btn_adjunto.Click, AddressOf Agregar_Adjunto
                TableLayoutPanel1.Controls.Add(we)
            Next

            ''Pintar los porcentajes generales

            If TLP_Requerimientos.Visible = False Then
                Progress_habilidades.Valor = 39
                Progress_competencias.Valor = 45
                Progress_conocimiento.Valor = 70
                TLP_Requerimientos.Visible = True
            Else
                Progress_habilidades.Valor = Progress_habilidades.Valor - 1
                Progress_competencias.Valor = Progress_competencias.Valor - 1
                Progress_conocimiento.Valor = Progress_conocimiento.Valor - 1
                Progress_habilidades.Refresh()
                Progress_competencias.Refresh()
                Progress_conocimiento.Refresh()
            End If
            Caracteristica1.Label1.Text = "Competencia"
            Caracteristica1.Label2.Text = "Requerido"
            Caracteristica1.Label3.Text = "Nivel req."
            Caracteristica1.Label4.Text = "Nivel actual"
            Caracteristica1.btn_adjunto.Visible = False
            Caracteristica1.Button2.Visible = False
            Exit Sub

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub No_empleado_KeyUp(sender As Object, e As KeyEventArgs) Handles No_empleado.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Buscar_empleado()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Buscar_empleado()
        Try
            Dim datos As DataTable = SqlQuery.PorCodigo(No_empleado.Text)
            If datos.Rows.Count > 0 Then

                Cmb_dpto.SelectedValue = datos.Rows(0).Item("cb_Nivel1")
                Cmb_pto.SelectedValue = datos.Rows(0).Item("cb_puesto")
                Cmb_nom.SelectedValue = No_empleado.Text
                No_empleado.Enabled = False
            Else
                MsgBox("Empleado no encontrado", MsgBoxStyle.Information)
                No_empleado.Text = ""

                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

#Region "Eventos combobox"
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_dpto.SelectedIndexChanged
        Try
            If iniciando Then Exit Sub
            If Cmb_dpto.SelectedIndex = -1 Then
                midataset.Tables("Puesto").DefaultView.RowFilter = "1=2"
                Exit Sub
            End If
            iniciando = True
            If Cmb_dpto.SelectedValue = 999999 Then
                midataset.Tables("Puesto").DefaultView.RowFilter = "CB_NIVEL1 is Null"

            Else
                midataset.Tables("Puesto").DefaultView.RowFilter = "CB_NIVEL1 = " & Cmb_dpto.SelectedValue
            End If
            iniciando = False
            Cmb_pto.SelectedIndex = -1


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_pto.SelectedIndexChanged
        Try
            If iniciando Then Exit Sub

            If Cmb_pto.SelectedIndex = -1 Then
                iniciando = True
                midataset.Tables("Personal").DefaultView.RowFilter = "1 = 0"
                GroupBox1.Visible = False
                Panel2.Visible = False
                iniciando = False
                Exit Sub
            End If
            GroupBox1.Visible = True
            Panel2.Visible = True
            If Cmb_dpto.SelectedValue = 999999 Then
                midataset.Tables("Personal").DefaultView.RowFilter = "1=0"
            Else
                midataset.Tables("Personal").DefaultView.RowFilter = "CB_NIVEL1=" & Cmb_dpto.SelectedValue & " AND CB_PUESTO='" & Cmb_pto.SelectedValue & "'"
            End If

            If Cmb_nom.Items.Count > 0 Then
                Cmb_nom.SelectedIndex = -1
                Cmb_nom.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub Cmb_nom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_nom.SelectedIndexChanged
        Try
            If iniciando Then Exit Sub
            If Cmb_nom.Items.Count = 0 Or Cmb_nom.SelectedIndex = -1 Then
                No_empleado.Text = ""
                txt_antiguedad.Text = ""
                txt_antiguedad_AÑOS.Text = ""
                PictureBox1.Image = Nothing
                cargar_categorias(0)
                Exit Sub
            End If
            If Cmb_nom.SelectedIndex = -1 Then Exit Sub

            No_empleado.Text = CType(sender, ComboBox).SelectedItem.Row.ItemArray(0).ToString
            txt_antiguedad.Text = CType(sender, ComboBox).SelectedItem.Row.ItemArray(17)
            txt_antiguedad_AÑOS.Text = Math.Truncate(DateDiff(DateInterval.Month, CType(sender, ComboBox).SelectedItem.ROW.ITEMARRAY(17), Today) / 12) & " Años y " & DateDiff(DateInterval.Month, CType(sender, ComboBox).SelectedItem.ROW.ITEMARRAY(17), Today) - (Math.Truncate(DateDiff(DateInterval.Month, CType(sender, ComboBox).SelectedItem.ROW.ITEMARRAY(17), Today) / 12) * 12) & " Meses"
            Dim tablaimagen As DataTable = SqlQuery.Imagen(CType(sender, ComboBox).SelectedItem.Row.ItemArray(0))
            If tablaimagen.Rows.Count > 0 Then
                Dim myByteArray() As Byte = tablaimagen.Rows(0).Item(0)
                Dim stream As New MemoryStream(myByteArray)
                PictureBox1.Image = Image.FromStream(stream)
            End If


            cargar_categorias(CType(sender, ComboBox).SelectedItem.Row.ItemArray(0))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TableLayoutPanel1_Scroll(sender As Object, e As ScrollEventArgs) Handles TableLayoutPanel1.Scroll

    End Sub


    Private Sub TableLayoutPanel1_Move(sender As Object, e As EventArgs) Handles Me.MouseWheel
        Me.Text = TimeOfDay.ToString
    End Sub

    Private Sub TableLayoutPanel1_Move_1(sender As Object, e As EventArgs) Handles TableLayoutPanel1.Move
        If TableLayoutPanel1.Location.Y > -1 * (habili_y) Then
            Caracteristica1.Label1.Text = "Caracteristica"
        ElseIf TableLayoutPanel1.Location.Y > -1 * (conocimi_y) Then
            Caracteristica1.Label1.Text = "Habilidad"
        Else
            Caracteristica1.Label1.Text = "Conocimiento"
        End If
    End Sub



#End Region

    Private Sub Agregar_Adjunto(sender As Object, e As EventArgs)
        Try
            'OpenFileDialog1.Filter = "Excel Workbook|*.xlsx;*.xlsm;*.xls" +
            '                          "|All Files|*.*"
            'OpenFileDialog1.ShowDialog()

            'If OpenFileDialog1.FileName <> "OpenFileDialog1" Then
            '    TextBox1.Text = OpenFileDialog1.FileName
            'Else
            '    TextBox1.Text = Form2.vb""
            'End If

            Dim a As New Agregar_evaluacion
            a.Caracteristica = CType(CType(sender, Button).Parent.Parent, Caracteristica).Label1.Text
            a.nivel_actual = CType(CType(sender, Button).Parent.Parent, Caracteristica).label4.Text
            a.Id_caracteristica = CType(sender, Button).Tag
            a.cb_codigo = Cmb_nom.SelectedValue
            a.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class