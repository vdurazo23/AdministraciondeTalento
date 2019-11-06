Public Class SqlQuery



    Public Shared CnMPS As New SqlClient.SqlConnection("")

    Public Shared da As New SqlClient.SqlDataAdapter("", CnMPS)

    Public Shared cmd As New SqlClient.SqlCommand("", CnMPS)

    Public Shared ds As New DataSet

#Region "ConnectionString"

    Shared Function constringMPS() As String
        Return "Data Source =" & My.Settings.MPSServer.Trim & "; workstation id =; Persist Security Info=True;User ID=" & My.Settings.MPSUsuario & ";password=" & My.Settings.MPSContraseña & ";initial catalog=" & My.Settings.MPSBD
    End Function 'Conexion

#End Region

#Region "Competencias"
    Shared Function Competencias() As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select c.Id,c.Competencia,ca.Categoria,ca.Id as 'Nivel' from MaRsTest.hr.Competencias c" &
                " left join hr.Nivel ca on c.Id_Nivel = ca.Id"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Competencias")
            Return ds.Tables("Competencias")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'DATATABLE
    Shared Function UPDATE_Competencias(ByVal id As Integer, ByVal nivel As Integer)
        Try

            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()

            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@id", SqlDbType.Int)
            cmd.Parameters("@id").Value = id
            If nivel > 0 Then
                cmd.Parameters.Add("@Nivel", SqlDbType.Int)
                cmd.Parameters("@Nivel").Value = nivel
                cmd.CommandText = "UPDATE HR.Competencias SET Id_Nivel = @Nivel where id = @id"
            Else
                cmd.CommandText = "UPDATE HR.Competencias SET Id_Nivel = NULL where id = @id"
            End If
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function 'UPDATE
    Shared Function Departamentos()
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandText = "select * from tress.dbo.NIVEL1  where tb_activo = 's' Union select 999999,'PUESTOS NO RELACIONADOS','PNR','S'"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Departamentos")
            Return ds.Tables("Departamentos")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'DATATABLE
    Shared Function puestos()
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If 1 <> 999999 Then
                'da.SelectCommand.Parameters.Add("@codigo", SqlDbType.Int)
                'da.SelectCommand.Parameters("@codigo").Value = departamento
                'da.SelectCommand.CommandText = "select  distinct c.CB_NIVEL1, c.CB_PUESTO, n1.TB_ELEMENT, pu.PU_DESCRIP from tress.dbo.COLABORA c
                '             left join tress.dbo.NIVEL1 n1 on c.CB_NIVEL1 = n1.TB_CODIGO
                '             left join tress.dbo.PUESTO pu on c.CB_PUESTO = pu.PU_CODIGO
                '            where CB_ACTIVO = 'S' "
                'da.SelectCommand.CommandText = "select  distinct c.CB_NIVEL1, c.CB_PUESTO, n1.TB_ELEMENT, pu.PU_DESCRIP from tress.dbo.COLABORA c
                '             left join tress.dbo.NIVEL1 n1 on c.CB_NIVEL1 = n1.TB_CODIGO
                '             left join tress.dbo.PUESTO pu on c.CB_PUESTO = pu.PU_CODIGO
                '            where CB_ACTIVO = 'S' and TB_CODIGO = @codigo"
                da.SelectCommand.CommandText = "select * from tress.dbo.PUESTO p left join (
                                    select  distinct c.CB_NIVEL1, c.CB_PUESTO, n1.TB_ELEMENT, pu.PU_DESCRIP from tress.dbo.COLABORA c
                                    left join tress.dbo.NIVEL1 n1 on c.CB_NIVEL1 = n1.TB_CODIGO
                                     Left Join tress.dbo.PUESTO pu on c.CB_PUESTO = pu.PU_CODIGO 
                                    where CB_ACTIVO = 'S' ) sd on p.PU_CODIGO = sd.CB_PUESTO
                                        order by p.PU_DESCRIP"
            Else
                da.SelectCommand.CommandText = "select * from tress.dbo.PUESTO p left join (
                                    select  distinct c.CB_NIVEL1, c.CB_PUESTO, n1.TB_ELEMENT, pu.PU_DESCRIP from tress.dbo.COLABORA c
                                    left join tress.dbo.NIVEL1 n1 on c.CB_NIVEL1 = n1.TB_CODIGO
                                     Left Join tress.dbo.PUESTO pu on c.CB_PUESTO = pu.PU_CODIGO 
                                    where CB_ACTIVO = 'S' ) sd on p.PU_CODIGO = sd.CB_PUESTO
                                       where CB_NIVEL1 is null order by p.PU_DESCRIP"
            End If

            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Puesto")
            Return ds.Tables("Puesto")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'DATATABLE

    Shared Function Personal()
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.Clear()
            'da.SelectCommand.Parameters.Add("@puesto", SqlDbType.VarChar)
            'da.SelectCommand.Parameters("@puesto").Value = Puesto
            'da.SelectCommand.Parameters.Add("@departamento", SqlDbType.VarChar)
            'da.SelectCommand.Parameters("@departamento").Value = departamento

            da.SelectCommand.CommandText = "select  * from tress.dbo.COLABORA where CB_ACTIVO = 'S' "


            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Personal")
            Return ds.Tables("Personal")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'DATATABLE
    Shared Function Imagen(ByVal cb_codigo As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.Add("@cb_codigo", SqlDbType.Int)
            da.SelectCommand.Parameters("@cb_codigo").Value = cb_codigo
            da.SelectCommand.CommandText = "Select [IM_BLOB] from [Tress].[dbo].[IMAGEN] where CB_CODIGO = @cb_codigo "
            ds.Tables.Clear()
            da.Fill(ds, "Imagen")
            Return ds.Tables("Imagen")


        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

        End Try
    End Function 'DATATABLE
    Shared Function PorCodigo(ByVal cb_codigo As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.Add("@cb_codigo", SqlDbType.Int)
            da.SelectCommand.Parameters("@cb_codigo").Value = cb_codigo
            da.SelectCommand.CommandText = "select prettyname, cb_Nivel1, cb_puesto from tress.dbo.COLABORA  where CB_CODIGO = @cb_codigo "
            ds.Tables.Clear()
            da.Fill(ds, "Datos")
            Return ds.Tables("Datos")


        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function 'DATATABLE
    Shared Function categorias() As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.CommandText = "Select * from HR.Nivel"
            ds.Tables.Clear()
            da.Fill(ds, "Nivel")
            Return ds.Tables("Nivel")


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'DATATABLE
#End Region

#Region "Login"
    Shared Function Busqueda_usuario(ByVal Usuario As String, ByVal Contraseña As String) As Integer
        Try
            CnMPS.ConnectionString = constringMPS()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.AddWithValue("@User", Usuario)
            cmd.Parameters.AddWithValue("@Pass", Contraseña)

            cmd.CommandText = "Select cb_codigo from Mars.dbo.usuarios where Usuario = @User and Password = @Pass "
            Dim res = cmd.ExecuteScalar
            Return res
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'Consulta
#End Region

#Region "Caracteristicas"
    Shared Function cargarCaracteristicas()
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Connection = CnMPS
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select * from HR.Caracteristicas"
            ds.Tables.Clear()
            da.Fill(ds, "Caracteristicas")
            Return ds.Tables("Caracteristicas")
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'DATATABLE

    Shared Function AgregarCaracteristica(ByVal Descripcion As String, ByVal Competencia As Boolean, ByVal Habilidad As Boolean, ByVal Conocimiento As Boolean, ByVal Nuevo As Boolean, ByVal Optional id As Integer = 0)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar)
            cmd.Parameters.Add("@Competencia", SqlDbType.Bit)
            cmd.Parameters.Add("@Habilidad", SqlDbType.Bit)
            cmd.Parameters.Add("@Conocimiento", SqlDbType.Bit)
            cmd.Parameters("@Descripcion").Value = Descripcion
            cmd.Parameters("@Competencia").Value = Competencia
            cmd.Parameters("@Habilidad").Value = Habilidad
            cmd.Parameters("@Conocimiento").Value = Conocimiento
            cmd.CommandText = "select id from HR.Caracteristicas where Descripcion = @Descripcion and competencia = @Competencia and Habilidad = @Habilidad and Conocimiento = @Conocimiento"
            Dim re As Integer = 0
            re = cmd.ExecuteScalar
            If re = 0 Then
                If Nuevo Then
                    cmd.CommandText = "Insert into HR.Caracteristicas (Descripcion,Competencia,Habilidad,Conocimiento) values(@Descripcion,@Competencia,@Habilidad,@Conocimiento);Select @@IDENTITY"
                    Dim res = cmd.ExecuteScalar
                    Return res
                Else
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.CommandText = "Update HR.Caracteristicas SET Descripcion = @Descripcion where id = @id"
                    cmd.ExecuteNonQuery()
                    Return id
                End If
            Else
                If re = id Then
                    Return re
                Else
                    Return 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return -1
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function


    Shared Function Cargar_carac_porpuesto(ByVal cb_codigo As Integer) As DataTable
        Try

            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.AddWithValue("@NoEmpleado", cb_codigo)
            da.SelectCommand.CommandText = "select PRETTYNAME, CB_PUESTO,re.id,re.Descripcion, re.Competencia,re.Habilidad,re.Conocimiento,re.Nivel_requerido,re.Nivel_actual,re.Id_evaluacion from tress.dbo.COLABORA co 
                                            inner join (select Id_categoria,ca.* , Nivel_requerido, PU_CODIGO,ev.Nivel_actual,ev.id as 'Id_evaluacion' from hr.Relaciones_pto_carac rpc 
                                            inner join hr.Caracteristicas ca on rpc.Id_categoria = ca.Id
                                            left join hr.Evaluacion ev on ca.id = ev.Id_caracteristica) re on co.CB_PUESTO = re.pu_codigo
                                            where CB_CODIGO = @NoEmpleado "
            ds.Tables.Clear()
            da.Fill(ds, "Relaciones")
            Return ds.Tables("Relaciones")



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function

#End Region

#Region "Support"
    Shared Function Save_Error(ex As Exception, ByVal Optional Msj As String = "")
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Software", My.Application.Info.ProductName.ToString)
            cmd.Parameters.AddWithValue("@Version", My.Application.Info.Version.ToString + " Revision - " + My.Application.Info.Version.Revision.ToString)
            cmd.Parameters.AddWithValue("@Empleado", My.Settings.CB_CODIGO)
            cmd.Parameters.AddWithValue("@StackTrace", ex.StackTrace.ToString)
            cmd.Parameters.AddWithValue("@Message", ex.Message)
            cmd.Parameters.AddWithValue("@Extra", Msj)
            cmd.Parameters.AddWithValue("@hostname", System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).HostName)
            cmd.Parameters.AddWithValue("@ip", System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Insert into Support.Errors(Software, Version, Empleado, Detalles,[Stack Trace], comentario_extra, IP_EQUIPO,HOSTNAME)
                                Values (@Software,@Version,@Empleado,@Message,@StackTrace,@Extra,@ip,@hostname)"
            cmd.ExecuteNonQuery()
        Catch exx As Exception

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close
        End Try
    End Function 'INSERT
    Shared Function Support(ByVal Empleado As String, ByVal msj As String)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Software", My.Application.Info.ProductName.ToString)
            cmd.Parameters.AddWithValue("@Version", My.Application.Info.Version.ToString + " Revision - " + My.Application.Info.Version.Revision.ToString)
            cmd.Parameters.AddWithValue("@EMPLEADO", Empleado)
            cmd.Parameters.AddWithValue("@cb_codigo", My.Settings.CB_CODIGO)
            cmd.Parameters.AddWithValue("@Message", msj)
            cmd.Parameters.AddWithValue("@hostname", System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).HostName)
            cmd.Parameters.AddWithValue("@ip", System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Insert into Support.Support (Software,Version,CB_CODIGO,Empleado,Detalles, HostName, IP_EQUIPO)
                               VALUES(@Software,@Version,@cb_codigo,@EMPLEADO,@Message,@hostname,@ip;Select @@IDENTITY"
            Dim RE = cmd.ExecuteScalar
            MsgBox("Registrado. Folio:" & RE)
        Catch exx As Exception

        Finally

        End Try
    End Function 'INSERT
#End Region

#Region "Organigrama"
    Shared Function puestos_Organigrama() As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select * From [HR].[Puesto] Order by PU_DESCRIP"

            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Puesto")
            Return ds.Tables("Puesto")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'DATATABLE

    Shared Function puestos_Organigrama_parents(ByVal cb_codigo As Integer) As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.CommandText = "HR.Puestos_padre"
            da.SelectCommand.Parameters.AddWithValue("@PU_INICIAL", cb_codigo)
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Puestos_parent")
            Return ds.Tables("Puestos_parent")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function Puestos_sin_relacionar()
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "SELECT PU_CODIGO,PU_DESCRIP FROM [HR].[Puesto] WHERE
                    PU_PARENT IS NULL and PU_CODIGO <> '264' and PU_ACTIVO = 's' Order by PU_DESCRIP"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "PuestosNO")
            Return ds.Tables("PuestosNO")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'DATATABLE
    Shared Function Puestos_AgregarDependiente(ByVal PU_PARENT As String, ByVal PU_CHILD As String)
        Try

            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandType = CommandType.Text
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@PUPA", SqlDbType.VarChar)
            cmd.Parameters("@PUPA").Value = PU_PARENT
            cmd.Parameters.Add("@PUCHI", SqlDbType.VarChar)
            cmd.Parameters("@PUCHI").Value = PU_CHILD
            cmd.CommandText = "UPDATE HR.Puesto SET PU_PARENT = @PUPA where PU_CODIGO = @PUCHI"
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'SET
    Shared Function Puestos_AgregarSuperior(ByVal PU_PARENT As String, ByVal PU_CHILD As String)
        Dim tra As SqlClient.SqlTransaction
        Try

            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            tra = CnMPS.BeginTransaction()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()
            cmd.Transaction = tra
            cmd.Parameters.Add("@PUCHI", SqlDbType.VarChar)
            cmd.Parameters("@PUCHI").Value = PU_CHILD

            cmd.CommandText = "Select PU_PARENT from HR.Puesto where PU_CODIGO = @PUCHI"
            Dim Parent = cmd.ExecuteScalar

            cmd.Parameters.Add("@PUPA", SqlDbType.VarChar)
            cmd.Parameters("@PUPA").Value = PU_PARENT
            cmd.CommandText = "Update HR.Puesto SET PU_PARENT = @PUPA WHERE PU_CODIGO = @PUCHI "
            cmd.ExecuteNonQuery()
            If Parent.ToString <> "" Then
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@PUPA", SqlDbType.VarChar)
                cmd.Parameters("@PUPA").Value = PU_PARENT
                cmd.Parameters.Add("@PUPAPA", SqlDbType.VarChar)
                cmd.Parameters("@PUPAPA").Value = Parent
                cmd.CommandText = "Update HR.Puesto SET PU_PARENT = @PUPAPA WHERE PU_CODIGO = @PUPA"
                cmd.ExecuteNonQuery()
            End If
            tra.Commit()
            Return 1
        Catch ex As Exception
            tra.Rollback()
            Throw New Exception(ex.Message)
            Return 0
        Finally

            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
            cmd.Transaction = Nothing
        End Try
    End Function 'SET TRANSACTION
#End Region

#Region "Relaciones"
    Shared Function agregar_relacion(ByVal id_caracteristica As Integer, ByVal Solicitado As String, ByVal Por_nivel As Boolean, ByVal Id_nivel As Integer,
                                     ByVal Por_puesto As Boolean, ByVal Escalona As Boolean, ByVal Hereda As Boolean, ByVal Puesto_inicial As String, ByVal Puesto_final As String, ByVal Activo As Boolean,
                                     ByVal Nuevo As Boolean, ByVal Optional Id As Integer = 0)

        'ADMINISTRACION DE RELACIONES ****************************************AGREGAR


        'Dim tra As SqlClient.SqlTransaction
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            'tra = CnMPS.BeginTransaction()
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            ds.Tables.Clear()
            'cmd.Transaction = tra
            cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
            cmd.Parameters.AddWithValue("@SOL", Solicitado)
            cmd.Parameters.AddWithValue("@PNI", Por_nivel)
            cmd.Parameters.AddWithValue("@PPU", Por_puesto)
            cmd.Parameters.AddWithValue("@ACT", Activo)





            'LA RELACION ES NUEVA O ES UNA ACTUALIZACION***************************************************
            If Nuevo Then



                If Por_nivel = True Then
                    'RELACION NUEVA POR NIVEL DE EMPLEADO------------------------------------------------------------------------



                    cmd.Parameters.AddWithValue("@INI", Id_nivel)
                    cmd.CommandType = CommandType.Text


                    'Revisar si existe una relacion identica **********************************************************************
                    cmd.CommandText = "Select id from HR.Instruccion_relacion where Id_caracteristica = @IDCA and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Id_nivel = @INI"
                    Dim ask = cmd.ExecuteScalar
                    If ask Is Nothing Then

                        'Revisar si existe una relacion que involucre los puestos requeridos para la caracteristica en cuestion********************************************************************************
                        cmd.CommandText = "Select id from HR.Instruccion_relacion where Id_caracteristica = @IDCA and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Id_nivel > @INI"
                        ask = cmd.ExecuteScalar
                        If ask Is Nothing Then

                            'Agregar nueva caracteristica y guardar valor en ID **************************************************************************************
                            cmd.CommandText = "Insert into HR.Instruccion_relacion (Id_caracteristica,Solicitado_por,Por_nivel,Por_puesto,Id_nivel,Activo)
                                   Values(@IDCA,@SOL,@PNI,@PPU,@INI,@ACT);SELECT @@IDENTITY"
                            Id = cmd.ExecuteScalar
                        Else
                            MsgBox("Ya existe una relacion que involucra los niveles de empleados solicitados", MsgBoxStyle.Critical)
                            Return 0
                        End If

                    Else
                        MsgBox("La relacion ingresada ya existe en el sistema", MsgBoxStyle.Critical)
                        Return 0
                    End If



                Else

                    'Relacion nueva por puesto--------------------------------------------------------------------------
                    cmd.Parameters.AddWithValue("@ESC", Escalona)
                    cmd.Parameters.AddWithValue("@HERE", Hereda)
                    cmd.Parameters.AddWithValue("@PUINI", Puesto_inicial)
                    cmd.CommandType = CommandType.Text


                    'Revisar si existe una relacion identica ***********************************************************************************************



                    If Puesto_final Is Nothing Then
                        cmd.CommandText = "Select  id from Hr.Instruccion_relacion where Id_caracteristica = @IDCA and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Escalona = @ESC and Hereda = @HERE and
                                        PU_INICIA = @PUINI and PU_FINAL is NULL"
                    Else
                        cmd.Parameters.AddWithValue("@PUFIN", Puesto_final)
                        cmd.CommandText = "Select  id from Hr.Instruccion_relacion where Id_caracteristica = @IDCA and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Escalona = @ESC and Hereda = @HERE and
                                        PU_INICIA = @PUINI and PU_FINAL = @PUFIN"
                    End If


                    Dim ask = cmd.ExecuteScalar

                    If ask Is Nothing Then
                        If Puesto_final Is Nothing Then
                            cmd.CommandText = "Insert into HR.Instruccion_relacion(Id_caracteristica, Solicitado_por,Por_nivel,Por_puesto,Escalona,Hereda,PU_INICIA,PU_FINAL,Activo)
                                       Values(@IDCA,@SOL,@PNI,@PPU,@ESC,@HERE,@PUINI,NULL,@ACT);SELECT @@IDENTITY"
                        Else
                            cmd.CommandText = "Insert into HR.Instruccion_relacion(Id_caracteristica, Solicitado_por,Por_nivel,Por_puesto,Escalona,Hereda,PU_INICIA,PU_FINAL,Activo)
                                       Values(@IDCA,@SOL,@PNI,@PPU,@ESC,@HERE,@PUINI,@PUFIN,@ACT);SELECT @@IDENTITY"
                        End If
                        'Agregar nueva relacion por puesto ***************************************************************************************************************************
                        Id = cmd.ExecuteScalar
                    Else
                        MsgBox("La relacion ingresada ya existe en el sistema", MsgBoxStyle.Critical)
                        Return 0
                    End If

                End If



            Else
                'Actualizar relacion*****************************************************************************


                If Por_nivel = True Then
                    'Actualizar por nivel-------------------------------------------------------------

                Else
                    'Actualizar por puesto ------------------------------------------------------------------



                End If
            End If
            CnMPS.Close()
            If Activo = True Then
                exec_instruccion(Id)
            End If

            Return 1

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function exec_instruccion(ByVal id_instruccion As Integer) As Integer
        Try
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.AddWithValue("@Id", id_instruccion)
            da.SelectCommand.CommandText = "Select * from HR.Instruccion_relacion where id = @Id"
            If ds.Tables("relac") IsNot Nothing Then
                ds.Tables.Remove("relac")
            End If
            da.Fill(ds, "relac")
            If ds.Tables("relac").Rows.Count > 0 Then
                Dim id_caracteristica = ds.Tables("relac").Rows(0).Item("Id_caracteristica")
                Dim id_nivel = ds.Tables("relac").Rows(0).Item("Id_nivel")
                Dim Hereda = ds.Tables("relac").Rows(0).Item("Hereda")
                Dim Escalona = ds.Tables("relac").Rows(0).Item("Escalona")
                Dim Puesto_inicial = ds.Tables("relac").Rows(0).Item("PU_INICIA")
                Dim Puesto_final = ds.Tables("relac").Rows(0).Item("PU_FINAL")
                If ds.Tables("relac").Rows(0).Item("Por_nivel") Then
                    cmd.Parameters.Clear()
                    If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                    da.SelectCommand.Parameters.Clear()
                    da.SelectCommand.Parameters.AddWithValue("@IDCA", id_caracteristica)
                    da.SelectCommand.CommandType = CommandType.Text
                    da.SelectCommand.CommandText = "Select * from HR.Relaciones_pto_carac where id_categoria = @IDCA"
                    da.SelectCommand.Connection = CnMPS
                    ds.Tables.Clear()
                    da.Fill(ds, "Relaciones")
                    da.SelectCommand.Parameters.Clear()
                    da.SelectCommand.Parameters.AddWithValue("@nivel", id_nivel)
                    da.SelectCommand.CommandText = "Select * from HR.Puesto where Id_nivel <= @nivel and PU_ACTIVO = 'S'"
                    da.SelectCommand.Connection = CnMPS
                    da.Fill(ds, "Puestos")
                    Console.WriteLine("")
                    For Each ro As DataRow In ds.Tables("Puestos").Rows
                        Dim bu = ds.Tables("Relaciones").Select("PU_CODIGO = '" & ro.ItemArray(1).ToString & "'")
                        If bu.Length > 0 Then
                            If id_instruccion <> bu(0).ItemArray(4) Then
                                cmd.Parameters.Clear()
                                cmd.Parameters.AddWithValue("@Id_rel", id_instruccion)
                                cmd.Parameters.AddWithValue("@PUCO", ro.ItemArray(1).ToString)
                                cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                                cmd.CommandText = "Update Hr.Relaciones_pto_carac SET Id_relacion = @Id_rel where Id_categoria = @IDCA and PU_CODIGO = @PUCO"
                                cmd.ExecuteNonQuery()
                                cmd.Parameters.Clear()
                                cmd.CommandType = CommandType.Text
                                cmd.Connection = CnMPS
                                If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                                cmd.CommandText = "Select id from Hr.Relaciones_repetidas where Id_relacion_principal = @Id_rel_pri and Id_relacion_repetido = @Id_rel_rep"
                                cmd.Parameters.AddWithValue("@Id_rel_pri", id_instruccion)
                                cmd.Parameters.AddWithValue("@Id_rel_rep", bu(0).ItemArray(4))
                                Dim r As Integer = 0
                                r = cmd.ExecuteScalar
                                If r = 0 Then
                                    cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
                                    cmd.ExecuteNonQuery()
                                End If
                            End If
                        Else
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                            cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                            cmd.Parameters.AddWithValue("@Nivreq", 25)
                            cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                            cmd.CommandType = CommandType.Text
                            cmd.Connection = CnMPS
                            cmd.CommandText = "Insert Into HR.Relaciones_pto_carac (Id_categoria,PU_CODIGO,Nivel_requerido,Id_relacion) VALUES ( @IDCA,@PU_CODIGO,@Nivreq,@IDREL)"
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Else
                    If Hereda = True Then
#Region "Heredado"
                        If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                        da.SelectCommand.CommandType = CommandType.Text
                        da.SelectCommand.Parameters.Clear()
                        da.SelectCommand.Connection = CnMPS
                        da.SelectCommand.CommandText = "Select * from HR.Relaciones_pto_carac where id_categoria = @IDCA "
                        da.SelectCommand.Parameters.AddWithValue("@IDCA", id_caracteristica)
                        da.Fill(ds, "Relaciones")
                        da.SelectCommand.Parameters.Clear()
                        da.SelectCommand.CommandText = "Select * from Hr.Puesto"
                        da.Fill(ds, "Puestos")

                        cmd.CommandType = CommandType.Text
                        cmd.Connection = CnMPS
                        Dim rhj = agregar_relpu_heredado(Puesto_inicial, id_caracteristica, id_instruccion)
#End Region
                    ElseIf Escalona = True Then
#Region "Escalonado"
                        If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                        da.SelectCommand.Parameters.Clear()
                        da.SelectCommand.CommandType = CommandType.StoredProcedure
                        da.SelectCommand.Connection = CnMPS
                        da.SelectCommand.CommandText = "HR.Puestos_padre"
                        da.SelectCommand.Parameters.AddWithValue("@PU_INICIAL", Puesto_inicial)
                        da.SelectCommand.Parameters.AddWithValue("@TOPA", True)
                        da.SelectCommand.Parameters.AddWithValue("@PU_FIN", Puesto_final)
                        da.Fill(ds, "Puestos_a_relacionar")
                        Console.WriteLine("")
                        da.SelectCommand.CommandType = CommandType.Text
                        da.SelectCommand.Parameters.Clear()
                        da.SelectCommand.Parameters.AddWithValue("@IDCA", id_caracteristica)
                        da.SelectCommand.CommandText = "Select * from HR.Relaciones_pto_carac where id_categoria = @IDCA"
                        da.Fill(ds, "Carac")

                        Dim sd = ds.Tables("Carac").Select("PU_CODIGO = '" & Puesto_inicial.ToString & "'")
                        If sd.Length = 0 Then
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                            cmd.Parameters.AddWithValue("@PU_CODIGO", Puesto_inicial)
                            cmd.Parameters.AddWithValue("@Nivel_requerido", 25)
                            cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                            cmd.CommandType = CommandType.Text
                            cmd.CommandText = "Insert into HR.Relaciones_pto_carac (Id_Categoria,PU_CODIGO, Nivel_requerido,Id_relacion) Values(@IDCA,@PU_CODIGO,@Nivel_requerido,@IDREL)"
                            cmd.ExecuteNonQuery()
                        Else
                            If sd(0).ItemArray(4) <> id_instruccion Then
                                cmd.Parameters.Clear()
                                cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                                cmd.Parameters.AddWithValue("@PU_CODIGO", Puesto_inicial)
                                cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL where Id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
                                cmd.ExecuteNonQuery()
                                cmd.Parameters.Clear()
                                cmd.Parameters.AddWithValue("@IDrelPrin", id_instruccion)
                                cmd.Parameters.AddWithValue("@IDrelRep", sd(0).ItemArray(4))
                                cmd.CommandText = "Select Id from Hr.Relaciones_repetidas where Id_relacion_principal = @IDrelPrin and Id_relacion_repetido = @IDrelRep"
                                Dim qwe As Integer = 0
                                qwe = cmd.ExecuteScalar
                                If qwe = 0 Then
                                    cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@IDrelPrin,@IDrelRep)"
                                    cmd.ExecuteNonQuery()
                                End If

                            End If




                        End If
                        For Each ro As DataRow In ds.Tables("Puestos_a_relacionar").Rows
                            Dim b = ds.Tables("Carac").Select("PU_CODIGO = '" & ro.ItemArray(1).ToString & "'")
                            If b.Length = 0 Then

                                cmd.Parameters.Clear()
                                cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                                cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                cmd.Parameters.AddWithValue("@Nivel_requerido", 25)
                                cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                cmd.CommandType = CommandType.Text
                                cmd.CommandText = "Insert into HR.Relaciones_pto_carac (Id_Categoria,PU_CODIGO, Nivel_requerido,Id_relacion) Values(@IDCA,@PU_CODIGO,@Nivel_requerido,@IDREL)"
                                cmd.ExecuteNonQuery()

                            Else
                                If b(0).ItemArray(4) <> id_instruccion Then
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                                    cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                    cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                    cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL where Id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
                                    cmd.ExecuteNonQuery()
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.AddWithValue("@IDrelPrin", id_instruccion)
                                    cmd.Parameters.AddWithValue("@IDrelRep", b(0).ItemArray(4))
                                    cmd.CommandText = "Select Id from Hr.Relaciones_repetidas where Id_relacion_principal = @IDrelPrin and Id_relacion_repetido = @IDrelRep"
                                    Dim qwe As Integer = 0
                                    qwe = cmd.ExecuteScalar
                                    If qwe = 0 Then
                                        cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@IDrelPrin,@IDrelRep)"
                                        cmd.ExecuteNonQuery()
                                    End If

                                End If


                            End If
                        Next
