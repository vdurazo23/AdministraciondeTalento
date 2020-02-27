Imports System.Reflection

Public Class Nivel_requerido
    Public d As DataTable
    Public CU_CODIGO As String
    Public califs As DataTable
    Public Sin_nombre_empleado As Boolean
    Public qw As New List(Of SqlQuery.requerido)
    Public qw_empleado As New List(Of SqlQuery.empleados)
    Public Id_ponderacion As Integer
    Public Nivel_competencia As Integer
    Public Es_competencia As Boolean
    Dim maximo As Integer
    Public calificar_maximo As Boolean = False
    Public editar As Boolean = False
    Public nombre As String = ""

    Public Sub EnableDoubleBuffered(ByVal dgv As DataGridView)

        Dim dgvType As Type = dgv.[GetType]()

        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance Or BindingFlags.NonPublic)

        pi.SetValue(dgv, True, Nothing)

    End Sub
    Private Sub Nivel_requerido_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label1.Text = nombre
        If editar Then

        Else

            DataGridView3.DataSource = d
            If Sin_nombre_empleado Then
                Label2.Text = "Calificación por puesto"
                DataGridView3.Columns(0).Visible = False
                DataGridView3.Columns(1).ReadOnly = True
                DataGridView3.Columns(2).ReadOnly = True
                DataGridView3.Columns(3).Visible = False
                DataGridView3.Columns(4).ReadOnly = True
                If DataGridView3.ColumnCount = 5 Then
                    Dim dc As New DataGridViewTextBoxColumn
                    dc.HeaderText = "Nivel "
                    DataGridView3.Columns.Add(dc)
                End If
                DataGridView3.Columns(5).Visible = False
                Dim c As New DataGridViewTextBoxColumn
                c.HeaderText = "Nivel requerido"
                DataGridView3.Columns.Add(c)
                d.DefaultView.Sort = "Id_Nivel desc,PU_DESCRIP"
            Else
                Label2.Text = "Calificación por empleado"
                If DataGridView3.Columns(4).Name = "Nivel" Then
                    DataGridView3.Columns(4).Name = "Id_Nivel"
                    DataGridView3.Columns(4).HeaderText = "Id_Nivel"
                    d.Columns(4).ColumnName = "Id_Nivel"
                End If
                Dim dc As New DataGridViewTextBoxColumn
                dc.HeaderText = "Nivel "
                DataGridView3.Columns.Add(dc)

                d.DefaultView.Sort = "Id_Nivel desc,Nombre asc"
            End If
            Select Case Id_ponderacion
                Case 1
                    maximo = 3
                    Label5.Text = 3
                Case 2
                    maximo = 4
                    Label5.Text = 4
                Case 3
                    maximo = 5
                    Label5.Text = 5
                Case 4
                    maximo = 1
                    Label5.Text = 1
            End Select

            For Each c As DataGridViewColumn In DataGridView3.Columns
                c.SortMode = False
            Next
            cargar_valores_default()

            EnableDoubleBuffered(DataGridView3)
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Console.WriteLine("")
        If CType(sender, TabControl).SelectedIndex = 0 Then
            Label2.Text = "Calificacion por puesto"
        Else
            Label2.Text = "Calificacion por nivel"
        End If
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    d.DefaultView.Sort = "Id_Nivel desc,PU_DESCRIP"
    '    For Each c As DataGridViewColumn In DataGridView3.Columns
    '        c.SortMode = False
    '    Next
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            If Sin_nombre_empleado Then
                Dim en_blanco As Boolean = False
                Dim guardar As Boolean = True
                For Each ro As DataGridViewRow In DataGridView3.Rows
                    Console.WriteLine("")
                    If ro.Cells(6).Value Is Nothing Then
                        en_blanco = True
                        guardar = False
                        Exit For
                    ElseIf ro.Cells(6).Value.ToString = "" Then
                        en_blanco = True
                        guardar = False
                        Exit For
                    End If
                Next

                If en_blanco Then
                    If MsgBox("Todas las casillas en blanco se pondran como 1", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        guardar = True
                    End If
                End If
                If guardar Then
                    For Each ro As DataGridViewRow In DataGridView3.Rows
                        Dim elemento As New SqlQuery.requerido
                        elemento.pu_codigo = ro.Cells(1).Value
                        If ro.Cells(6).Value IsNot Nothing Then
                            If ro.Cells(6).Value.ToString <> "" Then
                                elemento.requerido = ro.Cells(6).Value
                            Else
                                elemento.requerido = 1
                            End If
                        Else
                            elemento.requerido = 1
                        End If
                        qw.Add(elemento)
                    Next

                    Me.DialogResult = DialogResult.OK
                End If




            Else
                Dim en_blanco As Boolean = False
                Dim guardar As Boolean = True
                For Each ro As DataGridViewRow In DataGridView3.Rows
                    Console.WriteLine("")
                    If ro.Cells(5).Value Is Nothing Then
                        en_blanco = True
                        guardar = False
                        Exit For
                    ElseIf ro.Cells(5).Value.ToString = "" Then
                        en_blanco = True
                        guardar = False
                        Exit For
                    End If
                Next

                If en_blanco Then
                    If MsgBox("Todas las casillas en blanco se pondran como 1", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        guardar = True
                    End If
                End If
                If guardar Then
                    For Each ro As DataGridViewRow In DataGridView3.Rows
                        Dim elemento As New SqlQuery.empleados
                        elemento.cb_codigo = ro.Cells(0).Value
                        If ro.Cells(5).Value IsNot Nothing Then
                            If ro.Cells(5).Value.ToString <> "" Then
                                elemento.calif = ro.Cells(5).Value
                            Else
                                elemento.calif = 1
                            End If
                        Else
                            elemento.calif = 1
                        End If
                        qw_empleado.Add(elemento)
                    Next

                    Me.DialogResult = DialogResult.OK
                End If



            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub DataGridView3_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellEndEdit
        Try

            If Not IsNumeric(CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                Console.WriteLine("")
                MsgBox("Seleccione un valor correcto", MsgBoxStyle.Critical)
                CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""

            Else
                If CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex).Value > maximo Then
                    MsgBox("El valor es mayor al máximo (" & maximo & ")", MsgBoxStyle.Critical)
                    CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
                Else
                    Console.WriteLine()
                    If DataGridView3.SelectedCells.Count > 1 Then
                        For Each d As DataGridViewCell In DataGridView3.SelectedCells

                            If d.Value Is Nothing Then
                                d.Value = CType(sender, DataGridView).Item(e.ColumnIndex, e.RowIndex).Value
                            Else
                                If d.Value.ToString = "" Or d.Value.ToString <> CType(sender, DataGridView).Item(e.ColumnIndex, e.RowIndex).Value.ToString Then
                                    d.Value = CType(sender, DataGridView).Item(e.ColumnIndex, e.RowIndex).Value
                                End If

                            End If
                        Next
                    End If
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub cargar_valores_default()
        Try
            Dim pregunta As Boolean = True
            If calificar_maximo Then
                For Each ro As DataGridViewRow In DataGridView3.Rows
                    If Sin_nombre_empleado Then
                        ro.Cells(6).Value = maximo
                    Else
                        ro.Cells(5).Value = maximo
                    End If
                Next
                Button2.PerformClick()
                Exit Sub
            End If

            If maximo = 1 Then
                For Each ro As DataGridViewRow In DataGridView3.Rows
                    If Sin_nombre_empleado Then
                        ro.Cells(6).Value = 1
                    Else
                        ro.Cells(5).Value = 1
                    End If

                Next
                Button2.PerformClick()
                Exit Sub
            End If
            If Es_competencia Then
                If Nivel_competencia.ToString <> "" Then
                    If Nivel_competencia > 0 Then
                        For Each row As DataGridViewRow In DataGridView3.Rows
                            If row.Cells("Id_Nivel").Value > Nivel_competencia Then
                                If Sin_nombre_empleado Then
                                    row.Cells(6).Value = maximo
                                Else
                                    row.Cells(5).Value = maximo
                                End If


                            End If
                        Next
                    End If

                End If
            End If
            If califs.Rows.Count > 0 Then
                Dim cali As Integer = 0
                For Each ro As DataGridViewRow In DataGridView3.Rows
                    Console.WriteLine()
                    If Sin_nombre_empleado Then
                        If califs.Select("PU_CODIGO = '" & ro.Cells(1).Value & "'").Count > 0 Then
                            cali = califs.Select("PU_CODIGO = '" & ro.Cells(1).Value & "'")(0).ItemArray(4)
                        End If
                    Else
                        If califs.Select("CB_CODIGO = " & ro.Cells(0).Value).Count > 0 Then
                            cali = califs.Select("CB_CODIGO = '" & ro.Cells(0).Value & "'")(0).ItemArray(4)
                        End If
                    End If

                    If cali <> 0 Then
                        If cali > maximo Then
                            If pregunta Then
                                MsgBox("Calificaciones anteriores estan por encima del maximo actual. Estas calificaciones se modificaran automaticamente", MsgBoxStyle.Information)
                                pregunta = False
                            End If
                            If Sin_nombre_empleado Then
                                ro.Cells(6).Value = maximo
                            Else
                                ro.Cells(5).Value = maximo
                            End If


                        Else
                            If Sin_nombre_empleado Then
                                ro.Cells(6).Value = cali
                            Else
                                ro.Cells(5).Value = cali
                            End If

                        End If


                    End If
                    cali = 0
                Next
            End If



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class