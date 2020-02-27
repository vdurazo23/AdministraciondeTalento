
Imports System.Reflection

Public Class Caracteristicas
    Dim midataset As New DataSet
    Dim Pestaña As Integer
    Dim Caracteristicaa As String = ""
    Dim rf1 As String = "   "
    Dim rf2 As String = "   and 1 = 1"


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            cargar_combobox()
            cargar_informacion()
            btn_Competencias.PerformClick()
            DataGridView1.Columns("Conocimiento").Visible = False
            DataGridView1.Columns("Habilidad").Visible = False
            DataGridView1.Columns("Competencia").Visible = False
            DataGridView1.Columns("Curso").Visible = False

            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            DataGridView1.Columns(2).SortMode = False
            DataGridView1.Columns(3).SortMode = False
        Catch ex As Exception
            MsgBox(ex.Message)
            SqlQuery.Save_Error(ex)
        End Try

    End Sub


    Private Sub cargar_combobox()
        'Try
        '    Dim info1 As New DataTable
        '    info1 = SqlQuery.categorias.Copy
        '    info1.TableName = "Categorias"

        '    If midataset.Tables("Categorias") IsNot Nothing Then
        '        midataset.Tables.Remove("Categorias")
        '    End If

        '    midataset.Tables.Add(info1)
        '    ComboBox1.DataSource = Nothing
        '    ComboBox1.DataSource = info1
        '    ComboBox1.ValueMember = "Id"
        '    ComboBox1.DisplayMember = "Categoria"

        '    Dim info2 As DataTable = SqlQuery.Departamentos
        '    ComboBox2.DataSource = info2

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        'End Try

    End Sub

    Public Sub EnableDoubleBuffered(ByVal dgv As DataGridView)

        Dim dgvType As Type = dgv.[GetType]()

        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance Or BindingFlags.NonPublic)

        pi.SetValue(dgv, True, Nothing)



    End Sub
    Private Sub cargar_informacion()
        Try


            Dim info As DataTable
            DataGridView1.DataSource = Nothing
            info = SqlQuery.cargarCaracteristicas().Copy
            info.TableName = "Caracteristicas"
            Dim rofil As String = ""
            If midataset.Tables("Caracteristicas") IsNot Nothing Then
                rofil = midataset.Tables("Caracteristicas").DefaultView.RowFilter
                midataset.Tables.Remove("Caracteristicas")
            End If
            midataset.Tables.Add(info)
            DataGridView1.DataSource = midataset.Tables("Caracteristicas")
            midataset.Tables("Caracteristicas").DefaultView.RowFilter = rofil
            If btn_Competencias.Enabled = True Then
                DataGridView1.Columns(10).Visible = False
            End If
            EnableDoubleBuffered(DataGridView1)
        Catch ex As Exception
            SqlQuery.Save_Error(ex, "Al cargar información en datagridview1")
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Competencias.Click
        Try
            Caracteristicaa = "Competencia"
            Label5.Text = "Competencias"
            btn_Competencias.Enabled = False
            btn_Habilidades.Enabled = True
            Btn_conocimiento.Enabled = True
            ' btn_curso.Enabled = True
            rf1 = "Competencia = True "
            midataset.Tables("Caracteristicas").DefaultView.RowFilter = rf1 & rf2
            DataGridView1.Columns("Nivel").Visible = True
        Catch ex As Exception
            SqlQuery.Save_Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_Habilidades.Click
        Try
            Caracteristicaa = "Habilidad"
            Label5.Text = "Responsabilidades"
            btn_Competencias.Enabled = True
            btn_Habilidades.Enabled = False
            Btn_conocimiento.Enabled = True
            '  btn_curso.Enabled = True
            rf1 = " Habilidad = True "
            midataset.Tables("Caracteristicas").DefaultView.RowFilter = rf1 & rf2
            DataGridView1.Columns("Nivel").Visible = False
        Catch ex As Exception
            SqlQuery.Save_Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btn_curso.Click
        Try
            Exit Sub
            Caracteristicaa = "Curso"
            Label5.Text = "Cursos"
            btn_Competencias.Enabled = True
            btn_Habilidades.Enabled = True
            Btn_conocimiento.Enabled = True
            btn_curso.Enabled = False
            rf1 = " Curso = True "
            midataset.Tables("Caracteristicas").DefaultView.RowFilter = rf1 & rf2
            DataGridView1.Columns("Nivel").Visible = False
        Catch ex As Exception
            SqlQuery.Save_Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Btn_conocimiento_Click(sender As Object, e As EventArgs) Handles Btn_conocimiento.Click
        Try
            Caracteristicaa = "Conocimiento"
            Label5.Text = "Conocimiento"
            btn_Competencias.Enabled = True
            btn_Habilidades.Enabled = True
            Btn_conocimiento.Enabled = False
            '  btn_curso.Enabled = True
            rf1 = " Conocimiento = True "
            midataset.Tables("Caracteristicas").DefaultView.RowFilter = rf1 & rf2
            DataGridView1.Columns("Nivel").Visible = False
        Catch ex As Exception
            SqlQuery.Save_Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

