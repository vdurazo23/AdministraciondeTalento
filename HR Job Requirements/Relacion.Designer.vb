<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Relacion
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
        Me.cmb_requerido = New System.Windows.Forms.ComboBox()
        Me.cmd_rel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_puesto = New System.Windows.Forms.TextBox()
        Me.lbl_nivel = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmb_heredado = New System.Windows.Forms.ComboBox()
        Me.lbl_puestoTope = New System.Windows.Forms.Label()
        Me.txt_puesto_tope = New System.Windows.Forms.TextBox()
        Me.cmb_nivel = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Btn_puesto_tope = New System.Windows.Forms.Button()
        Me.Btn_puesto = New System.Windows.Forms.Button()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_requerido
        '
        Me.cmb_requerido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_requerido.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_requerido.FormattingEnabled = True
        Me.cmb_requerido.Items.AddRange(New Object() {"Corporativo", "Puesto"})
        Me.cmb_requerido.Location = New System.Drawing.Point(31, 35)
        Me.cmb_requerido.Name = "cmb_requerido"
        Me.cmb_requerido.Size = New System.Drawing.Size(191, 33)
        Me.cmb_requerido.TabIndex = 0
        '
        'cmd_rel
        '
        Me.cmd_rel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmd_rel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_rel.FormattingEnabled = True
        Me.cmd_rel.Items.AddRange(New Object() {"Por Nivel", "Por Puesto"})
        Me.cmd_rel.Location = New System.Drawing.Point(31, 115)
        Me.cmd_rel.Name = "cmd_rel"
        Me.cmd_rel.Size = New System.Drawing.Size(191, 33)
        Me.cmd_rel.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Requerido por"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tipo de relación"
        '
        'txt_puesto
        '
        Me.txt_puesto.Enabled = False
        Me.txt_puesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_puesto.Location = New System.Drawing.Point(31, 203)
        Me.txt_puesto.Name = "txt_puesto"
        Me.txt_puesto.Size = New System.Drawing.Size(324, 31)
        Me.txt_puesto.TabIndex = 4
        '
        'lbl_nivel
        '
        Me.lbl_nivel.AutoSize = True
        Me.lbl_nivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nivel.Location = New System.Drawing.Point(12, 168)
        Me.lbl_nivel.Name = "lbl_nivel"
        Me.lbl_nivel.Size = New System.Drawing.Size(96, 20)
        Me.lbl_nivel.TabIndex = 5
        Me.lbl_nivel.Text = "Nivel/Puesto"
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.Location = New System.Drawing.Point(129, 363)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 57)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Aceptar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button3.Location = New System.Drawing.Point(225, 363)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 57)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Cancelar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(353, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(80, 28)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Activo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmb_heredado
        '
        Me.cmb_heredado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_heredado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_heredado.FormattingEnabled = True
        Me.cmb_heredado.Items.AddRange(New Object() {"Solo puesto", "Se escalona", "Se hereda"})
        Me.cmb_heredado.Location = New System.Drawing.Point(31, 240)
        Me.cmb_heredado.Name = "cmb_heredado"
        Me.cmb_heredado.Size = New System.Drawing.Size(191, 33)
        Me.cmb_heredado.TabIndex = 10
        '
        'lbl_puestoTope
        '
        Me.lbl_puestoTope.AutoSize = True
        Me.lbl_puestoTope.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_puestoTope.Location = New System.Drawing.Point(12, 293)
        Me.lbl_puestoTope.Name = "lbl_puestoTope"
        Me.lbl_puestoTope.Size = New System.Drawing.Size(95, 20)
        Me.lbl_puestoTope.TabIndex = 11
        Me.lbl_puestoTope.Text = "Puesto tope"
        '
        'txt_puesto_tope
        '
        Me.txt_puesto_tope.Enabled = False
        Me.txt_puesto_tope.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_puesto_tope.Location = New System.Drawing.Point(31, 316)
        Me.txt_puesto_tope.Name = "txt_puesto_tope"
        Me.txt_puesto_tope.Size = New System.Drawing.Size(324, 31)
        Me.txt_puesto_tope.TabIndex = 12
        '
        'cmb_nivel
        '
        Me.cmb_nivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_nivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_nivel.FormattingEnabled = True
        Me.cmb_nivel.Items.AddRange(New Object() {"Solo puesto", "Se escalona", "Se hereda"})
        Me.cmb_nivel.Location = New System.Drawing.Point(31, 203)
        Me.cmb_nivel.Name = "cmb_nivel"
        Me.cmb_nivel.Size = New System.Drawing.Size(312, 33)
        Me.cmb_nivel.TabIndex = 14
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Btn_puesto_tope
        '
        Me.Btn_puesto_tope.BackgroundImage = Global.HR_Job_Requirements.My.Resources.Resources.icons8_búsqueda_50
        Me.Btn_puesto_tope.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btn_puesto_tope.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_puesto_tope.Location = New System.Drawing.Point(361, 316)
        Me.Btn_puesto_tope.Name = "Btn_puesto_tope"
        Me.Btn_puesto_tope.Size = New System.Drawing.Size(45, 31)
        Me.Btn_puesto_tope.TabIndex = 13
        Me.Btn_puesto_tope.UseVisualStyleBackColor = True
        '
        'Btn_puesto
        '
        Me.Btn_puesto.BackgroundImage = Global.HR_Job_Requirements.My.Resources.Resources.icons8_búsqueda_50
        Me.Btn_puesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btn_puesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_puesto.Location = New System.Drawing.Point(361, 203)
        Me.Btn_puesto.Name = "Btn_puesto"
        Me.Btn_puesto.Size = New System.Drawing.Size(45, 31)
        Me.Btn_puesto.TabIndex = 6
        Me.Btn_puesto.UseVisualStyleBackColor = True
        '
        'Relacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(445, 432)
        Me.Controls.Add(Me.cmb_nivel)
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
        Me.Controls.Add(Me.cmd_rel)
        Me.Controls.Add(Me.cmb_requerido)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximumSize = New System.Drawing.Size(461, 471)
        Me.MinimumSize = New System.Drawing.Size(461, 380)
        Me.Name = "Relacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmb_requerido As ComboBox
    Friend WithEvents cmd_rel As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_puesto As TextBox
    Friend WithEvents lbl_nivel As Label
    Friend WithEvents Btn_puesto As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents cmb_heredado As ComboBox
    Friend WithEvents lbl_puestoTope As Label
    Friend WithEvents Btn_puesto_tope As Button
    Friend WithEvents txt_puesto_tope As TextBox
    Friend WithEvents cmb_nivel As ComboBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
