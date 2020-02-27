Public Class Permiso



    Shared Function Habilitado(ByVal Consulta As String) As Boolean
        Try
            If My.Settings.Permisos IsNot Nothing Then
                If My.Settings.Permisos.Rows.Count > 0 Then
                    If My.Settings.Permisos.Select("Permiso = '" & Consulta & "'").Count > 0 Then
                        Return True
                    End If
                End If
            End If
            Return False
        Catch ex As Exception
            Return False
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function
End Class
