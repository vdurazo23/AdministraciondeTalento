<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Prueba
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txt_antiguedad_puesto_AÑOS = New System.Windows.Forms.TextBox()
        Me.txt_antiguedad_AÑOS = New System.Windows.Forms.TextBox()
        Me.Cmb_nom = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.No_empleado = New System.Windows.Forms.TextBox()
        Me.txt_antiguedad_puesto = New System.Windows.Forms.TextBox()
        Me.txt_antiguedad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmb_dpto = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmb_pto = New System.Windows.Forms.ComboBox()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Location = New System.Drawing.Point(11, 269)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1030, 327)
        Me.Panel2.TabIndex = 17
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, -2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1019, 49)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Chart3)
        Me.GroupBox1.Controls.Add(Me.Chart2)
        Me.GroupBox1.Controls.Add(Me.Chart1)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.txt_antiguedad_puesto_AÑOS)
        Me.GroupBox1.Controls.Add(Me.txt_antiguedad_AÑOS)
        Me.GroupBox1.Controls.Add(Me.Cmb_nom)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.No_empleado)
        Me.GroupBox1.Controls.Add(Me.txt_antiguedad_puesto)
        Me.GroupBox1.Controls.Add(Me.txt_antiguedad)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1030, 171)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Chart3
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart3.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart3.Legends.Add(Legend1)
        Me.Chart3.Location = New System.Drawing.Point(873, 63)
        Me.Chart3.Name = "Chart3"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart3.Series.Add(Series1)
        Me.Chart3.Size = New System.Drawing.Size(146, 96)
        Me.Chart3.TabIndex = 18
        Me.Chart3.Text = "v"
        '
        'Chart2
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(721, 63)
        Me.Chart2.Name = "Chart2"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(146, 96)
        Me.Chart2.TabIndex = 17
        Me.Chart2.Text = "v"
        '
        'Chart1
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend3)
        Me.Chart1.Location = New System.Drawing.Point(569, 63)
        Me.Chart1.Name = "Chart1"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series3.Legend = "Legend1"
        Series3.Name = "Conocimiento"
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(146, 92)
        Me.Chart1.TabIndex = 16
        Me.Chart1.Text = "v"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(823, 19)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(99, 28)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Currículum"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(718, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(99, 28)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Cursos"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(613, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 28)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Reporte"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txt_antiguedad_puesto_AÑOS
        '
        Me.txt_antiguedad_puesto_AÑOS.Enabled = False
        Me.txt_antiguedad_puesto_AÑOS.Location = New System.Drawing.Point(439, 139)
        Me.txt_antiguedad_puesto_AÑOS.Name = "txt_antiguedad_puesto_AÑOS"
        Me.txt_antiguedad_puesto_AÑOS.Size = New System.Drawing.Size(100, 20)
        Me.txt_antiguedad_puesto_AÑOS.TabIndex = 12
        '
        'txt_antiguedad_AÑOS
        '
        Me.txt_antiguedad_AÑOS.Enabled = False
        Me.txt_antiguedad_AÑOS.Location = New System.Drawing.Point(439, 115)
        Me.txt_antiguedad_AÑOS.Name = "txt_antiguedad_AÑOS"
        Me.txt_antiguedad_AÑOS.Size = New System.Drawing.Size(100, 20)
        Me.txt_antiguedad_AÑOS.TabIndex = 11
        '
        'Cmb_nom
        '
        Me.Cmb_nom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_nom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_nom.FormattingEnabled = True
        Me.Cmb_nom.Location = New System.Drawing.Point(226, 88)
        Me.Cmb_nom.Name = "Cmb_nom"
        Me.Cmb_nom.Size = New System.Drawing.Size(312, 24)
        Me.Cmb_nom.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_buscar_cliente_50
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(493, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 38)
        Me.Button1.TabIndex = 10
        Me.Button1.UseVisualStyleBackColor = True
        '
        'No_empleado
        '
        Me.No_empleado.Enabled = False
        Me.No_empleado.Location = New System.Drawing.Point(403, 46)
        Me.No_empleado.Name = "No_empleado"
        Me.No_empleado.Size = New System.Drawing.Size(84, 20)
        Me.No_empleado.TabIndex = 8
        '
        'txt_antiguedad_puesto
        '
        Me.txt_antiguedad_puesto.Enabled = False
        Me.txt_antiguedad_puesto.Location = New System.Drawing.Point(333, 139)
        Me.txt_antiguedad_puesto.Name = "txt_antiguedad_puesto"
        Me.txt_antiguedad_puesto.Size = New System.Drawing.Size(100, 20)
        Me.txt_antiguedad_puesto.TabIndex = 7
        Me.txt_antiguedad_puesto.Text = "No registrado"
        Me.txt_antiguedad_puesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_antiguedad
        '
        Me.txt_antiguedad.Enabled = False
        Me.txt_antiguedad.Location = New System.Drawing.Point(333, 115)
        Me.txt_antiguedad.Name = "txt_antiguedad"
        Me.txt_antiguedad.Size = New System.Drawing.Size(100, 20)
        Me.txt_antiguedad.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(199, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Antiguedad en el puesto :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(263, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Antiguedad:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(173, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(320, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "No. Empleado:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(6, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(134, 154)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(78, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 25)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Puesto"
        '
        'Cmb_dpto
        '
        Me.Cmb_dpto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_dpto.FormattingEnabled = True
        Me.Cmb_dpto.Location = New System.Drawing.Point(165, 15)
        Me.Cmb_dpto.Name = "Cmb_dpto"
        Me.Cmb_dpto.Size = New System.Drawing.Size(345, 21)
        Me.Cmb_dpto.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 25)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Departamento"
        '
        'Cmb_pto
        '
        Me.Cmb_pto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_pto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_pto.FormattingEnabled = True
        Me.Cmb_pto.Location = New System.Drawing.Point(165, 50)
        Me.Cmb_pto.Name = "Cmb_pto"
        Me.Cmb_pto.Size = New System.Drawing.Size(345, 24)
        Me.Cmb_pto.TabIndex = 13
        '
        'Prueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 710)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cmb_dpto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Cmb_pto)
        Me.Name = "Prueba"
        Me.Text = "Prueba"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Chart3 As DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents txt_antiguedad_puesto_AÑOS As TextBox
    Friend WithEvents txt_antiguedad_AÑOS As TextBox
    Friend WithEvents Cmb_nom As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents No_empleado As TextBox
    Friend WithEvents txt_antiguedad_puesto As TextBox
    Friend WithEvents txt_antiguedad As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Cmb_dpto As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Cmb_pto As ComboBox
End Class
