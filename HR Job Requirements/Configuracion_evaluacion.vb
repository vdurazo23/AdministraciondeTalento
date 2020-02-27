Public Class Configuracion_evaluacion
    Public Habilidades As Boolean = False
    Public Competencias As Boolean = False
    Public Conocimientos As Boolean = False

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles req_check.CheckedChanged
        If CType(sender, CheckBox).Checked = True Then
            cmb_req.SelectedIndex = -1
            cmb_req.Enabled = False
        Else
            cmb_req.SelectedIndex = -1
            cmb_req.Enabled = True
        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles pond_check.CheckedChanged
        If CType(sender, CheckBox).Checked = True Then
            cmb_pond.SelectedIndex = -1
            cmb_pond.Enabled = False
        Else
            cmb_pond.SelectedIndex = -1
            cmb_pond.Enabled = True
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles rel_check.CheckedChanged
        If CType(sender, CheckBox).Checked = True Then
            cmb_rel.SelectedIndex = -1
            cmb_rel.Enabled = False
        Else
            cmb_rel.SelectedIndex = -1
            cmb_rel.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Habilidades Then
                If req_check.Checked = True Then
                    My.Settings.Hab_req = -1
                Else
                    My.Settings.Hab_req = cmb_req.SelectedIndex
                End If
                If pond_check.Checked = True Then
                    My.Settings.Hab_pond = -1
                Else
                    My.Settings.Hab_pond = cmb_pond.SelectedIndex
                End If
                If Calificacion_check.Checked = True Then
                    My.Settings.Hab_nivreq = True
                Else
                    My.Settings.Hab_nivreq = False

                End If
                If rel_check.Checked = True Then
                    My.Settings.Hab_rel = -1
                Else
                    My.Settings.Hab_rel = cmb_rel.SelectedIndex
                End If

            ElseIf Competencias Then

                If req_check.Checked = True Then
                    My.Settings.Com_req = -1
                Else
                    My.Settings.Com_req = cmb_req.SelectedIndex
                End If
                If pond_check.Checked = True Then
                    My.Settings.Com_pond = -1
                Else
                    My.Settings.Com_pond = cmb_pond.SelectedIndex
                End If
                If Calificacion_check.Checked = True Then
                    My.Settings.Com_nivreq = True
                Else
                    My.Settings.Com_nivreq = False

                End If
                If rel_check.Checked = True Then
                    My.Settings.Com_rel = -1
                Else
                    My.Settings.Com_rel = cmb_rel.SelectedIndex
                End If





            ElseIf Conocimientos Then

                If req_check.Checked = True Then
                    My.Settings.Con_req = -1
                Else
                    My.Settings.Con_req = cmb_req.SelectedIndex
                End If
                If pond_check.Checked = True Then
                    My.Settings.Con_pond = -1
                Else
                    My.Settings.Con_pond = cmb_pond.SelectedIndex
                End If
                If Calificacion_check.Checked = True Then
                    My.Settings.Con_nivreq = True
                Else
                    My.Settings.Con_nivreq = False

                End If
                If rel_check.Checked = True Then
                    My.Settings.Con_rel = -1
                Else
                    My.Settings.Con_rel = cmb_rel.SelectedIndex
                End If

            Else
                If req_check.Checked = True Then
                    My.Settings.Cur_req = -1
                Else
                    My.Settings.Cur_req = cmb_req.SelectedIndex
                End If
                If pond_check.Checked = True Then
                    My.Settings.Cur_pond = -1
                Else
                    My.Settings.Cur_pond = cmb_pond.SelectedIndex
                End If
                If Calificacion_check.Checked = True Then
                    My.Settings.Cur_nivreq = True
                Else
                    My.Settings.Cur_nivreq = False

                End If
                If rel_check.Checked = True Then
                    My.Settings.Cur_rel = -1
                Else
                    My.Settings.Cur_rel = cmb_rel.SelectedIndex
                End If






            End If
            My.Settings.Save()
            Me.DialogResult = DialogResult.OK 
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Configuracion_evaluacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If Habilidades Then
                Label4.Text = "Habilidades"
            ElseIf Competencias Then
                Label4.Text = "Competencias"
            ElseIf Conocimientos Then
                Label4.Text = "Conocimientos"
            End If
            If Habilidades Then
                If My.Settings.Hab_req < 0 Then
                    req_check.Checked = True
                Else
                    req_check.Checked = False
                    cmb_req.SelectedIndex = My.Settings.Hab_req
                End If

                If My.Settings.Hab_pond < 0 Then
                    pond_check.Checked = True
                Else
                    pond_check.Checked = False
                    cmb_pond.SelectedIndex = My.Settings.Hab_pond
                End If
                If My.Settings.Hab_nivreq Then
                    Calificacion_check.Checked = True
                Else
                    Calificacion_check.Checked = False
                End If

                If My.Settings.Hab_rel < 0 Then
                    rel_check.Checked = True
                Else
                    rel_check.Checked = False
                    cmb_rel.SelectedIndex = My.Settings.Hab_rel

                End If


            ElseIf Conocimientos Then


                If My.Settings.Con_req < 0 Then
                    req_check.Checked = True
                Else
                    req_check.Checked = False
                    cmb_req.SelectedIndex = My.Settings.Con_req
                End If

                If My.Settings.Con_pond < 0 Then
                    pond_check.Checked = True
                Else
                    pond_check.Checked = False
                    cmb_pond.SelectedIndex = My.Settings.Con_pond
                End If
                If My.Settings.Con_nivreq Then
                    Calificacion_check.Checked = True
                Else
                    Calificacion_check.Checked = False
                End If

                If My.Settings.Con_rel < 0 Then
                    rel_check.Checked = True
                Else
                    rel_check.Checked = False
                    cmb_rel.SelectedIndex = My.Settings.Con_rel

                End If



            ElseIf Competencias Then

                If My.Settings.Com_req < 0 Then
                    req_check.Checked = True
                Else
                    req_check.Checked = False
                    cmb_req.SelectedIndex = My.Settings.Com_req
                End If

                If My.Settings.Com_pond < 0 Then
                    pond_check.Checked = True
                Else
                    pond_check.Checked = False
                    cmb_pond.SelectedIndex = My.Settings.Com_pond
                End If
                If My.Settings.Com_nivreq Then
                    Calificacion_check.Checked = True
                Else
                    Calificacion_check.Checked = False
                End If

                If My.Settings.Com_rel < 0 Then
                    rel_check.Checked = True
                Else
                    rel_check.Checked = False
                    cmb_rel.SelectedIndex = My.Settings.Com_rel

                End If




            End If

        Catch ex As Exception

        End Try
    End Sub
End Class