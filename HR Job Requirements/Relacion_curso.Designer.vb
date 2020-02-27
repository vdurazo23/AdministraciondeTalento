<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Relacion_curso
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
        Me.components = New System.ComponentModel.Container()
        Me.cmb_pond = New System.Windows.Forms.ComboBox()
        Me.lbl_pond = New System.Windows.Forms.Label()
        Me.pic_pond = New System.Windows.Forms.PictureBox()
        Me.Btn_puesto_tope = New System.Windows.Forms.Button()
        Me.txt_puesto_tope = New System.Windows.Forms.TextBox()
        Me.lbl_puestoTope = New System.Windows.Forms.Label()
        Me.cmb_heredado = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Btn_puesto = New System.Windows.Forms.Button()
        Me.lbl_nivel = New System.Windows.Forms.Label()
        Me.txt_puesto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_rel = New System.Windows.Forms.ComboBox()
        Me.cmb_requerido = New System.Windows.Forms.ComboBox()
        Me.cmb_nivel = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        CType(Me.pic_pond, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_pond
        '
        Me.cmb_pond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_pond.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_pond.FormattingEnabled = True
        Me.cmb_pond.Location = New System.Drawing.Point(302, 35)
        Me.cmb_pond.Name = "cmb_pond"
        Me.cmb_pond.Size = New System.Drawing.Size(146, 33)
        Me.cmb_pond.TabIndex = 35
        Me.cmb_pond.Visible = False
        '
        'lbl_pond
        '
        Me.lbl_pond.AutoSize = True
        Me.lbl_pond.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pond.Location = New System.Drawing.Point(298, 9)
        Me.lbl_pond.Name = "lbl_pond"
        Me.lbl_pond.Size = New System.Drawing.Size(98, 20)
        Me.lbl_pond.TabIndex = 34
        Me.lbl_pond.Text = "Ponderación"
        Me.lbl_pond.Visible = False
        '
        'pic_pond
        '
        Me.pic_pond.Image = Global.Administracion_de_talento.My.Resources.Resources._1004
        Me.pic_pond.Location = New System.Drawing.Point(317, 74)
        Me.pic_pond.Name = "pic_pond"
        Me.pic_pond.Size = New System.Drawing.Size(115, 92)
        Me.pic_pond.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_pond.TabIndex = 33
        Me.pic_pond.TabStop = False
        Me.pic_pond.Visible = False
        '
        'Btn_puesto_tope
        '
        Me.Btn_puesto_tope.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_búsqueda_50
        Me.Btn_puesto_tope.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btn_puesto_tope.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_puesto_tope.Location = New System.Drawing.Point(361, 296)
        Me.Btn_puesto_tope.Name = "Btn_puesto_tope"
        Me.Btn_puesto_tope.Size = New System.Drawing.Size(45, 31)
        Me.Btn_puesto_tope.TabIndex = 31
        Me.Btn_puesto_tope.UseVisualStyleBackColor = True
        '
        'txt_puesto_tope
        '
        Me.txt_puesto_tope.Enabled = False
        Me.txt_puesto_tope.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_puesto_tope.Location = New System.Drawing.Point(31, 296)
        Me.txt_puesto_tope.Name = "txt_puesto_tope"
        Me.txt_puesto_tope.Size = New System.Drawing.Size(324, 31)
        Me.txt_puesto_tope.TabIndex = 30
        '
        'lbl_puestoTope
        '
        Me.lbl_puestoTope.AutoSize = True
        Me.lbl_puestoTope.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_puestoTope.Location = New System.Drawing.Point(12, 273)
        Me.lbl_puestoTope.Name = "lbl_puestoTope"
        Me.lbl_puestoTope.Size = New System.Drawing.Size(95, 20)
        Me.lbl_puestoTope.TabIndex = 29
        Me.lbl_puestoTope.Text = "Puesto tope"
        '
        'cmb_heredado
        '
        Me.cmb_heredado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_heredado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_heredado.FormattingEnabled = True
        Me.cmb_heredado.Items.AddRange(New Object() {"Solo puesto", "Se escalona", "Se hereda"})
        Me.cmb_heredado.Location = New System.Drawing.Point(31, 237)
        Me.cmb_heredado.Name = "cmb_heredado"
        Me.cmb_heredado.Size = New System.Drawing.Size(191, 33)
        Me.cmb_heredado.TabIndex = 28
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(16, 376)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(80, 28)
        Me.CheckBox1.TabIndex = 27
        Me.CheckBox1.Text = "Activo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button3.Location = New System.Drawing.Point(379, 363)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 57)
        Me.Button3.TabIndex = 26
        Me.Button3.Text = "Cancelar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.Location = New System.Drawing.Point(283, 363)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 57)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Aceptar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Btn_puesto
        '
        Me.Btn_puesto.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_búsqueda_50
        Me.Btn_puesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btn_puesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_puesto.Location = New System.Drawing.Point(361, 200)
        Me.Btn_puesto.Name = "Btn_puesto"
        Me.Btn_puesto.Size = New System.Drawing.Size(45, 31)
        Me.Btn_puesto.TabIndex = 24
        Me.Btn_puesto.UseVisualStyleBackColor = True
        '
        'lbl_nivel
        '
        Me.lbl_nivel.AutoSize = True
        Me.lbl_nivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nivel.Location = New System.Drawing.Point(12, 177)
        Me.lbl_nivel.Name = "lbl_nivel"
        Me.lbl_nivel.Size = New System.Drawing.Size(188, 20)
        Me.lbl_nivel.TabIndex = 23
        Me.lbl_nivel.Text = "Nivel / Puesto / Empleado"
        '
        'txt_puesto
        '
        Me.txt_puesto.Enabled = False
        Me.txt_puesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_puesto.Location = New System.Drawing.Point(31, 200)
        Me.txt_puesto.Name = "txt_puesto"
        Me.txt_puesto.Size = New System.Drawing.Size(324, 31)
        Me.txt_puesto.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Tipo de relación"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Requerido por"
        '
        'cmb_rel
        '
        Me.cmb_rel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_rel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_rel.FormattingEnabled = True
        Me.cmb_rel.Items.AddRange(New Object() {"Por Nivel", "Por Puesto", "Por Número de Empleado"})
        Me.cmb_rel.Location = New System.Drawing.Point(30, 109)
        Me.cmb_rel.Name = "cmb_rel"
        Me.cmb_rel.Size = New System.Drawing.Size(255, 33)
        Me.cmb_rel.TabIndex = 19
        '
        'cmb_requerido
        '
        Me.cmb_requerido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_requerido.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_requerido.FormattingEnabled = True
        Me.cmb_requerido.Items.AddRange(New Object() {"Corporativo", "Descripción del puesto", "Requerimiento del cliente", "Legal/Normativa", "Adicional"})
        Me.cmb_requerido.Location = New System.Drawing.Point(31, 35)
        Me.cmb_requerido.Name = "cmb_requerido"
        Me.cmb_requerido.Size = New System.Drawing.Size(255, 33)
        Me.cmb_requerido.TabIndex = 18
        '
        'cmb_nivel
        '
        Me.cmb_nivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_nivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_nivel.FormattingEnabled = True
        Me.cmb_nivel.Items.AddRange(New Object() {"Solo puesto", "Se escalona", "Se hereda"})
        Me.cmb_nivel.Location = New System.Drawing.Point(30, 200)
        Me.cmb_nivel.Name = "cmb_nivel"
        Me.cmb_nivel.Size = New System.Drawing.Size(366, 33)
        Me.cmb_nivel.TabIndex = 32
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown3)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(465, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 264)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vencimiento"
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Location = New System.Drawing.Point(48, 109)
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(78, 20)
        Me.NumericUpDown3.TabIndex = 25
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(48, 87)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(78, 20)
        Me.NumericUpDown2.TabIndex = 24
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(49, 65)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(77, 20)
        Me.NumericUpDown1.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Días"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Meses"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Años"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Anual", "Mensual", "Personalizado"})
        Me.ComboBox1.Location = New System.Drawing.Point(15, 19)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(175, 33)
        Me.ComboBox1.TabIndex = 19
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(465, 12)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(116, 24)
        Me.CheckBox2.TabIndex = 37
        Me.CheckBox2.Text = "Vencimiento"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(206, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Días"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(159, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 24)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "0"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 20)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Comienza"
        Me.Label8.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(26, 174)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(128, 22)
        Me.RadioButton1.TabIndex = 36
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Siguiente enero"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(26, 202)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(89, 22)
        Me.RadioButton2.TabIndex = 37
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Al evaluar"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(26, 229)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(132, 22)
        Me.RadioButton3.TabIndex = 38
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Elegir al calificar"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'Relacion_curso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 432)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmb_pond)
        Me.Controls.Add(Me.lbl_pond)
        Me.Controls.Add(Me.pic_pond)
        Me.Controls.Add(Me.Btn_puesto_tope)
        Me.Controls.Add(Me.txt_puesto_tope)
        Me.Controls.Add(Me.lbl_puestoTope)
        Me.Controls.Add(Me.cmb_heredado)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Btn_puesto)
        Me.Controls.Add(Me.lbl_nivel)
        Me.Controls.Add(Me.txt_puesto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_rel)
        Me.Controls.Add(Me.cmb_requerido)
        Me.Controls.Add(Me.cmb_nivel)
        Me.MaximumSize = New System.Drawing.Size(800, 471)
        Me.MinimumSize = New System.Drawing.Size(474, 385)
        Me.Name = "Relacion_curso"
        Me.Text = "Relacion_curso"
        CType(Me.pic_pond, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmb_pond As ComboBox
    Friend WithEvents lbl_pond As Label
    Friend WithEvents pic_pond As PictureBox
    Friend WithEvents Btn_puesto_tope As Button
    Friend WithEvents txt_puesto_tope As TextBox
    Friend WithEvents lbl_puestoTope As Label
    Friend WithEvents cmb_heredado As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Btn_puesto As Button
    Friend WithEvents lbl_nivel As Label
    Friend WithEvents txt_puesto As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_rel As ComboBox
    Friend WithEvents cmb_requerido As ComboBox
    Friend WithEvents cmb_nivel As ComboBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
End Class
