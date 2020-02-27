
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
    Dim curso_y As Integer
    Dim busqueda As Boolean = False
    Public completa As Boolean = False
    Dim consultajerarquica As Boolean = False
    Dim tot As Double
    Dim cant As Double
    Dim clave_especial As Boolean = False
    Dim indicador_IDP As Boolean = False


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
            Cmb_pto.ValueMember = "PU_CODIGO"
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
            guardar_carac_iniciales()

            If completa = False Then
                GroupBox1.Visible = True
                No_empleado.Enabled = True
                No_empleado.Text = My.Settings.CB_CODIGO
                Button1.PerformClick()
                Button1.Enabled = False
                Panel3.Enabled = False
            Else

            End If

            If My.Settings.Permisos.Select("Identificador = 'CT'").Count > 0 Then
                consultajerarquica = False
            Else
                consultajerarquica = True
            End If

            Timer1.Interval = 1000
            Timer1.Enabled = True
            Timer1.Start()

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

    Private Sub categoria(ByVal Tipo As String, ByVal cb_codigo As Integer, ByVal Cargar_encabezado As Boolean)
        Try
            If Cargar_encabezado Then
                TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                Dim titulo2 As New Label
                titulo2.AutoSize = True
                titulo2.BackColor = Color.LightGray
                titulo2.Dock = DockStyle.Top
                titulo2.Padding = New Padding(15, 15, 0, 15)
                titulo2.ForeColor = Color.White
                If Tipo = "Habilidad" Then
                    titulo2.Text = "Responsabilidades"
                ElseIf Tipo = "Competencia" Then
                    titulo2.Text = "Competencia y habilidades"
                ElseIf Tipo = "Conocimiento" Then
                    titulo2.Text = "Conocimientos"
                Else
                    titulo2.Text = "Cursos"
                End If

                titulo2.Font = New Font("Microsoft Sans Serif", "15")
                TableLayoutPanel1.Controls.Add(titulo2)
            End If
            Dim a As DataRow()
            If Tipo = "Curso" Then
                a = midataset.Tables("Cursos").Select("1= 1")
            Else
                a = midataset.Tables("Caracteristicas").Select(Tipo & "= 1")
            End If

            tot = a.Count
            cant = 0
            For l = 0 To a.Length - 1
                TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                Dim we As New Caracteristica
                If Tipo = "Curso" Then we.Es_curso = True
                we.cb_codigo = cb_codigo
                we.Dock = DockStyle.Top
                If Tipo <> "Curso" Then
                    If a(l).ItemArray(15) IsNot Nothing Then
                        If a(l).ItemArray(15) = True Then
                            If My.Settings.MostrarIdp = True Then
                                we.lbl_caracteristica.BackColor = Color.Green
                            End If
                        End If

                    End If
                End If


                'Reiniciar control
                we.lbl_requerido.Text = a(l).ItemArray(13).ToString
                we.lbl_niv_req.Text = ""
                we.lbl_niv_actual.Text = ""

                'Agregar valores iniciales a control
                'AQUI PODRIA AGREGAR LA CALIFICACION Y HACER LA RELACION ENTRE EL PORCENTAJE ACTUAL Y NIVEL REQUERIDO ACTUAL 
                we.lbl_caracteristica.Text = a(l).ItemArray(3).ToString
                Select Case a(l).ItemArray(14)
                    Case Nothing
                        Console.WriteLine("")
                        we.id_ponderacion = 0

                    Case 1
                        we.lbl_niv_req.ImageList = ImageList2
                        we.lbl_niv_actual.ImageList = ImageList2
                        we.id_ponderacion = 1

                    Case 2
                        we.lbl_niv_req.ImageList = ImageList4
                        we.lbl_niv_actual.ImageList = ImageList4
                        we.id_ponderacion = 2

                    Case 3
                        we.lbl_niv_req.ImageList = ImageList1
                        we.lbl_niv_actual.ImageList = ImageList1
                        we.id_ponderacion = 3


                    Case 4
                        we.lbl_niv_req.ImageList = ImageList3
                        we.lbl_niv_actual.ImageList = ImageList3
                        we.id_ponderacion = 4

                    Case Else
                        we.id_ponderacion = 0
                End Select


                'Agregar valores actuales reales
                we.lbl_niv_req.ImageIndex = a(l).ItemArray(8)  'Nivel requerido
                we.btn_adjunto.Tag = a(l).ItemArray(2) 'Id de la categoria

                Dim valor_maximo As Double = 0

                'Evaluaciones
                we.lbl_porcentaje.ImageList = ImageList4
                we.lbl_porcentaje.ImageIndex = 0

                If a(l).ItemArray(9).ToString <> "" Then ' si existe evaluacion
                    we.Tag = a(l).ItemArray(9) 'Como tag al control se agrega el id_evaluacion
                    If a(l).ItemArray(10).ToString <> "" Then
                        Dim index = Math.Truncate((a(l).ItemArray(10) * a(l).ItemArray(8) / 100))
                        Dim indexx = Math.Truncate((a(l).ItemArray(10) * 4 / 100))
                        we.lbl_porcentaje.Text = a(l).ItemArray(10) & " %"
                        we.lbl_porcentaje.ImageIndex = indexx
                        we.lbl_niv_actual.ImageIndex = index

                    Else
                        we.lbl_niv_actual.ImageIndex = 0
                        we.lbl_porcentaje.Text = 0 & " %"
                        we.lbl_porcentaje.ImageIndex = 0
                    End If

                    we.btn_evidencia.Visible = True
                    If a(l).ItemArray(11) = False Then
                        we.Pendiente.Visible = True
                    Else
                        we.Pendiente.Visible = False
                    End If


                    'Calcular promedio de avance en la categoria
                    If a(l).ItemArray(10).ToString <> "" Then
                        cant = cant + (a(l).ItemArray(10) / 100)
                    End If

                Else
                    we.Tag = ""
                    we.lbl_niv_actual.ImageIndex = 0
                    we.btn_evidencia.Visible = False
                    we.Pendiente.Visible = False
                    we.lbl_porcentaje.Text = valor_maximo & " %"

                    If valor_maximo = 100 Then
                        we.lbl_porcentaje.BackColor = Color.DarkGreen
                        we.ForeColor = Color.White
                    End If

                End If
                we.lbl_porcentaje.Text = ""
                'Agregar evento para evaluacion
                AddHandler we.btn_adjunto.Click, AddressOf Agregar_Adjunto
                TableLayoutPanel1.Controls.Add(we)

            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Cargar categoria: " & Tipo)
        End Try
    End Sub

    Private Sub cargar_categorias(ByVal cb_codigo As Integer)
        Try

            Caracteristica1.lbl_caracteristica.Font = New Font("Microsoft Sans Serif", "15.75")
            Caracteristica1.lbl_caracteristica.Text = "Competencias y habilidades"
            TableLayoutPanel1.Controls.Clear()
            TableLayoutPanel1.RowStyles.Clear()

            If Cmb_nom.Items.Count = 0 Then
                TLP_Requerimientos.Visible = False
                Exit Sub
            End If
            If cb_codigo = 0 Then Exit Sub
            If midataset.Tables("Caracteristicas") IsNot Nothing Then
                midataset.Tables.Remove("Caracteristicas")
            End If
            Dim tabla As DataTable
            tabla = CType(SqlQuery.Cargar_carac_porpuesto(cb_codigo), DataTable).Copy
            tabla.TableName = "Caracteristicas"
            midataset.Tables.Add(tabla)
            If midataset.Tables("Cursos") IsNot Nothing Then
                midataset.Tables.Remove("Cursos")
            End If
            Dim tabla_cursos As DataTable
            tabla_cursos = CType(SqlQuery.cargar_cursos_porpuesto(cb_codigo), DataTable).Copy
            tabla_cursos.TableName = "Cursos"
            midataset.Tables.Add(tabla_cursos)


            'COMPETENCIAS
            categoria("Competencia", cb_codigo, False)
            If tot = 0 Then
                Progress_competencias.Valor = -1
            Else
                Progress_competencias.Valor = (cant / tot) * 100
            End If
            Progress_competencias.Refresh()

            'HABILIDADES
            habili_y = TableLayoutPanel1.Size.Height
            categoria("Habilidad", cb_codigo, True)
            If tot = 0 Then
                Progress_habilidades.Valor = -1
            Else
                Progress_habilidades.Valor = (cant / tot) * 100
            End If
            Progress_habilidades.Refresh()

            'CONOCIMIENTOS
            conocimi_y = TableLayoutPanel1.Size.Height
            categoria("Conocimiento", cb_codigo, True)

            If tot = 0 Then
                Progress_conocimiento.Valor = -1
            Else
                Progress_conocimiento.Valor = (cant / tot) * 100
            End If
            Progress_conocimiento.Refresh()

            'Cursos
            curso_y = TableLayoutPanel1.Size.Height
            categoria("Curso", cb_codigo, True)
            If tot = 0 Then
                Progress_curso.Valor = -1
            Else
                Progress_curso.Valor = (cant / tot) * 100
            End If
            Progress_curso.Refresh()


            If TLP_Requerimientos.Visible = False Then
                TLP_Requerimientos.Visible = True
            End If

            Caracteristica1.lbl_caracteristica.Text = "Competencias y habilidades"
            Caracteristica1.lbl_requerido.Text = "Requerido"
            Caracteristica1.lbl_niv_req.Text = "Nivel req."
            Caracteristica1.lbl_niv_actual.Text = "Nivel actual"
            Caracteristica1.btn_adjunto.Visible = False
            Caracteristica1.btn_evidencia.Visible = False
            Caracteristica1.Pendiente.Visible = False

            No_empleado.Enabled = False
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
            If No_empleado.Text.Trim = "" Then Exit Sub
            Dim datos As DataTable = SqlQuery.PorCodigo(No_empleado.Text)
            Console.WriteLine("")
            If datos.Rows.Count > 0 Then
                Dim nu = No_empleado.Text
                Cmb_pto.SelectedIndex = -1
                Cmb_dpto.SelectedIndex = -1

                Cmb_dpto.SelectedValue = datos.Rows(0).Item("cb_Nivel1")
                busqueda = True
                Cmb_pto.SelectedValue = datos.Rows(0).Item("cb_puesto")
                busqueda = False
                Cmb_nom.SelectedValue = nu
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
                GroupBox2.Visible = False
                Panel2.Visible = False

                iniciando = False
                Exit Sub
            End If
            If consultajerarquica Then

                If My.Settings.EmpleadosHijos IsNot Nothing Then
                    If My.Settings.EmpleadosHijos.Rows.Count > 0 Then
                        If My.Settings.EmpleadosHijos.Select("PU_CODIGO = '" & Cmb_pto.SelectedValue & "'").Count < 1 Then
                            If My.Settings.Puesto.Trim <> Cmb_pto.SelectedValue.TRIM Then
                                MsgBox("No estas autorizado para realizar esta consulta")
                                Cmb_pto.SelectedIndex = -1
                                Exit Sub
                            End If
                        End If
                    Else
                        MsgBox("No estas autorizado para realizar esta consulta")
                        Cmb_pto.SelectedIndex = -1
                        Exit Sub
                    End If
                Else
                    MsgBox("No estas autorizado para realizar esta consulta")
                    Exit Sub
                End If


            End If
            GroupBox1.Visible = True
            GroupBox2.Visible = True
            Panel2.Visible = True
            If Cmb_dpto.SelectedValue = 999999 Then
                midataset.Tables("Personal").DefaultView.RowFilter = "1=0"
            Else
                midataset.Tables("Personal").DefaultView.RowFilter = "CB_NIVEL1=" & Cmb_dpto.SelectedValue & " AND CB_PUESTO='" & Cmb_pto.SelectedValue & "'"
            End If

            If Cmb_nom.Items.Count > 0 Then
                Cmb_nom.SelectedIndex = -1
                If busqueda = False Then
                    Cmb_nom.SelectedIndex = 0
                End If

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
            indicador_IDP = Not (SqlQuery.IDP_COMPLETO(Cmb_nom.SelectedValue, True))
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
            Caracteristica1.lbl_caracteristica.Text = "Competencias y habilidades"
        ElseIf TableLayoutPanel1.Location.Y > -1 * (conocimi_y) Then
            Caracteristica1.lbl_caracteristica.Text = "Responsabilidades"
        ElseIf TableLayoutPanel1.Location.Y > -1 * (curso_y) Then
            Caracteristica1.lbl_caracteristica.Text = "Conocimiento"
        Else
            Caracteristica1.lbl_caracteristica.Text = "Curso"
        End If
    End Sub

