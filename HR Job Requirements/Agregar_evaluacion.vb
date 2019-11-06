Imports System.IO

Public Class Agregar_evaluacion
    Dim midataset As New DataSet
    Public Caracteristica As String
    Public Id_caracteristica As Integer
    Public cb_codigo As Integer
    Public nivel_actual As Integer
    Dim id_evaluacion As Integer = 0
    Dim nuevo As Boolean
    Private Sub Agregar_evaluacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        'LO PRIMERO A REALIZAR ES PREGUNTAR SI YA EXISTE UN ID DE EVALUACION
        Try
            Label1.Text = Id_caracteristica & " - " & Caracteristica
            id_evaluacion = SqlQuery.Id_evaluacion(cb_codigo, Id_caracteristica)
            If id_evaluacion > 0 Then
                nuevo = False
            Else
                nuevo = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub

















    'APROBACION
    Dim Data As AppData
    Dim verh As Aprobar
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim validacion_usuario As Boolean = Huella(CType(sender, Control), My.Settings.CB_CODIGO)
        If validacion_usuario = True Then
            Dim myByteArray() As Byte = File.ReadAllBytes(TextBox1.Text)

            'Hay que decidir si es imagen o documento
            Dim re = SqlQuery.agregar_Evaluacion(id_evaluacion, Id_caracteristica, TextBox2.Text.Trim, TextBox4.Text.Trim, False, True, myByteArray, "." & TextBox3.Text.Trim, cb_codigo, My.Settings.CB_CODIGO, 50)

            If re = 1 Then
                Me.DialogResult = DialogResult.OK
            End If

        Else
            MsgBox("ERROR", MsgBoxStyle.Critical)
        End If




    End Sub
    Function Huella(ByVal ctl As Control, a As String) As Boolean

        Try
            Dim cb_codigo_aprobacion As Integer = 0
            Dim supervisor_nombre As DataTable
            Dim usuario_correcto As Boolean = False
            Dim solicitud As DataRow()

            If midataset.Tables("HUELLAS") IsNot Nothing Then
                midataset.Tables.Remove("HUELLAS")
            End If
            Dim ta As DataTable
            ta = SqlQuery.Huellas(My.Settings.CB_CODIGO).Copy
            ta.TableName = "HUELLAS"
            midataset.Tables.Add(ta)
            If midataset.Tables("HUELLAS").DefaultView.Count = 0 Then
                usuario_correcto = False
                MsgBox("No hay huellas registradas para este usuario", MsgBoxStyle.Critical)
                Exit Function
            Else
                Dim i As Integer
                Data = Nothing
                Data = New AppData
                For i = 0 To midataset.Tables("HUELLAS").DefaultView.Count - 1
                    Dim arrpicture() As Byte
                    arrpicture = CType(midataset.Tables("HUELLAS").DefaultView.Item(i).Item("Huella"), Byte())
                    Dim ms As New IO.MemoryStream(arrpicture)
                    Dim template As New DPFP.Template(ms)

                    Data.Templates(midataset.Tables("HUELLAS").DefaultView.Item(i).Item("pos")) = template
                    Data.EnrolledFingersMask = midataset.Tables("HUELLAS").DefaultView.Item(i).Item("mask")
                    arrpicture = Nothing
                    ms = Nothing
                    template = Nothing

                Next

                verh = New Aprobar(Data)
                Try
                    ' If Debugger.IsAttached Then Return True
                    verh.escomedor = True
                    verh.Data = Data
                    '  verh.numemp = a
                    verh.StartPosition = FormStartPosition.CenterScreen
                    verh.ShowDialog()
                    If verh.DialogResult = 1 Then
                        ''HUELLA AUTORIZADA
                        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        usuario_correcto = True
                    Else
                        usuario_correcto = False
                    End If
                Catch ex As Exception

                End Try

            End If
            Return usuario_correcto
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try


    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            OpenFileDialog1.Reset()
            OpenFileDialog1.ShowDialog()
            TextBox1.Text = OpenFileDialog1.FileName
            Dim nom = Split(OpenFileDialog1.SafeFileName, ".")
            TextBox2.Text = nom(0)
            TextBox3.Text = nom(1)
            Console.WriteLine("")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SqlQuery.Save_Error(ex)
        End Try
    End Sub
End Class