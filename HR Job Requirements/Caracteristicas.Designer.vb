<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Caracteristicas
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_curso = New System.Windows.Forms.Button()
        Me.btn_Competencias = New System.Windows.Forms.Button()
        Me.btn_Habilidades = New System.Windows.Forms.Button()
        Me.Btn_conocimiento = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 81)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1148, 560)
        Me.DataGridView1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(494, 62)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Competencias"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Location = New System.Drawing.Point(16, 138)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1176, 644)
        Me.Panel2.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(516, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(328, 31)
        Me.TextBox1.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_waste_64
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(1074, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(42, 35)
        Me.Button1.TabIndex = 7
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_plus_math_32
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(1122, 40)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(42, 35)
        Me.Button4.TabIndex = 3
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btn_curso)
        Me.GroupBox1.Controls.Add(Me.btn_Competencias)
        Me.GroupBox1.Controls.Add(Me.btn_Habilidades)
        Me.GroupBox1.Controls.Add(Me.Btn_conocimiento)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1176, 120)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'btn_curso
        '
        Me.btn_curso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_curso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_curso.Image = Global.Administracion_de_talento.My.Resources.Resources.skills__1_
        Me.btn_curso.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn_curso.Location = New System.Drawing.Point(461, 30)
        Me.btn_curso.Name = "btn_curso"
        Me.btn_curso.Size = New System.Drawing.Size(143, 62)
        Me.btn_curso.TabIndex = 7
        Me.btn_curso.Text = "Curso"
        Me.btn_curso.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btn_curso.UseVisualStyleBackColor = True
        Me.btn_curso.Visible = False
        '
        'btn_Competencias
        '
        Me.btn_Competencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Competencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Competencias.Image = Global.Administracion_de_talento.My.Resources.Resources.skills
        Me.btn_Competencias.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn_Competencias.Location = New System.Drawing.Point(16, 30)
        Me.btn_Competencias.Name = "btn_Competencias"
        Me.btn_Competencias.Size = New System.Drawing.Size(143, 62)
        Me.btn_Competencias.TabIndex = 1
        Me.btn_Competencias.Text = "Competencias"
        Me.btn_Competencias.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btn_Competencias.UseVisualStyleBackColor = True
        '
        'btn_Habilidades
        '
        Me.btn_Habilidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Habilidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Habilidades.Image = Global.Administracion_de_talento.My.Resources.Resources.skills__1_
        Me.btn_Habilidades.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn_Habilidades.Location = New System.Drawing.Point(314, 30)
        Me.btn_Habilidades.Name = "btn_Habilidades"
        Me.btn_Habilidades.Size = New System.Drawing.Size(143, 62)
        Me.btn_Habilidades.TabIndex = 2
        Me.btn_Habilidades.Text = "Responsabilidades"
        Me.btn_Habilidades.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btn_Habilidades.UseVisualStyleBackColor = True
        '
        'Btn_conocimiento
        '
        Me.Btn_conocimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_conocimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_conocimiento.Image = Global.Administracion_de_talento.My.Resources.Resources.thought
        Me.Btn_conocimiento.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn_conocimiento.Location = New System.Drawing.Point(165, 30)
        Me.Btn_conocimiento.Name = "Btn_conocimiento"
        Me.Btn_conocimiento.Size = New System.Drawing.Size(143, 62)
        Me.Btn_conocimiento.TabIndex = 3
        Me.Btn_conocimiento.Text = "Conocimiento"
        Me.Btn_conocimiento.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_conocimiento.UseVisualStyleBackColor = True
        '
        'Caracteristicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 794)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.MinimumSize = New System.Drawing.Size(875, 833)
        Me.Name = "Caracteristicas"
        Me.Text = "Caracteristicas"
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Competencias As Button
    Friend WithEvents btn_Habilidades As Button
    Friend WithEvents Btn_conocimiento As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn_curso As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
End Class