#End Region

    Private Sub Agregar_Adjunto(sender As Object, e As EventArgs)
        Try
#Region "Comentarios"
            'OpenFileDialog1.Filter = "Excel Workbook|*.xlsx;*.xlsm;*.xls" +
            '                          "|All Files|*.*"
            'OpenFileDialog1.ShowDialog()

            'If OpenFileDialog1.FileName <> "OpenFileDialog1" Then
            '    TextBox1.Text = OpenFileDialog1.FileName
            'Else
            '    TextBox1.Text = Form2.vb""
            'End If

#End Region
            If My.Settings.Usuario.ToUpper = "ADMIN" Then
                MsgBox("Utilice una cuenta de usuario específico para realizar una evaluación")
                Exit Sub
            End If
            If Not Permiso.Habilitado("RCE") Then
                If Permiso.Habilitado("REJ") Then
                    If My.Settings.EmpleadosHijos.Select("Pu_codigo = '" & Cmb_pto.SelectedValue & "'").Count = 0 Then
                        MsgBox("No tienes permiso para evaluar a este empleado", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Else
                    MsgBox("No tienes permiso para evaluar a este empleado", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
            Dim a As New Agregar_evaluacion
            a.Caracteristica = CType(CType(sender, Button).Parent.Parent, Caracteristica).lbl_caracteristica.Text
            If CType(CType(sender, Button).Parent.Parent, Caracteristica).Es_curso = True Then
                a.es_curso = True
                a.CU_CODIGO = CType(sender, Button).Tag
            Else
                a.Id_caracteristica = CType(sender, Button).Tag
            End If
            a.nivelrequerido = CType(CType(sender, Button).Parent.Parent, Caracteristica).lbl_niv_req.ImageIndex
            a.id_ponderacion = CType(CType(sender, Button).Parent.Parent, Caracteristica).id_ponderacion
            a.cb_codigo = Cmb_nom.SelectedValue
            a.nivel_actual = CType(sender.Parent.Parent, Caracteristica).lbl_niv_actual.ImageIndex
            a.actual = CType(sender.parent.parent, Caracteristica).lbl_porcentaje.ImageIndex * 25
            'Try
            '    a.actual = CType(sender.parent.parent, Caracteristica).lbl_porcentaje.Text.Split("%")(0)
            'Catch ex As Exception
            '    a.actual = 0
            'End Try

            If CType(CType(sender, Button).Parent.Parent, Caracteristica).Tag.ToString <> "" Then
                a.id_evaluacion = CType(CType(sender, Button).Parent.Parent, Caracteristica).Tag
            End If
            If a.ShowDialog() = DialogResult.OK Then
                CType(CType(sender, Button).Parent.Parent, Caracteristica).Tag = a.id_evaluacion
                If My.Settings.Permisos.Select("Permiso = 'AFINAL'").Count > 0 Then

                    CType(sender.parent.parent, Caracteristica).lbl_niv_actual.Text = ""
                        CType(sender.Parent.Parent, Caracteristica).lbl_niv_actual.ImageIndex = a.nivel_actual
                    CType(sender.Parent.Parent, Caracteristica).calcular()
                    If No_empleado.Enabled = False Then
                        Button1.PerformClick()
                    End If
                    Button1.PerformClick()



                Else
                    CType(sender.Parent.Parent, Caracteristica).Pendiente.Visible = True
                End If
                CType(sender.Parent.Parent, Caracteristica).btn_evidencia.Visible = True

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'If r.Created Then
            '    r.BringToFront()
            '    r.Show()
            'Else
            '    r = New Reporte
            '    r.MdiParent = Me
            '    r.Show()
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Consulta_Resize(sender As Object, e As EventArgs) ' Handles MyBase.Resize
        If MyBase.Size.Width < 1364 Then

            GroupBox1.Size = New Size(Panel2.Size.Width, size_group.Height + TLP_Requerimientos.Height + 20)
            TLP_Requerimientos.Location = New Point(PictureBox1.Location.X, PictureBox1.Location.Y + PictureBox1.Size.Height + 15)
            '   Panel2.Location = New Point(GroupBox1.Location.X, GroupBox1.Location.Y + GroupBox1.Size.Height + 5)
            '  Panel2.Size = New Size(GroupBox1.Size.Width, Me.Size.Height - 10 - Panel2.Location.Y)
        Else
            GroupBox1.Size = New Size(Panel2.Size.Width, size_group.Height)
            TLP_Requerimientos.Location = New Point(tlp_requ)
            '  Panel2.Location = New Point(panelloc)
            '  Panel2.Size = New Size(GroupBox1.Size.Width, Me.Size.Height - 10 - Panel2.Location.Y)
        End If
    End Sub

    Dim size_group As Size
    Dim tlp_requ As Point
    Dim panelsi As Size
    Dim panelloc As Point

    Private Sub guardar_carac_iniciales()
        size_group = New Size(1324, 200)
        tlp_requ = New Point(622, 46)
        panelloc = New Point(12, 323)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim obj As New Objetivos
        obj.cb_codigo = Cmb_nom.SelectedValue
        obj.ShowDialog
    End Sub

#Region "Codigo anterior"
    Private Sub categoriaVieja(ByVal Tipo As String, ByVal cb_codigo As Integer, ByVal Cargar_encabezado As Boolean)
        Try
            If Cargar_encabezado Then
                TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                Dim titulo2 As New Label
                titulo2.AutoSize = True
                titulo2.BackColor = Color.LightGray
                titulo2.Dock = DockStyle.Top
                titulo2.Padding = New Padding(15, 15, 0, 15)
                titulo2.ForeColor = Color.White
                titulo2.Text = Tipo.ToString
                titulo2.Font = New Font("Microsoft Sans Serif", "15")
                TableLayoutPanel1.Controls.Add(titulo2)

            End If

            Dim a = midataset.Tables("Caracteristicas").Select(Tipo & "= 1")
            tot = a.Count
            cant = 0
            For l = 0 To a.Length - 1
                TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                Dim we As New Caracteristica
                we.cb_codigo = cb_codigo
                we.Dock = DockStyle.Top

                'Reiniciar control
                we.lbl_requerido.Text = a(l).ItemArray(13).ToString
                we.lbl_niv_req.Text = ""
                we.lbl_niv_actual.Text = ""

                'Agregar valores iniciales a control
                'AQUI PODRIA AGREGAR LA CALIFICACION Y HACER LA RELACION ENTRE EL PORCENTAJE ACTUAL Y NIVEL REQUERIDO ACTUAL 
                we.lbl_caracteristica.Text = a(l).ItemArray(3).ToString
                Select Case a(l).ItemArray(14)
                    Case Nothing
                        Console.WriteLine("")
                        we.id_ponderacion = 0

                    Case 1
                        we.lbl_niv_req.ImageList = ImageList2
                        we.lbl_niv_actual.ImageList = ImageList2
                        we.id_ponderacion = 1

                    Case 2
                        we.lbl_niv_req.ImageList = ImageList4
                        we.lbl_niv_actual.ImageList = ImageList4
                        we.id_ponderacion = 2

                    Case 3
                        we.lbl_niv_req.ImageList = ImageList1
                        we.lbl_niv_actual.ImageList = ImageList1
                        we.id_ponderacion = 3


                    Case 4
                        we.lbl_niv_req.ImageList = ImageList3
                        we.lbl_niv_actual.ImageList = ImageList3
                        we.id_ponderacion = 4

                    Case Else
                        we.id_ponderacion = 0
                End Select


                'Agregar valores actuales reales
                we.lbl_niv_req.ImageIndex = a(l).ItemArray(8)  'Nivel requerido
                we.btn_adjunto.Tag = a(l).ItemArray(2) 'Id de la categoria

                Dim valor_maximo As Double = 0

                'Evaluaciones


                If a(l).ItemArray(9).ToString <> "" Then ' si existe evaluacion
                    we.Tag = a(l).ItemArray(9) 'Como tag al control se agrega el id_evaluacion


                    'PASAR ARRIBA **********************************************************************************************************************************************************
                    If a(l).ItemArray(10).ToString <> "" Then
                        we.lbl_niv_actual.ImageIndex = a(l).ItemArray(10)
                    Else
                        we.lbl_niv_actual.ImageIndex = 0
                    End If
                    'PASAR ARRIBA **********************************************************************************************************************************************************


                    we.btn_evidencia.Visible = True
                    If a(l).ItemArray(11) = False Then
                        we.Pendiente.Visible = True
                    Else
                        we.Pendiente.Visible = False
                    End If


                    'Calcular promedio de avance en la categoria
                    If a(l).ItemArray(10).ToString <> "" Then






                        'PROBABLEMENTE SE QUITE ESTE CODIGO ***********
                        If a(l).ItemArray(10) > a(l).ItemArray(8) Then
                            cant = cant + 1
                            valor_maximo = 100
                        Else
                            cant = cant + (a(l).ItemArray(10) / a(l).ItemArray(8))
                            valor_maximo = (a(l).ItemArray(10) / a(l).ItemArray(8)) * 100
                        End If
                        'PROBABLEMENTE SE QUITE ESTE CODIGO ***********
                    End If

                Else
                    we.Tag = ""
                    we.lbl_niv_actual.ImageIndex = 0
                    we.btn_evidencia.Visible = False
                    we.Pendiente.Visible = False
                    we.lbl_porcentaje.Text = valor_maximo & " %"

                    If valor_maximo = 100 Then
                        we.lbl_porcentaje.BackColor = Color.DarkGreen
                        we.ForeColor = Color.White
                    End If

                End If

                'Agregar evento para evaluacion
                AddHandler we.btn_adjunto.Click, AddressOf Agregar_Adjunto
                TableLayoutPanel1.Controls.Add(we)

            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Cargar categoria: " & Tipo)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim detalle As New Detalles
            detalle.cb_codigo = Cmb_nom.SelectedValue
            detalle.ShowDialog()
            detalle = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim id As New IDP
        id.cb_codigo = Cmb_nom.SelectedValue
        If id.ShowDialog() = DialogResult.Retry Then
            Dim periodo As Integer = id.ComboBox1.SelectedValue
            indicador_IDP = Not (SqlQuery.IDP_COMPLETO(Cmb_nom.SelectedValue, True))
            Try
                If CType(CType(sender, Button).Parent.Parent.Parent.Parent, Principal).r.Created = True Then
                    CType(CType(sender, Button).Parent.Parent.Parent.Parent, Principal).r.BringToFront()
                    CType(CType(sender, Button).Parent.Parent.Parent.Parent, Principal).r.Show()
                Else
                    CType(CType(sender, Button).Parent.Parent.Parent.Parent, Principal).r = New Reporte
                    CType(CType(sender, Button).Parent.Parent.Parent.Parent, Principal).r.MdiParent = CType(CType(sender, Button).Parent.Parent.Parent.Parent, Principal)
                    CType(CType(sender, Button).Parent.Parent.Parent.Parent, Principal).r.Show()
                End If
                CType(CType(sender, Button).Parent.Parent.Parent.Parent, Principal).r.CargarIdp(Cmb_nom.SelectedValue, periodo, True)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If My.Settings.AlarmaIdp = False Then
            Button7.BackColor = Color.White
            Timer1.Stop()
        End If

        If indicador_IDP Then

            If Button7.BackColor = Color.White Then
                Button7.BackColor = Color.Red
            Else
                Button7.BackColor = Color.White
            End If

        Else
            Button7.BackColor = Color.White
        End If


    End Sub

#End Region






End Class