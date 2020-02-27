<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ticket
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_solicitante = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_aprueba = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_id = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_solicitud = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic)
        Me.Label1.Location = New System.Drawing.Point(3, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Solicitado por:"
        '
        'lbl_solicitante
        '
        Me.lbl_solicitante.AutoSize = True
        Me.lbl_solicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_solicitante.Location = New System.Drawing.Point(3, 135)
        Me.lbl_solicitante.Name = "lbl_solicitante"
        Me.lbl_solicitante.Size = New System.Drawing.Size(63, 20)
        Me.lbl_solicitante.TabIndex = 1
        Me.lbl_solicitante.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(508, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Status:"
        '
        'lbl_status
        '
        Me.lbl_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.Green
        Me.lbl_status.Location = New System.Drawing.Point(589, 47)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(90, 20)
        Me.lbl_status.TabIndex = 3
        Me.lbl_status.Text = "Pendiente"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Label3.Location = New System.Drawing.Point(495, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Usuario:"
        '
        'lbl_aprueba
        '
        Me.lbl_aprueba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_aprueba.AutoSize = True
        Me.lbl_aprueba.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_aprueba.Location = New System.Drawing.Point(589, 75)
        Me.lbl_aprueba.Name = "lbl_aprueba"
        Me.lbl_aprueba.Size = New System.Drawing.Size(127, 20)
        Me.lbl_aprueba.TabIndex = 5
        Me.lbl_aprueba.Text = "Quien aprueba"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(529, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Fecha:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(593, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "29/11/2019"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Button2.Image = Global.Administracion_de_talento.My.Resources.Resources.cancelar_login
        Me.Button2.Location = New System.Drawing.Point(625, 158)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(106, 46)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Rechazar"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Id:"
        '
        'lbl_id
        '
        Me.lbl_id.AutoSize = True
        Me.lbl_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_id.ForeColor = System.Drawing.Color.Red
        Me.lbl_id.Location = New System.Drawing.Point(39, 11)
        Me.lbl_id.Name = "lbl_id"
        Me.lbl_id.Size = New System.Drawing.Size(55, 16)
        Me.lbl_id.TabIndex = 11
        Me.lbl_id.Text = "Label7"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 18)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Solicitud:"
        '
        'lbl_solicitud
        '
        Me.lbl_solicitud.Location = New System.Drawing.Point(4, 58)
        Me.lbl_solicitud.Name = "lbl_solicitud"
        Me.lbl_solicitud.Size = New System.Drawing.Size(428, 50)
        Me.lbl_solicitud.TabIndex = 13
        Me.lbl_solicitud.Text = "Label8"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(568, 108)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(111, 32)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Ver"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lbl_id)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 33)
        Me.Panel1.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Administracion_de_talento.My.Resources.Resources.check_in1
        Me.Button1.Location = New System.Drawing.Point(513, 158)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 46)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Aprobar"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Ticket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.lbl_solicitud)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_aprueba)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_status)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_solicitante)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Ticket"
        Me.Size = New System.Drawing.Size(762, 216)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_solicitante As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_status As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lbl_aprueba As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents lbl_id As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lbl_solicitud As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel1 As Panel
End Class
