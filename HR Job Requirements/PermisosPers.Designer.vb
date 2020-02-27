<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PermisosPers
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_noempleado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_dpto = New System.Windows.Forms.TextBox()
        Me.Txt_pto = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TreeView3 = New System.Windows.Forms.TreeView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TreeView4 = New System.Windows.Forms.TreeView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_nombre = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(149, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "No. Empleado"
        '
        'Txt_noempleado
        '
        Me.Txt_noempleado.Location = New System.Drawing.Point(152, 28)
        Me.Txt_noempleado.Name = "Txt_noempleado"
        Me.Txt_noempleado.Size = New System.Drawing.Size(71, 20)
        Me.Txt_noempleado.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(149, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(154, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Departamento"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(154, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Puesto"
        '
        'Txt_dpto
        '
        Me.Txt_dpto.Enabled = False
        Me.Txt_dpto.Location = New System.Drawing.Point(152, 114)
        Me.Txt_dpto.Name = "Txt_dpto"
        Me.Txt_dpto.Size = New System.Drawing.Size(244, 20)
        Me.Txt_dpto.TabIndex = 7
        '
        'Txt_pto
        '
        Me.Txt_pto.Enabled = False
        Me.Txt_pto.Location = New System.Drawing.Point(152, 153)
        Me.Txt_pto.Name = "Txt_pto"
        Me.Txt_pto.Size = New System.Drawing.Size(244, 20)
        Me.Txt_pto.TabIndex = 8
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Enabled = False
        Me.TabControl1.Location = New System.Drawing.Point(12, 216)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(464, 393)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TreeView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(456, 367)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Caracteristicas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(3, 3)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(450, 361)
        Me.TreeView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TreeView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(456, 367)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Evaluación"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TreeView2
        '
        Me.TreeView2.CheckBoxes = True
        Me.TreeView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView2.Location = New System.Drawing.Point(3, 3)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(450, 361)
        Me.TreeView2.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TreeView3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(456, 367)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Otros"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TreeView3
        '
        Me.TreeView3.CheckBoxes = True
        Me.TreeView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView3.Location = New System.Drawing.Point(0, 0)
        Me.TreeView3.Name = "TreeView3"
        Me.TreeView3.Size = New System.Drawing.Size(456, 367)
        Me.TreeView3.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.TreeView4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(456, 367)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Pestañas"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TreeView4
        '
        Me.TreeView4.CheckBoxes = True
        Me.TreeView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView4.Location = New System.Drawing.Point(3, 3)
        Me.TreeView4.Name = "TreeView4"
        Me.TreeView4.Size = New System.Drawing.Size(450, 361)
        Me.TreeView4.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Permisos"
        '
        'cmb_nombre
        '
        Me.cmb_nombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_nombre.FormattingEnabled = True
        Me.cmb_nombre.Location = New System.Drawing.Point(152, 73)
        Me.cmb_nombre.Name = "cmb_nombre"
        Me.cmb_nombre.Size = New System.Drawing.Size(244, 21)
        Me.cmb_nombre.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(229, 615)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 85)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(118, 615)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(93, 85)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(395, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(74, 46)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Permisos múltiple"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Administracion_de_talento.My.Resources.Resources.LogoSmall___copia
        Me.PictureBox1.Location = New System.Drawing.Point(23, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(109, 106)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PermisosPers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(480, 708)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmb_nombre)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Txt_pto)
        Me.Controls.Add(Me.Txt_dpto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_noempleado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PermisosPers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "      "
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_noempleado As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_dpto As TextBox
    Friend WithEvents Txt_pto As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents cmb_nombre As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents TreeView2 As TreeView
    Friend WithEvents TreeView3 As TreeView
    Friend WithEvents TreeView4 As TreeView
End Class
