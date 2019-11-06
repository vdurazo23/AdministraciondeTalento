<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Organigrama
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarSuperiorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarDependienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AgregarCaracteristicaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodosLosPuestosHijosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodosLosPuestosPadreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionPersonalizadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodoElDepartamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SeleccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionarSuperioresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionarDependientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeseleccionarSuperioresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeselccionarDependientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.TreeView1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(979, 542)
        Me.Panel1.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.Location = New System.Drawing.Point(3, 3)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(731, 536)
        Me.TreeView1.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarSuperiorToolStripMenuItem, Me.AgregarDependienteToolStripMenuItem, Me.ToolStripSeparator1, Me.AgregarCaracteristicaToolStripMenuItem, Me.SeleccionToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(189, 120)
        '
        'AgregarSuperiorToolStripMenuItem
        '
        Me.AgregarSuperiorToolStripMenuItem.Name = "AgregarSuperiorToolStripMenuItem"
        Me.AgregarSuperiorToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AgregarSuperiorToolStripMenuItem.Text = "Agregar superior"
        '
        'AgregarDependienteToolStripMenuItem
        '
        Me.AgregarDependienteToolStripMenuItem.Name = "AgregarDependienteToolStripMenuItem"
        Me.AgregarDependienteToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AgregarDependienteToolStripMenuItem.Text = "Agregar dependiente"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(185, 6)
        '
        'AgregarCaracteristicaToolStripMenuItem
        '
        Me.AgregarCaracteristicaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TodosLosPuestosHijosToolStripMenuItem, Me.TodosLosPuestosPadreToolStripMenuItem, Me.SeleccionPersonalizadaToolStripMenuItem, Me.TodoElDepartamentoToolStripMenuItem})
        Me.AgregarCaracteristicaToolStripMenuItem.Name = "AgregarCaracteristicaToolStripMenuItem"
        Me.AgregarCaracteristicaToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.AgregarCaracteristicaToolStripMenuItem.Text = "Agregar caracteristica"
        '
        'TodosLosPuestosHijosToolStripMenuItem
        '
        Me.TodosLosPuestosHijosToolStripMenuItem.Name = "TodosLosPuestosHijosToolStripMenuItem"
        Me.TodosLosPuestosHijosToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.TodosLosPuestosHijosToolStripMenuItem.Text = "Todos los puestos hijos"
        '
        'TodosLosPuestosPadreToolStripMenuItem
        '
        Me.TodosLosPuestosPadreToolStripMenuItem.Name = "TodosLosPuestosPadreToolStripMenuItem"
        Me.TodosLosPuestosPadreToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.TodosLosPuestosPadreToolStripMenuItem.Text = "Todos los puestos padre"
        '
        'SeleccionPersonalizadaToolStripMenuItem
        '
        Me.SeleccionPersonalizadaToolStripMenuItem.Name = "SeleccionPersonalizadaToolStripMenuItem"
        Me.SeleccionPersonalizadaToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.SeleccionPersonalizadaToolStripMenuItem.Text = "Seleccion personalizada"
        '
        'TodoElDepartamentoToolStripMenuItem
        '
        Me.TodoElDepartamentoToolStripMenuItem.Name = "TodoElDepartamentoToolStripMenuItem"
        Me.TodoElDepartamentoToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.TodoElDepartamentoToolStripMenuItem.Text = "Todo el departamento"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(740, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 38)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Agregar caracteristica"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SeleccionToolStripMenuItem
        '
        Me.SeleccionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarSuperioresToolStripMenuItem, Me.SeleccionarDependientesToolStripMenuItem, Me.ToolStripSeparator2, Me.DeseleccionarSuperioresToolStripMenuItem, Me.DeselccionarDependientesToolStripMenuItem})
        Me.SeleccionToolStripMenuItem.Name = "SeleccionToolStripMenuItem"
        Me.SeleccionToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.SeleccionToolStripMenuItem.Text = "Seleccion"
        Me.SeleccionToolStripMenuItem.Visible = False
        '
        'SeleccionarSuperioresToolStripMenuItem
        '
        Me.SeleccionarSuperioresToolStripMenuItem.Name = "SeleccionarSuperioresToolStripMenuItem"
        Me.SeleccionarSuperioresToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.SeleccionarSuperioresToolStripMenuItem.Text = "Seleccionar superiores"
        '
        'SeleccionarDependientesToolStripMenuItem
        '
        Me.SeleccionarDependientesToolStripMenuItem.Name = "SeleccionarDependientesToolStripMenuItem"
        Me.SeleccionarDependientesToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.SeleccionarDependientesToolStripMenuItem.Text = "Seleccionar dependientes"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(212, 6)
        '
        'DeseleccionarSuperioresToolStripMenuItem
        '
        Me.DeseleccionarSuperioresToolStripMenuItem.Name = "DeseleccionarSuperioresToolStripMenuItem"
        Me.DeseleccionarSuperioresToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.DeseleccionarSuperioresToolStripMenuItem.Text = "Deseleccionar superiores"
        '
        'DeselccionarDependientesToolStripMenuItem
        '
        Me.DeselccionarDependientesToolStripMenuItem.Name = "DeselccionarDependientesToolStripMenuItem"
        Me.DeselccionarDependientesToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.DeselccionarDependientesToolStripMenuItem.Text = "Deselccionar dependientes"
        '
        'Organigrama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 566)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Organigrama"
        Me.Text = "Organigrama"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AgregarSuperiorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgregarDependienteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents AgregarCaracteristicaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodosLosPuestosHijosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodosLosPuestosPadreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionPersonalizadaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodoElDepartamentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents SeleccionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionarSuperioresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionarDependientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents DeseleccionarSuperioresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeselccionarDependientesToolStripMenuItem As ToolStripMenuItem
End Class
