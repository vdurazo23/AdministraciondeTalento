Public Class Objetivos_acciones
    Public año As Integer
    Public mes As Integer
    Public id_objetivo As Integer
    Public id_accion As Integer
    Public cb_codigo As Integer
    Public puesto As String
    Dim midataset As New DataSet
    Dim Nuevo As Boolean = True

    Private Sub Objetivos_acciones_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            cargarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            Dim com As New Comentario
            com.tipo = "Descripcion"
            If com.ShowDialog = DialogResult.OK Then

                If Nuevo Then

                    Dim rEe As Integer = SqlQuery.Accion_master_update(id_objetivo, mes, 0, Nuevo)
                    id_accion = rEe
                End If

                Dim descripcion As String = com.TextBox1.Text.Trim
                Dim nuevo_descr As Boolean = True
                Dim re As Integer = SqlQuery.Accion_DETALLES_update(id_accion, descripcion, True)
                If re = 1 Then
                    cargarDatos()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Try
            If ListView1.SelectedItems.Count > 0 Then
                Dim com As New Comentario
                com.TextBox1.Text = CType(sender, ListView).SelectedItems(0).SubItems(1).Text
                com.tipo = "Descripcion"
                If com.ShowDialog = DialogResult.OK Then
                    Console.WriteLine("")
                    Dim re As Integer = SqlQuery.Accion_DETALLES_update(id_accion, com.TextBox1.Text, False, CType(sender, ListView).SelectedItems(0).Text)
                    If re = 1 Then
                        CType(sender, ListView).SelectedItems(0).SubItems(1).Text = com.Textbox1.Text.Trim
                    End If

                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If ListView1.SelectedItems.Count = 0 Then
                MsgBox("No se ha seleccionado un elemento")
                Exit Sub
            End If
            If ListView1.Items.Count = 1 Then
                If MsgBox("Al ser el unico registro, el porcentaje actual cambiara a 0, ¿Seguro que desea eliminar?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
                    Dim re As Integer = SqlQuery.Borrar_objetivo_accion(id_accion, True)
                    If re = 1 Then
                        cargarDatos()
                    End If
                    Exit Sub
                End If
            Else
                If MsgBox("¿Seguro que desea eliminar?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then

                    Dim re As Integer = SqlQuery.Borrar_objetivo_accion(ListView1.SelectedItems(0).Text, False)
                    If re = 1 Then
                        ListView1.SelectedItems(0).Remove()
                    End If

                    Exit Sub
                End If

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cargarDatos()
        Try
            Dim dat As DataTable
            dat = CType(SqlQuery.Objetivos_acciones(id_objetivo, mes), DataTable).Copy
            Console.WriteLine("")
            dat.TableName = "Obj_acc_master"
            If midataset.Tables("Obj_acc_master") IsNot Nothing Then
                midataset.Tables.Remove("Obj_acc_master")
            End If
            midataset.Tables.Add(dat)
            If midataset.Tables("Obj_acc_master").Rows.Count > 0 Then
                Nuevo = False
                NumericUpDown1.Value = midataset.Tables("Obj_acc_master").Rows(0).ItemArray(1)
                NumericUpDown1.Enabled = True
                id_accion = midataset.Tables("Obj_acc_master").Rows(0).ItemArray(0)
                Button2.Enabled = True
                Dim det As DataTable
                det = CType(SqlQuery.Objetivos_acciones_detalles(id_accion), DataTable).Copy
                det.TableName = "Obj_acc_deta"
                If midataset.Tables("Obj_acc_deta") IsNot Nothing Then
                    midataset.Tables.Remove("Obj_acc_deta")
                End If
                midataset.Tables.Add(det)
                ListView1.Items.Clear()
                For Each ro As DataRow In midataset.Tables("Obj_acc_deta").Rows
                    Dim li As New ListViewItem
                    li.Text = ro.ItemArray(0)
                    li.SubItems.Add(ro.ItemArray(1))
                    ListView1.Items.Add(li)
                Next

            Else
                Nuevo = True
                id_accion = 0
                NumericUpDown1.Value = 0
                NumericUpDown1.Enabled = False
                Button2.Enabled = False
                ListView1.Items.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Objetivos_acciones_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If NumericUpDown1.Enabled = True Then
                SqlQuery.Accion_master_update(id_objetivo, mes, NumericUpDown1.Value, Nuevo, id_accion)
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class