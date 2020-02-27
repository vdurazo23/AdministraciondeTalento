Imports System.IO

Public Class Detalles
    Public cb_codigo As Integer
    Dim midataset As New DataSet
    Dim iniciando As Boolean = True
    Dim dbuffer As New SetDoubleBuffered
    Private Sub Detalles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Visible = False
        cargar_datos()
        cargar_tabla()
        If midataset.Tables("INFO").Rows.Count > 0 Then
            Dim Tipos As DataTable = midataset.Tables("INFO").DefaultView.ToTable(True, "Tipo")
            ComboBox1.DataSource = Tipos
            ComboBox1.DisplayMember = "Tipo"
            ComboBox1.ValueMember = "Tipo"
            Console.WriteLine("")
        End If

        iniciando = False
        dbuffer.Enabled(DataGridView1)
        Dim col As New DataGridViewLinkColumn
        Dim col3 As New DataGridViewLinkColumn
        col.HeaderText = "Entrenamiento"
        col3.HeaderText = "Entrenamiento"
        DataGridView1.Columns.Add(col)
        DataGridView2.Columns.Add(col3)
        Dim col2 As New DataGridViewLinkColumn
        Dim col4 As New DataGridViewLinkColumn
        col2.HeaderText = "Otras calificaciones"
        col4.HeaderText = "Otras calificaciones"
        DataGridView1.Columns.Add(col2)
        DataGridView2.Columns.Add(col4)
        DataGridView1.Columns(0).Visible = False
        DataGridView2.Columns(0).Visible = False
        '  DataGridView2.Visible = False
        ComboBox2.Visible = False
        CheckBox1.Checked = True
    End Sub


    Sub cargar_datos()
        Try
            Dim datos_generales As DataTable
            datos_generales = CType(SqlQuery.Personal_especifico(cb_codigo), DataTable).Copy
            If midataset.Tables("Datos") IsNot Nothing Then
                midataset.Tables.Remove("Datos")
            End If
            datos_generales.TableName = "Datos"
            midataset.Tables.Add(datos_generales)
            Console.WriteLine("")
            TextBox1.Text = datos_generales.Rows(0).Item("CB_CODIGO")
            TextBox2.Text = datos_generales.Rows(0).Item("PRETTYNAME")
            TextBox3.Text = datos_generales.Rows(0).Item("PU_DESCRIP")
            TextBox4.Text = datos_generales.Rows(0).Item("TB_ELEMENT") & " / " & datos_generales.Rows(0).Item("TB_ELEMENT1")
            TextBox5.Text = "No especificado"
            TextBox6.Text = Math.Truncate(DateDiff(DateInterval.Month, datos_generales.Rows(0).Item("CB_FEC_ANT"), Today) / 12) &
                " Años y " & DateDiff(DateInterval.Month, datos_generales.Rows(0).Item("CB_FEC_ANT"), Today) - (Math.Truncate(DateDiff(DateInterval.Month, datos_generales.Rows(0).Item("CB_FEC_ANT"), Today) / 12) * 12) & " Meses"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub cargar_tabla()
        Try
            Dim tablaimagen As DataTable = SqlQuery.Imagen(cb_codigo)
            If tablaimagen.Rows.Count > 0 Then
                Dim myByteArray() As Byte = tablaimagen.Rows(0).Item(0)
                Dim stream As New MemoryStream(myByteArray)
                PictureBox1.Image = Image.FromStream(stream)
            End If

            Dim ta As DataTable = CType(SqlQuery.Cargar_detallado(cb_codigo), DataTable).Copy
            If midataset.Tables("INFO") IsNot Nothing Then
                midataset.Tables.Remove("INFO")
            End If
            ta.TableName = "INFO"
            midataset.Tables.Add(ta)
            DataGridView1.DataSource = midataset.Tables("INFO").DefaultView

            Dim te As DataTable = CType(SqlQuery.cargar_detallado_nopuesto(cb_codigo), DataTable).Copy
            If midataset.Tables("INFO2") IsNot Nothing Then
                midataset.Tables.Remove("INFO2")
            End If
            te.TableName = "INFO2"
            midataset.Tables.Add(te)
            DataGridView2.DataSource = midataset.Tables("INFO2").DefaultView

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If CType(sender, CheckBox).Checked = True Then

                ComboBox1.SelectedIndex = -1
                ComboBox1.Enabled = False
                midataset.Tables("INFO").DefaultView.RowFilter = ""
            Else
                ComboBox1.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            If iniciando Then Exit Sub
            If CType(sender, ComboBox).SelectedIndex >= 0 Then
                midataset.Tables("INFO").DefaultView.RowFilter = "Tipo = '" & CType(sender, ComboBox).SelectedValue & "'"
            End If
            Select Case CType(sender, ComboBox).SelectedValue
                Case "Competencia"
                    DataGridView1.Columns(1).Visible = True

                Case "Conocimiento"
                    DataGridView1.Columns(1).Visible = False

                Case "Habilidad"
                    DataGridView1.Columns(1).Visible = False

                Case "Curso"
                    DataGridView1.Columns(1).Visible = False



                Case Else
                    For Each col As DataGridViewColumn In DataGridView1.Columns
                        If col.HeaderText <> "id" And col.Index <> 3 Then
                            col.Visible = True
                        End If

                    Next

            End Select


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Try
            If CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText = "Entrenamiento" Then
                e.Value = "Programar"
            End If
            If CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText = "Otras calificaciones" Then
                e.Value = "Ver"

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
            Select Case CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText
                Case "Entrenamiento"
                    Dim fecha As New Programar
                    If fecha.ShowDialog() = DialogResult.OK Then


                        Dim fecha_final As Date = fecha.MonthCalendar1.SelectionStart
                        Dim descripcion As String = fecha.TextBox1.Text.Trim
                        Dim id_ponderacion = DataGridView1.Item("Id_ponderacion", e.RowIndex).Value
                        Dim nivel_requerido = DataGridView1.Item("Nivel_requerido", e.RowIndex).Value

                        Dim RE As Integer
                        If DataGridView1.Item("Tipo", e.RowIndex).Value = "Curso" Then
                            RE = SqlQuery.Agregar_programacion(cb_codigo, Nothing, DataGridView1.Item("Identificador", e.RowIndex).Value, fecha_final, 100, nivel_requerido, id_ponderacion, descripcion)
                        Else
                            RE = SqlQuery.Agregar_programacion(cb_codigo, DataGridView1.Item("Identificador", e.RowIndex).Value, Nothing, fecha_final, 100, nivel_requerido, id_ponderacion, descripcion)
                        End If
                        If RE = 1 Then
                            cargar_tabla()
                        End If

                    End If
                    fecha.Dispose()
                    fecha = Nothing

                Case "Otras calificaciones"

                    'Ya no se mostraria en el grid2

                    If DataGridView1.Item("Tipo", e.RowIndex).Value = "Curso" Then
                        cargar_tabla2(Nothing, DataGridView1.Item("Identificador", e.RowIndex).Value.ToString)
                    Else
                        cargar_tabla2(DataGridView1.Item("Identificador", e.RowIndex).Value, Nothing)
                    End If


                Case ""

                Case Else

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cargar_categorias()
        Try
            'Dim s As DataTable = SQLCon.TPMStations
            'Dim c = s.DefaultView.ToTable(True, "ASSET")
            'TableLayoutPanel1.Controls.Clear()
            'TableLayoutPanel1.ColumnStyles.Clear()
            'TableLayoutPanel1.ColumnCount = 0
            'For a = 0 To c.Rows.Count - 1
            '    TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 250))
            '    TableLayoutPanel1.ColumnCount = a + 1
            '    Dim tr As New TreeView
            '    tr.Name = c.Rows(a).Item(0).trim
            '    tr.Width = 250
            '    tr.Height = TableLayoutPanel1.Height - 20
            '    tr.CheckBoxes = True
            '    Dim e As New TreeNode
            '    e.Name = c.Rows(a).Item(0).trim
            '    e.Tag = "Asset"
            '    e.Text = e.Name.Trim
            '    Dim cc = s.DefaultView.ToTable(True, "Asset", "Station")
            '    Dim fil = cc.Select("ASSET ='" & e.Name & "'")
            '    For t = 0 To fil.Count - 1
            '        Dim ee As New TreeNode
            '        ee.Name = fil(t).Item(1).ToString
            '        ' ee.Tag = 0
            '        ee.Text = ee.Name.Trim

            '        e.Nodes.Add(ee)
            '    Next
            '    tr.Nodes.Add(e)
            '    AddHandler tr.BeforeCheck, AddressOf select_ch
            '    TableLayoutPanel1.Controls.Add(tr, a, 0)
            '    tr.ExpandAll()
            'Next
            'RelTPMStations()
            'For Each tree As TreeView In TableLayoutPanel1.Controls
            '    tree.ShowNodeToolTips = True
            '    tree.ExpandAll()
            'Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cargar_tabla2(ByVal Id_caracteristica As Integer, ByVal CU_CODIGO As String)
        Try
            Exit Sub
            Dim tabla_nueva As DataTable
            tabla_nueva = CType(SqlQuery.Otras_Calificaciones(cb_codigo, Id_caracteristica, CU_CODIGO), DataTable).Copy
            tabla_nueva.TableName = "Otras"
            If midataset.Tables("Otras") IsNot Nothing Then
                midataset.Tables.Remove("Otras")
            End If
            midataset.Tables.Add(tabla_nueva)
            If midataset.Tables("Otras").Rows.Count > 0 Then
                ComboBox2.Visible = True
                DataGridView3.Visible = True
                Dim ponderaciones As DataTable = midataset.Tables("Otras").DefaultView.ToTable(True, "Id_ponderacion")
                ComboBox2.DataSource = ponderaciones
                ComboBox2.ValueMember = "Id_ponderacion"
                ComboBox2.DisplayMember = "Id_ponderacion"
                DataGridView3.DataSource = Nothing
                DataGridView3.DataSource = midataset.Tables("Otras").DefaultView
                DataGridView3.Columns(0).Visible = False
                DataGridView3.Columns(2).Visible = False
                Panel1.Visible = True
            Else
                ComboBox2.Visible = False
                DataGridView3.Visible = False
                Panel1.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Dim pu_Selec As New List(Of SqlQuery.Puesto_descripcion)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim s As New Puni
            s.cargar_todos = True
            s.cargar_empleados = False

            If pu_Selec.Count > 0 Then
                s.seleccionados = pu_Selec
            End If

            If s.ShowDialog = DialogResult.OK Then
                pu_Selec = s.seleccionados
                CargarLista()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CargarLista()
        Try
            ListBox1.Items.Clear()
            For Each er As SqlQuery.Puesto_descripcion In pu_Selec
                ListBox1.Items.Add(er.pu_codigo & "/" & er.pu_descripcion)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            TabControl1.TabPages.Clear()
            For a As Integer = 0 To ListBox1.Items.Count - 1

                TabControl1.TabPages.Add(a)

                Dim pu_codigo As String = ListBox1.Items(a).ToString.Split("/")(0).ToString
                Dim pu_descrip As String = ListBox1.Items(a).ToString.Split("/")(1).ToString
                TabControl1.TabPages(a).Name = pu_codigo
                TabControl1.TabPages(a).Text = pu_descrip
                '   Dim u As New UserControl1
                '   u.Dock = DockStyle.Fill

                ' 'Dim pa As New Panel
                ''pa.Dock = DockStyle.Fill

                '  TabControl1.TabPages(a).Controls.Add(u)
                '  Dim tabla As DataTable = CType(SqlQuery.Cargar_carac_otropuesto(cb_codigo, ListBox1.Items(a).ToString.Split("-")(0)), DataTable)

                Dim comparacion As New Comparacion_control
                comparacion.Dock = DockStyle.Fill
                comparacion.puesto = pu_descrip
                comparacion.pu_codigo = pu_codigo
                '  comparacion.datos = tabla
                comparacion.cb_codigo = cb_codigo
                TabControl1.TabPages(a).Controls.Add(comparacion)




                'Dim data As New DataGridView
                'Dim ee As New DataGridViewImageColumn
                'ee.HeaderText = "Prueba"
                'ee.DisplayIndex = 88
                'data.Columns.Add(ee)
                'data.Dock = DockStyle.Fill
                'data.AllowUserToAddRows = False
                'data.AllowUserToDeleteRows = False
                'data.AllowUserToOrderColumns = False
                'data.AllowUserToResizeColumns = False
                'data.ReadOnly = True

                'data.DataSource = tabla



                'AddHandler data.CellFormatting, AddressOf dataformat
                'TabControl1.TabPages(a).Controls.Add(data)

            Next





        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dataformat(sender As Object, e As EventArgs)
        Try

            If CType(sender, DataGridView).Columns(CType(e, DataGridViewCellFormattingEventArgs).ColumnIndex).HeaderText = "Prueba" Then

                CType(e, DataGridViewCellFormattingEventArgs).Value = ImageList1.Images(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        Try


            If TabControl2.SelectedIndex = 1 Then
                GroupBox2.Visible = True
            Else
                GroupBox2.Visible = False

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        Try
            Try
                If CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText = "Entrenamiento" Then
                    e.Value = "Programar"
                End If
                If CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText = "Otras calificaciones" Then
                    e.Value = "Ver"

                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Try
            Exit Sub
            If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
            Select Case CType(sender, DataGridView).Columns(e.ColumnIndex).HeaderText
                Case "Entrenamiento"
                    Dim fecha As New Programar
                    If fecha.ShowDialog() = DialogResult.OK Then


                        Dim fecha_final As Date = fecha.MonthCalendar1.SelectionStart
                        Dim descripcion As String = fecha.TextBox1.Text.Trim
                        Dim id_ponderacion = DataGridView1.Item("Id_ponderacion", e.RowIndex).Value
                        Dim nivel_requerido = DataGridView1.Item("Nivel_requerido", e.RowIndex).Value

                        Dim RE As Integer
                        If DataGridView1.Item("Tipo", e.RowIndex).Value = "Curso" Then
                            RE = SqlQuery.Agregar_programacion(cb_codigo, Nothing, DataGridView1.Item("Identificador", e.RowIndex).Value, fecha_final, 100, nivel_requerido, id_ponderacion, descripcion)
                        Else
                            RE = SqlQuery.Agregar_programacion(cb_codigo, DataGridView1.Item("Identificador", e.RowIndex).Value, Nothing, fecha_final, 100, nivel_requerido, id_ponderacion, descripcion)
                        End If
                        If RE = 1 Then
                            cargar_tabla()
                        End If

                    End If
                    fecha.Dispose()
                    fecha = Nothing

                Case "Otras calificaciones"
                    If DataGridView1.Item("Tipo", e.RowIndex).Value = "Curso" Then
                        cargar_tabla2(Nothing, DataGridView1.Item("Identificador", e.RowIndex).Value.ToString)
                    Else
                        cargar_tabla2(DataGridView1.Item("Identificador", e.RowIndex).Value, Nothing)
                    End If


                Case ""

                Case Else

            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        If keyData = Keys.Escape Then
            If Panel1.Visible = True Then
                Panel1.Visible = False
            Else
                Me.Close()
            End If

        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class