#End Region
                    Else
#Region "Solo puesto"
                        cmd.Parameters.Clear()
                        If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()

                        cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                        cmd.Parameters.AddWithValue("@PU_CODIGO", Puesto_inicial)
                        cmd.Parameters.AddWithValue("@ID", id_instruccion)
                        cmd.CommandText = "Select id_relacion from HR.Relaciones_pto_carac where id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
                        cmd.Connection = CnMPS
                        Dim r = cmd.ExecuteScalar
                        Console.WriteLine("")
                        If r Is Nothing Then

                            cmd.CommandText = "Insert into HR.Relaciones_pto_carac (Id_categoria,PU_CODIGO,Nivel_requerido,Id_relacion)
                                            Values(@IDCA,@PU_CODIGO,25,@ID)"
                            cmd.ExecuteNonQuery()

                            Return 1
                        Else

                            cmd.CommandText = "Update Hr.Relaciones_pto_carac SET Id_relacion = @ID where Id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
                            cmd.ExecuteNonQuery()

                            cmd.Parameters.Clear()
                            cmd.CommandType = CommandType.Text
                            cmd.Connection = CnMPS
                            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                            cmd.CommandText = "Select id from Hr.Relaciones_repetidas where Id_relacion_principal = @Id_rel_pri and Id_relacion_repetido = @Id_rel_rep"
                            cmd.Parameters.AddWithValue("@Id_rel_pri", id_instruccion)
                            cmd.Parameters.AddWithValue("@Id_rel_rep", r)
                            Dim rqw As Integer = 0
                            rqw = cmd.ExecuteScalar
                            If rqw = 0 Then
                                cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
                                cmd.ExecuteNonQuery()
                            End If

                            Return 1
                        End If

