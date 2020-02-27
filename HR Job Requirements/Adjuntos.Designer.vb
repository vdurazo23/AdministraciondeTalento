<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Adjuntos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Adjuntos))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_pendientes = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv_evaluaciones = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgv_rechazados = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgv_pendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_evaluaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_rechazados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(12, 78)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(932, 148)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-pdf-40.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8-word-48.png")
        Me.ImageList1.Images.SetKeyName(2, "icons8-archivo-de-imagen-48.png")
        Me.ImageList1.Images.SetKeyName(3, "icons8-ppt-48.png")
        Me.ImageList1.Images.SetKeyName(4, "icons8-xls-144.png")
        Me.ImageList1.Images.SetKeyName(5, "icons8-documento-48.png")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Goldenrod
        Me.Label1.Location = New System.Drawing.Point(12, 389)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pendientes de aprobacion"
        '
        'dgv_pendientes
        '
        Me.dgv_pendientes.AllowUserToAddRows = False
        Me.dgv_pendientes.AllowUserToDeleteRows = False
        Me.dgv_pendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pendientes.Location = New System.Drawing.Point(12, 410)
        Me.dgv_pendientes.Name = "dgv_pendientes"
        Me.dgv_pendientes.ReadOnly = True
        Me.dgv_pendientes.Size = New System.Drawing.Size(932, 137)
        Me.dgv_pendientes.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Archivos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(9, 231)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Evaluaciones"
        '
        'dgv_evaluaciones
        '
        Me.dgv_evaluaciones.AllowUserToAddRows = False
        Me.dgv_evaluaciones.AllowUserToDeleteRows = False
        Me.dgv_evaluaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_evaluaciones.Location = New System.Drawing.Point(12, 252)
        Me.dgv_evaluaciones.Name = "dgv_evaluaciones"
        Me.dgv_evaluaciones.ReadOnly = True
        Me.dgv_evaluaciones.Size = New System.Drawing.Size(932, 134)
        Me.dgv_evaluaciones.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(9, 550)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 18)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Rechazados"
        '
        'dgv_rechazados
        '
        Me.dgv_rechazados.AllowUserToAddRows = False
        Me.dgv_rechazados.AllowUserToDeleteRows = False
        Me.dgv_rechazados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_rechazados.Location = New System.Drawing.Point(12, 571)
        Me.dgv_rechazados.Name = "dgv_rechazados"
        Me.dgv_rechazados.ReadOnly = True
        Me.dgv_rechazados.Size = New System.Drawing.Size(932, 117)
        Me.dgv_rechazados.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(-1, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(958, 39)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Evidencia"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Adjuntos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(956, 695)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgv_rechazados)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgv_evaluaciones)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgv_pendientes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximumSize = New System.Drawing.Size(1247, 734)
        Me.MinimumSize = New System.Drawing.Size(805, 734)
        Me.Name = "Adjuntos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adjuntos"
        CType(Me.dgv_pendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_evaluaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_rechazados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label1 As Label
    Friend WithEvents dgv_pendientes As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgv_evaluaciones As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents dgv_rechazados As DataGridView
    Friend WithEvents Label5 As Label
End Class
