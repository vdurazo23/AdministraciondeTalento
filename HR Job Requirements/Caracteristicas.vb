
Public Class Caracteristicas
    Dim midataset As New DataSet
    Dim Pestaña As Integer
    Dim Caracteristicaa As String = ""



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            cargar_combobox()
            cargar_informacion()
            btn_Competencias.PerformClick()
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
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

            midataset.Tables("Caracteristicas").DefaultView.RowFilter = "Competencia = True "
        Catch ex As Exception
            SqlQuery.Save_Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_Habilidades.Click
        Try
            Caracteristicaa = "Habilidad"
            Label5.Text = "Habilidades"
            btn_Competencias.Enabled = True
            btn_Habilidades.Enabled = False
            Btn_conocimiento.Enabled = True
            midataset.Tables("Caracteristicas").DefaultView.RowFilter = " Habilidad = True "
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

            midataset.Tables("Caracteristicas").DefaultView.RowFilter = " Conocimiento = True"
        Catch ex As Exception
            SqlQuery.Save_Error(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


#Region "Competencias"

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim c As New Agregar_caracteristica
            c.caracteristicas = Caracteristicaa
            If c.ShowDialog = DialogResult.OK Then

                cargar_informacion()

                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).Visible = False
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
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

    Private Sub Com_fil_uno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_fil_uno.SelectedIndexChanged
        Try
            If CType(sender, ComboBox).SelectedIndex = 0 Then
                'Cargar niveles 

                Com_fil_dos.DataSource = Nothing


            ElseIf CType(sender, ComboBox).SelectedIndex > 0 Then
                'Cargar Puestos



            Else
                Com_fil_dos.SelectedIndex = -1
                Com_fil_dos.DataSource = Nothing
                

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Try
            Dim c As New Agregar_caracteristica
            c.TextBox1.Text = CType(sender, DataGridView).Item(1, e.RowIndex).Value.ToString
            c.Id = CType(sender, DataGridView).Item(0, e.RowIndex).Value
            c.caracteristicas = Caracteristicaa
            c.nuevo = False
            Dim res = c.ShowDialog()
            If res = DialogResult.OK Then
                cargar_informacion()
                '  btn_Competencias.PerformClick()
                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).Visible = False
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            ElseIf res = DialogResult.Cancel Then


            End If



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

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
