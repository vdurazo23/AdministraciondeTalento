Public Class Agregar_caracteristica
    Public caracteristicas As String = ""
    Public Id As Integer = 0
    Dim competencia_indicador As Boolean = False
    Dim habilidad_indicador As Boolean = False
    Dim conocimiento_indicador As Boolean = False
    Public nuevo As Boolean = True
    Dim midataset As DataSet
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
            End Select

            TextBox1.Focus()
            If TextBox1.Text = "" Then
                Button1.Enabled = False

                Panel2.Visible = False
            End If
            If nuevo = False Then
                TextBox1.Enabled = False
                Cargar_relaciones()

            End If
            ListView1.ContextMenuStrip = ContextMenuStrip1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
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
                Dim re = SqlQuery.AgregarCaracteristica(TextBox1.Text, competencia_indicador, habilidad_indicador, conocimiento_indicador, True)
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
                If TextBox1.Enabled = True Then
                    Dim re = SqlQuery.AgregarCaracteristica(TextBox1.Text, competencia_indicador, habilidad_indicador, conocimiento_indicador, False, Id)
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
                    Me.DialogResult = DialogResult.Cancel
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

                    Dim re = SqlQuery.AgregarCaracteristica(TextBox1.Text, competencia_indicador, habilidad_indicador, conocimiento_indicador, True)
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
                        Select Case caracteristicas
                            Case "Habilidad"
                                Label1.Text = "Editar habilidad"
                            Case "Conocimiento"
                                Label1.Text = "Editar conocimiento"
                            Case "Competencia"
                                Label1.Text = "Editar competencia"
                        End Select
                        Dim s As New Relacion
                        s.Id_caracteristica = re
                        Id = re
                        's.solicitado_por = ComboBox1.SelectedItem.ToString
                        s.Show()

                    End If

                Else
                    Exit Sub
                End If
            Else
                If TextBox1.Enabled = True Then


                    If TextBox1.Text.Trim = "" Then
                        ErrorProvider1.SetError(TextBox1, "El nombre no puede ser en blanco")
                        Exit Sub
                    End If

                    Dim re = SqlQuery.AgregarCaracteristica(TextBox1.Text, competencia_indicador, habilidad_indicador, conocimiento_indicador, False,Id)
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
            ListView1.Items.Clear()
            Dim ta As New DataTable
            ta = CType(SqlQuery.relaciones(Id), DataTable).Copy
            ta.TableName = "Relaciones"
            For Each ro As DataRow In ta.Rows
                If ro("Por_Nivel") = True Then
                    ListView1.Items.Add("Por Nivel")
                Else
                    ListView1.Items.Add("Por Puesto")
                End If
                ListView1.Items(ListView1.Items.Count - 1).Tag = ro("Id")

                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(ro("Solicitado_por").ToString) ' Tipo
                If ro("Por_Nivel") = True Then
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(ro("Id_nivel").ToString) ' Requerido por
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("N/A")
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("N/A")
                Else
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(ro("PU_INICIA").ToString) ' Nivel

                    If ro("Escalona") = True Then
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("Escalonado")
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(ro("PU_FINAL").ToString)
                    ElseIf ro("Hereda") = True Then
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("Heredado")
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("N/A")
                    Else
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("Solo puesto")
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("N/A")
                    End If

                End If

                If ro("Activo") = True Then
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("ACTIVO") ' tope
                Else
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("NO ACTIVO") ' tope
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btn_editar_Click(sender As Object, e As EventArgs) Handles btn_editar.Click
        TextBox1.Enabled = True
        TextBox1.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Enabled = True Then
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
            Me.DialogResult = DialogResult.Cancel
        End If


    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        Me.Text = Me.Text + "   DD"
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
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

    Private Sub ContextMenuStrip1_Opened(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Opened

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListView1.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        Console.WriteLine("")
        Dim reln As New Relacion

        reln.Nuevo = False
        reln.Id_caracteristica = Id

        reln.items = ListView1.SelectedItems(0)
        If reln.ShowDialog() = DialogResult.OK Then
            Cargar_relaciones()

        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Console.WriteLine("")
    End Sub
End Class