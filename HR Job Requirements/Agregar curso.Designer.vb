<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Agregar_curso
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
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXT_EXTRA = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_nivelrequerido = New System.Windows.Forms.Button()
        Me.btn_borrar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Por_nivel = New System.Windows.Forms.Button()
        Me.Todo = New System.Windows.Forms.Button()
        Me.Por_empleado = New System.Windows.Forms.Button()
        Me.Hereda = New System.Windows.Forms.Button()
        Me.Por_puesto = New System.Windows.Forms.Button()
        Me.Escalona = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.d = New System.Windows.Forms.Label()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(99, 140)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(779, 42)
        Me.TextBox2.TabIndex = 70
        Me.TextBox2.Visible = False
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(43, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 16)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Inglés:"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SlateGray
        Me.Label12.Location = New System.Drawing.Point(35, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 30)
        Me.Label12.TabIndex = 68
        Me.Label12.Visible = False
        '
        'TXT_EXTRA
        '
        Me.TXT_EXTRA.Location = New System.Drawing.Point(99, 188)
        Me.TXT_EXTRA.Multiline = True
        Me.TXT_EXTRA.Name = "TXT_EXTRA"
        Me.TXT_EXTRA.Size = New System.Drawing.Size(779, 62)
        Me.TXT_EXTRA.TabIndex = 67
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(12, 195)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 16)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Comentario:"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SlateGray
        Me.Label10.Location = New System.Drawing.Point(4, 188)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 30)
        Me.Label10.TabIndex = 65
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btn_nivelrequerido)
        Me.Panel2.Controls.Add(Me.btn_borrar)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(15, 265)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(863, 289)
        Me.Panel2.TabIndex = 61
        '
        'btn_nivelrequerido
        '
        Me.btn_nivelrequerido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nivelrequerido.Location = New System.Drawing.Point(739, 37)
        Me.btn_nivelrequerido.Name = "btn_nivelrequerido"
        Me.btn_nivelrequerido.Size = New System.Drawing.Size(96, 39)
        Me.btn_nivelrequerido.TabIndex = 19
        Me.btn_nivelrequerido.Text = "Modificar niveles requeridos"
        Me.btn_nivelrequerido.UseVisualStyleBackColor = True
        '
        'btn_borrar
        '
        Me.btn_borrar.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_waste_64
        Me.btn_borrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_borrar.FlatAppearance.BorderSize = 0
        Me.btn_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_borrar.Location = New System.Drawing.Point(631, 42)
        Me.btn_borrar.Name = "btn_borrar"
        Me.btn_borrar.Size = New System.Drawing.Size(42, 35)
        Me.btn_borrar.TabIndex = 17
        Me.btn_borrar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Por_nivel)
        Me.Panel3.Controls.Add(Me.Todo)
        Me.Panel3.Controls.Add(Me.Por_empleado)
        Me.Panel3.Controls.Add(Me.Hereda)
        Me.Panel3.Controls.Add(Me.Por_puesto)
        Me.Panel3.Controls.Add(Me.Escalona)
        Me.Panel3.Location = New System.Drawing.Point(6, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(619, 39)
        Me.Panel3.TabIndex = 16
        '
        'Por_nivel
        '
        Me.Por_nivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Por_nivel.Location = New System.Drawing.Point(106, 11)
        Me.Por_nivel.Name = "Por_nivel"
        Me.Por_nivel.Size = New System.Drawing.Size(97, 23)
        Me.Por_nivel.TabIndex = 16
        Me.Por_nivel.Text = "Por nivel"
        Me.Por_nivel.UseVisualStyleBackColor = True
        '
        'Todo
        '
        Me.Todo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Todo.Location = New System.Drawing.Point(3, 11)
        Me.Todo.Name = "Todo"
        Me.Todo.Size = New System.Drawing.Size(97, 23)
        Me.Todo.TabIndex = 15
        Me.Todo.Text = "Todas"
        Me.Todo.UseVisualStyleBackColor = True
        '
        'Por_empleado
        '
        Me.Por_empleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Por_empleado.Location = New System.Drawing.Point(518, 11)
        Me.Por_empleado.Name = "Por_empleado"
        Me.Por_empleado.Size = New System.Drawing.Size(97, 23)
        Me.Por_empleado.TabIndex = 14
        Me.Por_empleado.Text = "Por empleado"
        Me.Por_empleado.UseVisualStyleBackColor = True
        '
        'Hereda
        '
        Me.Hereda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Hereda.Location = New System.Drawing.Point(209, 11)
        Me.Hereda.Name = "Hereda"
        Me.Hereda.Size = New System.Drawing.Size(97, 23)
        Me.Hereda.TabIndex = 11
        Me.Hereda.Text = "Heredadas"
        Me.Hereda.UseVisualStyleBackColor = True
        '
        'Por_puesto
        '
        Me.Por_puesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Por_puesto.Location = New System.Drawing.Point(415, 11)
        Me.Por_puesto.Name = "Por_puesto"
        Me.Por_puesto.Size = New System.Drawing.Size(97, 23)
        Me.Por_puesto.TabIndex = 13
        Me.Por_puesto.Text = "Por puesto"
        Me.Por_puesto.UseVisualStyleBackColor = True
        '
        'Escalona
        '
        Me.Escalona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Escalona.Location = New System.Drawing.Point(312, 11)
        Me.Escalona.Name = "Escalona"
        Me.Escalona.Size = New System.Drawing.Size(97, 23)
        Me.Escalona.TabIndex = 12
        Me.Escalona.Text = "Escalonadas"
        Me.Escalona.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 81)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(829, 198)
        Me.DataGridView1.TabIndex = 10
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.Administracion_de_talento.My.Resources.Resources.icons8_plus_math_32
        Me.Button3.Location = New System.Drawing.Point(636, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(33, 26)
        Me.Button3.TabIndex = 9
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightGray
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(624, 26)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Relaciones"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.Location = New System.Drawing.Point(436, 560)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 39)
        Me.Button2.TabIndex = 60
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.Location = New System.Drawing.Point(342, 560)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 39)
        Me.Button1.TabIndex = 59
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(15, 93)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(412, 22)
        Me.TextBox1.TabIndex = 57
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 35)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Curso"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Location = New System.Drawing.Point(15, 121)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 1)
        Me.Panel1.TabIndex = 56
        '
        'd
        '
        Me.d.BackColor = System.Drawing.Color.SlateGray
        Me.d.Location = New System.Drawing.Point(-2, 10)
        Me.d.Name = "d"
        Me.d.Size = New System.Drawing.Size(324, 55)
        Me.d.TabIndex = 58
        '
        'btn_editar
        '
        Me.btn_editar.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_editar_64
        Me.btn_editar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_editar.FlatAppearance.BorderSize = 0
        Me.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_editar.Location = New System.Drawing.Point(436, 96)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(28, 26)
        Me.btn_editar.TabIndex = 62
        Me.btn_editar.UseVisualStyleBackColor = True
        Me.btn_editar.Visible = False
        '
        'Agregar_curso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(890, 611)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXT_EXTRA)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btn_editar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.d)
        Me.Name = "Agregar_curso"
        Me.Text = "Agregar_curso"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TXT_EXTRA As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btn_editar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_borrar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Por_nivel As Button
    Friend WithEvents Todo As Button
    Friend WithEvents Por_empleado As Button
    Friend WithEvents Hereda As Button
    Friend WithEvents Por_puesto As Button
    Friend WithEvents Escalona As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents d As Label
    Friend WithEvents btn_nivelrequerido As Button
End Class
