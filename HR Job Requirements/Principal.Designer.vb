<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_soporte = New System.Windows.Forms.Button()
        Me.btn_organigrama = New System.Windows.Forms.Button()
        Me.btn_curso = New System.Windows.Forms.Button()
        Me.btn_otro = New System.Windows.Forms.Button()
        Me.btn_config = New System.Windows.Forms.Button()
        Me.btn_admin = New System.Windows.Forms.Button()
        Me.Btn_reporte = New System.Windows.Forms.Button()
        Me.btn_puesto = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LogInOut = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 798)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btn_soporte)
        Me.Panel2.Controls.Add(Me.btn_organigrama)
        Me.Panel2.Controls.Add(Me.btn_curso)
        Me.Panel2.Controls.Add(Me.btn_otro)
        Me.Panel2.Controls.Add(Me.btn_config)
        Me.Panel2.Controls.Add(Me.btn_admin)
        Me.Panel2.Controls.Add(Me.Btn_reporte)
        Me.Panel2.Controls.Add(Me.btn_puesto)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 344)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 378)
        Me.Panel2.TabIndex = 22
        '
        'btn_soporte
        '
        Me.btn_soporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_soporte.FlatAppearance.BorderSize = 0
        Me.btn_soporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_soporte.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_soporte.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_soporte.Location = New System.Drawing.Point(0, 241)
        Me.btn_soporte.Name = "btn_soporte"
        Me.btn_soporte.Size = New System.Drawing.Size(200, 34)
        Me.btn_soporte.TabIndex = 19
        Me.btn_soporte.Text = "Soporte"
        Me.btn_soporte.UseVisualStyleBackColor = True
        '
        'btn_organigrama
        '
        Me.btn_organigrama.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_organigrama.FlatAppearance.BorderSize = 0
        Me.btn_organigrama.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_organigrama.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_organigrama.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_organigrama.Location = New System.Drawing.Point(0, 207)
        Me.btn_organigrama.Name = "btn_organigrama"
        Me.btn_organigrama.Size = New System.Drawing.Size(200, 34)
        Me.btn_organigrama.TabIndex = 16
        Me.btn_organigrama.Text = "Organigrama"
        Me.btn_organigrama.UseVisualStyleBackColor = True
        '
        'btn_curso
        '
        Me.btn_curso.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_curso.FlatAppearance.BorderSize = 0
        Me.btn_curso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_curso.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_curso.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_curso.Location = New System.Drawing.Point(0, 173)
        Me.btn_curso.Name = "btn_curso"
        Me.btn_curso.Size = New System.Drawing.Size(200, 34)
        Me.btn_curso.TabIndex = 15
        Me.btn_curso.Text = "Cursos"
        Me.btn_curso.UseVisualStyleBackColor = True
        '
        'btn_otro
        '
        Me.btn_otro.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_otro.FlatAppearance.BorderSize = 0
        Me.btn_otro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_otro.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_otro.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_otro.Location = New System.Drawing.Point(0, 139)
        Me.btn_otro.Name = "btn_otro"
        Me.btn_otro.Size = New System.Drawing.Size(200, 34)
        Me.btn_otro.TabIndex = 13
        Me.btn_otro.Text = "Otros"
        Me.btn_otro.UseVisualStyleBackColor = True
        '
        'btn_config
        '
        Me.btn_config.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_config.FlatAppearance.BorderSize = 0
        Me.btn_config.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_config.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_config.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_config.Location = New System.Drawing.Point(0, 105)
        Me.btn_config.Name = "btn_config"
        Me.btn_config.Size = New System.Drawing.Size(200, 34)
        Me.btn_config.TabIndex = 18
        Me.btn_config.Text = "Configuración"
        Me.btn_config.UseVisualStyleBackColor = True
        '
        'btn_admin
        '
        Me.btn_admin.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_admin.FlatAppearance.BorderSize = 0
        Me.btn_admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_admin.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_admin.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_admin.Location = New System.Drawing.Point(0, 71)
        Me.btn_admin.Name = "btn_admin"
        Me.btn_admin.Size = New System.Drawing.Size(200, 34)
        Me.btn_admin.TabIndex = 12
        Me.btn_admin.Text = "Administración"
        Me.btn_admin.UseVisualStyleBackColor = True
        '
        'Btn_reporte
        '
        Me.Btn_reporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.Btn_reporte.FlatAppearance.BorderSize = 0
        Me.Btn_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_reporte.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_reporte.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Btn_reporte.Location = New System.Drawing.Point(0, 37)
        Me.Btn_reporte.Name = "Btn_reporte"
        Me.Btn_reporte.Size = New System.Drawing.Size(200, 34)
        Me.Btn_reporte.TabIndex = 14
        Me.Btn_reporte.Text = "Reportes"
        Me.Btn_reporte.UseVisualStyleBackColor = True
        '
        'btn_puesto
        '
        Me.btn_puesto.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_puesto.FlatAppearance.BorderSize = 0
        Me.btn_puesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_puesto.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_puesto.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_puesto.Location = New System.Drawing.Point(0, 0)
        Me.btn_puesto.Name = "btn_puesto"
        Me.btn_puesto.Size = New System.Drawing.Size(200, 37)
        Me.btn_puesto.TabIndex = 4
        Me.btn_puesto.Text = "Consulta"
        Me.btn_puesto.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 126)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 218)
        Me.Panel4.TabIndex = 24
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.Image = Global.HR_Job_Requirements.My.Resources.Resources.user_icon_icons_com_57997
        Me.PictureBox2.Location = New System.Drawing.Point(53, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(93, 95)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(200, 126)
        Me.Panel5.TabIndex = 25
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_Job_Requirements.My.Resources.Resources.LogoSmall___copia
        Me.PictureBox1.Location = New System.Drawing.Point(43, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(113, 120)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.LogInOut)
        Me.Panel3.Controls.Add(Me.btn_salir)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 722)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 76)
        Me.Panel3.TabIndex = 23
        '
        'LogInOut
        '
        Me.LogInOut.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LogInOut.FlatAppearance.BorderSize = 0
        Me.LogInOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LogInOut.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogInOut.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LogInOut.Location = New System.Drawing.Point(0, 8)
        Me.LogInOut.Name = "LogInOut"
        Me.LogInOut.Size = New System.Drawing.Size(200, 34)
        Me.LogInOut.TabIndex = 20
        Me.LogInOut.Text = "Iniciar sesión"
        Me.LogInOut.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_salir.FlatAppearance.BorderSize = 0
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_salir.Location = New System.Drawing.Point(0, 42)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(200, 34)
        Me.btn_salir.TabIndex = 17
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1244, 798)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.IsMdiContainer = True
        Me.Name = "Principal"
        Me.Text = "Habilidades"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_puesto As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_organigrama As Button
    Friend WithEvents btn_curso As Button
    Friend WithEvents Btn_reporte As Button
    Friend WithEvents btn_otro As Button
    Friend WithEvents btn_admin As Button
    Friend WithEvents btn_soporte As Button
    Friend WithEvents btn_config As Button
    Friend WithEvents LogInOut As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel3 As Panel
End Class
