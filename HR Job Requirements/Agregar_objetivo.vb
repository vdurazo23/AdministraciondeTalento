Public Class Agregar_objetivo
    Public Nuevo As Boolean = True
    Public Id As Integer = 0
    Public cb_codigo As Integer
    Public Año As Integer
    Private Sub Agregar_objetivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarObjetivos()

        If Nuevo Then
            Me.Text = "Nuevo objetivo"
        Else
            Me.Text = "Editar objetivo"
            CargarInformacion(id)
        End If
        ''test github
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim re = SqlQuery.agregar_Objetivo(cb_codigo, txt_descrip.Text, txt_obs.Text, num_obj.Value, ComboBox1.SelectedValue, ComboBox2.SelectedText, Año, Nuevo, Id)
            If re = 1 Then
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.DialogResult = DialogResult.Cancel
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CargarObjetivos()
        Try
            Dim Tipos_objetivos As DataTable = SqlQuery.tipos_objetivos()
            Console.WriteLine("")
            ComboBox2.DataSource = Tipos_objetivos
            ComboBox2.ValueMember = "Id"
            ComboBox2.DisplayMember = "Tipo"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            If CType(sender, ComboBox).SelectedItem = CType(sender, ComboBox).Items.Count - 1 Then
                num_obj.Enabled = False
                ComboBox1.Enabled = False
            Else
                num_obj.Enabled = True
                ComboBox1.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CargarInformacion(ByVal id As Integer)
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class