#Region "Competencias"

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If Not Permiso.Habilitado("AC") Then
                MsgBox("No tiene permisos para agregar caracteristicas")
                Exit Sub
            End If
            Dim c As New Agregar_caracteristica
            c.caracteristicas = Caracteristicaa
            If c.ShowDialog = DialogResult.OK Then
                cargar_informacion()
                DataGridView1.Columns("Competencia").Visible = False
                DataGridView1.Columns("Habilidad").Visible = False
                DataGridView1.Columns("Conocimiento").Visible = False
                DataGridView1.Columns("Curso").Visible = False
                DataGridView1.Columns("Id").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

#Region "Habilidades"

#End Region

#Region "Conocimiento"


#End Region

#Region "General"





    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Try


        Catch ex As Exception
            Reset()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Try
            GroupBox1.Enabled = True

            Button4.Enabled = True
            Reset()


        Catch ex As Exception
            Reset()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Try


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try




        Catch ex As Exception
            SqlQuery.Save_Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
                Exit Sub
            End If


            If DataGridView1.Rows(e.RowIndex).Cells("Creado_Id_User").Value = My.Settings.Id_user Then
                If Not Permiso.Habilitado("ECCRE") And Not Permiso.Habilitado("RCCRE") Then
                    MsgBox("No tienes permisos para editar o relacionar esta caracteristica", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            ElseIf My.Settings.Permisos.Select("Permiso = 'ECC'").Count < 1 Then
                If Not Permiso.Habilitado("ECC") And Not Permiso.Habilitado("RCC") Then
                    MsgBox("No tienes permisos para editar o relacionar esta caracteristica", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            Dim c As New Agregar_caracteristica
            c.TextBox1.Text = CType(sender, DataGridView).Item("Descripcion", e.RowIndex).Value.ToString
            c.TextBox2.Text = CType(sender, DataGridView).Item("Description", e.RowIndex).Value.ToString
            c.Id = CType(sender, DataGridView).Item(0, e.RowIndex).Value
            c.caracteristicas = Caracteristicaa
            c.nuevo = False

            c.TXT_QUE.Text = CType(sender, DataGridView).Item("Desarrollo de meta, que y por que", e.RowIndex).Value.ToString
            c.TXT_WHAT.Text = CType(sender, DataGridView).Item("Development Goal-Do + What + Why", e.RowIndex).Value.ToString
            c.TXT_COMO.Text = CType(sender, DataGridView).Item("Como", e.RowIndex).Value.ToString
            c.TXT_HOW.Text = CType(sender, DataGridView).Item("How", e.RowIndex).Value.ToString
            c.TXT_RECURSOS.Text = CType(sender, DataGridView).Item("Recursos", e.RowIndex).Value.ToString
            c.TXT_RESOURCES.Text = CType(sender, DataGridView).Item("Resources", e.RowIndex).Value.ToString
            c.TXT_EXTRA.Text = CType(sender, DataGridView).Item("Extraordinario", e.RowIndex).Value.ToString
            c.id_creador = DataGridView1.Rows(e.RowIndex).Cells("Creado_Id_User").Value
            If Caracteristicaa = "Competencia" Then
                If CType(sender, DataGridView).Item(DataGridView1.Columns.Count - 1, e.RowIndex).Value.ToString <> "" Then
                    c.nivel_competencia = CType(sender, DataGridView).Item(DataGridView1.Columns.Count - 1, e.RowIndex).Value
                End If
            End If
            Dim res = c.ShowDialog()
            If res = DialogResult.OK Then
                cargar_informacion()
                '  btn_Competencias.PerformClick()
                DataGridView1.Columns("Competencia").Visible = False
                DataGridView1.Columns("Habilidad").Visible = False
                DataGridView1.Columns("Conocimiento").Visible = False
                DataGridView1.Columns("Curso").Visible = False
                DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            ElseIf res = DialogResult.Cancel Then

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If DataGridView1.CurrentRow.Index < 0 Then
                MsgBox("Seleccione un indice valido", MsgBoxStyle.Information)
                Exit Sub
            End If
            If DataGridView1.CurrentRow.Cells("Creado_Id_User").Value = My.Settings.Id_user Then
                If Not Permiso.Habilitado("ELCCRE") Then
                    MsgBox("No tiene permisos para eliminar este registro.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

            Else
                If Not Permiso.Habilitado("ELCC") Then
                    MsgBox("No tiene permisos para eliminar este registro.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
            If MsgBox("Seguro que desea eliminar la caracteristica: 
      
" & DataGridView1.CurrentRow.Cells("Id").Value.ToString & " - " & DataGridView1.CurrentRow.Cells("Descripcion").Value.ToString & "

Se eliminaran todas sus relaciones, asi como las evaluaciones ligadas a dicha caracteristica", MsgBoxStyle.Critical + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                'Eliminar y volver a cargar
                If SqlQuery.EliminarCaracteristica(DataGridView1.CurrentRow.Cells("Id").Value) = True Then
                    cargar_informacion()
                    DataGridView1.Columns("Competencia").Visible = False
                    DataGridView1.Columns("Habilidad").Visible = False
                    DataGridView1.Columns("Conocimiento").Visible = False
                    DataGridView1.Columns("Curso").Visible = False
                    DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If CType(sender, TextBox).Text.Trim = "" Then
                rf2 = " and 1 = 1"


            Else
                rf2 = "and Descripcion like '%" & CType(sender, TextBox).Text.Trim & "%' "
            End If
            midataset.Tables("Caracteristicas").DefaultView.RowFilter = rf1 & rf2

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

    'Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    'End Sub
    'Private Sub ArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchivoToolStripMenuItem.Click

    'End Sub
    'Private m_ChildFormNumber As Integer
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim ChildForm As New System.Windows.Forms.Form
    '    ' Conviértalo en un elemento secundario de este formulario MDI antes de mostrarlo.
    '    ChildForm.MdiParent = Me


    '    m_ChildFormNumber += 1
    '    ChildForm.Text = "Ventana " & m_ChildFormNumber
    '    Dim la As New Label

    '    la.Text = m_ChildFormNumber.ToString
    '    ChildForm.Controls.Add(la)

    '    ChildForm.Show()
    '    Dim but As New Button
    '    but.Dock = DockStyle.Top
    '    .Text = "Ventana" & " " & m_ChildFormNumber
    '    but.Tag = m_ChildFormNumber
    '    but.BackColor = Color.Black
    '    but.BackColor = Color.White
    '    '    but.UseVisualStyleBackColor = True
    '    AddHandler but.Click, AddressOf seleccionar_ventana
    '    SplitContainer1.Panel1.Controls.Add(but)
    'End Sub

    'Private Sub seleccionar_ventana(sender As Object, e As EventArgs)
    '    Try
    '        Me.MdiChildren(sender.tag - 1).BringToFront()

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "EROR")
    '    End Try
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    'End Sub

    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    Try
    '        Dim conf As New Competencias
    '        conf.MdiParent = Me
    '        conf.Show()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
    '    End Try
    'End Sub
End Class
