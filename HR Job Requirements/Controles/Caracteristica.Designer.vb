<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Caracteristica
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.lbl_caracteristica = New System.Windows.Forms.Label()
        Me.lbl_requerido = New System.Windows.Forms.Label()
        Me.lbl_niv_actual = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_evidencia = New System.Windows.Forms.Button()
        Me.lbl_niv_req = New System.Windows.Forms.Label()
        Me.btn_adjunto = New System.Windows.Forms.Button()
        Me.Pendiente = New System.Windows.Forms.PictureBox()
        Me.lbl_porcentaje = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Pendiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_caracteristica
        '
        Me.lbl_caracteristica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_caracteristica.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_caracteristica.Location = New System.Drawing.Point(3, 0)
        Me.lbl_caracteristica.Name = "lbl_caracteristica"
        Me.lbl_caracteristica.Size = New System.Drawing.Size(609, 45)
        Me.lbl_caracteristica.TabIndex = 0
        Me.lbl_caracteristica.Text = "Caracteristica"
        Me.lbl_caracteristica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_requerido
        '
        Me.lbl_requerido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_requerido.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_requerido.Location = New System.Drawing.Point(618, 0)
        Me.lbl_requerido.Name = "lbl_requerido"
        Me.lbl_requerido.Size = New System.Drawing.Size(123, 45)
        Me.lbl_requerido.TabIndex = 1
        Me.lbl_requerido.Text = "Requerido por:"
        Me.lbl_requerido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_niv_actual
        '
        Me.lbl_niv_actual.AutoSize = True
        Me.lbl_niv_actual.BackColor = System.Drawing.Color.Transparent
        Me.lbl_niv_actual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_niv_actual.Location = New System.Drawing.Point(815, 0)
        Me.lbl_niv_actual.Name = "lbl_niv_actual"
        Me.lbl_niv_actual.Size = New System.Drawing.Size(62, 45)
        Me.lbl_niv_actual.TabIndex = 5
        Me.lbl_niv_actual.Text = "Nivel actual"
        Me.lbl_niv_actual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.76438!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.2645!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.991576!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.991576!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.987967!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btn_evidencia, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_caracteristica, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_requerido, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_niv_req, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_niv_actual, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_adjunto, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Pendiente, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_porcentaje, 4, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1168, 45)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'btn_evidencia
        '
        Me.btn_evidencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_evidencia.FlatAppearance.BorderSize = 0
        Me.btn_evidencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_evidencia.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_evidencia.Location = New System.Drawing.Point(1030, 3)
        Me.btn_evidencia.Name = "btn_evidencia"
        Me.btn_evidencia.Size = New System.Drawing.Size(71, 39)
        Me.btn_evidencia.TabIndex = 6
        Me.btn_evidencia.Text = "Evidencia"
        Me.btn_evidencia.UseVisualStyleBackColor = True
        '
        'lbl_niv_req
        '
        Me.lbl_niv_req.AutoSize = True
        Me.lbl_niv_req.BackColor = System.Drawing.Color.Transparent
        Me.lbl_niv_req.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_niv_req.Location = New System.Drawing.Point(747, 0)
        Me.lbl_niv_req.Name = "lbl_niv_req"
        Me.lbl_niv_req.Size = New System.Drawing.Size(62, 45)
        Me.lbl_niv_req.TabIndex = 4
        Me.lbl_niv_req.Text = "Nivel requerido"
        Me.lbl_niv_req.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_adjunto
        '
        Me.btn_adjunto.BackgroundImage = Global.Administracion_de_talento.My.Resources.Resources.icons8_attach_32
        Me.btn_adjunto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_adjunto.FlatAppearance.BorderSize = 0
        Me.btn_adjunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_adjunto.Location = New System.Drawing.Point(980, 3)
        Me.btn_adjunto.Name = "btn_adjunto"
        Me.btn_adjunto.Size = New System.Drawing.Size(44, 39)
        Me.btn_adjunto.TabIndex = 3
        Me.btn_adjunto.UseVisualStyleBackColor = True
        '
        'Pendiente
        '
        Me.Pendiente.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pendiente.Image = Global.Administracion_de_talento.My.Resources.Resources.icons8_acerca_de_30
        Me.Pendiente.Location = New System.Drawing.Point(1107, 3)
        Me.Pendiente.Name = "Pendiente"
        Me.Pendiente.Size = New System.Drawing.Size(58, 39)
        Me.Pendiente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pendiente.TabIndex = 7
        Me.Pendiente.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Pendiente, "El nivel actual puede cambiar, debido a que tiene evaluaciones pendientes por apr" &
        "obar")
        '
        'lbl_porcentaje
        '
        Me.lbl_porcentaje.AutoSize = True
        Me.lbl_porcentaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_porcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_porcentaje.Location = New System.Drawing.Point(883, 0)
        Me.lbl_porcentaje.Name = "lbl_porcentaje"
        Me.lbl_porcentaje.Size = New System.Drawing.Size(91, 45)
        Me.lbl_porcentaje.TabIndex = 8
        Me.lbl_porcentaje.Text = "Porcentaje"
        Me.lbl_porcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'Caracteristica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Caracteristica"
        Me.Size = New System.Drawing.Size(1168, 45)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Pendiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbl_caracteristica As Label
    Friend WithEvents lbl_requerido As Label
    Friend WithEvents btn_adjunto As Button
    Friend WithEvents lbl_niv_req As Label
    Friend WithEvents lbl_niv_actual As Label
    Friend WithEvents btn_evidencia As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Pendiente As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents lbl_porcentaje As Label
End Class
