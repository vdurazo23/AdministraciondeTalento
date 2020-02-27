<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.TLP_Requerimientos = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Progress_competencias = New Administracion_de_talento.Progress()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Progress_habilidades = New Administracion_de_talento.Progress()
        Me.Progress_conocimiento = New Administracion_de_talento.Progress()
        Me.Progress_curso = New Administracion_de_talento.Progress()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Caracteristica1 = New Administracion_de_talento.Caracteristica()
        Me.TLP_Requerimientos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.TLP_Requerimientos.Location = New System.Drawing.Point(374, 3)
        Me.TLP_Requerimientos.Name = "TLP_Requerimientos"
        Me.TLP_Requerimientos.RowCount = 3
        Me.TLP_Requerimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TLP_Requerimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.66667!))
        Me.TLP_Requerimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.33334!))
        Me.TLP_Requerimientos.Size = New System.Drawing.Size(525, 141)
        Me.TLP_Requerimientos.TabIndex = 5
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
        'Progress_competencias
        '
        Me.Progress_competencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Progress_competencias.Location = New System.Drawing.Point(3, 58)
        Me.Progress_competencias.Name = "Progress_competencias"
        Me.Progress_competencias.Size = New System.Drawing.Size(125, 80)
        Me.Progress_competencias.TabIndex = 4
        Me.Progress_competencias.Valor = 15
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
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel2.Location = New System.Drawing.Point(3, 150)
        Me.Panel2.MinimumSize = New System.Drawing.Size(1300, 349)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1300, 397)
        Me.Panel2.TabIndex = 12
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1296, 393)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1290, 334)
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1290, 0)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.Caracteristica1.Size = New System.Drawing.Size(1290, 47)
        Me.Caracteristica1.TabIndex = 3
        '
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TLP_Requerimientos)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(1308, 557)
        Me.TLP_Requerimientos.ResumeLayout(False)
        Me.TLP_Requerimientos.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TLP_Requerimientos As TableLayoutPanel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Progress_competencias As Progress
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Progress_habilidades As Progress
    Friend WithEvents Progress_conocimiento As Progress
    Friend WithEvents Progress_curso As Progress
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Caracteristica1 As Caracteristica
End Class