#End Region
                    End If
                End If
            End If
            Return 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function agregar_relpu_heredado(ByVal puesto As String, ByVal id_categoria As Integer, ByVal id_relacion As Integer)
        Try
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@IDCA", id_categoria)
            cmd.Parameters.AddWithValue("@PUCO", puesto)
            cmd.CommandText = "Select Id_relacion from HR.Relaciones_pto_carac where Id_categoria = @IDCA and PU_CODIGO = @PUCO"
            Dim re As Integer = 0
            re = cmd.ExecuteScalar
            If re > 0 Then
                If re <> id_relacion Then
                    cmd.Parameters.AddWithValue("@Id_rel", id_relacion)
                    cmd.CommandText = "Update Hr.Relaciones_pto_carac SET Id_relacion = @Id_rel where Id_categoria = @IDCA and PU_CODIGO = @PUCO"
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@Id_rel", id_relacion)
                    cmd.Parameters.AddWithValue("@Id_rel_rep", re)
                    cmd.CommandText = "Select id from HR.Relaciones_repetidas where Id_relacion_principal = @Id_rel and Id_relacion_repetido =@Id_rel_rep"
                    re = 0
                    re = cmd.ExecuteScalar
                    If re = 0 Then
                        cmd.CommandText = "Insert into Hr.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)VALUES(@Id_rel,@Id_rel_rep)"
                        cmd.ExecuteNonQuery()
                    End If
                End If
            Else
                cmd.Parameters.AddWithValue("@Id_rel", id_relacion)
                cmd.CommandText = "Insert into HR.Relaciones_pto_carac (Id_categoria,PU_CODIGO,Nivel_requerido,Id_relacion) VALUES(@IDCA,@PUCO,25,@Id_rel)"
                cmd.ExecuteNonQuery()
            End If
            Dim ca = ds.Tables("Puestos").Select("PU_PARENT = '" & puesto.ToString & "'")

            For a = 0 To ca.Length - 1
                agregar_relpu_heredado(ca(a).ItemArray(1), id_categoria, id_relacion)
            Next

            Return 1

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function
#End Region

