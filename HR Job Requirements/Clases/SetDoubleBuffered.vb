Imports System.Reflection

Public Class SetDoubleBuffered


    Shared Sub Enabled(ByVal dgv As DataGridView)
        Dim dgvType As Type = dgv.[GetType]()

        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance Or BindingFlags.NonPublic)

        pi.SetValue(dgv, True, Nothing)

    End Sub

    Public Sub Disabled()

    End Sub

End Class
