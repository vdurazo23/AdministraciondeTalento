<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Comparacion_control
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Comparacion_control))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TLP_Requerimientos.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 532.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TLP_Requerimientos, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 147.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1081, 539)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.TLP_Requerimientos.Location = New System.Drawing.Point(552, 3)
        Me.TLP_Requerimientos.Name = "TLP_Requerimientos"
        Me.TLP_Requerimientos.RowCount = 3
        Me.TLP_Requerimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TLP_Requerimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.66667!))
        Me.TLP_Requerimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.33334!))
        Me.TLP_Requerimientos.Size = New System.Drawing.Size(526, 141)
        Me.TLP_Requerimientos.TabIndex = 6
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
        Me.Label11.Size = New System.Drawing.Size(127, 30)
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
        Me.Progress_curso.Size = New System.Drawing.Size(127, 80)
        Me.Progress_curso.TabIndex = 8
        Me.Progress_curso.Valor = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridView1, 2)
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 150)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(1075, 386)
        Me.DataGridView1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(543, 147)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "00.png")
        Me.ImageList1.Images.SetKeyName(1, "01.png")
        Me.ImageList1.Images.SetKeyName(2, "02.png")
        Me.ImageList1.Images.SetKeyName(3, "03.png")
        Me.ImageList1.Images.SetKeyName(4, "04.png")
        Me.ImageList1.Images.SetKeyName(5, "05.png")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "NoAplica.png")
        Me.ImageList2.Images.SetKeyName(1, "OK.png")
        '
        'Comparacion_control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Comparacion_control"
        Me.Size = New System.Drawing.Size(1081, 539)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TLP_Requerimientos.ResumeLayout(False)
        Me.TLP_Requerimientos.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
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
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageList2 As ImageList
End Class
