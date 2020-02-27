Imports System.ComponentModel

Public Class Duplicado
    Public info As DataTable
    Public id_user As Integer = 0

    Private Sub Duplicado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Console.WriteLine("")
        Try
            For Each ro As DataRow In info.Rows
                Dim che As New RadioButton
                che.AutoSize = True
                che.TextAlign = ContentAlignment.MiddleCenter
                che.Tag = ro.ItemArray(0)
                che.Text = ro.ItemArray(1) & "  (User:" & ro.ItemArray(2) & " -  Detalles: " & ro.ItemArray(3) & ")"
                che.Font = New Font("Microsoft Sans Serif", "11.25")
                FlowLayoutPanel1.Controls.Add(che)
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Console.WriteLine("")
            For Each ctl As Control In FlowLayoutPanel1.Controls
                If TypeOf (ctl) Is RadioButton Then
                    If CType(ctl, RadioButton).Checked = True Then
                        id_user = ctl.Tag
                    End If
                End If
            Next
            If id_user > 0 Then
                Me.DialogResult = DialogResult.OK
            Else
                MsgBox("Seleccione una opción")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

    Private Sub Duplicado_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            If Me.DialogResult <> DialogResult.OK Then
                Me.DialogResult = DialogResult.Cancel
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class