#Region "Actualizar puestos y relaciones"

    Shared Function relaciones(ByVal Optional Solo_activos As Boolean = True)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If Solo_activos Then
                da.SelectCommand.CommandText = "Select * from Hr.Instruccion_relacion where activo = 'S' "
            Else
                da.SelectCommand.CommandText = "Select * from Hr.Instruccion_relacion"
            End If

            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Relaciones")
            Return ds.Tables("Relaciones")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

        End Try
    End Function
    Shared Function relaciones(ByVal id As Integer, ByVal Optional Solo_activos As Boolean = True)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@idca", id)
            If Solo_activos Then
                da.SelectCommand.CommandText = "Select ir.id,ir.Id_caracteristica,ir.Solicitado_por,ir.Por_nivel,ir.Id_nivel,ir.Por_puesto,
                                                ir.Escalona,ir.Hereda,str(ir.PU_INICIA) + '-'+ pu.PU_DESCRIP as PU_INICIA,
                                                str(ir.PU_FINAL) + '-'+ puu.PU_DESCRIP as PU_FINAL,Activo from Hr.Instruccion_relacion ir 
                                                left join hr.Puesto pu on ir.PU_INICIA = pu.PU_CODIGO
                                                left join hr.Puesto puu on ir.PU_FINAL = puu.PU_CODIGO
                                                where activo = 1 and  id_caracteristica = @idca"
            Else
                da.SelectCommand.CommandText = "Select ir.id,ir.Id_caracteristica,ir.Solicitado_por,ir.Por_nivel,ir.Id_nivel,ir.Por_puesto,
                                                ir.Escalona,ir.Hereda,str(ir.PU_INICIA) + '-'+ pu.PU_DESCRIP as PU_INICIA,
                                                str(ir.PU_FINAL) + '-'+ puu.PU_DESCRIP as PU_FINAL,Activo from Hr.Instruccion_relacion ir 
                                                left join hr.Puesto pu on ir.PU_INICIA = pu.PU_CODIGO
                                                left join hr.Puesto puu on ir.PU_FINAL = puu.PU_CODIGO
                                                where id_caracteristica = @idca"
            End If

            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Relaciones")
            Return ds.Tables("Relaciones")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

        End Try
    End Function

    Shared Function actualizar_puestos()
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "[HR].[Actualizacion_puestos]"
            Dim re = cmd.ExecuteNonQuery
            Return 1

        Catch ex As Exception

            Throw New Exception(ex.Message)
            Return 0
        Finally

            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
            cmd.Transaction = Nothing

        End Try
    End Function

