Imports System.ComponentModel

Public Class Relacion
    Public Id_caracteristica As Integer = 0
    Public Nuevo As Boolean = True
    Public solicitado_por As String = ""
    Public items As ListViewItem

    Private Sub Relacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txt_puesto.Visible = False
            cmb_nivel.Visible = False
            Btn_puesto.Visible = False
            cmb_heredado.Visible = False
            txt_puesto_tope.Visible = False
            lbl_puestoTope.Visible = False
            Btn_puesto_tope.Visible = False
            lbl_nivel.Visible = False
            Dim ta As DataTable
            ta = CType(SqlQuery.categorias, DataTable).Copy
            ta.TableName = "Niveles"
            cmb_nivel.DataSource = ta
            cmb_nivel.DisplayMember = "Nivel"
            cmb_nivel.ValueMember = "Id"
            cmb_nivel.SelectedIndex = -1
            Me.Size = Me.MinimumSize

            If Nuevo = False Then
                If items.SubItems(1).Text.ToString = "Corporativo" Then cmb_requerido.SelectedItem = "Corporativo" Else cmb_requerido.SelectedItem = "Puesto"
                If items.SubItems(0).Text.ToString = "Por Puesto" Then
                    cmd_rel.SelectedItem = "Por Puesto"
                    Dim s = Split(items.SubItems(2).Text.ToString, "-")
                    txt_puesto.Text = s(1).ToString
                    txt_puesto.Tag = s(0).ToString
                    Select Case items.SubItems(3).Text.ToString
                        Case "Solo puesto"
                            cmb_heredado.SelectedItem = "Solo puesto"

                        Case "Heredado"
                            Dim ss = Split(items.SubItems(2).Text.ToString, "-")
                            txt_puesto.Text = ss(1).ToString
                            txt_puesto.Tag = ss(0).ToString
                            cmb_heredado.SelectedItem = "Se hereda"

                        Case "Escalonado"
                            Dim ss = Split(items.SubItems(4).Text.ToString, "-")
                            txt_puesto_tope.Text = ss(1).ToString
                            txt_puesto_tope.Tag = ss(0).ToString
                            cmb_heredado.SelectedItem = "Se escalona"
                    End Select
                Else
                    cmd_rel.SelectedItem = "Por Nivel"
                    cmb_nivel.SelectedValue = items.SubItems(2).Text
                End If
                If items.SubItems(5).Text.ToString = "ACTIVO" Then CheckBox1.Checked = True Else CheckBox1.Checked = False
                Console.WriteLine()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_puesto.Click

        Dim s As New Puni
        s.cargar_todos = True
        If txt_puesto.Text.Trim <> "" Then
            s.nuevo = False
            s.pues = txt_puesto.Text.Trim
        End If

        If s.ShowDialog() = DialogResult.OK Then
            Dim puesto As String = s.pues
            Dim codigo As String = s.pu_codigo
            txt_puesto.Text = puesto
            txt_puesto.Tag = codigo
        End If
    End Sub

    Private Sub ocultar_mostrar(ByVal Optional Por_nivel As Boolean = False)
        Try
            If Por_nivel Then




            Else



            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmd_rel.SelectedIndexChanged
        Try
            If CType(sender, ComboBox).SelectedIndex = -1 Then Exit Sub
            lbl_nivel.Visible = True
            If CType(sender, ComboBox).SelectedIndex = 0 Then
                cmb_nivel.Visible = True
                cmb_heredado.Visible = False
                txt_puesto.Visible = False
                Btn_puesto.Visible = False
                lbl_puestoTope.Visible = False
                txt_puesto.Text = ""
                txt_puesto_tope.Text = ""
                cmb_heredado.SelectedIndex = -1
                txt_puesto_tope.Visible = False
                Btn_puesto_tope.Visible = False
                Me.Size = Me.MinimumSize
            Else
                cmb_nivel.Visible = False
                cmb_nivel.SelectedIndex = -1
                cmb_heredado.Visible = True
                txt_puesto.Visible = True
                Btn_puesto.Visible = True
                lbl_puestoTope.Visible = False
                txt_puesto_tope.Visible = False
                Btn_puesto_tope.Visible = False

                Me.Size = New Size(461, 397) '= Me.MaximumSize
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub cmb_nivel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_nivel.SelectedIndexChanged

    End Sub

    Private Sub txt_puesto_TextChanged(sender As Object, e As EventArgs) Handles txt_puesto.TextChanged

    End Sub

    Private Sub Btn_puesto_tope_Click(sender As Object, e As EventArgs) Handles Btn_puesto_tope.Click
        Dim s As New Puni
        s.cargar_parents = True
        s.pu_codigo = txt_puesto.Tag
        If txt_puesto_tope.Text.ToString <> "" Then
            s.nuevo = False
            s.pues = txt_puesto_tope.Text

        End If

        If s.ShowDialog() = DialogResult.OK Then
            Dim puesto As String = s.pues
            Dim codigo As String = s.pu_codigo
            txt_puesto_tope.Text = puesto
            txt_puesto_tope.Tag = codigo
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'agregar relacion y generar puestos con caracteristica seleccionada

            ErrorProvider1.Clear() 'LIMPIAR ERRORES 
            If Completo() = False Then 'REVISAR QUE SE LLENARA TODO CORRECTAMENTE
                Exit Sub
            End If


            Dim solicitado = cmb_requerido.SelectedItem.ToString
            Dim PNIVEL As Boolean = False
            Dim PPUESTO As Boolean = False
            Dim idni
            Dim escalona
            Dim hereda
            Dim puesto_inicial
            Dim puesto_final
            Dim activo As Boolean = CheckBox1.Checked


            If Nuevo Then

                'EN CASO DE TRATARSE DE UN REGISTRO NUEVO
                If cmd_rel.SelectedItem.ToString = "Por Nivel" Then
                    PNIVEL = True
                    idni = cmb_nivel.SelectedValue
                    Dim re = SqlQuery.agregar_relacion(Id_caracteristica, solicitado, PNIVEL, idni, PPUESTO, escalona, hereda, puesto_inicial, puesto_final, activo, Nuevo)
                    If re = 1 Then
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    End If
                Else
                    PPUESTO = True
                    puesto_inicial = txt_puesto.Tag
                    Select Case cmb_heredado.SelectedItem
                        Case "Solo puesto"

                        Case "Se hereda"
                            hereda = True

                        Case "Se escalona"
                            escalona = True
                            puesto_final = txt_puesto_tope.Tag
                    End Select
                    Dim re = SqlQuery.agregar_relacion(Id_caracteristica, solicitado, PNIVEL, idni, PPUESTO, escalona, hereda, puesto_inicial, puesto_final, activo, Nuevo)
                    If re = 1 Then
                        Me.DialogResult = DialogResult.OK
                        Me.Close
                    End If
                End If


            Else
                'SI SE TRATA DE LA ACTUALIZACION DE UNA RELACION

                If HayCambios() Then   'REVISAR SI HAY ALGO NUEVO QUE GUARDAR
                    If cmd_rel.SelectedItem.ToString = "Por Nivel" Then 'Por nivel 
                        PNIVEL = True
                        idni = cmb_nivel.SelectedValue
                        Dim re = SqlQuery.agregar_relacion(Id_caracteristica, solicitado, PNIVEL, idni, PPUESTO, escalona, hereda, puesto_inicial, puesto_final, activo, Nuevo, items.Tag)
                        If re = 1 Then
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                        End If




                    Else 'Por puesto
                        PPUESTO = True

                        puesto_inicial = txt_puesto.Tag
                        Select Case cmb_heredado.SelectedItem
                            Case "Solo puesto"

                            Case "Se hereda"
                                hereda = True

                            Case "Escalona"
                                escalona = True

                        End Select
                        Dim re = SqlQuery.agregar_relacion(Id_caracteristica, solicitado, PNIVEL, idni, PPUESTO, escalona, hereda, puesto_inicial, puesto_final, activo, Nuevo)
                        If re = 1 Then
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                        End If




                    End If
                Else
                    Me.DialogResult = DialogResult.Cancel
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Function Completo() As Boolean
        Try
            Dim res As Boolean = True

            If cmb_requerido.SelectedIndex = -1 Then ErrorProvider1.SetError(cmb_requerido, "Seleccione un valor correcto") : res = False


            If cmd_rel.SelectedIndex = -1 Then
                'NO SELECCION CORRECTA
                ErrorProvider1.SetError(cmd_rel, "Selecione un valor correcto")
                res = False
            ElseIf cmd_rel.SelectedIndex = 0 Then
                'SELECCION POR NIVEL
                If cmb_nivel.SelectedIndex = -1 Then
                    ErrorProvider1.SetError(cmb_nivel, "Seleccione un valor correcto")
                    res = False
                End If
            Else
                'SELECCION POR PUESTO
                If txt_puesto.Text.Trim = "" Then ErrorProvider1.SetError(txt_puesto, "Seleccione al menos un puesto") : res = False
                If cmb_heredado.SelectedIndex = -1 Then
                    ErrorProvider1.SetError(cmb_heredado, "Selecione un valor correcto") : res = False
                ElseIf cmb_heredado.SelectedIndex = 1 Then
                    If txt_puesto_tope.Text.Trim = "" Then ErrorProvider1.SetError(txt_puesto_tope, "Seleccione el puesto tope") : res = False
                    
                End If


            End If
            Return res
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
            Return False
        End Try

    End Function

    Private Sub cmb_heredado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_heredado.SelectedIndexChanged
        Try
            Select Case CType(sender, ComboBox).SelectedIndex
                Case -1
                    Exit Sub
                Case 0
                    Btn_puesto_tope.Enabled = True
                    Btn_puesto_tope.Visible = False
                    lbl_puestoTope.Visible = False
                    txt_puesto_tope.Visible = False
                    txt_puesto_tope.Text = ""
                    txt_puesto_tope.Tag = Nothing
                    Me.Size = New Size(461, 397)
                Case 1
                    Btn_puesto_tope.Enabled = True
                    Btn_puesto_tope.Visible = True
                    lbl_puestoTope.Visible = True
                    txt_puesto_tope.Visible = True
                    Me.Size = Me.MaximumSize
                Case 2

                    Btn_puesto_tope.Visible = False
                    lbl_puestoTope.Visible = False
                    txt_puesto_tope.Visible = False
                    txt_puesto_tope.Text = ""
                    txt_puesto_tope.Tag = Nothing
                    Me.Size = New Size(461, 397)
            End Select



         

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Function HayCambios() As Boolean
        Try
            If Nuevo Then
                Return True

            Else

                If cmb_requerido.SelectedItem.ToString <> items.SubItems(1).Text.ToString Then Return True
                If cmd_rel.SelectedItem.ToString <> items.SubItems(0).Text.ToString Then Return True
                If items.SubItems(0).Text.ToString = "Por Puesto" Then
                    Dim s = Split(items.SubItems(2).Text, "-")
                    If s(1).ToString <> txt_puesto.Text.ToString Then Return True
                    Select Case items.SubItems(3).Text.ToString
                        Case "Solo puesto"
                            If cmb_heredado.SelectedItem.ToString <> items.SubItems(3).Text.ToString Then Return True



                        Case "Heredado"
                            If cmb_heredado.SelectedItem.ToString <> items.SubItems(3).Text.ToString Then Return True
                            Dim ss = Split(items.SubItems(4).Text, "-")
                            If txt_puesto_tope.Text <> ss(2).ToString Then Return True


                        Case "Escalonado"
                            If cmb_heredado.SelectedItem.ToString <> items.SubItems(3).Text.ToString And cmb_heredado.SelectedItem.ToString <> "Se escalona" Then Return True
                            Dim ss = Split(items.SubItems(4).Text, "-")
                            If txt_puesto_tope.Text <> ss(1).ToString Then Return True

                    End Select

                Else
                    If cmb_nivel.SelectedValue.ToString <> items.SubItems(2).Text.ToString Then Return True

                End If
                If CheckBox1.Checked And items.SubItems(5).Text.ToString <> "ACTIVO" Then Return True
                If CheckBox1.Checked = False And items.SubItems(5).Text.ToString = "ACTIVO" Then Return True

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try



    End Function

    Private Sub Relacion_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            If Me.DialogResult <> DialogResult.OK Then
                If HayCambios() Then
                    ErrorProvider1.Clear()
                    Dim m = MsgBox("¿Esta seguro de salir sin guardar?", MsgBoxStyle.YesNo)
                    If m = MsgBoxResult.No Then
                        e.Cancel = True
                    End If
                End If

            End If



        Catch ex As Exception

        End Try
    End Sub

End Class