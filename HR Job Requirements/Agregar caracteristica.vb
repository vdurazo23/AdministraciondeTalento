

Public Class Agregar_caracteristica
    Public caracteristicas As String = ""
    Public Id As Integer = 0
    Public nivel_competencia As Integer = 0
    Dim competencia_indicador As Boolean = False
    Dim habilidad_indicador As Boolean = False
    Dim conocimiento_indicador As Boolean = False
    Dim curso_indicador As Boolean = False
    Public nuevo As Boolean = True
    Dim midataset As New DataSet
    Public id_creador As Integer
    Dim rowfilter1 As String = "1=1 and"
    Dim rowfilter2 As String = " 1=1"
    Dim description As String = ""
    Dim queinicial As String = ""
    Dim what As String = ""
    Dim comoinicial As String = ""
    Dim how As String = ""
    Dim recursosinicial As String = ""
    Dim res As String = ""
    Dim extrainicial As String = ""

    Private Sub Agregar_caracteristica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If nuevo = True Then
                btn_editar.Visible = False

            End If
            Select Case caracteristicas
                Case "Habilidad"
                    habilidad_indicador = True
                    If nuevo Then
                        Label1.Text = "Nueva habilidad"
                    Else
                        Label1.Text = "Editar habilidad"
                    End If
                Case "Conocimiento"
                    conocimiento_indicador = True
                    If nuevo Then
                        Label1.Text = "Nuevo conocimiento"
                    Else
                        Label1.Text = "Editar conocimiento"
                    End If

                Case "Competencia"
                    competencia_indicador = True
                    If nuevo Then
                        Label1.Text = "Nueva competencia"

                    Else
                        Label1.Text = "Editar competencia"
                    End If
                    lbl_competencia.Visible = True
                    numeric_competencia.Visible = True
                Case "Curso"
                    curso_indicador = True
                    If nuevo Then
                        Label1.Text = "Nueva competencia"
                    Else
                        Label1.Text = "Editar competencia"
                    End If
            End Select

            TextBox1.Focus()
            If TextBox1.Text = "" Then
                Button1.Enabled = False

                Panel2.Visible = False
            End If
            If nuevo = False Then
                TextBox1.Enabled = False
                numeric_competencia.Value = nivel_competencia
                Cargar_relaciones()

            End If
            '  DataGridView1.ContextMenuStrip = ContextMenuStrip1

            queinicial = TXT_QUE.Text
            comoinicial = TXT_COMO.Text
            recursosinicial = TXT_RECURSOS.Text
            extrainicial = TXT_EXTRA.Text
            description = TextBox2.Text
            what = TXT_WHAT.Text
            how = TXT_HOW.Text
            res = TXT_RESOURCES.Text

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs)
        ''Se activa cuando se le da un doble click a un elemento del listview1

        'Dim reln As New Relacion

        'reln.Nuevo = False
        'reln.Id_caracteristica = Id

        'reln.items = CType(sender, ListView).SelectedItems(0)
        'If reln.ShowDialog() = DialogResult.OK Then
        '    Cargar_relaciones()

        'End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'Agregar o actualizar
            ErrorProvider1.Clear()
            If TextBox1.Text = "" Then
                ErrorProvider1.SetError(TextBox1, "")
            End If
            If nuevo Then
                Dim re = SqlQuery.AgregarCaracteristica(TextBox1.Text, TXT_QUE.Text, TXT_COMO.Text, TXT_RECURSOS.Text, TXT_EXTRA.Text, competencia_indicador, habilidad_indicador, conocimiento_indicador, curso_indicador, True, numeric_competencia.Value, TextBox2.Text, TXT_WHAT.Text, TXT_HOW.Text, TXT_RESOURCES.Text)
                If re = 0 Then
                    Console.WriteLine("")
                    ErrorProvider1.SetError(TextBox1, "Nombre repetido")
                    MsgBox("Ese nombre ya existe, seleccione otro", MsgBoxStyle.Critical)
                ElseIf re = -2 Then
                    ErrorProvider1.SetError(TextBox1, "Nombre repetido")
                    MsgBox("Ese nombre ya existe, seleccione otro", MsgBoxStyle.Critical)

                ElseIf re > 0 Then
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                    Me.Dispose()
                End If
            Else
                If TextBox1.Enabled = True Or (nivel_competencia <> numeric_competencia.Value) Or (TXT_QUE.Text <> queinicial) Or (TXT_COMO.Text <> comoinicial) Or (TXT_RECURSOS.Text <> recursosinicial) Or (TXT_EXTRA.Text <> extrainicial) Or (TextBox2.Text <> description) Or (TXT_WHAT.Text <> what) Or (TXT_HOW.Text <> how) Or (TXT_RESOURCES.Text <> res) Then
                    Dim re = SqlQuery.AgregarCaracteristica(TextBox1.Text, TXT_QUE.Text, TXT_COMO.Text, TXT_RECURSOS.Text, TXT_EXTRA.Text, competencia_indicador, habilidad_indicador, conocimiento_indicador, curso_indicador, False, numeric_competencia.Value, TextBox2.Text, TXT_WHAT.Text, TXT_HOW.Text, TXT_RESOURCES.Text, Id)
                    If re = 0 Then
                        Console.WriteLine("")
                        ErrorProvider1.SetError(TextBox1, "Nombre repetido")
                        MsgBox("Ese nombre ya existe, seleccione otro", MsgBoxStyle.Critical)
                    ElseIf re = -2 Then
                        ErrorProvider1.SetError(TextBox1, "Nombre repetido")
                        MsgBox("Ese nombre ya existe, seleccione otro", MsgBoxStyle.Critical)

                    ElseIf re > 0 Then
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                        Me.Dispose()
                    End If
                Else
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If

            End If



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Error al aceptar")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If TextBox1.Text <> "" Then
                Panel2.Visible = True
                Button1.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ErrorProvider1.Clear()

            If nuevo = True Then
                Dim i = MsgBox("Antes de relacionar la caracteristica es necesario guardarla, ¿Desea guardar la caracteristica?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
                If i = MsgBoxResult.Yes Then

                    'Guardar
                    If TextBox1.Text.Trim = "" Then
                        ErrorProvider1.SetError(TextBox1, "El nombre no puede ser en blanco")
                        Exit Sub
                    End If
                    Dim re = SqlQuery.AgregarCaracteristica(TextBox1.Text, TXT_QUE.Text, TXT_COMO.Text, TXT_RECURSOS.Text, TXT_EXTRA.Text, competencia_indicador, habilidad_indicador, conocimiento_indicador, curso_indicador, True, numeric_competencia.Value, TextBox2.Text, TXT_WHAT.Text, TXT_HOW.Text, TXT_RESOURCES.Text)
                    If re = 0 Then
                        ErrorProvider1.SetError(TextBox1, "Nombre repetido")
                        MsgBox("Ese nombre ya existe, seleccione otro", MsgBoxStyle.Critical)

                    ElseIf re = -2 Then
                        ErrorProvider1.SetError(TextBox1, "Nombre repetido")
                        MsgBox("Ese nombre ya existe, seleccione otro", MsgBoxStyle.Critical)

                    ElseIf re > 0 Then
                        Console.WriteLine("")
                        TextBox1.Enabled = False
                        btn_editar.Visible = True
                        nuevo = False
                        Id = re
                        nivel_competencia = numeric_competencia.Value
                        Select Case caracteristicas
                            Case "Habilidad"
                                Label1.Text = "Editar habilidad"
                            Case "Conocimiento"
                                Label1.Text = "Editar conocimiento"
                            Case "Competencia"
                                Label1.Text = "Editar competencia"
                        End Select
                        Dim s As New Relacion
                        id_creador = My.Settings.Id_user
                        s.Id_caracteristica = re
                        Id = re
                        s.nivel_competencia = nivel_competencia
                        's.solicitado_por = ComboBox1.SelectedItem.ToString
                        s.ShowDialog()
                    End If
                Else
                    Exit Sub
                End If
            Else

                If id_creador = My.Settings.Id_user Then
                    If Not Permiso.Habilitado("RCCRE") Then
                        MsgBox("No tiene permisos para relacionar esta caraceristica", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Else
                    If Not Permiso.Habilitado("RCC") Then
                        MsgBox("No tiene permisos para relacionar esta caracteristica", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If


                If TextBox1.Enabled = True Or nivel_competencia <> numeric_competencia.Value Or (TXT_QUE.Text <> queinicial) Or (TXT_COMO.Text <> comoinicial) Or (TXT_RECURSOS.Text <> recursosinicial) Or (TXT_EXTRA.Text <> extrainicial) Or (TextBox2.Text <> description) Or (TXT_WHAT.Text <> what) Or (TXT_HOW.Text <> how) Or (TXT_RESOURCES.Text <> res) Then
                    If TextBox1.Text.Trim = "" Then
                        ErrorProvider1.SetError(TextBox1, "El nombre no puede ser en blanco")
                        Exit Sub
                    End If
                    Dim re = SqlQuery.AgregarCaracteristica(TextBox1.Text, TXT_QUE.Text, TXT_COMO.Text, TXT_RECURSOS.Text, TXT_EXTRA.Text, competencia_indicador, habilidad_indicador, conocimiento_indicador, curso_indicador, False, numeric_competencia.Value, TextBox2.Text, TXT_WHAT.Text, TXT_HOW.Text, TXT_RESOURCES.Text, Id)
                    If re = 0 Then
                        ErrorProvider1.SetError(TextBox1, "Nombre repetido")
                        MsgBox("Ese nombre ya existe, seleccione otro", MsgBoxStyle.Critical)

                    ElseIf re = -2 Then
                        ErrorProvider1.SetError(TextBox1, "Nombre repetido")
                        MsgBox("Ese nombre ya existe, seleccione otro", MsgBoxStyle.Critical)

                    ElseIf re > 0 Then
                        Console.WriteLine("")
                        TextBox1.Enabled = False
                        btn_editar.Visible = True
                        Dim s As New Relacion
                        s.Id_caracteristica = re
                        s.Show()
                    End If
                Else
                    Dim s As New Relacion
                    If caracteristicas = "Competencia" Then s.nivel_competencia = nivel_competencia
                    Select Case caracteristicas
                        Case "Habilidad"
                            s.tipo = "Hab"
                        Case "Conocimiento"
                            s.tipo = "Con"
                        Case "Competencia"
                            s.tipo = "Com"
                    End Select

                    s.Id_caracteristica = Id
                    s.ShowDialog()

                End If

            End If
            'Actualizar relaciones

            Cargar_relaciones()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex, "Al querer agregar relación")
        End Try
    End Sub

    Private Sub Cargar_relaciones()
        Try


            Dim TE As New DataTable
            TE = CType(SqlQuery.relaciones(Id, False), DataTable).Copy
            TE.TableName = "Relacionescom"
            If midataset.Tables("Relacionescom") IsNot Nothing Then
                midataset.Tables.Remove("Relacionescom")
            End If
            midataset.Tables.Add(TE)

            DataGridView1.DataSource = TE.DefaultView
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(6).Visible = False
            DataGridView1.Columns(7).Visible = False
            DataGridView1.Columns(8).Visible = False
            DataGridView1.Columns(12).Visible = False

            Todo.PerformClick()
            Exit Sub
            Dim ta As New DataTable
            ta = CType(SqlQuery.relaciones(Id, False), DataTable).Copy
            ta.TableName = "Relaciones"
            If ta.Rows.Count > 0 Then

                ta.DefaultView.RowFilter = "Por_puesto = True and (Escalona = True or Hereda = True)"
                Dim we As DataTable = ta.Select("Por_puesto = True and (Escalona = True or Hereda = True)").CopyToDataTable


                Dim wee As DataTable = ta.Select("Por_puesto = True and Escalona = False and Hereda = False").CopyToDataTable


            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btn_editar_Click(sender As Object, e As EventArgs) Handles btn_editar.Click
        If id_creador = My.Settings.Id_user Then
            If Not Permiso.Habilitado("ECCRE") Then
                MsgBox("No tiene permisos para editar esta caraceristica", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Else
            If Not Permiso.Habilitado("ECC") Then
                MsgBox("No tiene permisos para editar esta caracteristica", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        TextBox1.Enabled = True
        TextBox1.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Enabled = True Or nivel_competencia <> numeric_competencia.Value Or (TXT_QUE.Text <> queinicial) Or (TXT_COMO.Text <> comoinicial) Or (TXT_RECURSOS.Text <> recursosinicial) Or (TXT_EXTRA.Text <> extrainicial) Or (TextBox2.Text <> description) Or (TXT_WHAT.Text <> what) Or (TXT_HOW.Text <> how) Or (TXT_RESOURCES.Text <> res) Then
            Dim a = MsgBox("¿Desea guardar antes de salir?", MsgBoxStyle.YesNoCancel)
            If a = MsgBoxResult.Yes Then
                'guardar
                If nuevo Then

                Else

                End If
                Me.DialogResult = DialogResult.Cancel
            ElseIf a = MsgBoxResult.No Then
                Me.DialogResult = DialogResult.Cancel
            ElseIf a = MsgBoxResult.Cancel Then

            End If
        Else
            Me.DialogResult = DialogResult.OK

        End If


    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)
        Me.Text = Me.Text + "   DD"
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)

        'Se activa cuando se le da un doble click a un elemento del listview1
        If e.Button = MouseButtons.Right Then Exit Sub
        Dim reln As New Relacion
        reln.Nuevo = False
        reln.Id_caracteristica = Id
        reln.items = CType(sender, ListView).SelectedItems(0)
        If reln.ShowDialog() = DialogResult.OK Then
            Cargar_relaciones()
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub




    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Delete Then
            btn_borrar.PerformClick()
        End If
        If keyData = Keys.Control + Keys.Alt + Keys.C Then
            Dim co As New Configuraciones
            co.ShowDialog()
        End If
        If keyData = Keys.Escape Then
            Me.Close()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Todo.Click, Hereda.Click, Escalona.Click, Por_puesto.Click, Por_empleado.Click, Por_nivel.Click
        Try

            For Each btn As Button In Panel3.Controls
                If btn.Name = CType(sender, Button).Name Then
                    btn.BackColor = Color.Gray
                    btn.Enabled = False
                Else
                    btn.BackColor = Color.White
                    btn.Enabled = True
                End If
            Next
            If midataset.Tables("Relacionescom") IsNot Nothing Then
                If midataset.Tables("Relacionescom").Rows.Count > 0 Then


                    Select Case CType(sender, Button).Name
                        Case "Todo"
                            rowfilter1 = "1=1 and"
                            midataset.Tables("Relacionescom").DefaultView.RowFilter = rowfilter1 & rowfilter2
                        Case "Por_puesto"
                            rowfilter1 = "Por_puesto = True and Escalona = False and Hereda = False   and "
                            midataset.Tables("Relacionescom").DefaultView.RowFilter = rowfilter1 & rowfilter2
                            DataGridView1.Columns(5).Visible = False
                        Case Else
                            rowfilter1 = CType(sender, Button).Name.ToString & " = True and"
                            midataset.Tables("Relacionescom").DefaultView.RowFilter = rowfilter1 & rowfilter2
                            If CType(sender, Button).Name <> "Por_nivel" Then
                                DataGridView1.Columns(5).Visible = False
                            Else
                                DataGridView1.Columns(5).Visible = True
                            End If

                    End Select
                    If CType(sender, Button).Name <> "Todo" Then
                        If CType(sender, Button).Name = "Por_empleado" Then
                            DataGridView1.Columns(13).Visible = True
                            DataGridView1.Columns(14).Visible = True
                        Else
                            DataGridView1.Columns(13).Visible = False
                            DataGridView1.Columns(14).Visible = False
                        End If
                        If CType(sender, Button).Name = "Por_nivel" Then
                            DataGridView1.Columns(5).Visible = True
                        Else
                            DataGridView1.Columns(5).Visible = False
                        End If
                        If CType(sender, Button).Name = "Escalona" Then
                            DataGridView1.Columns(10).Visible = True
                        Else
                            DataGridView1.Columns(10).Visible = False
                        End If
                        If (CType(sender, Button).Name = "Hereda" Or CType(sender, Button).Name = "Escalona" Or CType(sender, Button).Name = "Por_puesto") Then
                            DataGridView1.Columns(9).Visible = True
                        Else
                            DataGridView1.Columns(9).Visible = False
                        End If

                    Else
                        DataGridView1.Columns(13).Visible = True
                        DataGridView1.Columns(14).Visible = True
                        DataGridView1.Columns(5).Visible = True
                        DataGridView1.Columns(10).Visible = True
                        DataGridView1.Columns(9).Visible = True
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            If Not Debugger.IsAttached Then
                Exit Sub
            End If
            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
            If Not Permiso.Habilitado("RCC") Then
                If id_creador = My.Settings.Id_user Then
                    If Not Permiso.Habilitado("RCCRE") Then
                        MsgBox("No tiene permisos para agregar, eliminar o editar alguna relacion a esta caracteristica", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            End If
            Dim reln As New Relacion
            reln.Nuevo = False
            reln.Id_caracteristica = Id
            reln.items_row = DataGridView1.Rows(e.RowIndex)
            If reln.ShowDialog() = DialogResult.OK Then
                Cargar_relaciones()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub btn_borrar_click(sender As Object, e As EventArgs) Handles btn_borrar.Click
        Try
            If Not Permiso.Habilitado("BCR") Then
                If id_creador = My.Settings.Id_user Then
                    If Not Permiso.Habilitado("BCCRE") Then
                        MsgBox("No tiene permisos para agregar, eliminar o editar alguna relacion a esta caracteristica", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Else
                    MsgBox("No tiene permisos para agregar, eliminar o editar alguna relacion a esta caracteristica", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            If MsgBox("¿Seguro que desea eliminar esta relacion?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If SqlQuery.eliminar_instruccion(DataGridView1.CurrentRow.Cells("id").Value) = True Then
                    Cargar_relaciones()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Agregar_caracteristica_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Me.DialogResult = Nothing Then
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btn_nivelrequerido_Click(sender As Object, e As EventArgs) Handles btn_nivelrequerido.Click
        Try

            SqlQuery.modificar_calificaciones(Id)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class