<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuracion
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configuracion))
        Me.grpbx_Tress = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtserverTRESS = New System.Windows.Forms.TextBox()
        Me.btnvalidartress = New System.Windows.Forms.Button()
        Me.txtuserTRESS = New System.Windows.Forms.TextBox()
        Me.txtpassTRESS = New System.Windows.Forms.TextBox()
        Me.txtdbTRESS = New System.Windows.Forms.TextBox()
        Me.grpbx_MPS = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtserver = New System.Windows.Forms.TextBox()
        Me.btnvalidarmps = New System.Windows.Forms.Button()
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.txtbd = New System.Windows.Forms.TextBox()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpbx_Tress.SuspendLayout()
        Me.grpbx_MPS.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpbx_Tress
        '
        Me.grpbx_Tress.Controls.Add(Me.Label5)
        Me.grpbx_Tress.Controls.Add(Me.Label6)
        Me.grpbx_Tress.Controls.Add(Me.Label7)
        Me.grpbx_Tress.Controls.Add(Me.Label8)
        Me.grpbx_Tress.Controls.Add(Me.txtserverTRESS)
        Me.grpbx_Tress.Controls.Add(Me.btnvalidartress)
        Me.grpbx_Tress.Controls.Add(Me.txtuserTRESS)
        Me.grpbx_Tress.Controls.Add(Me.txtpassTRESS)
        Me.grpbx_Tress.Controls.Add(Me.txtdbTRESS)
        Me.grpbx_Tress.Location = New System.Drawing.Point(338, 12)
        Me.grpbx_Tress.Name = "grpbx_Tress"
        Me.grpbx_Tress.Size = New System.Drawing.Size(324, 155)
        Me.grpbx_Tress.TabIndex = 7
        Me.grpbx_Tress.TabStop = False
        Me.grpbx_Tress.Text = "Conexiones TRESS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Password:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "User:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Base de Datos:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(43, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Server:"
        '
        'txtserverTRESS
        '
        Me.txtserverTRESS.Location = New System.Drawing.Point(92, 24)
        Me.txtserverTRESS.Name = "txtserverTRESS"
        Me.txtserverTRESS.Size = New System.Drawing.Size(139, 20)
        Me.txtserverTRESS.TabIndex = 0
        '
        'btnvalidartress
        '
        Me.btnvalidartress.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.btnvalidartress.Location = New System.Drawing.Point(237, 55)
        Me.btnvalidartress.Name = "btnvalidartress"
        Me.btnvalidartress.Size = New System.Drawing.Size(71, 55)
        Me.btnvalidartress.TabIndex = 4
        Me.btnvalidartress.Text = "Validar"
        Me.btnvalidartress.UseVisualStyleBackColor = False
        '
        'txtuserTRESS
        '
        Me.txtuserTRESS.Location = New System.Drawing.Point(92, 86)
        Me.txtuserTRESS.Name = "txtuserTRESS"
        Me.txtuserTRESS.Size = New System.Drawing.Size(139, 20)
        Me.txtuserTRESS.TabIndex = 2
        '
        'txtpassTRESS
        '
        Me.txtpassTRESS.Location = New System.Drawing.Point(92, 116)
        Me.txtpassTRESS.Name = "txtpassTRESS"
        Me.txtpassTRESS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassTRESS.Size = New System.Drawing.Size(139, 20)
        Me.txtpassTRESS.TabIndex = 3
        '
        'txtdbTRESS
        '
        Me.txtdbTRESS.Location = New System.Drawing.Point(92, 55)
        Me.txtdbTRESS.Name = "txtdbTRESS"
        Me.txtdbTRESS.Size = New System.Drawing.Size(139, 20)
        Me.txtdbTRESS.TabIndex = 1
        '
        'grpbx_MPS
        '
        Me.grpbx_MPS.Controls.Add(Me.Label4)
        Me.grpbx_MPS.Controls.Add(Me.Label3)
        Me.grpbx_MPS.Controls.Add(Me.Label2)
        Me.grpbx_MPS.Controls.Add(Me.Label1)
        Me.grpbx_MPS.Controls.Add(Me.txtserver)
        Me.grpbx_MPS.Controls.Add(Me.btnvalidarmps)
        Me.grpbx_MPS.Controls.Add(Me.txtuser)
        Me.grpbx_MPS.Controls.Add(Me.txtpass)
        Me.grpbx_MPS.Controls.Add(Me.txtbd)
        Me.grpbx_MPS.Location = New System.Drawing.Point(12, 12)
        Me.grpbx_MPS.Name = "grpbx_MPS"
        Me.grpbx_MPS.Size = New System.Drawing.Size(320, 155)
        Me.grpbx_MPS.TabIndex = 6
        Me.grpbx_MPS.TabStop = False
        Me.grpbx_MPS.Text = "Conexiones MPS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "User:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Base de Datos:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Server:"
        '
        'txtserver
        '
        Me.txtserver.Location = New System.Drawing.Point(92, 24)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(139, 20)
        Me.txtserver.TabIndex = 0
        '
        'btnvalidarmps
        '
        Me.btnvalidarmps.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.btnvalidarmps.Location = New System.Drawing.Point(237, 51)
        Me.btnvalidarmps.Name = "btnvalidarmps"
        Me.btnvalidarmps.Size = New System.Drawing.Size(72, 55)
        Me.btnvalidarmps.TabIndex = 4
        Me.btnvalidarmps.Text = "Validar"
        Me.btnvalidarmps.UseVisualStyleBackColor = False
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(92, 86)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(139, 20)
        Me.txtuser.TabIndex = 2
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(92, 116)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass.Size = New System.Drawing.Size(139, 20)
        Me.txtpass.TabIndex = 3
        '
        'txtbd
        '
        Me.txtbd.Location = New System.Drawing.Point(92, 55)
        Me.txtbd.Name = "txtbd"
        Me.txtbd.Size = New System.Drawing.Size(139, 20)
        Me.txtbd.TabIndex = 1
        '
        'btncancelar
        '
        Me.btncancelar.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.btncancelar.Location = New System.Drawing.Point(338, 173)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(113, 47)
        Me.btncancelar.TabIndex = 10
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btncancelar.UseVisualStyleBackColor = False
        '
        'btnguardar
        '
        Me.btnguardar.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.btnguardar.Location = New System.Drawing.Point(219, 173)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(113, 47)
        Me.btnguardar.TabIndex = 9
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnguardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "connect.png")
        Me.ImageList1.Images.SetKeyName(1, "disconnect.png")
        '
        'Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 227)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.grpbx_Tress)
        Me.Controls.Add(Me.grpbx_MPS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(699, 266)
        Me.MinimumSize = New System.Drawing.Size(699, 266)
        Me.Name = "Configuracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuracion"
        Me.grpbx_Tress.ResumeLayout(False)
        Me.grpbx_Tress.PerformLayout()
        Me.grpbx_MPS.ResumeLayout(False)
        Me.grpbx_MPS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpbx_Tress As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtserverTRESS As TextBox
    Friend WithEvents btnvalidartress As Button
    Friend WithEvents txtuserTRESS As TextBox
    Friend WithEvents txtpassTRESS As TextBox
    Friend WithEvents txtdbTRESS As TextBox
    Friend WithEvents grpbx_MPS As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtserver As TextBox
    Friend WithEvents btnvalidarmps As Button
    Friend WithEvents txtuser As TextBox
    Friend WithEvents txtpass As TextBox
    Friend WithEvents txtbd As TextBox
    Friend WithEvents btncancelar As Button
    Friend WithEvents btnguardar As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ToolTip1 As ToolTip
End Class