#End Region

#Region "Evaluaciones"
    Shared Function Id_evaluacion(ByVal cb_codigo As Integer, ByVal id_caracteristica As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Select id from Hr.Evaluacion where cb_codigo = @cb_codigo and id_caracteristica = @idca"
            cmd.Parameters.AddWithValue("@cb_codigo", cb_codigo)
            cmd.Parameters.AddWithValue("@idca", id_caracteristica)
            Dim re As Integer = 0
            re = cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function agregar_Evaluacion(ByVal id_eva As Integer, ByVal id_caracteristica As Integer, ByVal NombreDoc As String, ByVal Descripcion As String, ByVal ima As Boolean, ByVal doc As Boolean, ByVal imagdoc As Array, ByVal extension As String, ByVal cb_codigo As Integer, ByVal cb_codigo_aprueba As String, ByVal calificacion As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text

            If id_eva < 1 Then
                cmd.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
                cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                cmd.Parameters.AddWithValue("@niv_Act", calificacion)
                cmd.CommandText = "Insert Into HR.Evaluacion (CB_CODIGO,Id_caracteristica,Nivel_actual) Values (@CB_CODIGO,@IDCA,@niv_Act); Select @@IDENTITY"
                id_eva = cmd.ExecuteScalar
            Else


            End If
            cmd.Parameters.AddWithValue("@id_eva", id_eva)
            cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
            cmd.Parameters.AddWithValue("@CB_CODIGO_Aprueba", cb_codigo_aprueba)
            If ima = True Then
                cmd.Parameters.AddWithValue("@Imagen", imagdoc)
                cmd.CommandText = "Insert Into HR.Evaluacion_detalles (Id_evaluacion,Descripcion,Imagen,Nombre_documento,Documento,Extension,Aprueba_CB_CODIGO,Fecha,Puntos) 
                               Values (@id_eva,@Descripcion,@Imagen,NULL,NULL,NULL,@CB_CODIGO_Aprueba,GETDATE(),@niv_Act)"
            ElseIf doc = True Then
                cmd.Parameters.AddWithValue("@DocName", NombreDoc)
                cmd.Parameters.AddWithValue("@Doc", imagdoc)
                cmd.Parameters.AddWithValue("@Ext", extension)
                cmd.CommandText = "Insert Into HR.Evaluacion_detalles (Id_evaluacion,Descripcion,Imagen,Nombre_documento,Documento,Extension,Aprueba_CB_CODIGO,Fecha,Puntos) 
                               Values (@id_eva,@Descripcion,NULL,@DocName,@Doc,@Ext,@CB_CODIGO_APRUEBA,GETDATE(),@niv_Act)"
            Else
                cmd.CommandText = "Insert Into HR.Evaluacion_detalles (Id_evaluacion,Descripcion,Imagen,Nombre_documento,Documento,Extension,Aprueba_CB_CODIGO,Fecha,Puntos) 
                               Values (@id_eva,@Descripcion,NULL,NULL,NULL,NULL,@CB_CODIGO_Aprueba,GETDATE(),@niv_Act)"
            End If
            Dim re = cmd.ExecuteScalar

            Return 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function

    Shared Function Documentos_evaluacion(ByVal CB_CODIGO As Integer, ByVal Id_evaluacion As Integer)

        Try
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select * From [HR].[Evaluacion_detalles] Where  Id_Evaluacion=@IdCA"
            '   da.SelectCommand.Parameters.AddWithValue("@CB_CODIGO", CB_CODIGO)
            da.SelectCommand.Parameters.AddWithValue("@IdCA", Id_evaluacion)
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Evaluaciones_det")
            Return ds.Tables("Evaluaciones_det")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try


    End Function
#End Region

#Region "Validar huella"


    Shared Function Huellas(ByVal cb_codigo As String) As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
            da.SelectCommand.CommandText = "Select * from [MaRs].[dbo].[COMEDOR_HUELLAS] where CB_CODIGO=@CB_CODIGO"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "HUELLAS")
            Return ds.Tables("HUELLAS")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

#End Region
End Class

