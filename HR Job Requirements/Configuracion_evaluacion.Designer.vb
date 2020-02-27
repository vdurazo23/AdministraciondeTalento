<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuracion_evaluacion
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmb_rel = New System.Windows.Forms.ComboBox()
        Me.cmb_pond = New System.Windows.Forms.ComboBox()
        Me.rel_check = New System.Windows.Forms.CheckBox()
        Me.pond_check = New System.Windows.Forms.CheckBox()
        Me.req_check = New System.Windows.Forms.CheckBox()
        Me.cmb_req = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Calificacion_check = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Calificacion_check)
        Me.Panel1.Controls.Add(Me.cmb_rel)
        Me.Panel1.Controls.Add(Me.cmb_pond)
        Me.Panel1.Controls.Add(Me.rel_check)
        Me.Panel1.Controls.Add(Me.pond_check)
        Me.Panel1.Controls.Add(Me.req_check)
        Me.Panel1.Controls.Add(Me.cmb_req)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(12, 62)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(685, 426)
        Me.Panel1.TabIndex = 0
        '
        'cmb_rel
        '
        Me.cmb_rel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_rel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_rel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_rel.FormattingEnabled = True
        Me.cmb_rel.Items.AddRange(New Object() {"Por Nivel", "Por Puesto", "Por Número de Empleado"})
        Me.cmb_rel.Location = New System.Drawing.Point(132, 360)
        Me.cmb_rel.Name = "cmb_rel"
        Me.cmb_rel.Size = New System.Drawing.Size(369, 33)
        Me.cmb_rel.TabIndex = 8
        '
        'cmb_pond
        '
        Me.cmb_pond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_pond.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_pond.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_pond.FormattingEnabled = True
        Me.cmb_pond.Items.AddRange(New Object() {"0 - 3", "0 - 4", "0 - 5", "OK - NO OK"})
        Me.cmb_pond.Location = New System.Drawing.Point(132, 189)
        Me.cmb_pond.Name = "cmb_pond"
        Me.cmb_pond.Size = New System.Drawing.Size(369, 33)
        Me.cmb_pond.TabIndex = 7
        '
        'rel_check
        '
        Me.rel_check.AutoSize = True
        Me.rel_check.Location = New System.Drawing.Point(20, 360)
        Me.rel_check.Name = "rel_check"
        Me.rel_check.Size = New System.Drawing.Size(103, 17)
        Me.rel_check.TabIndex = 6
        Me.rel_check.Text = "No especificado"
        Me.rel_check.UseVisualStyleBackColor = True
        '
        'pond_check
        '
        Me.pond_check.AutoSize = True
        Me.pond_check.Location = New System.Drawing.Point(20, 189)
        Me.pond_check.Name = "pond_check"
        Me.pond_check.Size = New System.Drawing.Size(103, 17)
        Me.pond_check.TabIndex = 5
        Me.pond_check.Text = "No especificado"
        Me.pond_check.UseVisualStyleBackColor = True
        '
        'req_check
        '
        Me.req_check.AutoSize = True
        Me.req_check.Location = New System.Drawing.Point(20, 73)
        Me.req_check.Name = "req_check"
        Me.req_check.Size = New System.Drawing.Size(103, 17)
        Me.req_check.TabIndex = 4
        Me.req_check.Text = "No especificado"
        Me.req_check.UseVisualStyleBackColor = True
        '
        'cmb_req
        '
        Me.cmb_req.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_req.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_req.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_req.FormattingEnabled = True
        Me.cmb_req.Items.AddRange(New Object() {"Corporativo", "Descripción del puesto", "Requerimiento del cliente", "Legal/Normativa", "Adicional"})
        Me.cmb_req.Location = New System.Drawing.Point(132, 73)
        Me.cmb_req.Name = "cmb_req"
        Me.cmb_req.Size = New System.Drawing.Size(369, 33)
        Me.cmb_req.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 333)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo de relación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ponderación"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Requerido por"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(171, 496)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(168, 50)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(345, 496)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(168, 50)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Calificacion_check
        '
        Me.Calificacion_check.AutoSize = True
        Me.Calificacion_check.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Calificacion_check.Location = New System.Drawing.Point(20, 228)
        Me.Calificacion_check.Name = "Calificacion_check"
        Me.Calificacion_check.Size = New System.Drawing.Size(185, 24)
        Me.Calificacion_check.TabIndex = 9
        Me.Calificacion_check.Text = "Calificación Máxima"
        Me.Calificacion_check.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 31)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Label4"
        '
        'Configuracion_evaluacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 559)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Configuracion_evaluacion"
        Me.Text = "Configuracion_evaluacion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cmb_rel As ComboBox
    Friend WithEvents cmb_pond As ComboBox
    Friend WithEvents rel_check As CheckBox
    Friend WithEvents pond_check As CheckBox
    Friend WithEvents req_check As CheckBox
    Friend WithEvents cmb_req As ComboBox
    Friend WithEvents Calificacion_check As CheckBox
    Friend WithEvents Label4 As Label
End Class
