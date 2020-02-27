Public Class IDP
    Public cb_codigo As Integer
    Dim midataset As New DataSet
    Public Permiso_especial As Boolean = False
    Dim periodo As Integer = 0
    Private Sub IDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Permiso.Habilitado("PESPCTR") Then
            Permiso_especial = True
        End If
        cargarPeriodos()
        cargarPreferencia()
        cargarProgramacion()
        ComboBox1.SelectedIndex = ComboBox1.Items.Count - 1

    End Sub

    Private Sub cargarPreferencia()
        Try
            Dim tabla As DataTable
            If Permiso_especial Then
                tabla = CType(SqlQuery.Preferencia(cb_codigo, ComboBox1.SelectedValue), DataTable).Copy
            Else
                tabla = CType(SqlQuery.Preferencia(cb_codigo), DataTable).Copy
            End If

            tabla.TableName = "Preferencia"
            If midataset.Tables("Preferencia") IsNot Nothing Then
                midataset.Tables.Remove("Preferencia")
            End If
            midataset.Tables.Add(tabla)
            DataGridView1.DataSource = Nothing
            DataGridView1.Columns.Clear()

            Dim co As New DataGridViewLinkColumn
            co.HeaderText = "IDP"
            co.Name = "IDP"
            DataGridView1.Columns.Add(co)
            DataGridView1.DataSource = midataset.Tables("Preferencia").DefaultView
            DataGridView1.Columns("Id_categoria").Visible = False
            DataGridView1.Columns("Nivel_requerido").Visible = False
            DataGridView1.Columns("Id_evaluacion").Visible = False
            DataGridView1.Columns("Id_ponderacion").Visible = False
            DataGridView1.Columns("Id_progra_idp").Visible = False

            For Each columna As DataGridViewColumn In DataGridView1.Columns
                columna.SortMode = False
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cargarPeriodos()
        Try
            Dim tabla2 As DataTable = CType(SqlQuery.Periodos(), DataTable).Copy
            tabla2.TableName = "Periodos"
            If midataset.Tables("Periodos") IsNot Nothing Then
                midataset.Tables.Remove("Periodos")
            End If

            midataset.Tables.Add(tabla2)
            ComboBox1.ValueMember = "Id"
            ComboBox1.DisplayMember = "Descripcion"
            ComboBox1.DataSource = midataset.Tables("Periodos")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CargarRowFilter(ByVal Optional Reset As Boolean = False)
        Try
            If midataset.Tables("Preferencia") IsNot Nothing Then
                If Reset = True Then
                    midataset.Tables("Preferencia").DefaultView.RowFilter = "1=1"
                Else
                    midataset.Tables("Preferencia").DefaultView.RowFilter = ""
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Name = "IDP" Then
            e.Value = "+ Agregar"
        End If
    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        If DataGridView2.Columns(e.ColumnIndex).Name = "Remover" Then
            If Permiso_especial Then
                e.Value = "(-) Eliminar"
            Else
                If ComboBox1.SelectedItem.row.itemArray(5) = True Then
                    e.Value = "(-) Eliminar"
                End If
            End If


        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Label6.Text = DirectCast(ComboBox1.SelectedItem.Row.ItemArray(4), Date).GetDateTimeFormats.ToList(10).ToString
            cargarProgramacion()
            If Permiso_especial Then
                cargarPreferencia()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If e.ColumnIndex = 0 Then

                If DataGridView2.Enabled = False Then
                    MsgBox("Este periodo ya no esta activo. Pongase en contacto con el desarrollador", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If DataGridView2.Rows.Count = 3 Then
                        MsgBox("Ya se han agregado 3 objetivos para este periodo", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                End If
                Dim pro As New Programar
                pro.IDP = True
                pro.Fecha_limite_1 = ComboBox1.SelectedItem.row.ItemArray(2).date
                pro.Fecha_limite_2 = ComboBox1.SelectedItem.row.ItemArray(3).date
                If pro.ShowDialog = DialogResult.OK Then
                    Console.WriteLine()
                    Dim fecha As Date = pro.MonthCalendar1.SelectionStart.Date
                    Dim Actual As String = pro.TextBox1.Text.Trim
                    Dim nivel_requerido As Integer = DataGridView1.Item("Nivel_requerido", e.RowIndex).Value
                    Dim id_pond As Integer = DataGridView1.Item("Id_ponderacion", e.RowIndex).Value
                    Dim Periodo As Integer = 0
                    If Permiso_especial Then
                        Periodo = ComboBox1.SelectedValue
                    End If
                    Dim re = SqlQuery.Programar_IDP(cb_codigo, DataGridView1.Item("Id_categoria", e.RowIndex).Value, Actual, "", fecha.Date, nivel_requerido, id_pond, Periodo)
                    If re = 1 Then
                        cargarProgramacion()
                        cargarPreferencia()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub cargarProgramacion()
        Try

            Dim tabla3 As DataTable = CType(SqlQuery.Programados(cb_codigo, ComboBox1.SelectedValue), DataTable).Copy

                tabla3.TableName = "Programacion"
                If midataset.Tables("Programacion") IsNot Nothing Then
                    midataset.Tables.Remove("Programacion")
                End If

                midataset.Tables.Add(tabla3)
                DataGridView2.DataSource = Nothing
                DataGridView2.Columns.Clear()
                DataGridView2.DataSource = midataset.Tables("Programacion")
                Dim col As New DataGridViewLinkColumn
                col.Name = "Remover"
                DataGridView2.Columns.Add(col)
            DataGridView2.Columns("Id").Visible = False
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Try
            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
                Exit Sub
            End If
            If DataGridView2.Columns(e.ColumnIndex).Name = "Remover" Then
                If MsgBox("Seguro que desea remover esta programacion, se perdera cualquier validacion", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim re = SqlQuery.Remover(DataGridView2.Item("Id", e.RowIndex).Value, cb_codigo)
                    cargarPreferencia()
                    cargarProgramacion()

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Retry

    End Sub
End Class