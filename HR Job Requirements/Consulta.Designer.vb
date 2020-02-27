<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Consulta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Consulta))
        Me.Cmb_dpto = New System.Windows.Forms.ComboBox()
        Me.No_empleado = New System.Windows.Forms.TextBox()
        Me.txt_antiguedad_puesto = New System.Windows.Forms.TextBox()
        Me.txt_antiguedad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TLP_Requerimientos = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_antiguedad_puesto_AÑOS = New System.Windows.Forms.TextBox()
        Me.txt_antiguedad_AÑOS = New System.Windows.Forms.TextBox()
        Me.Cmb_nom = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmb_pto = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.Caracteristica1 = New Administracion_de_talento.Caracteristica()
        Me.Progress_competencias = New Administracion_de_talento.Progress()
        Me.Progress_habilidades = New Administracion_de_talento.Progress()
        Me.Progress_conocimiento = New Administracion_de_talento.Progress()
        Me.Progress_curso = New Administracion_de_talento.Progress()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.TLP_Requerimientos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmb_dpto
        '
        Me.Cmb_dpto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_dpto.FormattingEnabled = True
        Me.Cmb_dpto.Location = New System.Drawing.Point(191, 21)
        Me.Cmb_dpto.Name = "Cmb_dpto"
        Me.Cmb_dpto.Size = New System.Drawing.Size(345, 21)
        Me.Cmb_dpto.TabIndex = 9
        '
        'No_empleado
        '
        Me.No_empleado.Enabled = False
        Me.No_empleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.No_empleado.Location = New System.Drawing.Point(191, 86)
        Me.No_empleado.Name = "No_empleado"
        Me.No_empleado.Size = New System.Drawing.Size(97, 29)
        Me.No_empleado.TabIndex = 8
        '
        'txt_antiguedad_puesto
        '
        Me.txt_antiguedad_puesto.Enabled = False
        Me.txt_antiguedad_puesto.Location = New System.Drawing.Point(350, 117)
        Me.txt_antiguedad_puesto.Name = "txt_antiguedad_puesto"
        Me.txt_antiguedad_puesto.Size = New System.Drawing.Size(100, 20)
        Me.txt_antiguedad_puesto.TabIndex = 7
        Me.txt_antiguedad_puesto.Text = "No registrado"
        Me.txt_antiguedad_puesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_antiguedad
        '
        Me.txt_antiguedad.Enabled = False
        Me.txt_antiguedad.Location = New System.Drawing.Point(350, 93)
        Me.txt_antiguedad.Name = "txt_antiguedad"
        Me.txt_antiguedad.Size = New System.Drawing.Size(100, 20)
        Me.txt_antiguedad.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(216, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Antiguedad en el puesto :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(280, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Antiguedad:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(190, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 25)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "No. Empleado"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TLP_Requerimientos)
        Me.GroupBox1.Controls.Add(Me.txt_antiguedad_puesto_AÑOS)
        Me.GroupBox1.Controls.Add(Me.txt_antiguedad_AÑOS)
        Me.GroupBox1.Controls.Add(Me.Cmb_nom)
        Me.GroupBox1.Controls.Add(Me.txt_antiguedad_puesto)
        Me.GroupBox1.Controls.Add(Me.txt_antiguedad)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1324, 160)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'TLP_Requerimientos
        '
        Me.TLP_Requerimientos.ColumnCount = 4
        Me.TLP_Requerimientos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TLP_Requerimientos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TLP_Requerimientos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TLP_Requerimientos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TLP_Requerimientos.Controls.Add(Me.Label11, 3, 1)
        Me.TLP_Requerimientos.Controls.Add(Me.Label10, 0, 0)
        Me.TLP_Requerimientos.Controls.Add(Me.Progress_competencias, 0, 2)
        Me.TLP_Requerimientos.Controls.Add(Me.Label7, 0, 1)
        Me.TLP_Requerimientos.Controls.Add(Me.Label8, 1, 1)
        Me.TLP_Requerimientos.Controls.Add(Me.Label9, 2, 1)
        Me.TLP_Requerimientos.Controls.Add(Me.Progress_habilidades, 1, 2)
        Me.TLP_Requerimientos.Controls.Add(Me.Progress_conocimiento, 2, 2)
        Me.TLP_Requerimientos.Controls.Add(Me.Progress_curso, 3, 2)
        Me.TLP_Requerimientos.Location = New System.Drawing.Point(648, 13)
        Me.TLP_Requerimientos.Name = "TLP_Requerimientos"
        Me.TLP_Requerimientos.RowCount = 3
        Me.TLP_Requerimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TLP_Requerimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.66667!))
        Me.TLP_Requerimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.33334!))
        Me.TLP_Requerimientos.Size = New System.Drawing.Size(525, 141)
        Me.TLP_Requerimientos.TabIndex = 4
        Me.TLP_Requerimientos.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Gainsboro
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(396, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 30)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Cursos"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.TLP_Requerimientos.SetColumnSpan(Me.Label10, 4)
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(519, 21)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Requerimientos"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 30)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Competencias y habilidades"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Gainsboro
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(134, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 30)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Responsabilidades"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Gainsboro
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(265, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 30)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Conocimiento"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_antiguedad_puesto_AÑOS
        '
        Me.txt_antiguedad_puesto_AÑOS.Enabled = False
        Me.txt_antiguedad_puesto_AÑOS.Location = New System.Drawing.Point(456, 117)
        Me.txt_antiguedad_puesto_AÑOS.Name = "txt_antiguedad_puesto_AÑOS"
        Me.txt_antiguedad_puesto_AÑOS.Size = New System.Drawing.Size(100, 20)
        Me.txt_antiguedad_puesto_AÑOS.TabIndex = 12
        '
        'txt_antiguedad_AÑOS
        '
        Me.txt_antiguedad_AÑOS.Enabled = False
        Me.txt_antiguedad_AÑOS.Location = New System.Drawing.Point(456, 93)
        Me.txt_antiguedad_AÑOS.Name = "txt_antiguedad_AÑOS"
        Me.txt_antiguedad_AÑOS.Size = New System.Drawing.Size(100, 20)
        Me.txt_antiguedad_AÑOS.TabIndex = 11
        '
        'Cmb_nom
        '
        Me.Cmb_nom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_nom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_nom.FormattingEnabled = True
        Me.Cmb_nom.Location = New System.Drawing.Point(243, 66)
        Me.Cmb_nom.Name = "Cmb_nom"
        Me.Cmb_nom.Size = New System.Drawing.Size(312, 24)
        Me.Cmb_nom.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(5, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(134, 137)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 25)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Departamento"
        '
        'Cmb_pto
        '
        Me.Cmb_pto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_pto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_pto.FormattingEnabled = True
        Me.Cmb_pto.Location = New System.Drawing.Point(191, 56)
        Me.Cmb_pto.Name = "Cmb_pto"
        Me.Cmb_pto.Size = New System.Drawing.Size(345, 24)
        Me.Cmb_pto.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(79, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 25)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Puesto"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel2.Location = New System.Drawing.Point(12, 314)
        Me.Panel2.MinimumSize = New System.Drawing.Size(1324, 349)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1324, 358)
        Me.Panel2.TabIndex = 11
        Me.Panel2.Visible = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Caracteristica1, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1320, 354)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1314, 295)
        Me.Panel1.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1314, 0)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Cmb_pto)
        Me.Panel3.Controls.Add(Me.Cmb_dpto)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.No_empleado)
        Me.Panel3.Location = New System.Drawing.Point(12, 10)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(570, 132)
        Me.Panel3.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_buscar_cliente_50
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(294, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 38)
        Me.Button1.TabIndex = 10
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "00.png")
        Me.ImageList1.Images.SetKeyName(1, "01.png")
        Me.ImageList1.Images.SetKeyName(2, "02.png")
        Me.ImageList1.Images.SetKeyName(3, "03.png")
        Me.ImageList1.Images.SetKeyName(4, "04.png")
        Me.ImageList1.Images.SetKeyName(5, "05.png")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "000.png")
        Me.ImageList2.Images.SetKeyName(1, "001.png")
        Me.ImageList2.Images.SetKeyName(2, "002.png")
        Me.ImageList2.Images.SetKeyName(3, "003.png")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button7)
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Location = New System.Drawing.Point(588, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(629, 132)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_lazo_marcapáginas_64
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(526, 17)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(96, 109)
        Me.Button7.TabIndex = 18
        Me.Button7.Text = "IDP"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_detalles_emergentes_64
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(424, 17)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(96, 109)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "Detalles"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.report256_24829
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(16, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 109)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Reporte"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_tarea_completada_64
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(322, 17)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(96, 109)
        Me.Button5.TabIndex = 16
        Me.Button5.Text = "Objetivos"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.university_cap_icon_icons_com_66109
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Enabled = False
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(118, 17)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 109)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Cursos"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources._4288584andbusinessfinancepersonalportfolioprofileresume_115772_115741
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button4.Enabled = False
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(220, 17)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(96, 109)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Currículum"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "OK.png")
        Me.ImageList3.Images.SetKeyName(1, "okk.png")
        '
        'ImageList4
        '
        Me.ImageList4.ImageStream = CType(resources.GetObject("ImageList4.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList4.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList4.Images.SetKeyName(0, "1000.png")
        Me.ImageList4.Images.SetKeyName(1, "1001.png")
        Me.ImageList4.Images.SetKeyName(2, "1002.png")
        Me.ImageList4.Images.SetKeyName(3, "1003.png")
        Me.ImageList4.Images.SetKeyName(4, "1004.png")
        '
        'Caracteristica1
        '
        Me.Caracteristica1.BackColor = System.Drawing.Color.Navy
        Me.Caracteristica1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Caracteristica1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Caracteristica1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Caracteristica1.ForeColor = System.Drawing.Color.White
        Me.Caracteristica1.Location = New System.Drawing.Point(3, 3)
        Me.Caracteristica1.Name = "Caracteristica1"
        Me.Caracteristica1.Padding = New System.Windows.Forms.Padding(30, 0, 15, 0)
        Me.Caracteristica1.Size = New System.Drawing.Size(1314, 47)
        Me.Caracteristica1.TabIndex = 3
        '
        'Progress_competencias
        '
        Me.Progress_competencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Progress_competencias.Location = New System.Drawing.Point(3, 58)
        Me.Progress_competencias.Name = "Progress_competencias"
        Me.Progress_competencias.Size = New System.Drawing.Size(125, 80)
        Me.Progress_competencias.TabIndex = 4
        Me.Progress_competencias.Valor = 15
        '
        'Progress_habilidades
        '
        Me.Progress_habilidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Progress_habilidades.Location = New System.Drawing.Point(134, 58)
        Me.Progress_habilidades.Name = "Progress_habilidades"
        Me.Progress_habilidades.Size = New System.Drawing.Size(125, 80)
        Me.Progress_habilidades.TabIndex = 5
        Me.Progress_habilidades.Valor = 0
        '
        'Progress_conocimiento
        '
        Me.Progress_conocimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Progress_conocimiento.Location = New System.Drawing.Point(265, 58)
        Me.Progress_conocimiento.Name = "Progress_conocimiento"
        Me.Progress_conocimiento.Size = New System.Drawing.Size(125, 80)
        Me.Progress_conocimiento.TabIndex = 6
        Me.Progress_conocimiento.Valor = 0
        '
        'Progress_curso
        '
        Me.Progress_curso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Progress_curso.Location = New System.Drawing.Point(396, 58)
        Me.Progress_curso.Name = "Progress_curso"
        Me.Progress_curso.Size = New System.Drawing.Size(126, 80)
        Me.Progress_curso.TabIndex = 8
        Me.Progress_curso.Valor = 0
        '
        'Timer1
        '
        '
        'Consulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1348, 684)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MinimumSize = New System.Drawing.Size(1364, 723)
        Me.Name = "Consulta"
        Me.Text = "Consulta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TLP_Requerimientos.ResumeLayout(False)
        Me.TLP_Requerimientos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Cmb_dpto As ComboBox
    Friend WithEvents No_empleado As TextBox
    Friend WithEvents txt_antiguedad_puesto As TextBox
    Friend WithEvents txt_antiguedad As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Cmb_pto As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Cmb_nom As ComboBox
    Friend WithEvents txt_antiguedad_puesto_AÑOS As TextBox
    Friend WithEvents txt_antiguedad_AÑOS As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Progress_competencias As Progress
    Friend WithEvents TLP_Requerimientos As TableLayoutPanel
    Friend WithEvents Progress_habilidades As Progress
    Friend WithEvents Progress_conocimiento As Progress
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Caracteristica1 As Caracteristica
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label11 As Label
    Friend WithEvents Progress_curso As Progress
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Button5 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ImageList3 As ImageList
    Friend WithEvents ImageList4 As ImageList
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Timer1 As Timer
End Class
