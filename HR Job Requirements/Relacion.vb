Imports System.ComponentModel

Public Class Relacion
    Public Id_caracteristica As Integer = 0
    Public Nuevo As Boolean = True
    Public solicitado_por As String = ""
    Public items As ListViewItem
    Public items_row As DataGridViewRow
    Dim Empleados As List(Of String)
    Dim seleccionados As List(Of SqlQuery.Puesto_descripcion)
    Dim seleccionados_codigos As List(Of SqlQuery.empleados)
    Public nivel_competencia As Integer
    Public tipo As String = ""
    Public calificacion_maxima As Boolean = False
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
            pic_pond.Image = Nothing
            Dim ta As DataTable
            ta = CType(SqlQuery.categorias, DataTable).Copy
            ta.TableName = "Niveles"
            cmb_nivel.DataSource = ta
            cmb_nivel.DisplayMember = "Nivel"
            cmb_nivel.ValueMember = "Id"
            cmb_nivel.SelectedIndex = -1
            Dim te As DataTable
            te = CType(SqlQuery.Ponderaciones, DataTable).Copy
            te.TableName = "Ponderacion"
            cmb_pond.DataSource = te
            cmb_pond.DisplayMember = "Tipo de ponderacion"
            cmb_pond.ValueMember = "Id"
            cmb_pond.SelectedIndex = -1

            Me.Size = Me.MinimumSize

            If Nuevo = False Then

                cmb_requerido.SelectedItem = items_row.Cells("Solicitado_por").Value
                If items_row.Cells("Por_puesto").Value = True Then
                    cmb_rel.SelectedItem = "Por Puesto"
                    Dim s = Split(items_row.Cells("PU_INICIA").Value, "--")
                    txt_puesto.Text = s(1).ToString
                    txt_puesto.Tag = s(0).ToString

                    If items_row.Cells("Escalona").Value = True Then
                        Dim ss = Split(items_row.Cells("PU_FINAL").Value, "--")
                        txt_puesto_tope.Text = ss(1).ToString
                        txt_puesto_tope.Tag = ss(0).ToString
                        cmb_heredado.SelectedItem = "Se escalona"
                    ElseIf items_row.Cells("Hereda").Value = True Then
                        cmb_heredado.SelectedItem = "Se hereda"
                    Else
                        cmb_heredado.SelectedItem = "Solo puesto"
                    End If


                Else
                    cmb_rel.SelectedItem = "Por Nivel"
                    cmb_nivel.SelectedValue = items_row.Cells("Id_nivel").Value
                End If

                ' If items.SubItems(1).Text.ToString = "Corporativo" Then cmb_requerido.SelectedItem = "Corporativo" Else cmb_requerido.SelectedItem = "Puesto"
                '  If items.SubItems(0).Text.ToString = "Por Puesto" Then
                '    cmd_rel.SelectedItem = "Por Puesto"
                '   Dim s = Split(items.SubItems(2).Text.ToString, "-")
                '    txt_puesto.Text = s(1).ToString
                '   txt_puesto.Tag = s(0).ToString
                'Select Case items.SubItems(3).Text.ToString
                '        Case "Solo puesto"
                '            cmb_heredado.SelectedItem = "Solo puesto"

                '        Case "Heredado"
                '            Dim ss = Split(items.SubItems(2).Text.ToString, "-")
                '            txt_puesto.Text = ss(1).ToString
                '            txt_puesto.Tag = ss(0).ToString
                '            cmb_heredado.SelectedItem = "Se hereda"

                '        Case "Escalonado"
                '            Dim ss = Split(items.SubItems(4).Text.ToString, "-")
                '            txt_puesto_tope.Text = ss(1).ToString
                '            txt_puesto_tope.Tag = ss(0).ToString
                '            cmb_heredado.SelectedItem = "Se escalona"
                '    End Select
                ' Else
                ' cmd_rel.SelectedItem = "Por Nivel"
                'cmb_nivel.SelectedValue = items.SubItems(2).Text
                'End If
                ' If items.SubItems(5).Text.ToString = "ACTIVO" Then CheckBox1.Checked = True Else CheckBox1.Checked = False
                If items_row.Cells("Activo").Value.ToString = "ACTIVO" Then CheckBox1.Checked = True Else CheckBox1.Checked = False
                Console.WriteLine()
            Else

                Select Case tipo

                    Case "Hab"
                        If My.Settings.Hab_req >= 0 Then
                            cmb_requerido.SelectedIndex = My.Settings.Hab_req
                        End If
                        If My.Settings.Hab_rel >= 0 Then
                            cmb_rel.SelectedIndex = My.Settings.Hab_rel
                        End If
                        If My.Settings.Hab_pond >= 0 Then
                            cmb_pond.SelectedIndex = My.Settings.Hab_pond
                        End If
                        calificacion_maxima = My.Settings.Hab_nivreq

                    Case "Com"
                        If My.Settings.Com_req >= 0 Then
                            cmb_requerido.SelectedIndex = My.Settings.Com_req
                        End If
                        If My.Settings.Com_rel >= 0 Then
                            cmb_rel.SelectedIndex = My.Settings.Com_rel
                        End If
                        If My.Settings.Com_pond >= 0 Then
                            cmb_pond.SelectedIndex = My.Settings.Com_pond
                        End If
                        calificacion_maxima = My.Settings.Com_nivreq
                    Case "Con"
                        If My.Settings.Con_req >= 0 Then
                            cmb_requerido.SelectedIndex = My.Settings.Con_req
                        End If
                        If My.Settings.Con_rel >= 0 Then
                            cmb_rel.SelectedIndex = My.Settings.Con_rel
                        End If
                        If My.Settings.Con_pond >= 0 Then
                            cmb_pond.SelectedIndex = My.Settings.Con_pond
                        End If
                        calificacion_maxima = My.Settings.Con_nivreq
                    Case "Cur"
                        If My.Settings.cur_req >= 0 Then
                            cmb_requerido.SelectedIndex = My.Settings.cur_req
                        End If
                        If My.Settings.cur_rel >= 0 Then
                            cmb_rel.SelectedIndex = My.Settings.cur_rel
                        End If
                        If My.Settings.cur_pond >= 0 Then
                            cmb_pond.SelectedIndex = My.Settings.cur_pond
                        End If
                        calificacion_maxima = My.Settings.Cur_nivreq
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_puesto.Click

        Dim s As New Puni
        Select Case cmb_rel.SelectedIndex
            Case 1
                s.cargar_todos = True
                s.cargar_empleados = False
                If txt_puesto.Text.Trim <> "" Then
                    s.seleccionados = seleccionados
                End If
                If s.ShowDialog = DialogResult.OK Then
                    txt_puesto_tope.Text = ""
                    txt_puesto_tope.Tag = Nothing
                    seleccionados = s.seleccionados
                    cmb_heredado.Enabled = True
                    If seleccionados.Count > 0 Then
                        If seleccionados.Count = 1 Then
                            txt_puesto.Text = seleccionados(0).pu_descripcion
                            txt_puesto.Tag = seleccionados(0).pu_codigo
                        Else
                            txt_puesto.Text = "Personalizado"
                            txt_puesto.Tag = "Personalizado"
                            cmb_heredado.SelectedIndex = 0
                            cmb_heredado.Enabled = False
                        End If
                    End If
                End If

            Case 2
                s.cargar_empleados = True
                s.cargar_todos = False
                If txt_puesto.Text.Trim <> "" Then
                    s.seleccionados_codigos = seleccionados_codigos
                End If
                If s.ShowDialog = DialogResult.OK Then
                    seleccionados_codigos = s.seleccionados_codigos
                    If seleccionados_codigos.Count > 0 Then
                        If seleccionados_codigos.Count = 1 Then
                            txt_puesto.Text = seleccionados_codigos(0).Name
                            txt_puesto.Tag = seleccionados_codigos(0).cb_codigo
                        Else
                            txt_puesto.Text = "Varios empleados"
                            txt_puesto.Tag = "Varios empleados"
                        End If
                    End If
                End If
        End Select

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

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_rel.SelectedIndexChanged
        Try
            lbl_nivel.Visible = True
            lbl_pond.Visible = True
            cmb_pond.Visible = True
            pic_pond.Visible = True
            txt_puesto.Text = ""
            txt_puesto.Tag = ""
            cmb_heredado.SelectedIndex = -1
            Select Case CType(sender, ComboBox).SelectedIndex
                Case -1
                    lbl_nivel.Visible = False
                    lbl_pond.Visible = False
                    cmb_pond.Visible = False
                    pic_pond.Visible = False
                    cmb_heredado.SelectedIndex = -1
                    cmb_heredado.Visible = False
                    txt_puesto.Text = ""
                    txt_puesto.Tag = Nothing
                    txt_puesto.Visible = False
                    Btn_puesto.Visible = False
                    cmb_nivel.SelectedIndex = -1
                    cmb_nivel.Visible = False

                Case 0
                    lbl_nivel.Visible = True

                    lbl_pond.Visible = True
                    cmb_pond.Visible = True
                    pic_pond.Visible = True
                    cmb_pond.SelectedIndex = 1

                    cmb_heredado.SelectedIndex = -1
                    cmb_heredado.Visible = False

                    txt_puesto.Text = ""
                    txt_puesto.Tag = Nothing
                    txt_puesto.Visible = False
                    Btn_puesto.Visible = False

                    cmb_nivel.Visible = True

                Case 1
                    lbl_nivel.Visible = True

                    lbl_pond.Visible = True
                    cmb_pond.Visible = True
                    pic_pond.Visible = True
                    cmb_pond.SelectedIndex = 1

                    cmb_heredado.SelectedIndex = -1
                    cmb_heredado.Visible = True

                    txt_puesto.Text = ""
                    txt_puesto.Tag = Nothing
                    txt_puesto.Visible = True
                    Btn_puesto.Visible = True

                    cmb_nivel.Visible = False



                Case 2
                    lbl_nivel.Visible = True

                    lbl_pond.Visible = True
                    cmb_pond.Visible = True
                    pic_pond.Visible = True
                    cmb_pond.SelectedIndex = 1

                    cmb_heredado.SelectedIndex = -1
                    cmb_heredado.Visible = False

                    txt_puesto.Text = ""
                    txt_puesto.Tag = Nothing
                    txt_puesto.Visible = True
                    Btn_puesto.Visible = True

                    cmb_nivel.Visible = False

                Case Else


            End Select
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
            Dim puesto As String = ""
            Dim codigo As String = ""

            If s.seleccionados.Count > 0 Then
                puesto = s.seleccionados(0).pu_descripcion
                codigo = s.seleccionados(0).pu_codigo
            End If
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
            Dim PEMPLEADO As Boolean = False
            Dim idni
            Dim escalona
            Dim hereda
            Dim puesto_inicial
            Dim puesto_final
            Dim activo As Boolean = CheckBox1.Checked
            Dim id_ponderacion As Integer = cmb_pond.SelectedValue

            If Nuevo Then

                'EN CASO DE TRATARSE DE UN REGISTRO NUEVO
                If cmb_rel.SelectedItem.ToString = "Por Nivel" Then
                    PNIVEL = True
                    idni = cmb_nivel.SelectedValue
                    Dim re = SqlQuery.agregar_relacion(Id_caracteristica, solicitado, PEMPLEADO, PNIVEL, idni, PPUESTO, escalona, hereda, puesto_inicial, puesto_final, activo, Nuevo, Nothing, Nothing, id_ponderacion)
                    If re = 1 Then
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    End If
                ElseIf cmb_rel.SelectedItem.ToString = "Por Puesto" Then
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
                    Dim ree As Integer
                    If seleccionados.Count > 0 Then
                        If seleccionados.Count > 1 Then

                            If MsgBox("Al ser una selección multiple, las relaciones repetidas solamente se saltaran", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                ree = SqlQuery.agregar_relacion_multiple(Id_caracteristica, solicitado, PEMPLEADO, PPUESTO, seleccionados, seleccionados_codigos, activo, Nuevo, id_ponderacion)
                            End If

                        Else
                            ree = SqlQuery.agregar_relacion(Id_caracteristica, solicitado, PEMPLEADO, PNIVEL, idni, PPUESTO, escalona, hereda, seleccionados(0).pu_codigo, puesto_final, activo, Nuevo, Nothing, Nothing, id_ponderacion)
                        End If
                    End If
                    If ree = 1 Then
                        Me.DialogResult = DialogResult.OK
                        Me.Close()

                    End If


                Else
                    PEMPLEADO = True
                    Dim re = Sqlquery.agregar_relacion_multiple(Id_caracteristica,solicitado,True,False,seleccionados,seleccionados_codigos,activo,Nuevo,id_ponderacion)
                    '  For Each r As SqlQuery.empleados In seleccionados_codigos
                    ' Dim re = SqlQuery.agregar_relacion(Id_caracteristica, solicitado, PEMPLEADO, PNIVEL, Nothing, PPUESTO, escalona, hereda, puesto_inicial, puesto_final, activo, Nuevo, Nothing, r.cb_codigo, id_ponderacion)
                    ' Next
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If


            Else
                'SI SE TRATA DE LA ACTUALIZACION DE UNA RELACION

                If HayCambios() Then   'REVISAR SI HAY ALGO NUEVO QUE GUARDAR
                    If cmb_rel.SelectedItem.ToString = "Por Nivel" Then 'Por nivel 
                        PNIVEL = True
                        idni = cmb_nivel.SelectedValue
                        Dim re = SqlQuery.agregar_relacion(Id_caracteristica, solicitado, PEMPLEADO, PNIVEL, idni, PPUESTO, escalona, hereda, puesto_inicial, puesto_final, activo, Nuevo, items.Tag)
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
                        Dim re = SqlQuery.agregar_relacion(Id_caracteristica, solicitado, PEMPLEADO, PNIVEL, idni, PPUESTO, escalona, hereda, puesto_inicial, puesto_final, activo, Nuevo)
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
            ErrorProvider1.Clear()
            Dim res As Boolean = True

            If cmb_requerido.SelectedIndex = -1 Then ErrorProvider1.SetError(cmb_requerido, "Seleccione un valor correcto") : res = False
            If cmb_pond.SelectedIndex = -1 Then ErrorProvider1.SetError(cmb_pond, "Seleccione un valor correcto") : res = False

            If cmb_rel.SelectedIndex = -1 Then
                'NO SELECCION CORRECTA
                ErrorProvider1.SetError(cmb_rel, "Selecione un valor correcto")
                res = False
            ElseIf cmb_rel.SelectedIndex = 0 Then
                'SELECCION POR NIVEL
                If cmb_nivel.SelectedIndex = -1 Then
                    ErrorProvider1.SetError(cmb_nivel, "Seleccione un valor correcto")
                    res = False
                End If
            ElseIf cmb_rel.SelectedIndex = 2 Then
                If txt_puesto.Text = "" Then ErrorProvider1.SetError(txt_puesto, "Seleccione un valor correcto") : res = False
                If cmb_requerido.SelectedIndex = -1 Then ErrorProvider1.SetError(cmb_requerido, "Seleccione un valor correcto") : res = False
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
                Case -1 Or 0 Or 2
                    lbl_puestoTope.Visible = False
                    txt_puesto_tope.Text = ""
                    txt_puesto_tope.Tag = Nothing
                    txt_puesto_tope.Visible = False
                    Btn_puesto_tope.Visible = False
                    Me.Size = MinimumSize

                Case 0
                    lbl_puestoTope.Visible = False
                    txt_puesto_tope.Text = ""
                    txt_puesto_tope.Tag = Nothing
                    txt_puesto_tope.Visible = False
                    Btn_puesto_tope.Visible = False
                    Me.Size = MinimumSize
                Case 1
                    Btn_puesto_tope.Enabled = True
                    Btn_puesto_tope.Visible = True
                    lbl_puestoTope.Visible = True
                    txt_puesto_tope.Visible = True
                    Me.Size = Me.MaximumSize

                Case 2
                    lbl_puestoTope.Visible = False
                    txt_puesto_tope.Text = ""
                    txt_puesto_tope.Tag = Nothing
                    txt_puesto_tope.Visible = False
                    Btn_puesto_tope.Visible = False
                    Me.Size = MinimumSize

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Function cambio_activo() As Boolean
        Try
            If CheckBox1.Checked = True Then
                If items.SubItems(5).Text.ToString = "ACTIVO" Then


                    'no hay cambios de activo


                End If
            Else
                If items.SubItems(5).Text.ToString = "ACTIVO" Then


                    'Si hay cambios


                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Function HayCambios() As Boolean
        Try
            If Nuevo Then
                Return True

            Else
                If cmb_requerido.SelectedItem.ToString <> items_row.Cells("Solicitado_por").Value Then Return True
                If items_row.Cells("Por_puesto").Value = True Then
                    If cmb_rel.SelectedItem.ToString <> "Por Puesto" Then Return True
                    Dim s = Split(items_row.Cells("PU_INICIA").Value, "--")
                    If s(1).ToString <> txt_puesto.Text.ToString Then Return True
                    If items_row.Cells("Escalona").Value = True Then
                        If cmb_heredado.SelectedItem.ToString <> "Se escalona" Then Return True
                        Dim ss = Split(items_row.Cells("PU_FINAL").Value, "--")
                        If ss(1).ToString <> txt_puesto_tope.Text.ToString Then Return True

                    ElseIf items_row.Cells("Hereda").Value = True Then
                        If cmb_heredado.SelectedItem.ToString <> "Se hereda" Then Return True
                    Else
                        If cmb_heredado.SelectedItem.ToString <> "Solo puesto" Then Return True
                    End If

                ElseIf items_row.Cells("Por_nivel").Value = True Then
                    If cmb_rel.SelectedItem.ToString <> "Por Nivel" Then Return True
                    If cmb_nivel.SelectedValue.ToString <> items_row.Cells("Id_nivel").Value Then Return True
                Else
                    If cmb_rel.SelectedItem.ToString = "Por Puesto" Or cmb_rel.SelectedItem.ToString = "Por Nivel" Then Return True
                    'QUEDA PENDIENTE HASTA AGREGAR RELACION POR EMPLEADO
                End If


                If CheckBox1.Checked And items_row.Cells("Activo").Value.ToString <> "ACTIVO" Then Return True
                If CheckBox1.Checked = False And items_row.Cells("Activo").Value.ToString = "ACTIVO" Then Return True
                'If cmb_requerido.SelectedItem.ToString <> items.SubItems(1).Text.ToString Then Return True
                'If cmd_rel.SelectedItem.ToString <> items.SubItems(0).Text.ToString Then Return True
                'If items.SubItems(0).Text.ToString = "Por Puesto" Then
                '    Dim s = Split(items.SubItems(2).Text, "-")
                '    If s(1).ToString <> txt_puesto.Text.ToString Then Return True

                '    Select Case items.SubItems(3).Text.ToString
                '        Case "Solo puesto"
                '            If cmb_heredado.SelectedItem.ToString <> items.SubItems(3).Text.ToString Then Return True

                '        Case "Heredado"
                '            If cmb_heredado.SelectedItem.ToString <> items.SubItems(3).Text.ToString Then Return True
                '            Dim ss = Split(items.SubItems(4).Text, "-")
                '            If txt_puesto_tope.Text <> ss(2).ToString Then Return True


                '        Case "Escalonado"
                '            If cmb_heredado.SelectedItem.ToString <> items.SubItems(3).Text.ToString And cmb_heredado.SelectedItem.ToString <> "Se escalona" Then Return True
                '            Dim ss = Split(items.SubItems(4).Text, "-")
                '            If txt_puesto_tope.Text <> ss(1).ToString Then Return True

                '    End Select

                'Else
                '    If cmb_nivel.SelectedValue.ToString <> items.SubItems(2).Text.ToString Then Return True

                'End If
                'If CheckBox1.Checked And items.SubItems(5).Text.ToString <> "ACTIVO" Then Return True
                'If CheckBox1.Checked = False And items.SubItems(5).Text.ToString = "ACTIVO" Then Return True

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_pond.SelectedIndexChanged
        Try

            Select Case CType(sender, ComboBox).SelectedIndex
                Case 0
                    pic_pond.Image = My.Resources._003
                Case 1
                    pic_pond.Image = My.Resources._1004
                Case 2
                    pic_pond.Image = My.Resources._05

                Case 3
                    pic_pond.Image = My.Resources.okk
                Case Else
                    pic_pond.Image = Nothing
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class