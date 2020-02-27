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
        Me.btn_help = New System.Windows.Forms.Button()
        Me.btn_cursos = New System.Windows.Forms.Button()
        Me.btn_Tickets = New System.Windows.Forms.Button()
        Me.btn_Permisos = New System.Windows.Forms.Button()
        Me.btn_Soporte = New System.Windows.Forms.Button()
        Me.btn_Organigrama = New System.Windows.Forms.Button()
        Me.btn_Cursosadmin = New System.Windows.Forms.Button()
        Me.btn_Otros = New System.Windows.Forms.Button()
        Me.btn_Configuración = New System.Windows.Forms.Button()
        Me.btn_Administración = New System.Windows.Forms.Button()
        Me.Btn_Reportes = New System.Windows.Forms.Button()
        Me.btn_Consulta = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_consultasencilla = New System.Windows.Forms.Button()
        Me.LogInOut = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(224, 860)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.btn_help)
        Me.Panel2.Controls.Add(Me.btn_cursos)
        Me.Panel2.Controls.Add(Me.btn_Tickets)
        Me.Panel2.Controls.Add(Me.btn_Permisos)
        Me.Panel2.Controls.Add(Me.btn_Soporte)
        Me.Panel2.Controls.Add(Me.btn_Organigrama)
        Me.Panel2.Controls.Add(Me.btn_Cursosadmin)
        Me.Panel2.Controls.Add(Me.btn_Otros)
        Me.Panel2.Controls.Add(Me.btn_Configuración)
        Me.Panel2.Controls.Add(Me.btn_Administración)
        Me.Panel2.Controls.Add(Me.Btn_Reportes)
        Me.Panel2.Controls.Add(Me.btn_Consulta)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.DimGray
        Me.Panel2.Location = New System.Drawing.Point(0, 219)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(224, 550)
        Me.Panel2.TabIndex = 22
        '
        'btn_help
        '
        Me.btn_help.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_help.FlatAppearance.BorderSize = 0
        Me.btn_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_help.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_help.ForeColor = System.Drawing.Color.DimGray
        Me.btn_help.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_help.Location = New System.Drawing.Point(0, 514)
        Me.btn_help.Name = "btn_help"
        Me.btn_help.Size = New System.Drawing.Size(207, 45)
        Me.btn_help.TabIndex = 24
        Me.btn_help.Tag = "Ayuda"
        Me.btn_help.Text = "Ayuda"
        Me.btn_help.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_help.UseVisualStyleBackColor = True
        '
        'btn_cursos
        '
        Me.btn_cursos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_cursos.FlatAppearance.BorderSize = 0
        Me.btn_cursos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cursos.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cursos.ForeColor = System.Drawing.Color.DimGray
        Me.btn_cursos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cursos.Location = New System.Drawing.Point(0, 469)
        Me.btn_cursos.Name = "btn_cursos"
        Me.btn_cursos.Size = New System.Drawing.Size(207, 45)
        Me.btn_cursos.TabIndex = 23
        Me.btn_cursos.Tag = "Cursos"
        Me.btn_cursos.Text = "Cursos"
        Me.btn_cursos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cursos.UseVisualStyleBackColor = True
        '
        'btn_Tickets
        '
        Me.btn_Tickets.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Tickets.FlatAppearance.BorderSize = 0
        Me.btn_Tickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Tickets.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Tickets.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Tickets.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Tickets.Location = New System.Drawing.Point(0, 424)
        Me.btn_Tickets.Name = "btn_Tickets"
        Me.btn_Tickets.Size = New System.Drawing.Size(207, 45)
        Me.btn_Tickets.TabIndex = 22
        Me.btn_Tickets.Tag = "Tickets"
        Me.btn_Tickets.Text = "Tickets"
        Me.btn_Tickets.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Tickets.UseVisualStyleBackColor = True
        '
        'btn_Permisos
        '
        Me.btn_Permisos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Permisos.FlatAppearance.BorderSize = 0
        Me.btn_Permisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Permisos.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Permisos.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Permisos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Permisos.Location = New System.Drawing.Point(0, 379)
        Me.btn_Permisos.Name = "btn_Permisos"
        Me.btn_Permisos.Size = New System.Drawing.Size(207, 45)
        Me.btn_Permisos.TabIndex = 21
        Me.btn_Permisos.Tag = "Permisos"
        Me.btn_Permisos.Text = "Permisos"
        Me.btn_Permisos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Permisos.UseVisualStyleBackColor = True
        '
        'btn_Soporte
        '
        Me.btn_Soporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Soporte.FlatAppearance.BorderSize = 0
        Me.btn_Soporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Soporte.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Soporte.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Soporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Soporte.Location = New System.Drawing.Point(0, 334)
        Me.btn_Soporte.Name = "btn_Soporte"
        Me.btn_Soporte.Size = New System.Drawing.Size(207, 45)
        Me.btn_Soporte.TabIndex = 19
        Me.btn_Soporte.Tag = "Soporte"
        Me.btn_Soporte.Text = "Soporte"
        Me.btn_Soporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Soporte.UseVisualStyleBackColor = True
        '
        'btn_Organigrama
        '
        Me.btn_Organigrama.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Organigrama.FlatAppearance.BorderSize = 0
        Me.btn_Organigrama.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Organigrama.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Organigrama.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Organigrama.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Organigrama.Location = New System.Drawing.Point(0, 289)
        Me.btn_Organigrama.Name = "btn_Organigrama"
        Me.btn_Organigrama.Size = New System.Drawing.Size(207, 45)
        Me.btn_Organigrama.TabIndex = 16
        Me.btn_Organigrama.Tag = "Organigrama"
        Me.btn_Organigrama.Text = "Organigrama"
        Me.btn_Organigrama.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Organigrama.UseVisualStyleBackColor = True
        '
        'btn_Cursosadmin
        '
        Me.btn_Cursosadmin.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Cursosadmin.FlatAppearance.BorderSize = 0
        Me.btn_Cursosadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cursosadmin.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cursosadmin.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Cursosadmin.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cursosadmin.Location = New System.Drawing.Point(0, 244)
        Me.btn_Cursosadmin.Name = "btn_Cursosadmin"
        Me.btn_Cursosadmin.Size = New System.Drawing.Size(207, 45)
        Me.btn_Cursosadmin.TabIndex = 15
        Me.btn_Cursosadmin.Tag = "Admin Cursos"
        Me.btn_Cursosadmin.Text = "Admin Cursos"
        Me.btn_Cursosadmin.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cursosadmin.UseVisualStyleBackColor = True
        '
        'btn_Otros
        '
        Me.btn_Otros.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Otros.FlatAppearance.BorderSize = 0
        Me.btn_Otros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Otros.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Otros.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Otros.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Otros.Location = New System.Drawing.Point(0, 199)
        Me.btn_Otros.Name = "btn_Otros"
        Me.btn_Otros.Size = New System.Drawing.Size(207, 45)
        Me.btn_Otros.TabIndex = 13
        Me.btn_Otros.Tag = "Otros"
        Me.btn_Otros.Text = "Otros"
        Me.btn_Otros.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Otros.UseVisualStyleBackColor = True
        '
        'btn_Configuración
        '
        Me.btn_Configuración.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Configuración.FlatAppearance.BorderSize = 0
        Me.btn_Configuración.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Configuración.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Configuración.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Configuración.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Configuración.Location = New System.Drawing.Point(0, 154)
        Me.btn_Configuración.Name = "btn_Configuración"
        Me.btn_Configuración.Size = New System.Drawing.Size(207, 45)
        Me.btn_Configuración.TabIndex = 18
        Me.btn_Configuración.Tag = "Configuración"
        Me.btn_Configuración.Text = "Configuración"
        Me.btn_Configuración.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Configuración.UseVisualStyleBackColor = True
        '
        'btn_Administración
        '
        Me.btn_Administración.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Administración.FlatAppearance.BorderSize = 0
        Me.btn_Administración.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Administración.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Administración.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Administración.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Administración.Location = New System.Drawing.Point(0, 109)
        Me.btn_Administración.Name = "btn_Administración"
        Me.btn_Administración.Size = New System.Drawing.Size(207, 45)
        Me.btn_Administración.TabIndex = 12
        Me.btn_Administración.Tag = "Administración"
        Me.btn_Administración.Text = "Administración"
        Me.btn_Administración.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Administración.UseVisualStyleBackColor = True
        '
        'Btn_Reportes
        '
        Me.Btn_Reportes.Dock = System.Windows.Forms.DockStyle.Top
        Me.Btn_Reportes.FlatAppearance.BorderSize = 0
        Me.Btn_Reportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Reportes.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Reportes.ForeColor = System.Drawing.Color.DimGray
        Me.Btn_Reportes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Reportes.Location = New System.Drawing.Point(0, 64)
        Me.Btn_Reportes.Name = "Btn_Reportes"
        Me.Btn_Reportes.Size = New System.Drawing.Size(207, 45)
        Me.Btn_Reportes.TabIndex = 14
        Me.Btn_Reportes.Tag = "Reportes"
        Me.Btn_Reportes.Text = "Reportes"
        Me.Btn_Reportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Reportes.UseVisualStyleBackColor = True
        '
        'btn_Consulta
        '
        Me.btn_Consulta.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Consulta.FlatAppearance.BorderSize = 0
        Me.btn_Consulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Consulta.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Consulta.ForeColor = System.Drawing.Color.DimGray
        Me.btn_Consulta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Consulta.Location = New System.Drawing.Point(0, 19)
        Me.btn_Consulta.Name = "btn_Consulta"
        Me.btn_Consulta.Size = New System.Drawing.Size(207, 45)
        Me.btn_Consulta.TabIndex = 4
        Me.btn_Consulta.Tag = "Consulta"
        Me.btn_Consulta.Text = "Consulta"
        Me.btn_Consulta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Consulta.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 19)
        Me.Label1.TabIndex = 20
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 104)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(224, 115)
        Me.Panel4.TabIndex = 24
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Image = Global.Administracion_de_talento.My.Resources.Resources.user_icon_icons_com_57997
        Me.PictureBox2.Location = New System.Drawing.Point(52, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(113, 105)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.PictureBox3)
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(224, 104)
        Me.Panel5.TabIndex = 25
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Gainsboro
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = Global.Administracion_de_talento.My.Resources.Resources.icons8_doble_izquierda_48
        Me.PictureBox3.Location = New System.Drawing.Point(187, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(37, 104)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Administracion_de_talento.My.Resources.Resources.LogoSmall___copia
        Me.PictureBox1.Location = New System.Drawing.Point(63, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(102, 98)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.btn_consultasencilla)
        Me.Panel3.Controls.Add(Me.LogInOut)
        Me.Panel3.Controls.Add(Me.btn_salir)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 769)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(224, 91)
        Me.Panel3.TabIndex = 23
        '
        'btn_consultasencilla
        '
        Me.btn_consultasencilla.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_consultasencilla.FlatAppearance.BorderSize = 0
        Me.btn_consultasencilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_consultasencilla.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consultasencilla.ForeColor = System.Drawing.Color.Black
        Me.btn_consultasencilla.Location = New System.Drawing.Point(0, 7)
        Me.btn_consultasencilla.Name = "btn_consultasencilla"
        Me.btn_consultasencilla.Size = New System.Drawing.Size(224, 28)
        Me.btn_consultasencilla.TabIndex = 21
        Me.btn_consultasencilla.Tag = "Consulta por empleado"
        Me.btn_consultasencilla.Text = "Consulta por empleado"
        Me.btn_consultasencilla.UseVisualStyleBackColor = True
        '
        'LogInOut
        '
        Me.LogInOut.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LogInOut.FlatAppearance.BorderSize = 0
        Me.LogInOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LogInOut.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogInOut.ForeColor = System.Drawing.Color.Black
        Me.LogInOut.Image = Global.Administracion_de_talento.My.Resources.Resources.icons8_apagar_24
        Me.LogInOut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LogInOut.Location = New System.Drawing.Point(0, 35)
        Me.LogInOut.Name = "LogInOut"
        Me.LogInOut.Size = New System.Drawing.Size(224, 28)
        Me.LogInOut.TabIndex = 20
        Me.LogInOut.Tag = "Iniciar sesión"
        Me.LogInOut.Text = "Iniciar sesión"
        Me.LogInOut.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_salir.FlatAppearance.BorderSize = 0
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.ForeColor = System.Drawing.Color.Black
        Me.btn_salir.Image = Global.Administracion_de_talento.My.Resources.Resources.icons8_exportar_24
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(0, 63)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(224, 28)
        Me.btn_salir.TabIndex = 17
        Me.btn_salir.Tag = "Salir"
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1244, 860)
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
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_Consulta As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_Organigrama As Button
    Friend WithEvents btn_Cursosadmin As Button
    Friend WithEvents Btn_Reportes As Button
    Friend WithEvents btn_Otros As Button
    Friend WithEvents btn_Administración As Button
    Friend WithEvents btn_Soporte As Button
    Friend WithEvents btn_Configuración As Button
    Friend WithEvents LogInOut As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btn_Permisos As Button
    Friend WithEvents btn_consultasencilla As Button
    Friend WithEvents btn_Tickets As Button
    Friend WithEvents btn_cursos As Button
    Friend WithEvents btn_help As Button
End Class
