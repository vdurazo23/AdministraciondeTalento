<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Evaluacion_detalles
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_id = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_evalua = New System.Windows.Forms.TextBox()
        Me.txt_tipo = New System.Windows.Forms.TextBox()
        Me.txt_nivel = New System.Windows.Forms.TextBox()
        Me.txt_fecha = New System.Windows.Forms.TextBox()
        Me.txt_estatus = New System.Windows.Forms.TextBox()
        Me.txt_vence = New System.Windows.Forms.TextBox()
        Me.txt_puntos = New System.Windows.Forms.TextBox()
        Me.txt_carac = New System.Windows.Forms.TextBox()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.txt_descripcion = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btn_zoom = New System.Windows.Forms.Button()
        Me.btn_open = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID:"
        '
        'lbl_id
        '
        Me.lbl_id.AutoSize = True
        Me.lbl_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_id.ForeColor = System.Drawing.Color.Black
        Me.lbl_id.Location = New System.Drawing.Point(53, 9)
        Me.lbl_id.Name = "lbl_id"
        Me.lbl_id.Size = New System.Drawing.Size(21, 24)
        Me.lbl_id.TabIndex = 1
        Me.lbl_id.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(32, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Evaluado por:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(33, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Caracteristica"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(93, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Nivel"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Fecha evaluación"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(78, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Estatus"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(266, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Vence"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(75, 438)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 17)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Archivo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(44, 471)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 17)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Descripción"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(266, 553)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 17)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Aprobaciones"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(456, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 16)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Puntos"
        '
        'txt_evalua
        '
        Me.txt_evalua.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_evalua.Location = New System.Drawing.Point(143, 50)
        Me.txt_evalua.Name = "txt_evalua"
        Me.txt_evalua.ReadOnly = True
        Me.txt_evalua.Size = New System.Drawing.Size(471, 23)
        Me.txt_evalua.TabIndex = 15
        '
        'txt_tipo
        '
        Me.txt_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_tipo.Location = New System.Drawing.Point(143, 74)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.ReadOnly = True
        Me.txt_tipo.Size = New System.Drawing.Size(88, 23)
        Me.txt_tipo.TabIndex = 16
        '
        'txt_nivel
        '
        Me.txt_nivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_nivel.Location = New System.Drawing.Point(143, 98)
        Me.txt_nivel.Name = "txt_nivel"
        Me.txt_nivel.ReadOnly = True
        Me.txt_nivel.Size = New System.Drawing.Size(88, 23)
        Me.txt_nivel.TabIndex = 17
        '
        'txt_fecha
        '
        Me.txt_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_fecha.Location = New System.Drawing.Point(143, 122)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(106, 23)
        Me.txt_fecha.TabIndex = 18
        '
        'txt_estatus
        '
        Me.txt_estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_estatus.ForeColor = System.Drawing.Color.Red
        Me.txt_estatus.Location = New System.Drawing.Point(143, 151)
        Me.txt_estatus.Name = "txt_estatus"
        Me.txt_estatus.Size = New System.Drawing.Size(88, 22)
        Me.txt_estatus.TabIndex = 19
        '
        'txt_vence
        '
        Me.txt_vence.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_vence.Location = New System.Drawing.Point(324, 122)
        Me.txt_vence.Name = "txt_vence"
        Me.txt_vence.ReadOnly = True
        Me.txt_vence.Size = New System.Drawing.Size(118, 23)
        Me.txt_vence.TabIndex = 20
        '
        'txt_puntos
        '
        Me.txt_puntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_puntos.Location = New System.Drawing.Point(517, 122)
        Me.txt_puntos.Name = "txt_puntos"
        Me.txt_puntos.ReadOnly = True
        Me.txt_puntos.Size = New System.Drawing.Size(97, 23)
        Me.txt_puntos.TabIndex = 21
        '
        'txt_carac
        '
        Me.txt_carac.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_carac.Location = New System.Drawing.Point(237, 74)
        Me.txt_carac.Name = "txt_carac"
        Me.txt_carac.ReadOnly = True
        Me.txt_carac.Size = New System.Drawing.Size(377, 23)
        Me.txt_carac.TabIndex = 22
        '
        'txt_nombre
        '
        Me.txt_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_nombre.Location = New System.Drawing.Point(143, 435)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.ReadOnly = True
        Me.txt_nombre.Size = New System.Drawing.Size(451, 23)
        Me.txt_nombre.TabIndex = 23
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_descripcion.Location = New System.Drawing.Point(143, 468)
        Me.txt_descripcion.Multiline = True
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(451, 67)
        Me.txt_descripcion.TabIndex = 24
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 573)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(618, 202)
        Me.DataGridView1.TabIndex = 25
        '
        'btn_zoom
        '
        Me.btn_zoom.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_acercar_26
        Me.btn_zoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_zoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_zoom.Location = New System.Drawing.Point(539, 384)
        Me.btn_zoom.Name = "btn_zoom"
        Me.btn_zoom.Size = New System.Drawing.Size(42, 40)
        Me.btn_zoom.TabIndex = 13
        Me.btn_zoom.UseVisualStyleBackColor = True
        '
        'btn_open
        '
        Me.btn_open.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_abrir_en_popup_32
        Me.btn_open.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_open.Location = New System.Drawing.Point(539, 338)
        Me.btn_open.Name = "btn_open"
        Me.btn_open.Size = New System.Drawing.Size(42, 40)
        Me.btn_open.TabIndex = 12
        Me.btn_open.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.Administracion_de_talento.My.Resources.Resources.SinVistaPrevia
        Me.PictureBox1.Location = New System.Drawing.Point(143, 195)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(390, 232)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'btn_editar
        '
        Me.btn_editar.Location = New System.Drawing.Point(390, 6)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(111, 35)
        Me.btn_editar.TabIndex = 26
        Me.btn_editar.Text = "Editar"
        Me.btn_editar.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Location = New System.Drawing.Point(507, 6)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(107, 35)
        Me.btn_eliminar.TabIndex = 27
        Me.btn_eliminar.Text = "Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'Evaluacion_detalles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(646, 787)
        Me.Controls.Add(Me.btn_eliminar)
        Me.Controls.Add(Me.btn_editar)
        Me.Controls.Add(Me.btn_zoom)
        Me.Controls.Add(Me.btn_open)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txt_descripcion)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.txt_carac)
        Me.Controls.Add(Me.txt_puntos)
        Me.Controls.Add(Me.txt_vence)
        Me.Controls.Add(Me.txt_estatus)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.txt_nivel)
        Me.Controls.Add(Me.txt_tipo)
        Me.Controls.Add(Me.txt_evalua)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbl_id)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Evaluacion_detalles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Evaluacion_detalles"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_id As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btn_open As Button
    Friend WithEvents btn_zoom As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_evalua As TextBox
    Friend WithEvents txt_tipo As TextBox
    Friend WithEvents txt_nivel As TextBox
    Friend WithEvents txt_fecha As TextBox
    Friend WithEvents txt_estatus As TextBox
    Friend WithEvents txt_vence As TextBox
    Friend WithEvents txt_puntos As TextBox
    Friend WithEvents txt_carac As TextBox
    Friend WithEvents txt_nombre As TextBox
    Friend WithEvents txt_descripcion As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btn_editar As Button
    Friend WithEvents btn_eliminar As Button
End Class
