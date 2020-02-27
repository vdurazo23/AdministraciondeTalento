Public Class SqlQuery



    Public Shared CnMPS As New SqlClient.SqlConnection("")
    Public Shared CnTress As New SqlClient.SqlConnection("")

    Public Shared da As New SqlClient.SqlDataAdapter("", CnMPS)

    Public Shared cmd As New SqlClient.SqlCommand("", CnMPS)

    Public Shared ds As New DataSet

#Region "ConnectionString"

    Shared Function constringMPS() As String
        Return "Data Source =" & My.Settings.MPSServer.Trim & "; workstation id =; Persist Security Info=True;User ID=" & My.Settings.MPSUsuario & ";password=" & My.Settings.MPSContraseña & ";initial catalog=" & My.Settings.MPSBD
    End Function 'Conexion

    Shared Function constringTRESS() As String
        Return "Data Source =" & My.Settings.TRESSServer.Trim & ";workstation id =; Persist Security Info=True;User ID=" & My.Settings.TRESSUsuario & ";password=" & My.Settings.TRESSContraseña & ";initial catalog=" & My.Settings.TressBD
    End Function

#End Region

#Region "Competencias"
    Shared Function Competencias() As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select c.Id,c.Competencia,ca.Categoria,ca.Id as 'Nivel' from hr.Competencias c" &
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

            da.SelectCommand.CommandText = "select  * from tress.dbo.COLABORA where CB_ACTIVO = 'S' order by Prettyname"


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
    Shared Function Personal_especifico(ByVal CB_CODIGO As Integer)
        Try

            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If


            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandText = "select co.CB_CODIGO, co.PRETTYNAME,pu.PU_DESCRIP,n1.TB_ELEMENT,n2.TB_ELEMENT,n3.TB_ELEMENT,n4.TB_ELEMENT,co.CB_FEC_ANT from tress.dbo.COLABORA co 
                                            inner join tress.dbo.NIVEL1 n1 on co.CB_NIVEL1 = n1.TB_CODIGO
                                            inner join tress.dbo.NIVEL2 n2 on co.CB_NIVEL2 = n2.TB_CODIGO
											inner join tress.dbo.NIVEL3 n3 on co.CB_NIVEL3 = n3.TB_CODIGO
											inner join tress.dbo.NIVEL4 n4 on co.CB_NIVEL4 = n4.TB_CODIGO
											inner join tress.dbo.NIVEL5 n5 on co.CB_NIVEL5 = n5.TB_CODIGO
											inner join tress.dbo.NIVEL6 n6 on co.CB_NIVEL6 = n6.TB_CODIGO
											inner join tress.dbo.PUESTO pu on co.CB_PUESTO = pu.PU_CODIGO
                                            where  CB_CODIGO = @CB_CODIGO "
            da.SelectCommand.Parameters.AddWithValue("@CB_CODIGO", CB_CODIGO)
            ds.Tables.Clear()
            da.Fill(ds, "Datos")
            Return ds.Tables("Datos")
        Catch ex As Exception

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function



    Shared Function Objetivos_detalles(ByVal id_objetivo)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select * from Hr.Objetivos_detail where Id_objetivo_Master = @id"
            da.SelectCommand.Parameters.AddWithValue("@id", id_objetivo)
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Objetivos")
            Return ds.Tables("Objetivos")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    ' Shared Function Agregar_Objetivo()
    '    Try
    '        CnMPS.ConnectionString = constringMPS()
    '        If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
    '        cmd.Connection = CnMPS
    '        cmd.Parameters.Clear()
    '        cmd.Parameters.AddWithValue("@CB_CODIGO", My.Application.Info.ProductName.ToString)
    '        cmd.Parameters.AddWithValue("@Objetivo", My.Application.Info.Version.ToString + " Revision - " + My.Application.Info.Version.Revision.ToString)
    '        cmd.Parameters.AddWithValue("@Detalles", My.Settings.CB_CODIGO)
    '        cmd.Parameters.AddWithValue("@Fecha_final", ex.StackTrace.ToString)
    '        cmd.Parameters.AddWithValue("@Message", ex.Message)
    '        cmd.Parameters.AddWithValue("@Extra", Msj)
    '        cmd.Parameters.AddWithValue("@hostname", System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).HostName)
    '        cmd.Parameters.AddWithValue("@ip", System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString)

    '        cmd.CommandType = CommandType.Text
    '        cmd.CommandText = "Insert into Support.Errors(Software, Version, Empleado, Detalles,[Stack Trace], comentario_extra, IP_EQUIPO,HOSTNAME)
    '                            Values (@Software,@Version,@Empl
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    Finally
    '        If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

    '    End Try
    'End Function
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
    Shared Function PorCodigo(ByVal cb_codigo As Integer, ByVal Optional activo As Boolean = True)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.Add("@cb_codigo", SqlDbType.Int)
            da.SelectCommand.Parameters("@cb_codigo").Value = cb_codigo
            If activo Then
                da.SelectCommand.CommandText = "Select prettyname, cb_Nivel1, cb_puesto from tress.dbo.COLABORA  where CB_CODIGO = @cb_codigo And CB_ACTIVO = 'S'"
            Else
                da.SelectCommand.CommandText = "select prettyname, cb_Nivel1, cb_puesto from tress.dbo.COLABORA  where CB_CODIGO = @cb_codigo "
            End If

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
    Shared Function Ponderaciones() As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.CommandText = "Select * from Hr.Ponderacion"
            ds.Tables.Clear()
            da.Fill(ds, "Ponderacion")
            Return ds.Tables("Ponderacion")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Nombre(ByVal id_caracteristica As Integer) As String
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.Parameters.AddWithValue("@Id", id_caracteristica)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select [Descripcion] from hr.caracteristicas where id = @Id"
            Dim Carac_nombre As String = cmd.ExecuteScalar
            CnMPS.Close()
            Return Carac_nombre
        Catch ex As Exception
            Throw New Exception
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function
    Shared Function Nombre_curso(ByVal cu_codigo As String) As String
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.Parameters.AddWithValue("@Codigo", cu_codigo)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select CU_NOMBRE from Tress.dbo.CURSO where CU_CODIGO = @Codigo"
            Dim Carac_nombre As String = cmd.ExecuteScalar
            CnMPS.Close()
            Return Carac_nombre
        Catch ex As Exception
            Throw New Exception
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function
#End Region

#Region "Login"
    Shared Function Busqueda_usuario(ByVal Usuario As String, ByVal Contraseña As String) As Usuario
        Dim us As New Usuario
        Try
            CnMPS.ConnectionString = constringMPS()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@User", Usuario)
            cmd.Parameters.AddWithValue("@Pass", Contraseña)
            cmd.CommandText = "Select Id from Mars.dbo.usuarios where Usuario = @User and Password = @Pass "
            us.id_user = cmd.ExecuteScalar
            cmd.CommandText = "Select cb_codigo from Mars.dbo.usuarios where Usuario = @User and Password = @Pass "
            us.cb_codigo = cmd.ExecuteScalar
            Return us
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return us
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function 'Consulta
#End Region




    Shared Function Cargar_carac_porpuesto(ByVal cb_codigo As Integer) As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
#Region "Codigo no utilizado"
            '            da.SelectCommand.CommandText = "select PRETTYNAME, CB_PUESTO,re.id,re.Descripcion, re.Competencia,re.Habilidad,re.Conocimiento,re.Nivel_requerido,re.Nivel_actual,re.Id_evaluacion from tress.dbo.COLABORA co 
            '                                            inner join (select Id_categoria,ca.* , Nivel_requerido, PU_CODIGO,ev.Nivel_actual,ev.id as 'Id_evaluacion' from hr.Relaciones_pto_carac rpc 
            '                                            inner join hr.Caracteristicas ca on rpc.Id_categoria = ca.Id
            '                                            left join hr.Evaluacion ev on ca.id = ev.Id_caracteristica and ev.CB_CODIGO = @NoEmpleado ) re on co.CB_PUESTO = re.pu_codigo
            '                                            where CB_CODIGO = @NoEmpleado "
            '            da.SelectCommand.CommandText = "select PRETTYNAME,CB_PUESTO,carac.id, carac.Descripcion,carac.Competencia,carac.Habilidad,carac.Conocimiento,carac.Curso,rel.Nivel_requerido,ev.id as 'Id_evaluacion',ev.Nivel_actual,ev.validado from tress.dbo.COLABORA co
            '                            inner join Hr.Relaciones_pto_carac rel on co.CB_PUESTO = rel.PU_CODIGO
            '                            inner join hr.Caracteristicas carac on carac.Id = rel.Id_categoria
            '                            left join hr.Evaluacion ev on ev.Id_caracteristica = rel.Id_categoria and co.CB_CODIGO = ev.CB_CODIGO
            '                            where co.CB_CODIGO=@NoEmpleado"
            '            da.SelectCommand.CommandText = "select PRETTYNAME,CB_PUESTO,carac.id, carac.Descripcion,carac.Competencia,carac.Habilidad,carac.Conocimiento,carac.Curso,rel.Nivel_requerido,ev.id as 'Id_evaluacion',
            '(SELECT MAX(PUNTOS) FROM HR.Evaluacion_detalles WHERE Id_Evaluacion = EV.Id AND VALIDADO = 1) as 'Nivel actual',
            ' Case when (Select count(id) from hr.Evaluacion_detalles where id_evaluacion = ev.id and Validado = 0) > 0 then convert(bit,0)  else convert(bit,1) end as 'Validado',
            ' carac.Nivel
            ' from tress.dbo.COLABORA co
            'inner join Hr.Relaciones_pto_carac rel on co.CB_PUESTO = rel.PU_CODIGO
            'inner join hr.Caracteristicas carac on carac.Id = rel.Id_categoria
            'left join hr.Evaluacion ev on ev.Id_caracteristica = rel.Id_categoria and co.CB_CODIGO = ev.CB_CODIGO
            'LEFT join hr.Evaluacion_detalles evd on ev.id = evd.Id_Evaluacion and evd.Validado = 1
            'where co.CB_CODIGO=@NoEmpleado order by Nivel desc, id"
            '            da.SelectCommand.CommandText = "
            'select prettyname,CB_PUESTO,Subconsulta.*  from tress.dbo.COLABORA co inner join (

            'Select 
            'inicial.Id_categoria as 'id',
            'ca.Descripcion,ca.Competencia,ca.Habilidad,ca.Conocimiento,ca.Curso,
            'inicial.[Nivel requerido],
            'ev.Id as 'Id_evaluacion',
            '(select max(Puntos) from hr.Evaluacion_detalles evd where evd.Id_Evaluacion = ev.Id and Validado = 1) as 'Nivel actual',
            'case when(select count(id) from hr.evaluacion_detalles where Id_Evaluacion=ev.Id and Validado = 0)>0 then CONVERT(bit,0) else CONVERT(bit,1) end as 'Validado',ca.Nivel
            ' from(
            'select id_categoria,MAX(Nivel_requerido) as 'Nivel requerido' from Hr.Relaciones_pto_carac where CB_CODIGO = @CB_CODIGO or PU_CODIGO = (
            'select CB_PUESTO from tress.dbo.COLABORA where CB_CODIGO = @CB_CODIGO) group by Id_categoria
            ') inicial 
            ' inner join hr.Caracteristicas ca on inicial.Id_categoria = ca.Id
            ' left join hr.Evaluacion ev on inicial.Id_categoria = ev.Id_caracteristica and ev.CB_CODIGO = @CB_CODIGO

            ') Subconsulta on 1 = 1
            ' where cb_codigo = @CB_CODIGO order by nivel desc, id"


#End Region
            da.SelectCommand.CommandText = "select prettyname,CB_PUESTO,Subconsulta.*  from tress.dbo.COLABORA co inner join (
Select 
inicial.Id_categoria as 'id',
ca.Descripcion,ca.Competencia,ca.Habilidad,ca.Conocimiento,ca.Curso,
inicial.[Nivel requerido],
ev.Id as 'Id_evaluacion',
(select max(Puntos) from hr.Evaluacion_detalles evd where evd.Id_Evaluacion = ev.Id and Validado = 1) as 'Nivel actual',
case when(select count(id) from hr.evaluacion_detalles where Id_Evaluacion=ev.Id and Validado = 0 and Rechazado = 0)>0 then CONVERT(bit,0) else CONVERT(bit,1) end as 'Validado',ca.Nivel,inicial.Solicitado_por,inicial.Id_ponderacion,
case when eer.id is null then convert(bit,0) else convert(bit,1) end as 'IDP' 
from( select Principal.*,secundario.Id_relacion,sec.Solicitado_por,sec.Id_ponderacion from ( select id_categoria,max(Nivel_requerido)as 'Nivel requerido'  from Hr.Relaciones_pto_carac
  where  CB_CODIGO =  @CB_CODIGO or PU_CODIGO = (select CB_PUESTO from tress.dbo.COLABORA where CB_CODIGO =  @CB_CODIGO) 
 group by Id_categoria) Principal
 cross apply  (select top 1 * from hr.Relaciones_pto_carac  where id_categoria = Principal.Id_categoria and  (CB_CODIGO =  @CB_CODIGO or PU_CODIGO = (select CB_PUESTO from tress.dbo.COLABORA where CB_CODIGO =  @CB_CODIGO)) order by nivel_requerido desc) secundario
 cross apply (select Solicitado_por,Id_ponderacion from hr.Instruccion_relacion where id = secundario.Id_relacion) sec ) inicial
 inner join hr.Caracteristicas ca on inicial.Id_categoria = ca.Id
 left join hr.Evaluacion ev on inicial.Id_categoria = ev.Id_caracteristica and ev.CB_CODIGO = @CB_CODIGO and inicial.Id_ponderacion  = ev.id_ponderacion  and inicial.[Nivel requerido] = ev.Nivel_requerido
 left join (select top(3) * from hr.Programacion_IDP where CB_CODIGO = @cb_codigo and Id_Periodo = (select top(1) Id from hr.Periodos_IDP per where per.[Fecha inicio] <= GETDATE() and GETDATE() <= per.[Fecha fin] and Activo = 1 )  ) eer on eer.Id_competencia = ca.id  
) Subconsulta on 1 = 1
 where cb_codigo = @CB_CODIGO order by nivel desc, id  "

            ds.Tables.Clear()
            da.Fill(ds, "Relaciones")
            Return ds.Tables("Relaciones")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function
    Shared Function cargar_cursos_porpuesto(ByVal cb_codigo As Integer) As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)

            da.SelectCommand.CommandText = "
    select prettyname,CB_PUESTO,Subconsulta.*  from tress.dbo.COLABORA co inner join (
   Select 
inicial2.CU_CODIGO as 'CU_CODIGO',
ca.CU_NOMBRE,0 as 'Competencia',0 as 'Habilidad',0 as 'Conocimiento',1 as 'Curso',
inicial2.[Nivel requerido],
ev.Id as 'Id_evaluacion',
(select max(Puntos) from hr.Evaluacion_detalles evd where evd.Id_Evaluacion = ev.Id and Validado = 1) as 'Nivel actual',
case when(select count(id) from hr.evaluacion_detalles where Id_Evaluacion=ev.Id and Validado = 0 and Rechazado = 0)>0 then CONVERT(bit,0) else CONVERT(bit,1) end as 'Validado',0 as 'Nivel',inicial2.Solicitado_por,inicial2.Id_ponderacion
 from( 
 select Principal2.*,secundario2.Id_relacion,sec2.Solicitado_por,sec2.Id_ponderacion from (select CU_CODIGO,max(nivel_requerido)as 'Nivel requerido' from hr.Relaciones_pto_carac 
 where cu_codigo is not null and (CB_CODIGO = @CB_CODIGO or PU_CODIGO =  (select CB_PUESTO from tress.dbo.COLABORA where CB_CODIGO =  @CB_CODIGO) )
 group by CU_CODIGO ) principal2
  cross apply  (select top 1 * from hr.Relaciones_pto_carac  where CU_CODIGO = principal2.CU_CODIGO and  (CB_CODIGO =  @CB_CODIGO or PU_CODIGO = (select CB_PUESTO from tress.dbo.COLABORA where CB_CODIGO =  @CB_CODIGO)) order by nivel_requerido desc) secundario2
  cross apply (select Solicitado_por,Id_ponderacion from hr.Instruccion_relacion where id = secundario2.Id_relacion) sec2
   ) inicial2
   inner join tress.dbo.CURSO ca on inicial2.CU_CODIGO = ca.CU_CODIGO
   left join hr.Evaluacion ev on inicial2.CU_CODIGO = ev.CU_CODIGO and ev.CB_CODIGO = @CB_CODIGO and inicial2.Id_ponderacion  = ev.id_ponderacion  and inicial2.[Nivel requerido] = ev.Nivel_requerido
   ) Subconsulta on 1 = 1
 where cb_codigo = @CB_CODIGO order by [Nivel requerido] desc,CU_NOMBRE

 "

            ds.Tables.Clear()
            da.Fill(ds, "Relaciones_cursos")
            Return ds.Tables("Relaciones_cursos")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function

    Shared Function Cargar_carac_otropuesto(ByVal cb_codigo As Integer, ByVal cb_puesto As String)
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
            da.SelectCommand.Parameters.AddWithValue("@PU_CODIGO", cb_puesto)

            da.SelectCommand.CommandText = "
select prettyname,CB_PUESTO,Subconsulta.*  from tress.dbo.COLABORA co inner join (
Select 
inicial.Id_categoria as 'id',
ca.Descripcion,ca.Competencia,ca.Habilidad,ca.Conocimiento,ca.Curso,
inicial.[Nivel requerido],
ev.Id as 'Id_evaluacion',
 case when ev.id is null then  case when (
 select sum(evp.id) 
 from hr.Evaluacion evp
 inner join hr.Evaluacion_detalles evdp on evdp.Id_Evaluacion = evp.Id and evdp.Validado = 1 and Puntos > 0 
  where Id_caracteristica = inicial.Id_categoria and CB_CODIGO = @CB_CODIGO and Id_ponderacion = inicial.Id_ponderacion and evp.Nivel_requerido > inicial.[Nivel requerido] 
 ) is not null then 100  else null end  
 else (select max(Puntos) from hr.Evaluacion_detalles evd where evd.Id_Evaluacion = ev.Id and Validado = 1) end as 'Nivel actual',
case when(select count(id) from hr.evaluacion_detalles where Id_Evaluacion=ev.Id and Validado = 0 and Rechazado = 0)>0 then CONVERT(bit,0) else CONVERT(bit,1) end as 'Validado',ca.Nivel,inicial.Solicitado_por,inicial.Id_ponderacion
from( select Principal.*,secundario.Id_relacion,sec.Solicitado_por,sec.Id_ponderacion from ( select id_categoria,max(Nivel_requerido)as 'Nivel requerido'  from Hr.Relaciones_pto_carac
  where  PU_CODIGO = @PU_CODIGO 
 group by Id_categoria) Principal
 cross apply  (select top 1 * from hr.Relaciones_pto_carac  where id_categoria = Principal.Id_categoria and  PU_CODIGO = @PU_CODIGO order by nivel_requerido desc) secundario
 cross apply (select Solicitado_por,Id_ponderacion from hr.Instruccion_relacion where id = secundario.Id_relacion) sec ) inicial
 inner join hr.Caracteristicas ca on inicial.Id_categoria = ca.Id
 left join hr.Evaluacion ev on inicial.Id_categoria = ev.Id_caracteristica and ev.CB_CODIGO = @CB_CODIGO and inicial.Id_ponderacion  = ev.id_ponderacion  and inicial.[Nivel requerido] = ev.Nivel_requerido 
) Subconsulta on 1 = 1
 where cb_codigo = @CB_CODIGO order by nivel desc, id
 "

            da.SelectCommand.CommandText = "
Select 
convert(char(6),inicial.Id_categoria) as 'Id',
ca.Nivel,
case when ca.Competencia = 1 then 'Competencia' when ca.Habilidad = 1 then 'Habilidad' when ca.Conocimiento = 1 then 'Conocimiento' when ca.Curso = 1 then 'Curso' end as 'Tipo',
ca.Descripcion,inicial.Solicitado_por,inicial.[Nivel requerido],ev.Id as 'Id_evaluacion',
case 
when ev.id is null then  
	case when ( select sum(evp.id)  from hr.Evaluacion evp inner join hr.Evaluacion_detalles evdp on evdp.Id_Evaluacion = evp.Id and evdp.Validado = 1 and Puntos > 0 
			where Id_caracteristica = inicial.Id_categoria and CB_CODIGO = @CB_CODIGO and Id_ponderacion = inicial.Id_ponderacion and evp.Nivel_requerido > inicial.[Nivel requerido] 
		 ) is not null then 100  else 0 end  
	else  case when (select max(Puntos) from hr.Evaluacion_detalles evd where evd.Id_Evaluacion = ev.Id and Validado = 1) is not null 
			then (select max(Puntos) from hr.Evaluacion_detalles evd where evd.Id_Evaluacion = ev.Id and Validado = 1) else 0 end end as 'Porcentaje',
case when(select count(id) from hr.evaluacion_detalles where Id_Evaluacion=ev.Id and Validado = 0 and Rechazado = 0)>0 then CONVERT(bit,0) else CONVERT(bit,1) end as 'Validado',inicial.Id_ponderacion
from( select Principal.*,secundario.Id_relacion,sec.Solicitado_por,sec.Id_ponderacion from ( select id_categoria,max(Nivel_requerido)as 'Nivel requerido'  from Hr.Relaciones_pto_carac
where  PU_CODIGO = @PU_CODIGO 
group by Id_categoria) Principal
 cross apply  (select top 1 * from hr.Relaciones_pto_carac  where id_categoria = Principal.Id_categoria and  PU_CODIGO = @PU_CODIGO order by nivel_requerido desc) secundario
 cross apply (select Solicitado_por,Id_ponderacion from hr.Instruccion_relacion where id = secundario.Id_relacion) sec ) inicial
 inner join hr.Caracteristicas ca on inicial.Id_categoria = ca.Id
 left join hr.Evaluacion ev on inicial.Id_categoria = ev.Id_caracteristica and ev.CB_CODIGO = @CB_CODIGO and inicial.Id_ponderacion  = ev.id_ponderacion  and inicial.[Nivel requerido] = ev.Nivel_requerido 
    union all
Select inicial2.CU_CODIGO as 'Identificador',
NUll as 'Nivel','Curso' as Tipo,ca.CU_NOMBRE as 'Descripcion',inicial2.Solicitado_por,inicial2.[Nivel requerido],ev.Id as 'Id_evaluacion',
case when ev.id is null then  case when (
select sum(evp.id) 
from hr.Evaluacion evp
inner join hr.Evaluacion_detalles evdp on evdp.Id_Evaluacion = evp.Id and evdp.Validado = 1 and Puntos > 0 
where evp.CU_CODIGO = inicial2.CU_CODIGO and CB_CODIGO = @CB_CODIGO and Id_ponderacion = inicial2.Id_ponderacion and evp.Nivel_requerido > inicial2.[Nivel requerido] 
) is not null then 100  else 0 end  
else 

case when (select max(Puntos) from hr.Evaluacion_detalles evd where evd.Id_Evaluacion = ev.Id and Validado = 1) is not null then 
(select max(Puntos) from hr.Evaluacion_detalles evd where evd.Id_Evaluacion = ev.Id and Validado = 1) else 0 end
 end as 'Porcentaje',
 case when(select count(id) from hr.evaluacion_detalles where Id_Evaluacion=ev.Id and Validado = 0 and Rechazado = 0)>0 then CONVERT(bit,0) else CONVERT(bit,1) end as 'Validado',inicial2.Id_ponderacion
from(select Principal2.*,secundario2.Id_relacion,sec2.Solicitado_por,sec2.Id_ponderacion from (select CU_CODIGO,max(nivel_requerido)as 'Nivel requerido' from hr.Relaciones_pto_carac 
where cu_codigo is not null and  PU_CODIGO =  @PU_CODIGO  group by CU_CODIGO ) principal2
cross apply  (select top 1 * from hr.Relaciones_pto_carac  where CU_CODIGO = principal2.CU_CODIGO and   PU_CODIGO = @pu_codigo order by nivel_requerido desc) secundario2
cross apply (select Solicitado_por,Id_ponderacion from hr.Instruccion_relacion where id = secundario2.Id_relacion) sec2
) inicial2   inner join tress.dbo.CURSO ca on inicial2.CU_CODIGO = ca.CU_CODIGO
left join hr.Evaluacion ev on inicial2.CU_CODIGO = ev.CU_CODIGO and ev.CB_CODIGO = @CB_CODIGO and inicial2.Id_ponderacion  = ev.id_ponderacion  and inicial2.[Nivel requerido] = ev.Nivel_requerido
order by Tipo,[Nivel requerido] desc, Porcentaje
"

            ds.Tables.Clear()
            da.Fill(ds, "carac_otro")
            Return ds.Tables("carac_otro")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function cargar_cursos_otropuesto(ByVal cb_codigo As Integer, ByVal cb_puesto As String)
        Try

            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
            da.SelectCommand.Parameters.AddWithValue("@PU_CODIGO", cb_puesto)

            da.SelectCommand.CommandText = "

 "

            ds.Tables.Clear()
            da.Fill(ds, "curs_otro")
            Return ds.Tables("curs_otro")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function Cargar_detallado(ByVal cb_codigo As Integer) As DataTable
        Try
            Dim PTo = puesto(cb_codigo)
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            da.SelectCommand.Parameters.Clear()

            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@Cb_codigo", cb_codigo)
            da.SelectCommand.Parameters.AddWithValue("@Pu_codigo", PTo)
            da.SelectCommand.CommandText = "
               select rpc.id,
case when c.id is not null then c.Nivel end as 'Nivel competencia',
case when c.Id is not null then   
case when c.Competencia = 1 then 'Competencia' when c.Conocimiento = 1 then 'Conocimiento' when c.Habilidad  = 1 then 'Habilidad' end
 else 'Curso' end as 'Tipo' ,
case when c.Id is not null then rtrim(ltrim(str(c.Id))) else cur.CU_CODIGO end as 'Identificador' ,  case when c.Id is not null then c.Descripcion else cur.CU_NOMBRE end as 'Detalles',
i.Solicitado_por,rpc.Nivel_requerido,ev.Calificacion,i.Id_ponderacion, pr.Fecha as 'Proximo entrenamiento',pr.Calificacion_esperada as 'Nivel esperado'
from hr.Relaciones_pto_carac rpc 
inner join ( select Id_categoria, CU_CODIGO,MAX(Nivel_requerido) AS 'Nivel_requerido' 
 from hr.Relaciones_pto_carac where CB_CODIGO = @cb_codigo OR PU_CODIGO = @Pu_codigo
 GROUP BY Id_categoria,CU_CODIGO) rr on rpc.Id_categoria = rr.Id_categoria or rr.CU_CODIGO = rpc.CU_CODIGO
left join hr.Caracteristicas c on rpc.Id_categoria = c.Id
left join tress.dbo.CURSO cur on rpc.CU_CODIGO = cur.CU_CODIGO
inner join hr.Instruccion_relacion i on rpc.Id_relacion = i.Id
left join hr.Evaluacion e on (e.Id_caracteristica = c.id or e.CU_CODIGO = cur.CU_CODIGO) and e.CB_CODIGO = @Cb_codigo and e.Id_ponderacion = i.Id_ponderacion and rpc.Nivel_requerido = e.Nivel_requerido
left join (select id_evaluacion, max(Puntos) as 'Calificacion' from hr.Evaluacion_detalles where validado = 1 group by Id_Evaluacion) ev on e.Id = ev.Id_Evaluacion
left join hr.programacion pr on (c.Id = pr.Id_caracteristica or cur.CU_CODIGO =pr.CU_CODIGO) and i.Id_ponderacion = pr.Id_ponderacion and pr.Nivel_requerido = rpc.Nivel_requerido 
 where rpc.id in ( select id from hr.Relaciones_pto_carac rpc
 inner join ( select Id_categoria, CU_CODIGO,MAX(Nivel_requerido) AS 'Nivel_requerido' 
 from hr.Relaciones_pto_carac where CB_CODIGO = @cb_codigo OR PU_CODIGO = @Pu_codigo 
 GROUP BY Id_categoria,CU_CODIGO) rr on (rpc.Id_categoria = rr.Id_categoria and rpc.Nivel_requerido = rr.Nivel_requerido) or (rpc.CU_CODIGO = rr.CU_CODIGO and rpc.Nivel_requerido = rr.Nivel_requerido)
  where CB_CODIGO = @Cb_codigo or PU_CODIGO = @Pu_codigo) order by Tipo
"
            ds.Tables.Clear()
            da.Fill(ds, "Detalles")
            Return ds.Tables("Detalles")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function
    Shared Function cargar_detallado_nopuesto(ByVal cb_codigo As Integer) As DataTable
        Try
            Dim PTo = puesto(cb_codigo)
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            da.SelectCommand.Parameters.Clear()

            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@cb_codigo", cb_codigo)
            da.SelectCommand.Parameters.AddWithValue("@pu_codigo", PTo)
            da.SelectCommand.CommandText = "
         select 
'N/A' as 'id',
ca.Nivel,
case when ca.Competencia = 1 then 'Competencia' when ca.Conocimiento = 1 then 'Conociemiento' when ca.Habilidad = 1 then 'Habilidad' else 'Curso' end as 'Tipo',
case when ca.Id is not null then RTRIM(ltrim(str(ca.id))) else cu.CU_CODIGO end as 'Identificador',
case when ca.id is not null then ca.Descripcion else cu.CU_NOMBRE end as 'Detalles',
'Otro' as 'Solicitado_por',otros.Nivel_requerido,
otros.Nivel_actual as 'Calificacion'
, otros.Id_ponderacion
, pr.Fecha as 'Proximo entrenamiento'
, pr.Calificacion_esperada as 'Nivel esperado'  
 from (
    select id,CB_CODIGO,Id_caracteristica,CU_CODIGO,Nivel_requerido,Id_ponderacion,(select max(puntos) from hr.Evaluacion_detalles where Id_Evaluacion = e.id and Validado = 1) as 'Nivel_actual',convert(bit,1) as 'Validado' from hr.Evaluacion e where CB_CODIGO = @cb_codigo and Id_caracteristica not in (
    select Id_categoria from hr.Relaciones_pto_carac where (PU_CODIGO = @pu_codigo or CB_CODIGO = @cb_codigo) and Id_categoria is not null
  )
  union all
  select id,CB_CODIGO,Id_caracteristica,CU_CODIGO,Nivel_requerido,Id_ponderacion,(select max(puntos) from hr.Evaluacion_detalles where Id_Evaluacion = e.id and Validado = 1) as 'Nivel_actual',convert(bit,1) as 'Validado' from hr.Evaluacion e where CB_CODIGO = @cb_codigo and CU_CODIGO not in (
  select r.CU_CODIGO from hr.Relaciones_pto_carac r where (PU_CODIGO = @pu_codigo or CB_CODIGO = @cb_codigo) and  r.CU_CODIGO is not null
  ) ) otros
 left join hr.Caracteristicas ca on otros.Id_caracteristica = ca.Id
 left join tress.dbo.CURSO cu on otros.CU_CODIGO = cu.CU_CODIGO 
 left join hr.Programacion pr on pr.CB_CODIGO = @cb_codigo and (pr.Id_caracteristica = otros.Id or pr.CU_CODIGO = otros.CU_CODIGO) and otros.Id_ponderacion = pr.Id_ponderacion and otros.Nivel_requerido = pr.Nivel_requerido
"
            ds.Tables.Clear()
            da.Fill(ds, "info2")
            Return ds.Tables("info2")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Otras_Calificaciones(ByVal cb_codigo As Integer, ByVal id_caracteristica As Integer, ByVal cu_codigo As String) As DataTable
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            da.SelectCommand.Parameters.Clear()

            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@Cb_codigo", cb_codigo)
            If cu_codigo <> "" Then

                da.SelectCommand.Parameters.AddWithValue("@CU_CODIGO", cu_codigo)
                da.SelectCommand.CommandText = "
select ev.Id,ev.Nivel_requerido,ev.Id_ponderacion, max(evd.puntos) as 'Calificación',case when (select count(id) from hr.Evaluacion_detalles where Id_Evaluacion = ev.Id and Validado = 0 and Rechazado = 0) > 0
then 0 else 1 end as 'Validado'  from hr.Evaluacion ev 
left join hr.Evaluacion_detalles evd on ev.Id = evd.Id_Evaluacion and evd.Validado = 1
 where CB_CODIGO = @Cb_codigo and CU_CODIGO = @CU_CODIGO
 group by ev.Id,ev.Nivel_requerido,ev.Id_ponderacion
"
            Else
                da.SelectCommand.Parameters.AddWithValue("@Id_carac", id_caracteristica)
                da.SelectCommand.CommandText = "
select ev.Id,ev.Nivel_requerido,ev.Id_ponderacion, max(evd.puntos) as 'Calificación',case when (select count(id) from hr.Evaluacion_detalles where Id_Evaluacion = ev.Id and Validado = 0 and Rechazado = 0) > 0
then 0 else 1 end as 'Validado'  from hr.Evaluacion ev 
left join hr.Evaluacion_detalles evd on ev.Id = evd.Id_Evaluacion and evd.Validado = 1
 where CB_CODIGO = @Cb_codigo and Id_caracteristica = @Id_carac
 group by ev.Id,ev.Nivel_requerido,ev.Id_ponderacion
"

            End If

            ds.Tables.Clear()
            da.Fill(ds, "Otros")
            Return ds.Tables("Otros")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

#Region "Relaciones"


    Shared Function agregar_relacion(ByVal id_caracteristica As Integer, ByVal Solicitado As String, ByVal Por_empleado As Boolean, ByVal Por_nivel As Boolean, ByVal Id_nivel As Integer,
                                     ByVal Por_puesto As Boolean, ByVal Escalona As Boolean, ByVal Hereda As Boolean, ByVal Puesto_inicial As String, ByVal Puesto_final As String, ByVal Activo As Boolean,
                                     ByVal Nuevo As Boolean, ByVal Optional Id As Integer = 0, ByVal Optional cb_codigo As Integer = Nothing, ByVal Optional Id_ponderacion As Integer = Nothing, ByVal Optional CU_CODIGO As String = "")

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
            cmd.Parameters.AddWithValue("@PEMP", Por_empleado)
            cmd.Parameters.AddWithValue("@Ponderacion", Id_ponderacion)
            If CU_CODIGO <> "" Then

            End If


            'LA RELACION ES NUEVA O ES UNA ACTUALIZACION***************************************************
            If Nuevo Then


#Region "Por nivel"
                If Por_nivel = True Then
                    'RELACION NUEVA POR NIVEL DE EMPLEADO------------------------------------------------------------------------



                    cmd.Parameters.AddWithValue("@INI", Id_nivel)
                    cmd.CommandType = CommandType.Text


                    'Revisar si existe una relacion identica **********************************************************************
                    cmd.CommandText = "Select id from HR.Instruccion_relacion where Id_caracteristica = @IDCA and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Id_nivel = @INI"
                    Dim ask = cmd.ExecuteScalar
                    If ask Is Nothing Then

                        'Revisar si existe una relacion que involucre los puestos requeridos para la caracteristica en cuestion********************************************************************************
                        cmd.CommandText = "Select id from HR.Instruccion_relacion where Id_caracteristica = @IDCA and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Id_nivel < @INI"
                        ask = cmd.ExecuteScalar
                        If ask Is Nothing Then

                            'Agregar nueva caracteristica y guardar valor en ID **************************************************************************************
                            cmd.CommandText = "Insert into HR.Instruccion_relacion (Id_caracteristica,Solicitado_por,Por_nivel,Por_puesto,Id_nivel,Activo,Por_empleado,Id_ponderacion)
                                   Values(@IDCA,@SOL,@PNI,@PPU,@INI,@ACT,@PEMP,@Ponderacion);SELECT @@IDENTITY"
                            Id = cmd.ExecuteScalar
                        Else
                            MsgBox("Ya existe una relacion que involucra los niveles de empleados solicitados", MsgBoxStyle.Critical)
                            Return 0
                        End If

                    Else
                        MsgBox("La relacion ingresada ya existe en el sistema", MsgBoxStyle.Critical)
                        Return 0
                    End If


                    CnMPS.Close()
                    If Activo = True Then
                        exec_instruccion(Id)
                    End If
#End Region

                ElseIf Por_puesto Then 'Else if por nivel

                    'Relacion nueva por puesto--------------------------------------------------------------------------
                    cmd.Parameters.AddWithValue("@ESC", Escalona)
                    cmd.Parameters.AddWithValue("@HERE", Hereda)
                    cmd.Parameters.AddWithValue("@PUINI", Puesto_inicial)
                    cmd.CommandType = CommandType.Text


                    'Revisar si existe una relacion identica ***********************************************************************************************

#Region "Se escalona o se hereda"
                    If Escalona Or Hereda Then
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
                                cmd.CommandText = "Insert into HR.Instruccion_relacion(Id_caracteristica, Solicitado_por,Por_nivel,Por_puesto,Escalona,Hereda,PU_INICIA,PU_FINAL,Activo,Por_empleado,Id_ponderacion)
                                       Values(@IDCA,@SOL,@PNI,@PPU,@ESC,@HERE,@PUINI,NULL,@ACT,0,@Ponderacion);SELECT @@IDENTITY"
                            Else
                                cmd.CommandText = "Insert into HR.Instruccion_relacion(Id_caracteristica, Solicitado_por,Por_nivel,Por_puesto,Escalona,Hereda,PU_INICIA,PU_FINAL,Activo,Por_empleado,Id_ponderacion)
                                       Values(@IDCA,@SOL,@PNI,@PPU,@ESC,@HERE,@PUINI,@PUFIN,@ACT,0,@Ponderacion);SELECT @@IDENTITY"
                            End If
                            Id = cmd.ExecuteScalar
                            CnMPS.Close()
                            If Activo = True Then
                                exec_instruccion(Id)
                            End If
                        Else
                            MsgBox("La relacion ingresada ya existe en el sistema", MsgBoxStyle.Critical)
                            Return 0
                        End If
#End Region

                    Else
                        'Solo puesto

                        If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                        cmd.Parameters("@PUINI").Value = Puesto_inicial
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
                                cmd.CommandText = "Insert into HR.Instruccion_relacion(Id_caracteristica, Solicitado_por,Por_nivel,Por_puesto,Escalona,Hereda,PU_INICIA,PU_FINAL,Activo,Id_ponderacion)
                                       Values(@IDCA,@SOL,@PNI,@PPU,@ESC,@HERE,@PUINI,NULL,@ACT,@Ponderacion);SELECT @@IDENTITY"
                            Else
                                cmd.CommandText = "Insert into HR.Instruccion_relacion(Id_caracteristica, Solicitado_por,Por_nivel,Por_puesto,Escalona,Hereda,PU_INICIA,PU_FINAL,Activo,Id_ponderacion)
                                       Values(@IDCA,@SOL,@PNI,@PPU,@ESC,@HERE,@PUINI,@PUFIN,@ACT,@Ponderacion);SELECT @@IDENTITY"
                            End If
                            Id = cmd.ExecuteScalar
                            CnMPS.Close()
                            If Activo = True Then
                                exec_instruccion(Id)
                            End If
                        Else
                            MsgBox("Ya existe una relacion identica", MsgBoxStyle.Critical)
                            Return 0
                        End If

                    End If
                ElseIf Por_empleado Then
                    If CnMPS.State = ConnectionState.Closed Then
                        CnMPS.ConnectionString = constringMPS()
                        CnMPS.Open()
                    End If
                    cmd.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
                    cmd.CommandText = "Select id from HR.Instruccion_relacion where id_caracteristica = @IDCA and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Por_empleado = @PEMP and Id_ponderacion = @Ponderacion and CB_CODIGO = @CB_CODIGO"
                    Dim ask = cmd.ExecuteScalar
                    If ask Is Nothing Then
                        cmd.CommandText = "Insert into Hr.Instruccion_relacion(Id_caracteristica,Solicitado_por,Por_nivel,Por_puesto,Activo,Por_empleado,CB_CODIGO,Id_ponderacion)
                                            Values(@IDCA,@SOL,@PNI,@PPU,@ACT,@PEMP,@CB_CODIGO,@Ponderacion); SELECT @@IDENTITY"
                        Id = cmd.ExecuteScalar
                        CnMPS.Close()
                        If Activo = True Then
                            exec_instruccion(Id)
                        End If
                    Else
                        MsgBox("Ya existe una relacion identica", MsgBoxStyle.Critical)
                        Return 0
                    End If
                End If ' End if por nivel
            Else   'Else if nuevo
                'Actualizar relacion*****************************************************************************
                If Por_nivel = True Then
                    'Actualizar por nivel-------------------------------------------------------------
                Else
                    'Actualizar por puesto ------------------------------------------------------------------
                End If
            End If ' End if nuevo

            Return 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function agregar_relacion_multiple(ByVal id_caracteristica As Integer, ByVal Solicitado As String, ByVal Por_empleado As Boolean,
                                     ByVal Por_puesto As Boolean, ByVal Puestos_lista As List(Of Puesto_descripcion), ByVal Empleados_lista As List(Of empleados), ByVal Activo As Boolean,
                                     ByVal Nuevo As Boolean, ByVal Id_ponderacion As Integer, ByVal Optional CU_CODIGO As String = "")
        Try

            Dim puestos_a_calificar As New List(Of Puesto_descripcion)
            Dim empleados_a_calificar As New List(Of empleados)

            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            ds.Tables.Clear()
            cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
            cmd.Parameters.AddWithValue("@SOL", Solicitado)
            cmd.Parameters.AddWithValue("@PPU", Por_puesto)
            cmd.Parameters.AddWithValue("@ACT", Activo)
            cmd.Parameters.AddWithValue("@PEMP", Por_empleado)
            cmd.Parameters.AddWithValue("@Ponderacion", Id_ponderacion)
            Dim instrucciones As New List(Of Integer)
            'LA RELACION ES NUEVA O ES UNA ACTUALIZACION***************************************************
            If Nuevo Then
                If CnMPS.State = ConnectionState.Closed Then
                    CnMPS.ConnectionString = constringMPS()
                    CnMPS.Open()
                End If
                If Por_puesto Then 'Else if por nivel


                    'Relacion nueva por puesto--------------------------------------------------------------------------
                    cmd.Parameters.Add("@PUINI", SqlDbType.VarChar)
                    For Each pues As Puesto_descripcion In Puestos_lista
                        cmd.Parameters("@PUINI").Value = pues.pu_codigo
                        cmd.CommandType = CommandType.Text
                        'Revisar si existe una relacion identica ***********************************************************************************************
                        cmd.CommandText = "Select  id from Hr.Instruccion_relacion where Id_caracteristica = @IDCA and Solicitado_por = @SOL and Por_nivel = 0 and Por_puesto = 1 and Escalona = 0 and Hereda = 0 and
                                        PU_INICIA = @PUINI and PU_FINAL is NULL"
                        Dim ask = cmd.ExecuteScalar
                        If ask Is Nothing Then
                            cmd.CommandText = "Insert into HR.Instruccion_relacion(Id_caracteristica, Solicitado_por,Por_puesto,PU_INICIA,Activo,Id_ponderacion)
                                       Values(@IDCA,@SOL,1,@PUINI,@ACT,@Ponderacion);SELECT @@IDENTITY"
                            Dim Id = cmd.ExecuteScalar
                            instrucciones.Add(Id)
                            puestos_a_calificar.Add(pues)
                        End If
                    Next

                ElseIf Por_empleado Then
                    cmd.Parameters.Add("@CB_CODIGO", SqlDbType.Int)
                    For Each emp As empleados In Empleados_lista
                        cmd.Parameters("@CB_CODIGO").Value = emp.cb_codigo
                        cmd.CommandText = "Select id from HR.Instruccion_relacion where id_caracteristica = @IDCA and Solicitado_por = @SOL and Por_nivel = 0 and Por_puesto = 0 and Por_empleado = 1 and Id_ponderacion = @Ponderacion and CB_CODIGO = @CB_CODIGO"
                        Dim ask = cmd.ExecuteScalar
                        If ask Is Nothing Then
                            cmd.CommandText = "Insert into Hr.Instruccion_relacion(Id_caracteristica,Solicitado_por,Activo,Por_empleado,CB_CODIGO,Id_ponderacion)
                                            Values(@IDCA,@SOL,@ACT,1,@CB_CODIGO,@Ponderacion); SELECT @@IDENTITY"
                            Dim id = cmd.ExecuteScalar
                            instrucciones.Add(id)
                            empleados_a_calificar.Add(emp)
                        End If
                    Next
                End If
            Else
            End If
            If instrucciones.Count > 0 Then
                exec_instruccion_multiple(id_caracteristica, instrucciones, puestos_a_calificar, empleados_a_calificar, Por_puesto, Id_ponderacion)
            End If
            Return 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function eliminar_instruccion(ByVal id_instruccion As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()

            'ELIMINAR RELACIONRES_PTO_CARAC
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@Id_rel", id_instruccion)
            cmd.CommandText = "  select e.Cero + e.Uno+e.dos+e.tres+e.cuatro as 'Comentario'from (
  select 'Se elimina' as 'Cero',
  case when Id_caracteristica is null then ' relacion de curso:' + CU_CODIGO when CU_CODIGO is null then ' relacion de caracteristica con id:'+ str(Id_caracteristica)end as 'Uno',
   ' Solicitado por -' + Solicitado_por +'-' as 'dos',
            Case when Por_nivel=1 then 'para nivel:' + str(Id_nivel) when Por_puesto=1 then ' para el puesto:' + PU_INICIA
  when Por_empleado=1 then ' para el empleado:' + str(CB_CODIGO) end as 'tres',
  Case when Escalona =1 then ' escalonado al puesto ' + PU_FINAL when Hereda = 1 then ' heredado a sus puestos hijos'  else '' end as 'cuatro' 
   From hr.Instruccion_relacion  Where id = @Id_rel ) e"
            Dim comentario As String = cmd.ExecuteScalar


            cmd.Parameters.AddWithValue("@Comentario", comentario)
            cmd.Parameters.AddWithValue("@Usuario", My.Settings.Id_user)
            cmd.CommandText = "Insert into hr.Historial(Id_usuario, Accion)values (@Usuario,@Comentario)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Delete from [HR].[Relaciones_pto_carac] where id_relacion = @Id_rel"
            cmd.ExecuteNonQuery()


            'ELIMINAR RELACIONES_REPETIDAS DONDE ID_INSTRUCCION SEA SECUNDARIO
            cmd.CommandText = "Delete from [HR].[Relaciones_repetidas] where id_relacion_repetido = @Id_rel"
            cmd.ExecuteNonQuery()






            'EJECUTAR INSTRUCCIONES DONDE ID_INSTRUCCION SEA PRINCIPAL
            Console.Write("")
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@Id_instruccion", id_instruccion)
            da.SelectCommand.CommandText = "Select * from HR.Relaciones_repetidas where Id_relacion_principal = @Id_instruccion Order by Id_relacion_repetido"
            If ds.Tables("ElPRI") IsNot Nothing Then
                ds.Tables.Remove("ElPRI")
            End If
            da.Fill(ds, "ElPRI")
            For Each ro As DataRow In ds.Tables("ElPRI").Rows
                Console.WriteLine("")
                exec_instruccion(ro.ItemArray(2))
            Next

            'ELIMINAR RELACIONES_REPETIDAS
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Id_rel", id_instruccion)
            cmd.CommandText = "Delete from [HR].[Relaciones_repetidas] where id_relacion_principal = @Id_rel"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "Delete from [HR].[Instruccion_relacion] where id = @Id_rel"
            cmd.ExecuteNonQuery()

            'ELIMINAR DE INSTRUCCIONES


            'da.SelectCommand.CommandText = "Select * from Hr.Relaciones_repetidas where Id_relacion_repetido = @Id_instruccion"
            'da.Fill(ds, "A quien pasaba")
            'Console.WriteLine("")

            'If ds.Tables("Heredar").Rows.Count > 0 Then
            '    If ds.Tables("A quien pasaba").Rows.Count > 0 Then
            '        'Caso 2 y 3
            '        cmd.Parameters.Clear()
            '        cmd.Parameters.AddWithValue("@id_rel", id_instruccion)
            '        cmd.CommandType = CommandType.Text
            '        cmd.CommandText = "Delete from HR.Relaciones_pto_carac where id_relacion = @id_rel"
            '        cmd.ExecuteNonQuery()
            '        For Each ro As DataRow In ds.Tables("Heredar").Rows
            '        Next
            '    Else
            '        'Caso 1
            '        cmd.Parameters.Clear()
            '        cmd.Parameters.AddWithValue("@id_rel", id_instruccion)
            '        cmd.CommandType = CommandType.Text
            '        cmd.CommandText = "Delete From Hr.Relaciones_pto_carac where id_relacion = @id_rel"
            '        Dim r = cmd.ExecuteNonQuery()
            '        For Each ro As DataRow In ds.Tables("Heredar").Rows
            '            exec_instruccion(ro.ItemArray(0))
            '        Next
            '        cmd.CommandText = "Delete * from HR.Relaciones_repetidas where id_relacion_principal = @id_rel "
            '        r = cmd.ExecuteNonQuery()
            '    End If
            'Else
            '    If ds.Tables("A quien pasaba").Rows.Count > 0 Then
            '        'Caso 4

            '    Else
            '        'Caso 5
            '        cmd.CommandType = CommandType.Text
            '        cmd.Parameters.Clear()
            '        cmd.Parameters.AddWithValue("@id_rel", id_instruccion)
            '        cmd.CommandText = "Delete * from HR.Relaciones_pto_carac where id_relacion = @id_rel"
            '        Dim r = cmd.ExecuteNonQuery
            '    End If
            'End If
            Return True

        Catch ex As Exception
            Return False
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function exec_instruccion(ByVal id_instruccion As Integer) As Integer
        Try

#Region "Configuracion inicial"
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.AddWithValue("@Id", id_instruccion)

#Region "Eliminar tablas"
            If ds.Tables("relac") IsNot Nothing Then
                ds.Tables.Remove("relac")
            End If
            If ds.Tables("Her") IsNot Nothing Then
                ds.Tables.Remove("Her")
            End If
            If ds.Tables("HerEsc") IsNot Nothing Then
                ds.Tables.Remove("HerEsc")
            End If
            If ds.Tables("Repetidas") IsNot Nothing Then
                ds.Tables.Remove("Repetidas")
            End If
            If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                ds.Tables.Remove("Relaciones_repetidas")
            End If
            If ds.Tables("Otras_carac") IsNot Nothing Then
                ds.Tables.Remove("Otras_carac")
            End If

#End Region
#Region "Cargar tablas"
            da.SelectCommand.CommandText = "Select * from HR.Instruccion_relacion where id = @Id"

            da.Fill(ds, "relac")

            da.SelectCommand.CommandText = "Select * from HR.Relaciones_repetidas where Id_relacion_principal = @Id"
            da.Fill(ds, "Her")

            da.SelectCommand.CommandText = "Select * from Hr.Relaciones_repetidas where Id_relacion_repetido = @Id"
            da.Fill(ds, "HerEsc")

            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
            da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
            da.Fill(ds, "Relaciones_repetidas")

            da.SelectCommand.CommandText = "Select Competencia, Nivel from Hr.Caracteristicas where id = @Id"
            da.Fill(ds, "Otras_carac")

            da.SelectCommand.CommandText = "Select Competencia, Habilidad, Conocimiento,Curso from Hr.Caracteristicas where id = @Id"
            da.Fill(ds, "Tipo")
#End Region


            'SI HAY DATOS COMENZAMOS A TRABAJAR
            If ds.Tables("relac").Rows.Count > 0 Then

                Dim id_caracteristica = ds.Tables("relac").Rows(0).Item("Id_caracteristica")
                Dim Es_competencia As Boolean = ds.Tables("Otras_carac").Rows(0).Item("Competencia")
                Dim nivel_compt As Integer
                If Es_competencia Then
                    If ds.Tables("Otras_carac").Rows(0).Item("Nivel").ToString <> "" Then
                        nivel_compt = ds.Tables("Otras_carac").Rows(0).Item("Nivel")
                    Else
                        nivel_compt = 0
                    End If
                Else
                    nivel_compt = 0
                End If
                Dim solicitado_por = ds.Tables("relac").Rows(0).Item("Solicitado_por")
                Dim id_nivel = ds.Tables("relac").Rows(0).Item("Id_nivel")
                Dim Hereda = ds.Tables("relac").Rows(0).Item("Hereda")
                Dim Escalona = ds.Tables("relac").Rows(0).Item("Escalona")
                Dim Puesto_inicial = ""
                Puesto_inicial = ds.Tables("relac").Rows(0).Item("PU_INICIA").ToString
                Dim Puesto_final = ""
                Puesto_final = ds.Tables("relac").Rows(0).Item("PU_FINAL").ToString
                Dim cb_codigo = ds.Tables("relac").Rows(0).Item("CB_CODIGO")
                Dim id_ponderacion = ds.Tables("relac").Rows(0).Item("Id_ponderacion")

                If id_nivel.ToString = "" Then id_nivel = 0
                If cb_codigo.ToString = "" Then cb_codigo = 0
                If Puesto_inicial.ToString = "" Then Puesto_inicial = ""
                If Puesto_final.ToString = "" Then Puesto_final = ""

#End Region
#Region "Cargar puestos, relaciones y calificaciones"
                Dim tab As DataTable = Puestos_a_relacionar(ds.Tables("relac").Rows(0).Item("Por_nivel"), ds.Tables("relac").Rows(0).Item("Por_puesto"), ds.Tables("relac").Rows(0).Item("Por_empleado"),
                                       id_nivel, Hereda, Escalona, Puesto_inicial, Puesto_final, cb_codigo).Copy
                tab.TableName = "Puestos"
                If ds.Tables("Puestos") IsNot Nothing Then
                    ds.Tables.Remove("Puestos")
                End If
                ds.Tables.Add(tab)
                Dim Lista_niveles_requeridos
                Dim ri As String = ""
                If ds.Tables("Tipo").Rows(0).Item("Habilidad") Then ri = "Habilidad"
                If ds.Tables("Tipo").Rows(0).Item("Conocimiento") Then ri = "Conocimiento"
                If ds.Tables("Tipo").Rows(0).Item("Curso") Then ri = "Curso"

                If ds.Tables("relac").Rows(0).Item("Por_empleado") = True Then
                    Lista_niveles_requeridos = New List(Of empleados)
                    Lista_niveles_requeridos = calificar_por_empleado(id_caracteristica, Es_competencia, nivel_compt, id_ponderacion, "Relaciones", ri)
                Else
                    Lista_niveles_requeridos = New List(Of requerido)


                    Lista_niveles_requeridos = calificar(id_caracteristica, Es_competencia, nivel_compt, id_ponderacion, "Relaciones", ri)
                End If


#End Region

#Region "Ejecutar relaciones"

                If CnMPS.State = ConnectionState.Closed Then
                    CnMPS.ConnectionString = constringMPS()
                    CnMPS.Open()
                End If
                For Each ro As DataRow In ds.Tables("Puestos").Rows
                    If ds.Tables("relac").Rows(0).Item("Por_empleado") = False Then
#Region "Por puestos"
                        'PREGUNTAR SI YA EXISTE UNA RELACION PARA CADA PUESTO ************************************************************
                        Dim bu = ds.Tables("Relaciones").Select("PU_CODIGO = '" & ro.ItemArray(1).ToString & "'")
                        If bu.Length > 0 Then

                            'La caracteristica ya esta relacionada con ese puesto
                            If id_instruccion <> bu(0).ItemArray(5) Then 'SABER SI ES LA MISMA RELACION ****************************************

                                'ES UNA RELACION DIFERENTE LA QUE EXISTE
                                If id_instruccion > bu(0).ItemArray(5) Then
                                    'SI LA RELACION ES MAS RECIENTE
                                    Dim r As Integer = 0
                                    If ds.Tables("Relaciones_repetidas").Select("Id_relacion_principal = " & id_instruccion & " and Id_relacion_repetido = " & bu(0).ItemArray(5)).Count > 0 Then
                                        'Actualizar registro
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                                        cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                        cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                        Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido
                                        cmd.Parameters.AddWithValue("@REQ", cal)
                                        cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where Id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
                                        cmd.ExecuteNonQuery()

                                    Else
                                        'crear relacion y actualizar registro
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                                        cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                        cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                        Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido
                                        cmd.Parameters.AddWithValue("@REQ", cal)
                                        cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where Id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
                                        cmd.ExecuteNonQuery()
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@IDold", bu(0).ItemArray(5))
                                        cmd.Parameters.AddWithValue("@IDnew", id_instruccion)
                                        cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido) VALUES(@IDnew,@IDold)"
                                        cmd.ExecuteNonQuery()
                                        If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                            ds.Tables.Remove("Relaciones_repetidas")
                                        End If
                                        da.SelectCommand.Parameters.Clear()
                                        da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
                                        da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                        da.Fill(ds, "Relaciones_repetidas")

                                    End If
                                    If r = 0 Then

                                    End If
                                Else
                                    'SI LA RELACION ES ANTIGUA
                                    'BUSCAR ENTRE LAS RELACIONES DE LA ID_INSTRUCCION SI YA EXISTE CONEXION CON LA ACTUAL 
                                    Dim bus = relup(id_instruccion, bu(0).ItemArray(5))
                                    If bus.res = True Then
                                        'SI EXISTE CONEXION
                                        Console.WriteLine()
                                    Else
                                        'SI NO EXISTE RELACION
                                        cmd.Parameters.Clear()
                                        cmd.Connection = CnMPS
                                        cmd.CommandType = CommandType.Text
                                        If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                                        cmd.Parameters.AddWithValue("@Id_rel_pri", bu(0).ItemArray(5))
                                        cmd.Parameters.AddWithValue("@Id_rel_rep", id_instruccion)
                                        cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
                                        cmd.ExecuteNonQuery()
#Region "Recargar tabla de relaciones"
                                        If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                            ds.Tables.Remove("Relaciones_repetidas")
                                        End If
                                        da.SelectCommand.Parameters.Clear()
                                        da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
                                        da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                        da.Fill(ds, "Relaciones_repetidas")

#End Region
                                    End If
                                End If
                            Else
                                'NO ES NECESARIO REALIZAR UNA RELACION****************************************
                            End If

                        Else
                            'REALIZAR RELACION NUEVA *********************************************************

                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                            cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)

                            Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido

                            cmd.Parameters.AddWithValue("@Nivreq", cal)
                            cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                            cmd.CommandType = CommandType.Text
                            cmd.Connection = CnMPS
                            cmd.CommandText = "Insert Into HR.Relaciones_pto_carac (Id_categoria,PU_CODIGO,Nivel_requerido,Id_relacion) VALUES ( @IDCA,@PU_CODIGO,@Nivreq,@IDREL)"
                            cmd.ExecuteNonQuery()
                        End If
#End Region
                    Else
#Region "Por empleado"
                        Dim bu = ds.Tables("Relaciones").Select("CB_CODIGO = '" & ro.ItemArray(0).ToString & "'")
                        If bu.Length > 0 Then
                            If id_instruccion <> bu(0).ItemArray(5) Then
                                'ES UNA RELACION DIFERENTE LA QUE EXISTE
                                If id_instruccion > bu(0).ItemArray(5) Then
                                    'SI LA RELACION ES MAS RECIENTE
                                    Dim r As Integer = 0
                                    If ds.Tables("Relaciones_repetidas").Select("Id_relacion_principal = " & id_instruccion & " and Id_relacion_repetido = " & bu(0).ItemArray(5)).Count > 0 Then
                                        'Actualizar registro
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                                        cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                        cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                        Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                                        cmd.Parameters.AddWithValue("@REQ", cal)
                                        cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where Id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
                                        cmd.ExecuteNonQuery()

                                    Else
                                        'crear relacion y actualizar registro
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                                        cmd.Parameters.AddWithValue("@CB_CODIGO", ro.ItemArray(0))
                                        cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                        Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                                        cmd.Parameters.AddWithValue("@REQ", cal)
                                        cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where Id_categoria = @IDCA and CB_CODIGO = @CB_CODIGO"
                                        cmd.ExecuteNonQuery()
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@IDold", bu(0).ItemArray(5))
                                        cmd.Parameters.AddWithValue("@IDnew", id_instruccion)
                                        cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido) VALUES(@IDnew,@IDold)"
                                        cmd.ExecuteNonQuery()
                                        If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                            ds.Tables.Remove("Relaciones_repetidas")
                                        End If
                                        da.SelectCommand.Parameters.Clear()
                                        da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
                                        da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                        da.Fill(ds, "Relaciones_repetidas")

                                    End If
                                    If r = 0 Then

                                    End If
                                Else
                                    'SI LA RELACION ES ANTIGUA
                                    'BUSCAR ENTRE LAS RELACIONES DE LA ID_INSTRUCCION SI YA EXISTE CONEXION CON LA ACTUAL 
                                    Dim bus = relup(id_instruccion, bu(0).ItemArray(5))
                                    If bus.res = True Then
                                        'SI EXISTE CONEXION
                                        Console.WriteLine()
                                    Else
                                        'SI NO EXISTE RELACION
                                        cmd.Parameters.Clear()
                                        cmd.Connection = CnMPS
                                        cmd.CommandType = CommandType.Text
                                        If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                                        cmd.Parameters.AddWithValue("@Id_rel_pri", bu(0).ItemArray(5))
                                        cmd.Parameters.AddWithValue("@Id_rel_rep", id_instruccion)
                                        cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
                                        cmd.ExecuteNonQuery()
#Region "Recargar tabla de relaciones"
                                        If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                            ds.Tables.Remove("Relaciones_repetidas")
                                        End If
                                        da.SelectCommand.Parameters.Clear()
                                        da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
                                        da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                        da.Fill(ds, "Relaciones_repetidas")

#End Region
                                    End If
                                End If
                            End If
                        Else

                            cmd.CommandType = CommandType.Text
                            cmd.Connection = CnMPS
                            cmd.Parameters.Clear()
                            cmd.CommandText = "Insert into HR.Relaciones_pto_carac (Id_categoria,PU_CODIGO,CB_CODIGO,Nivel_requerido,Id_relacion)Values(@IDCA,NULL,@CB_CODIGO,@NR,@IDREL)"
                            cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
                            cmd.Parameters.AddWithValue("@CB_CODIGO", ro.ItemArray(0))
                            Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                            cmd.Parameters.AddWithValue("@NR", cal) 'FALTA PREGRUNTAR POR EL NIVEL REQUERIDO
                            cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                            cmd.ExecuteNonQuery()


                        End If
#End Region
                    End If
                Next
#End Region
            End If

            Return 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function exec_instruccion_multiple(ByVal Id_caracteristica As Integer, ByVal Instrucciones As List(Of Integer), ByVal Puestoss As List(Of Puesto_descripcion), ByVal Empleadoss As List(Of empleados), ByVal ESPuesto As Boolean, ByVal Id_ponderacion As Integer)
        Try
#Region "Configuracion inicial"
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            Dim Filtro As String = "(0,"
            For Each i As Integer In Instrucciones
                Filtro = Filtro & " " & i & ","
            Next
            Filtro = Filtro & " -1)"
            '  da.SelectCommand.Parameters.AddWithValue("@Id", Filtro)

#Region "Eliminar tablas"
            If ds.Tables("relac") IsNot Nothing Then
                ds.Tables.Remove("relac")
            End If
            If ds.Tables("Her") IsNot Nothing Then
                ds.Tables.Remove("Her")
            End If
            If ds.Tables("HerEsc") IsNot Nothing Then
                ds.Tables.Remove("HerEsc")
            End If
            If ds.Tables("Repetidas") IsNot Nothing Then
                ds.Tables.Remove("Repetidas")
            End If
            If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                ds.Tables.Remove("Relaciones_repetidas")
            End If
            If ds.Tables("Otras_carac") IsNot Nothing Then
                ds.Tables.Remove("Otras_carac")
            End If

#End Region
#Region "Cargar tablas"
            da.SelectCommand.CommandText = "Select * from HR.Instruccion_relacion where id in " & Filtro

            da.Fill(ds, "relac")

            da.SelectCommand.CommandText = "Select * from HR.Relaciones_repetidas where Id_relacion_principal in " & Filtro
            da.Fill(ds, "Her")

            da.SelectCommand.CommandText = "Select * from Hr.Relaciones_repetidas where Id_relacion_repetido in " & Filtro
            da.Fill(ds, "HerEsc")

            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
            da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica in " & Filtro & " ) Or 
            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica in " & Filtro & ")"
            da.Fill(ds, "Relaciones_repetidas")

            da.SelectCommand.CommandText = "Select Competencia, Nivel from Hr.Caracteristicas where id = @Id"
            da.Fill(ds, "Otras_carac")
            da.SelectCommand.CommandText = "Select Competencia, Habilidad, Conocimiento,Curso from Hr.Caracteristicas where id = @Id"
            da.Fill(ds, "Tipo")
#End Region


            'SI HAY DATOS COMENZAMOS A TRABAJAR
            If ds.Tables("relac").Rows.Count > 0 Then
                Dim Es_competencia As Boolean = ds.Tables("Otras_carac").Rows(0).Item("Competencia")
                Dim nivel_compt As Integer
                If Es_competencia Then
                    If ds.Tables("Otras_carac").Rows(0).Item("Nivel").ToString <> "" Then
                        nivel_compt = ds.Tables("Otras_carac").Rows(0).Item("Nivel")
                    Else
                        nivel_compt = 0
                    End If
                Else
                    nivel_compt = 0
                End If
#End Region

#Region "Cargar puestos, relaciones y calificaciones"
                Dim tab As New DataTable

                If ESPuesto Then

                    tab.Columns.Add("Id")
                    tab.Columns.Add("PU_CODIGO")
                    tab.Columns.Add("PU_DESCRIP")
                    tab.Columns.Add("PU_PARENT")
                    tab.Columns.Add("Id_Nivel")
                    tab.Columns.Add("PU_ACTIVO")
                    For Each pu As Puesto_descripcion In Puestoss
                        Dim tab2 As DataTable = Puestos_a_relacionar(0, 1, 0, Nothing, 0, 0, pu.pu_codigo, Nothing, 0).Copy
                        tab.ImportRow(tab2.Rows(0))
                        Console.WriteLine("")
                    Next
                Else
                    tab.Columns.Add("Numero de empleado")
                    tab.Columns.Add("Nombre")
                    tab.Columns.Add("Departamento")
                    tab.Columns.Add("Puesto")
                    tab.Columns.Add("Id_Nivel")
                    For Each co As empleados In Empleadoss
                        Dim tab2 As DataTable = Puestos_a_relacionar(0, 0, 1, Nothing, 0, 0, Nothing, Nothing, co.cb_codigo)
                        tab.ImportRow(tab2.Rows(0))
                    Next


                End If




                tab.TableName = "Puestos"
                If ds.Tables("Puestos") IsNot Nothing Then
                    ds.Tables.Remove("Puestos")
                End If
                ds.Tables.Add(tab)
                Dim LIsta_niveles_requeridos
                Dim ri As String = ""
                If ds.Tables("Tipo").Rows(0).Item("Habilidad") Then ri = "Habilidad"
                If ds.Tables("Tipo").Rows(0).Item("Conocimiento") Then ri = "Conocimiento"
                If ds.Tables("Tipo").Rows(0).Item("Curso") Then ri = "Curso"
                If ESPuesto Then
                    LIsta_niveles_requeridos = New List(Of requerido)
                    LIsta_niveles_requeridos = calificar(Id_caracteristica, Es_competencia, nivel_compt, Id_ponderacion, "Relaciones", ri)
                Else
                    LIsta_niveles_requeridos = New List(Of empleados)
                    LIsta_niveles_requeridos = calificar_por_empleado(Id_caracteristica, Es_competencia, nivel_compt, Id_ponderacion, "Relaciones", ri, True)
                End If



#End Region

#Region "Ejecutar relaciones"

                If CnMPS.State = ConnectionState.Closed Then
                    CnMPS.ConnectionString = constringMPS()
                    CnMPS.Open()
                End If
                Dim id_instruccion As Integer = 0

                If ESPuesto Then
                    If ds.Tables("Puestos") IsNot Nothing Then
                        For Each ro As DataRow In ds.Tables("Puestos").Rows
                            If ds.Tables("relac").Select("PU_INICIA = '" & ro.ItemArray(1).ToString & "'").Length > 0 Then
                                id_instruccion = ds.Tables("relac").Select("PU_INICIA = '" & ro.ItemArray(1).ToString & "'")(0).ItemArray(0)
                                Dim bu = ds.Tables("Relaciones").Select("PU_CODIGO = '" & ro.ItemArray(1).ToString & "'")
                                If bu.Length > 0 Then
                                    If id_instruccion <> bu(0).ItemArray(5) Then

                                        If id_instruccion > bu(0).ItemArray(5) Then
                                            Dim r As Integer = 0
                                            If ds.Tables("Relaciones_repetidas").Select("Id_relacion_principal = " & id_instruccion & " and Id_relacion_repetido = " & bu(0).ItemArray(5)).Count > 0 Then
                                                'Actualizar registro
                                                cmd.Parameters.Clear()
                                                cmd.Parameters.AddWithValue("@IDCA", Id_caracteristica)
                                                cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                                cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                                Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido
                                                cmd.Parameters.AddWithValue("@REQ", cal)
                                                cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where Id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
                                                cmd.ExecuteNonQuery()

                                            Else
                                                'crear relacion y actualizar registro
                                                cmd.Parameters.Clear()
                                                cmd.Parameters.AddWithValue("@IDCA", Id_caracteristica)
                                                cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                                cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                                Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido
                                                cmd.Parameters.AddWithValue("@REQ", cal)
                                                cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where Id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
                                                cmd.ExecuteNonQuery()
                                                cmd.Parameters.Clear()
                                                cmd.Parameters.AddWithValue("@IDold", bu(0).ItemArray(5))
                                                cmd.Parameters.AddWithValue("@IDnew", id_instruccion)
                                                cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido) VALUES(@IDnew,@IDold)"
                                                cmd.ExecuteNonQuery()
                                                If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                                    ds.Tables.Remove("Relaciones_repetidas")
                                                End If
                                                da.SelectCommand.Parameters.Clear()
                                                da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
                                                da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                                da.Fill(ds, "Relaciones_repetidas")
                                            End If
                                        Else
                                            'SI LA RELACION ES ANTIGUA
                                            'BUSCAR ENTRE LAS RELACIONES DE LA ID_INSTRUCCION SI YA EXISTE CONEXION CON LA ACTUAL 
                                            Dim bus = relup(id_instruccion, bu(0).ItemArray(5))
                                            If bus.res = True Then
                                                'SI EXISTE CONEXION
                                                Console.WriteLine()
                                            Else
                                                'SI NO EXISTE RELACION
                                                cmd.Parameters.Clear()
                                                cmd.Connection = CnMPS
                                                cmd.CommandType = CommandType.Text
                                                If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                                                cmd.Parameters.AddWithValue("@Id_rel_pri", bu(0).ItemArray(5))
                                                cmd.Parameters.AddWithValue("@Id_rel_rep", id_instruccion)
                                                cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
                                                cmd.ExecuteNonQuery()
#Region "Recargar tabla de relaciones"
                                                If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                                    ds.Tables.Remove("Relaciones_repetidas")
                                                End If
                                                da.SelectCommand.Parameters.Clear()
                                                da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
                                                da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                                da.Fill(ds, "Relaciones_repetidas")

#End Region
                                            End If



                                        End If
                                    End If
                                Else

                                    cmd.Parameters.Clear()
                                    cmd.Parameters.AddWithValue("@IDCA", Id_caracteristica)
                                    cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)

                                    Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido

                                    cmd.Parameters.AddWithValue("@Nivreq", cal)
                                    cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                    cmd.CommandType = CommandType.Text
                                    cmd.Connection = CnMPS
                                    cmd.CommandText = "Insert Into HR.Relaciones_pto_carac (Id_categoria,PU_CODIGO,Nivel_requerido,Id_relacion) VALUES ( @IDCA,@PU_CODIGO,@Nivreq,@IDREL)"
                                    cmd.ExecuteNonQuery()
                                End If
                            End If
                        Next
                    End If
                Else

                    ' Por empleado
                    If ds.Tables("Puestos") IsNot Nothing Then
                        For Each ro As DataRow In ds.Tables("Puestos").Rows
                            id_instruccion = ds.Tables("relac").Select("CB_CODIGO = " & ro.ItemArray(0))(0).ItemArray(0)
                            Dim bu = ds.Tables("Relaciones").Select("CB_CODIGO = '" & ro.ItemArray(0).ToString & "'")
                            If bu.Length > 0 Then
                                If id_instruccion <> bu(0).ItemArray(5) Then
                                    'ES UNA RELACION DIFERENTE LA QUE EXISTE
                                    If id_instruccion > bu(0).ItemArray(5) Then
                                        'SI LA RELACION ES MAS RECIENTE
                                        Dim r As Integer = 0
                                        If ds.Tables("Relaciones_repetidas").Select("Id_relacion_principal = " & id_instruccion & " and Id_relacion_repetido = " & bu(0).ItemArray(5)).Count > 0 Then
                                            'Actualizar registro
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.AddWithValue("@IDCA", Id_caracteristica)
                                            cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                            cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                            Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                                            cmd.Parameters.AddWithValue("@REQ", cal)
                                            cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where Id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
                                            cmd.ExecuteNonQuery()

                                        Else
                                            'crear relacion y actualizar registro
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.AddWithValue("@IDCA", Id_caracteristica)
                                            cmd.Parameters.AddWithValue("@CB_CODIGO", ro.ItemArray(0))
                                            cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                            Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                                            cmd.Parameters.AddWithValue("@REQ", cal)
                                            cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where Id_categoria = @IDCA and CB_CODIGO = @CB_CODIGO"
                                            cmd.ExecuteNonQuery()
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.AddWithValue("@IDold", bu(0).ItemArray(5))
                                            cmd.Parameters.AddWithValue("@IDnew", id_instruccion)
                                            cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido) VALUES(@IDnew,@IDold)"
                                            cmd.ExecuteNonQuery()
                                            If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                                ds.Tables.Remove("Relaciones_repetidas")
                                            End If
                                            da.SelectCommand.Parameters.Clear()
                                            da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
                                            da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                            da.Fill(ds, "Relaciones_repetidas")

                                        End If
                                        If r = 0 Then

                                        End If
                                    Else
                                        'SI LA RELACION ES ANTIGUA
                                        'BUSCAR ENTRE LAS RELACIONES DE LA ID_INSTRUCCION SI YA EXISTE CONEXION CON LA ACTUAL 
                                        Dim bus = relup(id_instruccion, bu(0).ItemArray(5))
                                        If bus.res = True Then
                                            'SI EXISTE CONEXION
                                            Console.WriteLine()
                                        Else
                                            'SI NO EXISTE RELACION
                                            cmd.Parameters.Clear()
                                            cmd.Connection = CnMPS
                                            cmd.CommandType = CommandType.Text
                                            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                                            cmd.Parameters.AddWithValue("@Id_rel_pri", bu(0).ItemArray(5))
                                            cmd.Parameters.AddWithValue("@Id_rel_rep", id_instruccion)
                                            cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
                                            cmd.ExecuteNonQuery()
#Region "Recargar tabla de relaciones"
                                            If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                                ds.Tables.Remove("Relaciones_repetidas")
                                            End If
                                            da.SelectCommand.Parameters.Clear()
                                            da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
                                            da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                            da.Fill(ds, "Relaciones_repetidas")

#End Region
                                        End If
                                    End If
                                End If
                            Else

                                cmd.CommandType = CommandType.Text
                                cmd.Connection = CnMPS
                                cmd.Parameters.Clear()
                                cmd.CommandText = "Insert into HR.Relaciones_pto_carac (Id_categoria,PU_CODIGO,CB_CODIGO,Nivel_requerido,Id_relacion)Values(@IDCA,NULL,@CB_CODIGO,@NR,@IDREL)"
                                cmd.Parameters.AddWithValue("@IDCA", Id_caracteristica)
                                cmd.Parameters.AddWithValue("@CB_CODIGO", ro.ItemArray(0))
                                Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                                cmd.Parameters.AddWithValue("@NR", cal) 'FALTA PREGRUNTAR POR EL NIVEL REQUERIDO
                                cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                cmd.ExecuteNonQuery()


                            End If


                        Next
                    End If


#End Region
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

        End Try
    End Function

#End Region




    ''' <summary>
    ''' Puestos a relacionar
    ''' </summary>
    ''' <param name="id_caracteristica">Id de la caracteristica a relacionar</param>
    ''' <param name="Por_nivel">Tipo de realcion por nivel</param>
    ''' <param name="Por_puesto">Tipo de realcion por nivel</param>
    ''' <param name="Por_empleado">Tipo de realcion por nivel</param>
    ''' <param name="Id_nivel">Nivel inicial de relacion</param>
    ''' <remarks>Guarda la tabla en el dataset de los puestos que se relacionaran asi como las relaciones existentes</remarks>
    Shared Function Puestos_a_relacionar(ByVal Por_nivel As Boolean, ByVal Por_puesto As Boolean, ByVal Por_empleado As Boolean,
                                         ByVal Id_nivel As Integer, ByVal Heredado As Boolean, ByVal Escalonado As Boolean, ByVal Puesto_inicial As String, ByVal Puesto_final As String, ByVal cb_codigo As Integer) As DataTable
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Connection = CnMPS


            If Por_nivel Then

                da.SelectCommand.CommandType = CommandType.Text
                da.SelectCommand.Parameters.AddWithValue("@nivel", Id_nivel)
                da.SelectCommand.CommandText = "Select * from HR.Puesto where Id_nivel >= @nivel and PU_ACTIVO = 'S'"
                If ds.Tables("Puestos") IsNot Nothing Then
                    ds.Tables.Remove("Puestos")
                End If
                da.Fill(ds, "Puestos")
                Return ds.Tables("Puestos")


            ElseIf Por_puesto Then

                If Heredado Then
                    da.SelectCommand.CommandType = CommandType.Text
                    da.SelectCommand.CommandText = "Select * from Hr.Puesto"
                    If ds.Tables("Puesto") IsNot Nothing Then
                        ds.Tables.Remove("Puesto")
                    End If
                    da.Fill(ds, "Puesto")
                    Dim tabla As New DataTable
                    tabla = cargar_tabla_heredado(Puesto_inicial).Copy
                    Return tabla

                ElseIf Escalonado Then

                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                    da.SelectCommand.CommandText = "HR.Puestos_padre"
                    da.SelectCommand.Parameters.AddWithValue("@PU_INICIAL", Puesto_inicial)
                    da.SelectCommand.Parameters.AddWithValue("@TOPA", True)
                    da.SelectCommand.Parameters.AddWithValue("@PU_FIN", Puesto_final)
                    da.SelectCommand.Parameters.AddWithValue("@Todo", True)
                    If ds.Tables("Puestos") IsNot Nothing Then
                        ds.Tables.Remove("Puestos")
                    End If
                    da.Fill(ds, "Puestos")
                    Return ds.Tables("Puestos")

                Else

                    da.SelectCommand.CommandType = CommandType.Text
                    da.SelectCommand.CommandText = "Select * from Hr.Puesto where PU_CODIGO = '" & Puesto_inicial & "'"
                    If ds.Tables("Puestos") IsNot Nothing Then
                        ds.Tables.Remove("Puestos")
                    End If
                    da.Fill(ds, "Puestos")
                    Return ds.Tables("Puestos")

                End If


            ElseIf Por_empleado Then
                da.SelectCommand.CommandType = CommandType.Text
                da.SelectCommand.Parameters.AddWithValue("@cb_codigo", cb_codigo)
                da.SelectCommand.CommandText = "  select cb_codigo as 'Numero de empleado',PRETTYNAME as 'Nombre',n1.TB_ELEMENT as 'Departamento',pu.PU_DESCRIP as 'Puesto' ,pu.Id_Nivel from tress.dbo.COLABORA co
  inner join tress.dbo.NIVEL1 n1 on co.CB_NIVEL1 = n1.tb_codigo
  inner join HR.PUESTO pu on co.CB_PUESTO = pu.PU_CODIGO
	where CB_CODIGO = @cb_codigo "
                If ds.Tables("Puestos") IsNot Nothing Then
                    ds.Tables.Remove("Puestos")
                End If
                da.Fill(ds, "Puestos")
                Return ds.Tables("Puestos")
            End If

        Catch ex As Exception
            Throw New Exception()
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    ''' <summary>
    ''' Relaciones existentes
    ''' </summary>
    ''' <param name="id_caracteristica">Id de la caracteristica a relacionar</param>
    ''' <param name="Nombre_tabla">Nombre de la tabla con el cual se guardara en el dataset</param>
    ''' <remarks>Guarda la tabla en el dataset de las relaciones existentes</remarks>
    Shared Function Relaciones_repetidas(ByVal id_caracteristica As Integer, ByVal Nombre_tabla As String)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@IDCA", id_caracteristica)
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select * from HR.Relaciones_pto_carac where id_categoria = @IDCA"
            da.SelectCommand.Connection = CnMPS
            If ds.Tables(Nombre_tabla) IsNot Nothing Then
                ds.Tables.Remove(Nombre_tabla)
            End If
            da.Fill(ds, Nombre_tabla)

            CnMPS.Close()
        Catch ex As Exception
            Throw New Exception
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    ''' <summary>
    ''' Relaciones existentes
    ''' </summary>
    ''' <param name="id_caracteristica">Id de la caracteristica a relacionar</param>
    ''' <param name="Nombre_tabla">Nombre de la tabla con el cual se guardara en el dataset</param>
    ''' <remarks>Guarda la tabla en el dataset de las relaciones existentes</remarks>
    Shared Function Relaciones_repetidas_curso(ByVal CU_CODIGO As String, ByVal Nombre_tabla As String)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@CUR", CU_CODIGO)
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select * from HR.Relaciones_pto_carac where CU_CODIGO = @CUR"
            da.SelectCommand.Connection = CnMPS
            If ds.Tables(Nombre_tabla) IsNot Nothing Then
                ds.Tables.Remove(Nombre_tabla)
            End If
            da.Fill(ds, Nombre_tabla)

            CnMPS.Close()
        Catch ex As Exception
            Throw New Exception
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function


    Shared Function cargar_tabla_heredado(ByVal Puesto As String) As DataTable
        Try
            Dim tabla As New DataTable
            tabla.Columns.Add("Id")
            tabla.Columns.Add("PU_CODIGO")
            tabla.Columns.Add("PU_DESCRIP")
            tabla.Columns.Add("PU_PARENT")
            tabla.Columns.Add("Id_Nivel")
            tabla.Columns.Add("PU_ACTIVO")
            Dim parent = ds.Tables("Puesto").Select("PU_CODIGO = '" & Puesto & "'").CopyToDataTable
            tabla.ImportRow(parent(0))
            Dim ree = ds.Tables("Puesto").Select("PU_PARENT = '" & Puesto & "'")
            If ree.Count > 0 Then
                Dim r = ds.Tables("Puesto").Select("PU_PARENT = '" & Puesto & "'").CopyToDataTable
                If r.Rows.Count > 0 Then
                    For Each ew As DataRow In r.Rows
                        Dim re = ds.Tables("Puesto").Select("PU_PARENT = '" & ew.ItemArray(1) & "'")
                        If re.Count > 0 Then
                            Dim we As DataTable = cargar_tabla_heredado(ew.ItemArray(1))
                            For Each wewe As DataRow In we.Rows
                                tabla.ImportRow(wewe)
                            Next
                        Else
                            tabla.ImportRow(ew)
                        End If
                    Next
                End If

            End If


            Return tabla
        Catch ex As Exception
            Throw New Exception
        End Try
    End Function
    Shared Function calificar(ByVal id_caracteristica As Integer, ByVal Competencia As Boolean, ByVal nivel_competencias As Integer, ByVal id_ponderacion As Integer, ByVal Nombre_tabla_relacionesExistentes As String, ByVal tipo As String, ByVal Optional Por_puesto As Boolean = True) As List(Of requerido)
        Try
            Dim a As New Nivel_requerido
            a.d = ds.Tables("Puestos").Copy
            a.nombre = Nombre(id_caracteristica)
            Relaciones_repetidas(id_caracteristica, Nombre_tabla_relacionesExistentes)
            a.califs = ds.Tables(Nombre_tabla_relacionesExistentes).Copy
            a.Sin_nombre_empleado = True
            a.Es_competencia = Competencia
            If Competencia Then
                a.calificar_maximo = My.Settings.Com_nivreq
            ElseIf tipo = "Habilidad" Then
                a.calificar_maximo = My.Settings.Hab_nivreq
            ElseIf tipo = "Conocimiento" Then
                a.calificar_maximo = My.Settings.Con_nivreq
            ElseIf tipo = "Curso" Then
                a.calificar_maximo = My.Settings.Cur_nivreq
            End If
            a.Nivel_competencia = nivel_competencias
            a.Id_ponderacion = id_ponderacion
            a.ShowDialog()


            Dim r As List(Of requerido)
            r = a.qw
            Return r
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Shared Function calificar_por_empleado(ByVal id_caracteristica As Integer, ByVal Competencia As Boolean, ByVal nivel_competencias As Integer, ByVal id_ponderacion As Integer, ByVal Nombre_tabla_relacionesExistentes As String, ByVal tipo As String, ByVal Optional Por_puesto As Boolean = True) As List(Of empleados)
        Try
            Dim a As New Nivel_requerido
            a.d = ds.Tables("Puestos").Copy
            a.nombre = Nombre(id_caracteristica)
            Relaciones_repetidas(id_caracteristica, Nombre_tabla_relacionesExistentes)
            a.califs = ds.Tables(Nombre_tabla_relacionesExistentes).Copy
            a.Sin_nombre_empleado = False
            a.Es_competencia = Competencia
            If Competencia Then
                a.calificar_maximo = My.Settings.Com_nivreq
            ElseIf tipo = "Habilidad" Then
                a.calificar_maximo = My.Settings.Hab_nivreq
            ElseIf tipo = "Conocimiento" Then
                a.calificar_maximo = My.Settings.Con_nivreq
            ElseIf tipo = "Curso" Then
                a.calificar_maximo = My.Settings.Cur_nivreq
            End If
            a.Nivel_competencia = nivel_competencias
            a.Id_ponderacion = id_ponderacion
            a.ShowDialog()
            Dim r As List(Of empleados)
            r = a.qw_empleado
            Return r
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Shared Function modificar_calificaciones(ByVal id_caracateristica As Integer)
        Try
            Dim nueva_lista As New List(Of requerido)
            Dim nueva_lista_empleados As New List(Of empleados)
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@IDCA", id_caracateristica)
            da.SelectCommand.CommandText = "SELECT rel.*,ir.Id_ponderacion
  FROM [HR].[Relaciones_pto_carac] rel
  inner join hr.Instruccion_relacion ir on rel.Id_relacion = ir.Id
where rel.id_categoria = @IDCA"
            da.SelectCommand.CommandText = "SELECT rel.*,pu.PU_DESCRIP,pu.PU_PARENT,pu.Id_Nivel,pu.PU_ACTIVO,co.PRETTYNAME as 'Nombre', n1.TB_ELEMENT as 'Departamento',puu.PU_DESCRIP as 'Puesto',puu.Id_Nivel as 'Nivel', ir.Id_ponderacion
  FROM [HR].[Relaciones_pto_carac] rel
  inner join hr.Instruccion_relacion ir on rel.Id_relacion = ir.Id
  left join hr.Puesto pu on rel.PU_CODIGO = pu.PU_CODIGO
  left join tress.dbo.COLABORA co on rel.CB_CODIGO = co.CB_CODIGO
  left join hr.Puesto puu on co.CB_PUESTO = puu.PU_CODIGO
  left join tress.dbo.NIVEL1 n1 on co.CB_NIVEL1 = n1.TB_CODIGO
where rel.id_categoria = @IDCA"
            If ds.Tables("Calificaciones") IsNot Nothing Then
                ds.Tables.Remove("Calificaciones")
            End If
            da.Fill(ds, "Calificaciones")
            Console.WriteLine("")

            Dim tr As DataTable
            Dim id_ponderaciones As DataTable
            Dim tr_empleado As DataTable
            Dim id_ponderaciones_empleado As DataTable
            If ds.Tables("Calificaciones").Select("CB_CODIGO is null").Count > 0 Then
                tr = ds.Tables("Calificaciones").Select("CB_CODIGO is null").CopyToDataTable
                id_ponderaciones = tr.DefaultView.ToTable(True, "Id_ponderacion")
                tr = tr.DefaultView.ToTable(False, "Id", "PU_CODIGO", "PU_DESCRIP", "Id_ponderacion", "Id_Nivel")
            End If
            If ds.Tables("Calificaciones").Select("PU_CODIGO IS Null").Count > 0 Then
                tr_empleado = ds.Tables("Calificaciones").Select("PU_CODIGO IS Null").CopyToDataTable
                id_ponderaciones_empleado = tr_empleado.DefaultView.ToTable(True, "Id_ponderacion")
                tr_empleado = tr_empleado.DefaultView.ToTable(False, "CB_CODIGO", "Nombre", "Departamento", "Puesto", "Nivel", "Id_ponderacion")
            End If
            If id_ponderaciones IsNot Nothing Then
                For Each ro As DataRow In id_ponderaciones.Rows
                    If ds.Tables("Puestos") IsNot Nothing Then
                        ds.Tables.Remove("Puestos")
                    End If
                    Dim tabla_provicional As DataTable
                    tabla_provicional = tr.Select("Id_ponderacion = " & ro.ItemArray(0)).CopyToDataTable
                    tabla_provicional.TableName = "Puestos"
                    ds.Tables.Add(tabla_provicional)

                    Dim i As List(Of requerido) = calificar(id_caracateristica, False, 0, ro.ItemArray(0), "Calificaciones", "s")
                    For Each req As requerido In i
                        nueva_lista.Add(req)
                    Next
                Next

            End If
            If id_ponderaciones_empleado IsNot Nothing Then
                For Each ro As DataRow In id_ponderaciones_empleado.Rows
                    If ds.Tables("Puestos") IsNot Nothing Then
                        ds.Tables.Remove("Puestos")
                    End If
                    Dim tabla_provicional As DataTable
                    tabla_provicional = tr_empleado.Select("").CopyToDataTable.DefaultView.ToTable(False, "CB_CODIGO", "Nombre", "Departamento", "Puesto", "Nivel")
                    tabla_provicional.TableName = "Puestos"
                    ds.Tables.Add(tabla_provicional)

                    Dim i As List(Of empleados) = calificar_por_empleado(id_caracateristica, False, 0, ro.ItemArray(0), "Calificaciones", "Otro", False)
                    For Each emp As empleados In i
                        nueva_lista_empleados.Add(emp)
                    Next
                Next
            End If



            'AQUI SE VA HACER UPDATE EN LA TABLA DE RELACIONES PUESTO CARACTERISTICAS
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.Parameters.AddWithValue("@IDCA", id_caracateristica)
            cmd.Parameters.Add("@Cal", SqlDbType.Int)
            cmd.Parameters.Add("@PTO", SqlDbType.VarChar)
            cmd.CommandText = "Update Hr.Relaciones_pto_carac set Nivel_requerido =@Cal where Id_categoria = @idca and pu_codigo = @PTO"
            For Each emp As requerido In nueva_lista
                cmd.Parameters("@Cal").Value = emp.requerido
                cmd.Parameters("@PTO").Value = emp.pu_codigo
                cmd.ExecuteNonQuery()
            Next
            cmd.CommandText = "Update Hr.Relaciones_pto_carac set Nivel_requerido =@Cal where Id_categoria = @idca and CB_CODIGO = @PTO"
            For Each emp As empleados In nueva_lista_empleados
                cmd.Parameters("@Cal").Value = emp.calif
                cmd.Parameters("@PTO").Value = emp.cb_codigo
                cmd.ExecuteNonQuery()
            Next
            Return 1
        Catch ex As Exception
            Return 0
            Throw New Exception
        Finally
            If CnMPS.State = ConnectionState.Open Then
                CnMPS.Close()
            End If
        End Try
    End Function

    Shared Function modificar_calificaciones_curso(ByVal Codigo_curso As String)
        Try
            Dim nueva_lista As New List(Of requerido)
            Dim nueva_lista_empleados As New List(Of empleados)
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@CUR", Codigo_curso)
            da.SelectCommand.CommandText = "SELECT rel.*,pu.PU_DESCRIP,pu.PU_PARENT,pu.Id_Nivel,pu.PU_ACTIVO,co.PRETTYNAME as 'Nombre', n1.TB_ELEMENT as 'Departamento',puu.PU_DESCRIP as 'Puesto',puu.Id_Nivel as 'Nivel', ir.Id_ponderacion
  FROM [HR].[Relaciones_pto_carac] rel
  inner join hr.Instruccion_relacion ir on rel.Id_relacion = ir.Id
  left join hr.Puesto pu on rel.PU_CODIGO = pu.PU_CODIGO
  left join tress.dbo.COLABORA co on rel.CB_CODIGO = co.CB_CODIGO
  left join hr.Puesto puu on co.CB_PUESTO = puu.PU_CODIGO
  left join tress.dbo.NIVEL1 n1 on co.CB_NIVEL1 = n1.TB_CODIGO
where rel.CU_CODIGO  = @CUR"
            If ds.Tables("Calificaciones") IsNot Nothing Then
                ds.Tables.Remove("Calificaciones")
            End If
            da.Fill(ds, "Calificaciones")

            Dim tr As DataTable = ds.Tables("Calificaciones").Select("CB_CODIGO is null").CopyToDataTable
            Dim tr_empleado As DataTable = ds.Tables("Calificaciones").Select("PU_CODIGO IS Null").CopyToDataTable
            Dim id_ponderaciones = tr.DefaultView.ToTable(True, "Id_ponderacion")
            Dim id_ponderaciones_empleado = tr_empleado.DefaultView.ToTable(True, "Id_ponderacion")
            tr = tr.DefaultView.ToTable(False, "Id", "PU_CODIGO", "PU_DESCRIP", "Id_ponderacion", "Id_Nivel")
            tr_empleado = tr_empleado.DefaultView.ToTable(False, "CB_CODIGO", "Nombre", "Departamento", "Puesto", "Nivel", "Id_ponderacion")


            For Each ro As DataRow In id_ponderaciones.Rows
                If ds.Tables("Puestos") IsNot Nothing Then
                    ds.Tables.Remove("Puestos")
                End If
                Dim tabla_provicional As DataTable
                tabla_provicional = tr.Select("Id_ponderacion = " & ro.ItemArray(0)).CopyToDataTable
                tabla_provicional.TableName = "Puestos"
                ds.Tables.Add(tabla_provicional)

                Dim i As List(Of requerido) = calificar_curso(Codigo_curso, False, 0, ro.ItemArray(0), "Calificaciones", "s")
                For Each req As requerido In i
                    nueva_lista.Add(req)
                Next
            Next
            For Each ro As DataRow In id_ponderaciones_empleado.Rows


                If ds.Tables("Puestos") IsNot Nothing Then
                    ds.Tables.Remove("Puestos")
                End If
                Dim tabla_provicional As DataTable
                tabla_provicional = tr_empleado.Select("").CopyToDataTable.DefaultView.ToTable(False, "CB_CODIGO", "Nombre", "Departamento", "Puesto", "Nivel")
                tabla_provicional.TableName = "Puestos"
                ds.Tables.Add(tabla_provicional)

                Dim i As List(Of empleados) = calificar_por_empleado(Codigo_curso, False, 0, ro.ItemArray(0), "Calificaciones", "Otro", False)
                For Each emp As empleados In i
                    nueva_lista_empleados.Add(emp)
                Next
            Next


            'AQUI SE VA HACER UPDATE EN LA TABLA DE RELACIONES PUESTO CARACTERISTICAS
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.Parameters.AddWithValue("@CUR", Codigo_curso)
            cmd.Parameters.Add("@Cal")
            cmd.Parameters.Add("@PTO")
            cmd.CommandText = "Update Hr.Relaciones_pto_carac set Nivel_requerido =@Cal where CU_CODIGO= @CUR and pu_codigo = @PTO"
            For Each emp As requerido In nueva_lista
                cmd.Parameters("@Cal").Value = emp.requerido
                cmd.Parameters("@PTO").Value = emp.pu_codigo
                cmd.ExecuteNonQuery()
            Next
            cmd.CommandText = "Update Hr.Relaciones_pto_carac set Nivel_requerido =@Cal where CU_CODIGO = @CUR and CB_CODIGO = @PTO"
            For Each emp As empleados In nueva_lista_empleados
                cmd.Parameters("@Cal").Value = emp.calif
                cmd.Parameters("@PTO").Value = emp.cb_codigo
                cmd.ExecuteNonQuery()
            Next
            Return 1

        Catch ex As Exception
            Throw New Exception
        Finally
            If CnMPS.State = ConnectionState.Open Then
                CnMPS.Close()
            End If
        End Try
    End Function
#Region "Probablemente no utilizado"
    Shared Function Puestos_por_relacion(ByVal id_instruccion)
        Try

            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
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

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    '    Shared Function agregar_relpu_heredado(ByVal puesto As String, ByVal id_categoria As Integer, ByVal id_relacion As Integer)
    '        Try

    '            If ds.Tables("Relaciones").Select("PU_CODIGO = '" & puesto & "'  And Id_categoria = " & id_categoria).Count > 0 Then
    '                'ya existe una 
    '                Dim b = ds.Tables("Relaciones").Select("PU_CODIGO = '" & puesto & "'  And Id_categoria = " & id_categoria).CopyToDataTable
    '                If id_relacion <> b.Rows(0).ItemArray(4) Then
    '                    Console.WriteLine("")
    '                    If id_relacion > b.Rows(0).ItemArray(4) Then
    '                        Console.WriteLine("")
    '                        cmd.Parameters.Clear()
    '                        cmd.Parameters.AddWithValue("@IDCA", id_categoria)
    '                        cmd.Parameters.AddWithValue("@PU_CODIGO", puesto)
    '                        cmd.Parameters.AddWithValue("@IDREL", id_relacion)
    '                        cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL where Id_categoria = @IDCA and PU_CODIGO = @PU_CODIGO"
    '                        cmd.ExecuteNonQuery()

    '                        If ds.Tables("Relaciones_repetidas").Select("Id_relacion_principal = " & id_relacion & " and Id_relacion_repetido = " & b(0).ItemArray(4)).Count = 0 Then
    '                            cmd.Parameters.Clear()
    '                            cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@id_re_pri,@id_re_rep)"
    '                            cmd.Parameters.AddWithValue("@id_re_pri", id_relacion)
    '                            cmd.Parameters.AddWithValue("@id_re_rep", b(0).ItemArray(4))
    '                            cmd.ExecuteNonQuery()
    '#Region "Cargar tabla"
    '                            If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
    '                                ds.Tables.Remove("Relaciones_repetidas")
    '                            End If
    '                            da.SelectCommand.Parameters.Clear()
    '                            da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
    '                            da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
    '                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
    '                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
    '                            da.Fill(ds, "Relaciones_repetidas")
    '#End Region

    '                        End If


    '                    Else
    '                        Console.WriteLine("")
    '                        Dim bus = relup(id_relacion, b.Rows(0).ItemArray(4))
    '                        If bus.res = True Then
    '                            'SI EXISTE CONEXION
    '                            Console.WriteLine()
    '                        Else
    '                            'SI NO EXISTE RELACION
    '                            cmd.Parameters.Clear()
    '                            cmd.Connection = CnMPS
    '                            cmd.CommandType = CommandType.Text
    '                            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
    '                            cmd.Parameters.AddWithValue("@Id_rel_pri", b(0).ItemArray(4))
    '                            cmd.Parameters.AddWithValue("@Id_rel_rep", id_relacion)
    '                            cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
    '                            cmd.ExecuteNonQuery()
    '#Region "Recargar tabla de relaciones"
    '                            If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
    '                                ds.Tables.Remove("Relaciones_repetidas")
    '                            End If
    '                            da.SelectCommand.Parameters.Clear()
    '                            da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
    '                            da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
    '                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
    '                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
    '                            da.Fill(ds, "Relaciones_repetidas")

    '#End Region
    '                        End If



    '                    End If
    '                Else
    '                    'Si es igual no se necesita hacer nada
    '                End If
    '            Else
    '                'nueva relacion
    '                cmd.Parameters.Clear()
    '                cmd.Parameters.AddWithValue("@Id_categoria", id_categoria)
    '                cmd.Parameters.AddWithValue("@PU_CODIGO", puesto)
    '                cmd.Parameters.AddWithValue("@Nivelreq", 25)
    '                cmd.Parameters.AddWithValue("@Id_relacion", id_relacion)
    '                cmd.CommandText = "Insert into Hr.Relaciones_pto_carac (Id_categoria,PU_CODIGO,Nivel_requerido,Id_relacion)VALUES(@Id_categoria,@PU_CODIGO,@Nivelreq,@Id_relacion)"
    '                cmd.ExecuteNonQuery()

    '            End If

    '            Dim ca = ds.Tables("Puestos").Select("PU_PARENT = '" & puesto.ToString & "'")

    '            For a = 0 To ca.Length - 1
    '                agregar_relpu_heredado(ca(a).ItemArray(1), id_categoria, id_relacion)
    '            Next

    '            Return 1

    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '    End Function
#End Region


#Region "Subs,functions "
    Shared Function relup(ByVal id_original As Integer, ByVal id_busqueda As Integer) As RELUUP
        Try

            'ID_RELACION_DOS ES LA FUTURA COMPARA CONTRA ELLA LAS QUE TIENE IDRELACIONUNO COMO PRINCIPALE 
            Dim RES As RELUUP
            RES.id_rel = 0
            RES.res = False
            If ds.Tables("Relaciones_repetidas").Select("Id_relacion_repetido = " & id_original & "").Count > 0 Then
                Dim f = ds.Tables("Relaciones_repetidas").Select("Id_relacion_repetido = " & id_original & "").CopyToDataTable
                For Each ro As DataRow In f.Rows
                    If ro.ItemArray(1) = id_busqueda Then
                        RES.id_rel = id_busqueda
                        RES.res = True
                        Return RES
                    End If
                Next

                For Each ro As DataRow In f.Rows
                    If ds.Tables("Relaciones_repetidas").Select("Id_relacion_repetido = " & ro.ItemArray(1)).Count > 0 Then
                        RES = relup(ro.ItemArray(1), id_busqueda)
                        If RES.res = True Then
                            RES.id_rel = id_original
                            Return RES
                        End If
                    End If

                Next
            End If




            Return RES
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Save_Error(ex)
            Dim res As RELUUP
            res.id_rel = 0
            res.res = False
            Return Res
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
                                                str(ir.PU_FINAL) + '-'+ puu.PU_DESCRIP as PU_FINAL,Activo,Por_empleado, cb_codigo  from Hr.Instruccion_relacion ir 
                                                left join hr.Puesto pu on ir.PU_INICIA = pu.PU_CODIGO
                                                left join hr.Puesto puu on ir.PU_FINAL = puu.PU_CODIGO
                                                where activo = 1 and  id_caracteristica = @idca"
            Else
                da.SelectCommand.CommandText = "Select ir.id as 'Id', case 
when Por_nivel = 1 then 'Nivel'
when Escalona = 1 then 'Puesto escalonado'
when Hereda = 1 then 'Puesto heredado'
when Por_puesto = 1 then 'Solo empleado'
when Por_empleado = 1 then 'Directo a empleado'
else 'No definido' end as 'Tipo',
ir.Id_caracteristica,ir.Solicitado_por,ir.Por_nivel,ir.Id_nivel,ir.Por_puesto,ir.Escalona,ir.Hereda,ir.PU_INICIA + ' -- '+ pu.PU_DESCRIP as PU_INICIA,
ir.PU_FINAL + ' -- '+ puu.PU_DESCRIP as PU_FINAL,Activo ,Por_empleado, ir.cb_codigo,co.prettyname from Hr.Instruccion_relacion ir 
left join hr.Puesto pu on ir.PU_INICIA = pu.PU_CODIGO
left join hr.Puesto puu on ir.PU_FINAL = puu.PU_CODIGO
left join tress.dbo.COLABORA co on ir.cb_codigo = co.cb_codigo 
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

    Shared Function puesto(ByVal cb_codigo As Integer)
        Try
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select CB_PUESTO from TRESS.dbo.colabora where cb_codigo = @cb_codigo"
            cmd.Parameters.AddWithValue("@cb_codigo", cb_codigo)
            Dim MiPuesto As String = ""
            MiPuesto = cmd.ExecuteScalar
            Return MiPuesto
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return ""
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function puestos_hijos(ByVal Optional pu_codigo As String = "271  ")

        Try
            Dim puesto = CType(SqlQuery.puestos, DataTable).Copy
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select * from HR.Puesto"
            ds.Tables.Clear()
            da.Fill(ds, "Puestos")
            Console.WriteLine("")

            If ds.Tables("Puestos").Select("Pu_PARENT = '" & pu_codigo & "'").Count > 0 Then
                Dim tabl = ap(pu_codigo)
                Return tabl
            End If
            Console.WriteLine("")
            Return New DataTable
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return New DataTable
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function ap(ByVal pu_codigo As String) As DataTable
        Try
            Dim hij = ds.Tables("Puestos").Select("PU_PARENT = '" & pu_codigo & "'").CopyToDataTable

            Dim rres As New DataTable ' As DataRow = hij.NewRow
                For Each col As DataColumn In hij.Columns
                    rres.Columns.Add(col.ColumnName)
                Next

            For Each ro As DataRow In hij.Rows

                If ds.Tables("Puestos").Select("PU_PARENT = '" & ro.ItemArray(1).ToString & "'").Count > 0 Then
                    Dim t = ap(ro.ItemArray(1))
                    For a = 0 To t.Rows.Count - 1
                        rres.ImportRow(t.Rows(a))
                    Next
                End If
            Next

            For Each re As DataRow In rres.Rows
                    hij.ImportRow(re)
                Next

                Return hij


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function


#End Region

#Region "Evaluaciones"
    Shared Function Id_evaluacion(ByVal cb_codigo As Integer, ByVal id_caracteristica As Integer, ByVal CU_CODIGO As String, ByVal Nivel_requerido As Integer, ByVal Id_ponderacion As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@NR", Nivel_requerido)
            cmd.Parameters.AddWithValue("@Max", Id_ponderacion)
            cmd.Parameters.AddWithValue("@cb_codigo", cb_codigo)
            If id_caracteristica = 0 Then
                cmd.Parameters.AddWithValue("@Cur", CU_CODIGO)
                cmd.CommandText = "Select id from Hr.Evaluacion where cb_codigo = @cb_codigo and CU_CODIGO = @Cur and Nivel_requerido=@NR and Id_ponderacion=@Max"
            Else
                cmd.Parameters.AddWithValue("@idca", id_caracteristica)
                cmd.CommandText = "Select id from Hr.Evaluacion where cb_codigo = @cb_codigo and id_caracteristica = @idca and Nivel_requerido=@NR and Id_ponderacion=@Max"
            End If
            Dim re As Integer = 0
            re = cmd.ExecuteScalar
            Return re
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function info(ByVal id_caracteristica As Integer) As DataTable
        Try
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select [Desarrollo de meta, que y por que],[Como],[Recursos],[Extraordinario] From [HR].[Caracteristicas] Where  Id=@IdCA"
            da.SelectCommand.Parameters.AddWithValue("@IdCA", id_caracteristica)
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "desc")
            Return ds.Tables("desc")


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function agregar_Evaluacion(ByVal id_eva As Integer, ByVal id_caracteristica As Integer, ByVal NombreDoc As String, ByVal Descripcion As String,
                                       ByVal ima As Boolean, ByVal doc As Boolean, ByVal imagdoc As Array, ByVal extension As String,
                                       ByVal cb_codigo As Integer, ByVal cb_codigo_aprueba As String, ByVal calificacion As Integer, ByVal nivel_actual As Integer, ByVal id_ponderacion As Integer, ByVal nivel_requerido As Integer)

        Try

            'tener en cuenta que se usara user id en lugar de cb_codigo

            CnMPS.ConnectionString = constringMPS()

            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()

            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
            cmd.Parameters.AddWithValue("@IDCA", id_caracteristica)
            cmd.Parameters.Add("@niv_Act", SqlDbType.Int)
            cmd.Parameters.AddWithValue("@IDP", id_ponderacion)
            cmd.Parameters.AddWithValue("@NR", nivel_requerido)


#Region "Tabla evaluaciones master"
            If Permiso.Habilitado("AFINAL") Then
                'con permisos de aprobacion
                If id_eva < 1 Then
                    'evaluacion nueva
                    cmd.Parameters("@niv_Act").Value = calificacion
                    cmd.CommandText = "Insert Into HR.Evaluacion (CB_CODIGO,Id_caracteristica,Nivel_actual,Validado,Nivel_requerido,Id_ponderacion) Values (@CB_CODIGO,@IDCA,@niv_Act,1,@NR,@IDP); Select @@IDENTITY"
                    id_eva = cmd.ExecuteScalar
                End If
            Else
                If id_eva < 1 Then
                    'ok
                    'evaluacion nueva
                    cmd.Parameters("@niv_Act").Value = 0
                    cmd.CommandText = "Insert Into HR.Evaluacion (CB_CODIGO,Id_caracteristica,Nivel_actual,Validado,Nivel_requerido,Id_ponderacion) Values (@CB_CODIGO,@IDCA,@niv_Act,0,@NR,@IDP); Select @@IDENTITY"
                    id_eva = cmd.ExecuteScalar
                End If
            End If
#End Region

#Region "Datos"
            cmd.Parameters.AddWithValue("@id_eva", id_eva)
            cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
            If ima Then
                cmd.Parameters.AddWithValue("@Imagen", imagdoc)
                cmd.Parameters.AddWithValue("@Doc", DBNull.Value)
            ElseIf doc Then
                cmd.Parameters.AddWithValue("@Imagen", DBNull.Value)
                cmd.Parameters.AddWithValue("@Doc", imagdoc)
            Else
                cmd.Parameters.AddWithValue("@Imagen", DBNull.Value)
                cmd.Parameters.AddWithValue("@Doc", DBNull.Value)
            End If

            cmd.Parameters.AddWithValue("@DocName", NombreDoc)
            cmd.Parameters.AddWithValue("@Ext", extension)
#End Region
#Region "ultimos valores"
            cmd.Parameters.AddWithValue("@CB_CODIGO_Aprueba", cb_codigo_aprueba)
            cmd.Parameters("@niv_Act").Value = calificacion
            cmd.Parameters.AddWithValue("@Rechazado", False)

#End Region
#Region "Aprobado"
            If Permiso.Habilitado("AFINAL") Then
                cmd.Parameters.AddWithValue("@Validado", True)
                cmd.Parameters.AddWithValue("@WHO", My.Settings.Id_user)
            Else
                cmd.Parameters.AddWithValue("@Validado", False)
                cmd.Parameters.AddWithValue("@WHO", DBNull.Value)
            End If
#End Region
#Region "Guardar"
            If ima Then
                cmd.CommandText = "Insert Into HR.Evaluacion_detalles(Id_evaluacion,Descripcion,Imagen,Nombre_documento,Extension,Aprueba_CB_CODIGO,Fecha,Puntos,Validado,Rechazado,VALREC_por)
                            Values(@id_eva,@Descripcion,@Imagen,@DocName,@Ext,@CB_CODIGO_Aprueba,GETDATE(),@niv_Act,@Validado,@Rechazado,@WHO); Select @@IDENTITY"

            ElseIf doc Then
                cmd.CommandText = "Insert Into HR.Evaluacion_detalles(Id_evaluacion,Descripcion,Nombre_documento,Documento,Extension,Aprueba_CB_CODIGO,Fecha,Puntos,Validado,Rechazado,VALREC_por)
                            Values(@id_eva,@Descripcion,@DocName,@Doc,@Ext,@CB_CODIGO_Aprueba,GETDATE(),@niv_Act,@Validado,@Rechazado,@WHO); Select @@IDENTITY"

            Else
                cmd.CommandText = "Insert Into HR.Evaluacion_detalles(Id_evaluacion,Descripcion,Aprueba_CB_CODIGO,Fecha,Puntos,Validado,Rechazado,VALREC_por)
                            Values(@id_eva,@Descripcion,@CB_CODIGO_Aprueba,GETDATE(),@niv_Act,@Validado,@Rechazado,@WHO); Select @@IDENTITY"

            End If
            Dim re = cmd.ExecuteScalar
#End Region

            cmd.Parameters.Clear()
            If Not Permiso.Habilitado("AFINAL") Then

                cmd.Parameters.AddWithValue("@user", My.Settings.Id_user)
                cmd.Parameters.AddWithValue("@id_eva", id_eva)
                cmd.Parameters.AddWithValue("@id_eva_detalles", re)
                cmd.CommandText = "Insert into HR.Tickets (Solicitud,[Solicitado por],Evaluacion,Id_evaluacion,Id_evaluacion_detalle,Comentario)
                                values('Aprobacion de evaluación',@user,1,@id_eva,@id_eva_detalles,'')"
                cmd.ExecuteNonQuery()




            End If


            Return id_eva
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function

    Shared Function agregar_evaluacion_cursos(ByVal id_eva As Integer, ByVal CU_CODIGO As String, ByVal NombreDoc As String, ByVal Descripcion As String,
                                       ByVal ima As Boolean, ByVal doc As Boolean, ByVal imagdoc As Array, ByVal extension As String,
                                       ByVal cb_codigo As Integer, ByVal cb_codigo_aprueba As String, ByVal calificacion As Integer, ByVal nivel_actual As Integer, ByVal id_ponderacion As Integer, ByVal nivel_requerido As Integer)

        Try

            'tener en cuenta que se usara user id en lugar de cb_codigo

            CnMPS.ConnectionString = constringMPS()

            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()

            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
            cmd.Parameters.AddWithValue("@Cur", CU_CODIGO)
            cmd.Parameters.Add("@niv_Act", SqlDbType.Int)
            cmd.Parameters.AddWithValue("@IDP", id_ponderacion)
            cmd.Parameters.AddWithValue("@NR", nivel_requerido)


#Region "Tabla evaluaciones master"
            If Permiso.Habilitado("AFINAL") Then
                'con permisos de aprobacion
                If id_eva < 1 Then
                    'evaluacion nueva
                    cmd.Parameters("@niv_Act").Value = calificacion
                    cmd.CommandText = "Insert Into HR.Evaluacion (CB_CODIGO,CU_CODIGO,Nivel_actual,Validado,Nivel_requerido,Id_ponderacion) Values (@CB_CODIGO,@Cur,@niv_Act,1,@NR,@IDP); Select @@IDENTITY"
                    id_eva = cmd.ExecuteScalar
                End If
            Else
                If id_eva < 1 Then
                    'ok
                    'evaluacion nueva
                    cmd.Parameters("@niv_Act").Value = 0
                    cmd.CommandText = "Insert Into HR.Evaluacion (CB_CODIGO,CU_CODIGO,Nivel_actual,Validado,Nivel_requerido,Id_ponderacion) Values (@CB_CODIGO,@Cur,@niv_Act,0,@NR,@IDP); Select @@IDENTITY"
                    id_eva = cmd.ExecuteScalar
                End If
            End If
#End Region

#Region "Datos"
            cmd.Parameters.AddWithValue("@id_eva", id_eva)
            cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
            If ima Then
                cmd.Parameters.AddWithValue("@Imagen", imagdoc)
                cmd.Parameters.AddWithValue("@Doc", DBNull.Value)
            ElseIf doc Then
                cmd.Parameters.AddWithValue("@Imagen", DBNull.Value)
                cmd.Parameters.AddWithValue("@Doc", imagdoc)
            Else
                cmd.Parameters.AddWithValue("@Imagen", DBNull.Value)
                cmd.Parameters.AddWithValue("@Doc", DBNull.Value)
            End If

            cmd.Parameters.AddWithValue("@DocName", NombreDoc)
            cmd.Parameters.AddWithValue("@Ext", extension)
#End Region
#Region "ultimos valores"
            cmd.Parameters.AddWithValue("@CB_CODIGO_Aprueba", cb_codigo_aprueba)
            cmd.Parameters("@niv_Act").Value = calificacion
            cmd.Parameters.AddWithValue("@Rechazado", False)

#End Region
#Region "Aprobado"
            If Permiso.Habilitado("AFINAL") Then
                cmd.Parameters.AddWithValue("@Validado", True)
                cmd.Parameters.AddWithValue("@WHO", My.Settings.Id_user)
            Else
                cmd.Parameters.AddWithValue("@Validado", False)
                cmd.Parameters.AddWithValue("@WHO", DBNull.Value)
            End If
#End Region
#Region "Guardar"
            If ima Then
                cmd.CommandText = "Insert Into HR.Evaluacion_detalles(Id_evaluacion,Descripcion,Imagen,Nombre_documento,Extension,Aprueba_CB_CODIGO,Fecha,Puntos,Validado,Rechazado,VALREC_por)
                            Values(@id_eva,@Descripcion,@Imagen,@DocName,@Ext,@CB_CODIGO_Aprueba,GETDATE(),@niv_Act,@Validado,@Rechazado,@WHO); Select @@IDENTITY"

            ElseIf doc Then
                cmd.CommandText = "Insert Into HR.Evaluacion_detalles(Id_evaluacion,Descripcion,Nombre_documento,Documento,Extension,Aprueba_CB_CODIGO,Fecha,Puntos,Validado,Rechazado,VALREC_por)
                            Values(@id_eva,@Descripcion,@DocName,@Doc,@Ext,@CB_CODIGO_Aprueba,GETDATE(),@niv_Act,@Validado,@Rechazado,@WHO); Select @@IDENTITY"

            Else
                cmd.CommandText = "Insert Into HR.Evaluacion_detalles(Id_evaluacion,Descripcion,Aprueba_CB_CODIGO,Fecha,Puntos,Validado,Rechazado,VALREC_por)
                            Values(@id_eva,@Descripcion,@CB_CODIGO_Aprueba,GETDATE(),@niv_Act,@Validado,@Rechazado,@WHO); Select @@IDENTITY"

            End If
            Dim re = cmd.ExecuteScalar
#End Region

            cmd.Parameters.Clear()
            If Not Permiso.Habilitado("AFINAL") Then

                cmd.Parameters.AddWithValue("@user", My.Settings.Id_user)
                cmd.Parameters.AddWithValue("@id_eva", id_eva)
                cmd.Parameters.AddWithValue("@id_eva_detalles", re)
                cmd.CommandText = "Insert into HR.Tickets (Solicitud,[Solicitado por],Evaluacion,Id_evaluacion,Id_evaluacion_detalle,Comentario)
                                values('Aprobacion de evaluación',@user,1,@id_eva,@id_eva_detalles,'')"
                cmd.ExecuteNonQuery()




            End If


            Return id_eva
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function


    Shared Function editar_evaluacion(ByVal id As Integer, ByVal id_eva_detalles As Integer, ByVal Descripcion As String, ByVal NombreDoc As String,
                                      ByVal ima As Boolean, ByVal doc As Boolean, ByVal imagdoc As Array, ByVal extension As String,
                                      ByVal calificacion As Integer, ByVal cambio_en_documento As Boolean, ByVal estatus As String)
        Try

            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()

            End If

            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@Id_eva", id_eva_detalles)
            cmd.Parameters.AddWithValue("@Desc", Descripcion)
            cmd.Parameters.AddWithValue("@Puntos", calificacion)

            If ima Or doc Then
                cmd.Parameters.AddWithValue("@NomDoc", NombreDoc)
                If cambio_en_documento Then
                    If imagdoc.ToString <> "" Then
                        cmd.Parameters.AddWithValue("@Datos", imagdoc)
                        cmd.Parameters.AddWithValue("@Ext", extension)
                        If ima Then
                            cmd.CommandText = "Update Hr.Evaluacion_detalles set Descripcion = @Desc, Imagen = @Datos, Nombre_documento = @NomDoc , Documento = Null,
                                               Extension = @Ext, Puntos = @Puntos, Validado = 0, Rechazado = 0, VALREC_por = Null where id = @Id_eva"
                            cmd.ExecuteNonQuery()
                        ElseIf doc Then
                            cmd.CommandText = "Update Hr.Evaluacion_detalles set Descripcion = @Desc, Imagen = Null, Nombre_documento = @NomDoc , Documento = @Datos,
                                               Extension = @Ext, Puntos = @Puntos, Validado = 0, Rechazado = 0, VALREC_por = Null where id = @Id_eva"
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                Else
                    cmd.CommandText = "Update Hr.Evaluacion_detalles set Descripcion = @Desc, Nombre_documento=@NomDoc,Puntos=@Puntos,Validado=0,Rechazado=0,
                                                VALREC_por = Null where id = @Id_eva"
                    cmd.ExecuteNonQuery()
                End If
            ElseIf cambio_en_documento Then
                cmd.CommandText = "Update Hr.Evaluacion_detalles set Descripcion = @Desc, Puntos = @Puntos, Validado = 0, Rechazado = 0, VALREC_por = Null, Imagen = Null,
                                  Nombre_documento = Null, Documento = Null, Extension = Null where id = @Id_eva"
                cmd.ExecuteNonQuery()
            Else
                cmd.CommandText = "Update Hr.Evaluacion_detalles set Descripcion = @Desc,Puntos=@Puntos,Validado=0,Rechazado=0,VALREC_por = Null where id = @Id_eva"
                cmd.ExecuteNonQuery()
            End If


            'Agregar Ticket
            If estatus = "Rechazado" Then

                cmd.Parameters.AddWithValue("@user", My.Settings.Id_user)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.CommandText = "Insert Into Hr.Tickets (Solicitud,[Solicitado por],Evaluacion,Id_evaluacion,Id_evaluacion_detalle,Mostrar)
                                   Values('Cambio de información tras rechazo',@user,1,@id,@Id_eva,1)"
                cmd.ExecuteNonQuery()

            ElseIf estatus = "Pendiente" Then
                cmd.CommandText = "Select  count(*) from hr.Tickets_detalles where id_ticket = ( select max(id) from hr.Tickets where Id_evaluacion_detalle = @Id_eva)"
                Dim cant_ticket_detalles As Integer = cmd.ExecuteScalar

                If cant_ticket_detalles > 1 Then
                    Dim ultimo_id_ticket As Integer = 0
                    cmd.CommandText = "select max(id) from hr.Tickets_detalles where id_ticket in (select id from hr.Tickets where Id_evaluacion_detalle = @Id_eva) and aprobado = 0 and rechazado = 0"
                    ultimo_id_ticket = cmd.ExecuteScalar

                    cmd.Parameters.AddWithValue("@Comentario_abort", "Abortado por usuario (" & My.Settings.Id_user & " - " & My.Settings.Usuario & ") para cambio de información")
                    cmd.Parameters.AddWithValue("@Id_ticket_detalle", ultimo_id_ticket)
                    cmd.CommandText = "Update Hr.Tickets_detalles set rechazado = 1 ,  comentario = @Comentario_abort where id = @Id_ticket_detalle"
                    cmd.ExecuteNonQuery()
                    Console.WriteLine("")
                    cmd.Parameters.AddWithValue("@user", My.Settings.Id_user)
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.CommandText = "Insert Into Hr.Tickets (Solicitud,[Solicitado por],Evaluacion,Id_evaluacion,Id_evaluacion_detalle,Mostrar)
                                   Values('Cambio de información de usuario creador',@user,1,@id,@Id_eva,1)"
                    cmd.ExecuteNonQuery()
                End If
            End If





            'POSIBLEMENTE NO SE UTILICE
            '#Region "Aprobado"
            '            If Permiso.Habilitado("AFINAL") Then
            '                cmd.Parameters.AddWithValue("@Validado", True)
            '                cmd.Parameters.AddWithValue("@WHO", My.Settings.Id_user)
            '            Else
            '                cmd.Parameters.AddWithValue("@Validado", False)
            '                cmd.Parameters.AddWithValue("@WHO", DBNull.Value)
            '            End If
            '#End Region
            '            cmd.Parameters.Clear()
            '            If Not Permiso.Habilitado("AFINAL") Then

            '                cmd.Parameters.AddWithValue("@user", My.Settings.Id_user)
            '                cmd.Parameters.AddWithValue("@id_eva", id_eva)
            '                cmd.Parameters.AddWithValue("@id_eva_detalles", re)
            '                cmd.CommandText = "Insert into HR.Tickets (Solicitud,[Solicitado por],Evaluacion,Id_evaluacion,Id_evaluacion_detalle,Comentario)
            '                                    values('Aprobacion de evaluación',@user,1,@id_eva,@id_eva_detalles,'')"
            '                cmd.ExecuteNonQuery()
            '            End If






            Return 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function editar_evaluacion_cursos(ByVal id_eva_detalles As Integer, ByVal Descripcion As String, ByVal NombreDoc As String,
                                      ByVal ima As Boolean, ByVal doc As Boolean, ByVal imagdoc As Array, ByVal extension As String,
                                      ByVal cb_codigo_aprueba As String, ByVal calificacion As Integer, ByVal cambio_en_documento As Boolean)
        Try


        Catch ex As Exception
            Throw New Exception(ex.Message)
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
    Shared Function Detalles_evaluacion(ByVal Id_evaluacion As Integer)

        Try
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select top(1) evd.Id,evd.Aprueba_CB_CODIGO,usu.Nombre,
	case when ev.Id_caracteristica is null then 'Curso'
	else (
	case when ca.Competencia = 1 then 'Competencia' when ca.Conocimiento = 1 then 'Conocimiento' when ca.Habilidad = 1 then 'Habilidad' end 
	) end as 'Tipo',
	case when ev.Id_caracteristica is null then cu.CU_NOMBRE else ca.Descripcion end as 'Caracteristica',
	ca.Nivel,evd.Fecha,'N/A' as 'Vencimiento', evd.Puntos, evd.Nombre_documento, evd.Extension,evd.Descripcion,evd.Imagen,evd.Documento,
	case when ti.Aprobado = 1 then 'Aprobado' when ti.Rechazado	= 1 then 'Rechazado' else 'Pendiente' end as 'Estatus'
  FROM [HR].[Evaluacion_detalles] evd
  inner join hr.Evaluacion ev on evd.Id_Evaluacion = ev.Id
  left join MaRs.dbo.Usuarios usu on Aprueba_CB_CODIGO = usu.id
  left join hr.Caracteristicas ca on ev.Id_caracteristica = ca.Id
  left join tress.dbo.CURSO cu on ev.CU_CODIGO = cu.CU_CODIGO
  left join hr.Tickets ti on evd.Id = ti.Id_evaluacion_detalle
  where evd.id = @IdCA order by ti.Id desc"
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
    Shared Function Datos_para_editar_evaluacion(ByVal id As Integer)
        Try
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "  Select evd.Id as 'Id_evaluacion_detalles',ev.Id as 'Id_evaluacion', Id_caracteristica,ca.Descripcion,ev.CU_CODIGO,cu.CU_NOMBRE,ev.CB_CODIGO,(select max(n.Puntos) from hr.Evaluacion_detalles n where
  n.Id_Evaluacion = ev.Id and Validado = 1 )  as 'Nivel_actual',ev.Id_ponderacion,ev.Nivel_requerido
  from hr.Evaluacion_detalles evd
  inner join hr.Evaluacion ev on evd.Id_Evaluacion = ev.id
  left join hr.Caracteristicas ca on ev.Id_caracteristica = ca.Id
  left join tress.dbo.CURSO cu on ev.CU_CODIGO = cu.CU_CODIGO
  where evd.id = @Eva"
            da.SelectCommand.Parameters.AddWithValue("@Eva", id)
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

    Shared Function Detalles_aprobaciones(ByVal id_evaluacion As Integer)
        Try
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "  select  ti.Id,usu.Nombre as 'Usuario',Fecha,'Solicitud' as 'Estatus',Solicitud as 'Comentario', 1 as 'ForOrder' ,0 as 'ForOrdertwo' from hr.Tickets ti 
  inner join mars.dbo.Usuarios usu on ti.[Solicitado por] = usu.Id where Id_evaluacion_detalle = @IdCA
  union all
  select td.id_ticket, usu.Nombre,date_update,
  case when td.aprobado = 1 then 'Aprobado' when td.rechazado = 1 then 'Rechazado' else 'Pendiente' end as 'Estatus'
  ,comentario, case when td.date_update is null then 0 else 1 end as 'yu'
  ,td.id
   from hr.Tickets_detalles td 
   inner join mars.dbo.Usuarios usu on td.user_aprueba = usu.Id
   where id_ticket in (select id from hr.Tickets where Id_evaluacion_detalle = @IdCA)
   order by Id asc, ForOrder desc,ForOrderTwo asc,fecha asc
"
            da.SelectCommand.Parameters.AddWithValue("@IdCA", id_evaluacion)
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "APRO")
            Return ds.Tables("APRO")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function

    Shared Function Eliminar_evaluaciones(ByVal id As Integer, ByVal Estatus As String)
        Dim tra As SqlClient.SqlTransaction
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            tra = CnMPS.BeginTransaction()
            cmd.Transaction = tra
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@Id", id)
            If Estatus = "Pendiente" Then
                cmd.Parameters.AddWithValue("@Comentario", "Abortado por usuario: " & My.Settings.Usuario & " ")
                cmd.CommandText = "Update hr.tickets_detalles set comentario = @Comentario, rechazado = 1 
                                where id_ticket = (select id from hr.Tickets where id_evaluacion_detalle = @Id) and aprobado = 0 and rechazado = 0"
                cmd.ExecuteNonQuery()
            End If
            cmd.CommandText = "update hr.Tickets set Mostrar = 0 where Id_evaluacion_detalle = @Id "
            cmd.ExecuteNonQuery()
                cmd.CommandText = "Delete from hr.Evaluacion_detalles where id = @Id"
                cmd.ExecuteNonQuery()
                cmd.Parameters.AddWithValue("@User", My.Settings.Id_user)
                cmd.Parameters.AddWithValue("@Descripcion", "Se ha eliminado evaluacion (id= " & id & ") con estatus: " & Estatus)
                cmd.CommandText = "Insert into hr.Historial (Id_usuario,Accion)values(@User,@Descripcion)"
                cmd.ExecuteNonQuery()
            tra.Commit()

        Catch ex As Exception
            tra.Rollback()
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

#End Region

#Region "Structures"
    Public Structure RELUUP
        Dim res As Boolean
        Dim id_rel As Integer
    End Structure
    Public Structure Permisos_stru
        Dim col As String
        Dim val As Boolean
    End Structure
    Public Structure Usuario
        Dim cb_codigo As Integer
        Dim id_user As Integer
    End Structure
    Public Structure Puesto_descripcion
        Dim pu_codigo As String
        Dim pu_descripcion As String
    End Structure
    Public Structure empleados
        Dim cb_codigo As Integer
        Dim Name As String
        Dim calif As Integer
    End Structure
    Public Structure requerido
        Dim pu_codigo As String
        Dim requerido As Integer
    End Structure

#End Region

#Region "Permisos"
    Shared Function Permisos(ByVal id_user As Integer)

        Try
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select * From [HR].[Permisos_detalle] det inner join [HR].[Permisos_Master] pem  On det.Permiso = pem.Identificador Where  ID_USER=@id_user"
            da.SelectCommand.Parameters.AddWithValue("@id_user", id_user)
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Permisos")
            Return ds.Tables("Permisos")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try


    End Function
    Shared Function Permisos_cAT()

        Try
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select * From [HR].[Permisos_Master]"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Permisos")
            Return ds.Tables("Permisos")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try


    End Function
    Shared Function UserMpsExists(ByVal CB_CODIGO As Integer) As Integer
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandText = "Select Id, Nombre, Usuario, Descripcion from Mars.dbo.Usuarios where cb_codigo = @cb_codigo"
            da.SelectCommand.Parameters.AddWithValue("@cb_codigo", CB_CODIGO)
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "usuarios")
            If ds.Tables("usuarios").Rows.Count = 0 Then
                Return 0
            ElseIf ds.Tables("usuarios").Rows.Count > 1 Then
                Dim new_select As New Duplicado
                new_select.info = ds.Tables("usuarios").Copy
                If new_select.ShowDialog() = DialogResult.OK Then
                    Return new_select.id_user
                Else
                    Return -1
                End If
            ElseIf ds.Tables("usuarios").Rows.Count = 1 Then
                Return ds.Tables("usuarios").Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function PorCodigoDetalles(ByVal cb_codigo As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.Add("@cb_codigo", SqlDbType.Int)
            da.SelectCommand.Parameters("@cb_codigo").Value = cb_codigo

            da.SelectCommand.CommandText = "Select prettyname, cb_Nivel1, cb_puesto from tress.dbo.COLABORA  where CB_CODIGO = @cb_codigo And CB_ACTIVO = 'S'"

            ds.Tables.Clear()
            da.Fill(ds, "Datos")
            Return ds.Tables("Datos")


        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function
    Shared Function PersonalDetail()
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandText = "select co.CB_CODIGO, co.PRETTYNAME, n1.TB_ELEMENT,pu.PU_DESCRIP from tress.dbo.COLABORA co 
                                            inner join tress.dbo.NIVEL1 n1 on co.CB_NIVEL1 = n1.TB_CODIGO
                                            inner join tress.dbo.PUESTO pu on co.CB_PUESTO = pu.PU_CODIGO
                                            where CB_ACTIVO = 's' order by PRETTYNAME"
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
    Shared Function agregarPermisos(ByVal empleados As List(Of Integer), ByVal Permisos As List(Of Permisos_stru), ByVal nuevo As Boolean)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()
            For Each user As Integer In empleados
                Console.WriteLine("")
                Dim para_eliminar = Permisos.FindAll(Function(c) c.val = "False")
                Console.WriteLine("")
                cmd.Parameters.AddWithValue("@id_user", user)
                cmd.Parameters.AddWithValue("@Identificador", SqlDbType.VarChar)
                cmd.CommandText = "Delete from Hr.Permisos_detalle where ID_USER = @id_user and Permiso = @Identificador"
                For Each per As Permisos_stru In para_eliminar
                    cmd.Parameters("@Identificador").Value = per.col
                    cmd.ExecuteNonQuery()
                Next
                Dim para_agregar = Permisos.FindAll(Function(c) c.val = "True")
                Dim re As Integer = 0
                For Each per As Permisos_stru In para_agregar
                    re = 0
                    cmd.Parameters("@Identificador").Value = per.col
                    cmd.CommandText = "Select id from Hr.Permisos_detalle where ID_USER = @id_user and Permiso = @Identificador"
                    re = cmd.ExecuteScalar
                    If re < 1 Then
                        cmd.CommandText = "Insert into HR.Permisos_detalle (ID_USER,Permiso) Values (@id_user,@Identificador)"
                        cmd.ExecuteNonQuery()
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
#End Region

#Region "Cursos"
    Shared Function lista_cursos() As DataTable
        Try
            da.SelectCommand.Parameters.Clear()
            If CnTress.State = ConnectionState.Closed Then
                CnTress.ConnectionString = constringTRESS()
                CnTress.Open()
            End If
            da.SelectCommand.Connection = CnTress
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = " Select CU_CODIGO,CU_ACTIVO,CU_NOMBRE from dbo.Curso where CU_ACTIVO = 'S'"
            ds.Tables.Clear()
            da.Fill(ds, "Cursos")
            Return ds.Tables("Cursos")

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return Nothing
        Finally
            If CnTress.State = ConnectionState.Open Then CnTress.Close()
        End Try
    End Function
#End Region

#Region "Tickets"

    Shared Function Get_tickets(ByVal Completo As Boolean, ByVal Optional id_user As Integer = 0)
        Try
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.AddWithValue("@id_user", My.Settings.Id_user)
            If Completo Then
                da.SelectCommand.CommandText = "Select * from HR.Tickets"
            Else
                da.SelectCommand.CommandText = "Select distinct ti.Id, ti.Fecha, ti.Solicitud, ti.[Solicitado por], usu.Usuario, 
Evaluacion,Id_evaluacion,Id_evaluacion_detalle,[Agregar caracteristica],Id_caracteristica,ti.Comentario,ti.Aprobado,ti.Rechazado,[Aprobado por],
usus.Usuario as 'Aprueba',[Ultima fecha update], ss.Usuario as 'Pendiente', td.id as 'Id_detalles' from Hr.Tickets ti 
left join Mars.dbo.Usuarios usu on ti.[Solicitado por] = usu.Id
left join Mars.dbo.Usuarios usus on ti.[Aprobado por] = usus.Id
left join hr.Tickets_detalles td on ti.Id = td.id_ticket and td.aprobado = 0 and td.rechazado = 0
left join mars.dbo.Usuarios ss on td.user_aprueba = ss.Id
where [Solicitado por] = @id_user or ti.id in (select id_ticket from hr.Tickets_detalles where user_aprueba = @id_user and aprobado = 0 and rechazado = 0) and mostrar = 1
"
                da.SelectCommand.CommandText = "Select distinct case when [Solicitado por] = @id_user then ti.Id else td.Id end as 'Id', ti.Fecha, ti.Solicitud,col.PRETTYNAME as 'Evaluado', Case when ev.CU_CODIGO is null then 'Caracteristica evaluada:'+ carac.Descripcion when ev.Id_caracteristica is null then 
'Curso evaluado:'+ cur.CU_NOMBRE end as 'Detalles', ti.[Solicitado por], usu.Usuario, 
Evaluacion,Id_evaluacion,Id_evaluacion_detalle,[Agregar caracteristica],ti.Id_caracteristica,ti.Comentario,ti.Aprobado,ti.Rechazado,[Aprobado por],
usus.Usuario as 'Aprueba',[Ultima fecha update], ss.Usuario as 'Pendiente', td.id as 'Id_detalles' from Hr.Tickets ti 
left join Mars.dbo.Usuarios usu on ti.[Solicitado por] = usu.Id
left join Mars.dbo.Usuarios usus on ti.[Aprobado por] = usus.Id
left join hr.Tickets_detalles td on ti.Id = td.id_ticket and td.aprobado = 0 and td.rechazado = 0
left join mars.dbo.Usuarios ss on td.user_aprueba = ss.Id
left join hr.Evaluacion ev on ti.Id_evaluacion = ev.Id
left join tress.dbo.COLABORA col on ev.CB_CODIGO = col.CB_CODIGO
left join hr.Caracteristicas carac on ev.Id_caracteristica = carac.Id
left join tress.dbo.CURSO cur on ev.CU_CODIGO = cur.CU_CODIGO
where ([Solicitado por] = @id_user or ti.id in (select id_ticket from hr.Tickets_detalles where user_aprueba = @id_user and aprobado = 0 and rechazado = 0)) and mostrar = 1"
            End If
            ds.Tables.Clear()
            da.Fill(ds, "Tickets")
            Return ds.Tables("Tickets")


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function aprobar(ByVal id As Integer, ByVal Aprobado As Boolean, ByVal Optional Comentario As String = "")
        Try

            If CnMPS.State = ConnectionState.Closed Then

                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@Id", id)
            cmd.Parameters.AddWithValue("@Comentario", Comentario)
            If Aprobado Then
                cmd.CommandText = "UPDATE HR.Tickets_detalles set Aprobado = 1,comentario = @Comentario  where id = @Id"

            Else
                cmd.CommandText = "UPDATE HR.Tickets_detalles set Rechazado = 1,comentario = @Comentario where id = @Id"
            End If
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function limpiar_tickets(ByVal Aprobados As Boolean, ByVal Rechazados As Boolean)
        Try

            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@User", My.Settings.Id_user)
            cmd.Parameters.AddWithValue("@Aprobados", Aprobados)
            cmd.Parameters.AddWithValue("@Rechazados", Rechazados)
            cmd.CommandText = "HR.Limpiar_tickets"
            cmd.ExecuteNonQuery()
            Return 1
           
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function

#End Region

#Region "Aprobacion"
    Shared Function Aprobacion(ByVal Aprobado As Boolean, ByVal CB_CODIGO As Integer, ByVal Comentario As String)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            cmd.CommandText = ""


            Dim SIGUIENTE As Integer = 0
            SIGUIENTE = cmd.ExecuteScalar
            Return SIGUIENTE






        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function Siguiente_aprueba(ByVal cb_codigo As Integer)
        Try



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

#End Region


#Region "Debug"
    'CODIGO PARA DEBUGGEAR
    Shared Function contraseña(ByVal usuario As String) As String
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@User", usuario)
            cmd.CommandText = "Select Password from Mars.dbo.Usuarios where Usuario = @User"
            Dim re As String = ""
            re = cmd.ExecuteScalar
            Return re
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
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
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

    Shared Function AgregarCaracteristica(ByVal Descripcion As String, ByVal QUE As String, ByVal Como As String, ByVal recursos As String, ByVal extra As String, ByVal Competencia As Boolean, ByVal Habilidad As Boolean, ByVal Conocimiento As Boolean, ByVal Curso As Boolean, ByVal Nuevo As Boolean, ByVal nivel As Integer, ByVal Description As String, ByVal What As String, ByVal How As String, ByVal Resources As String, ByVal Optional id As Integer = 0)
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
            cmd.Parameters.Add("@Curso", SqlDbType.Bit)
            cmd.Parameters.AddWithValue("@CoUsuario", My.Settings.Id_user)
            cmd.Parameters.AddWithValue("@Usuario", My.Settings.Usuario)
            cmd.Parameters("@Descripcion").Value = Descripcion
            cmd.Parameters("@Competencia").Value = Competencia
            cmd.Parameters("@Habilidad").Value = Habilidad
            cmd.Parameters("@Conocimiento").Value = Conocimiento
            cmd.Parameters("@Curso").Value = Curso



            cmd.CommandText = "select id from HR.Caracteristicas where Descripcion = @Descripcion and competencia = @Competencia and Habilidad = @Habilidad and Conocimiento = @Conocimiento and Curso = @Curso"
            Dim re As Integer = 0
            re = cmd.ExecuteScalar

            cmd.Parameters.AddWithValue("@QUE", QUE)
            cmd.Parameters.AddWithValue("@COMO", Como)
            cmd.Parameters.AddWithValue("@RECURSOS", recursos)
            cmd.Parameters.AddWithValue("@Extra", extra)
            cmd.Parameters.AddWithValue("@Desc", Description)
            cmd.Parameters.AddWithValue("@What", What)
            cmd.Parameters.AddWithValue("@How", How)
            cmd.Parameters.AddWithValue("@Res", Resources)
            If re > 0 Then
                ' Ya existe
                If Nuevo Then
                    'si es nuevo esta repetido 
                    Return 0
                ElseIf re = id Then
                    'si el que existe es el mismo que se esta editando
                    cmd.Parameters.AddWithValue("@id", id)
                    If nivel > 0 Then
                        'si tiene nivel
                        cmd.Parameters.AddWithValue("@Nivel", nivel)
                        cmd.CommandText = "Update HR.Caracteristicas SET Descripcion = @Descripcion,[Desarrollo de meta, que y por que] = @QUE ,Como = @COMO , Recursos = @Recursos ,Extraordinario = @Extra, Nivel = @Nivel,Description = @Desc,[Development Goal-Do + What + Why]=@What,How=@How,Resources = @Res  where id = @id"
                    Else
                        'Nivel nulo
                        cmd.CommandText = "Update HR.Caracteristicas SET Descripcion = @Descripcion,[Desarrollo de meta, que y por que] = @QUE ,Como = @COMO , Recursos = @Recursos,Extraordinario = @Extra , Nivel = Null ,Description = @Desc,[Development Goal-Do + What + Why]=@What,How=@How,Resources = @Res where id = @id"
                    End If

                    cmd.ExecuteNonQuery()
                    Return id
                Else
                    Return 0
                End If
            Else
                'Nuevo correcto

                If Nuevo Then
                    If nivel > 0 Then
                        'nuevo con nivel
                        cmd.Parameters.AddWithValue("@Nivel", nivel)
                        cmd.CommandText = "Insert into HR.Caracteristicas (Descripcion,Competencia,Habilidad,Conocimiento,Curso,Creado_User,Creado_Id_User,Nivel,[Desarrollo de meta, que y por que],Como, Recursos,Extraordinario,[Development Goal-Do + What + Why],How,Resources) values(@Descripcion,@Competencia,@Habilidad,@Conocimiento,@Curso,@Usuario,@CoUsuario,@Nivel,@QUE,@COMO,@RECURSOS,@Extra,@What,@How,@Res);Select @@IDENTITY"
                    Else
                        'nuevo sin nivel
                        cmd.CommandText = "Insert into HR.Caracteristicas (Descripcion,Competencia,Habilidad,Conocimiento,Curso,Creado_User,Creado_Id_User,[Desarrollo de meta, que y por que],Como, Recursos,Extraordinario,[Development Goal-Do + What + Why],How,Resources) values(@Descripcion,@Competencia,@Habilidad,@Conocimiento,@Curso,@Usuario,@CoUsuario,@QUE,@COMO,@RECURSOS,@Extra,@What,@How,@Res);Select @@IDENTITY"
                    End If
                    Dim res = cmd.ExecuteScalar
                    Return res
                Else
                    cmd.Parameters.AddWithValue("@id", id)
                    If nivel > 0 Then
                        cmd.Parameters.AddWithValue("@Nivel", nivel)
                        cmd.CommandText = "Update HR.Caracteristicas SET Descripcion = @Descripcion,[Desarrollo de meta, que y por que] = @QUE ,Como = @COMO , Recursos = @Recursos, Extraordinario = @Extra , Nivel = @Nivel, [Development Goal-Do + What + Why] = @What,How=@How,Resources=@Res where id = @id"
                    Else
                        cmd.CommandText = "Update HR.Caracteristicas SET Descripcion = @Descripcion,[Desarrollo de meta, que y por que] = @QUE ,Como = @COMO , Recursos = @Recursos, Extraordinario = @Extra , Nivel = Null, [Development Goal-Do + What + Why] = @What,How=@How,Resources=@Res where id = @id"
                    End If

                    cmd.ExecuteNonQuery()
                    Return id
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return -1
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function

    Shared Function EliminarCaracteristica(ByVal id As Integer)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            'da.SelectCommand.Parameters.Clear()
            'da.SelectCommand.CommandType = CommandType.Text
            'da.SelectCommand.Connection = CnMPS
            'da.SelectCommand.Parameters.AddWithValue("@Id", id)
            'da.SelectCommand.CommandText = "Delete from Hr.Caracteristicas where id = @Id"
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.Parameters.AddWithValue("@Id", id)
            cmd.CommandText = "Select Descripcion from HR.Caracteristicas where id = @id"
            Dim nombre As String = cmd.ExecuteScalar



            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.Parameters.AddWithValue("@Id", id)
            cmd.CommandText = "Delete from HR.Caracteristicas where id = @Id"
            cmd.ExecuteNonQuery()


            cmd.Parameters.AddWithValue("@Descripcion", "Usuario ha eliminado la caracteristica con id " & id & " :" & nombre)
            cmd.Parameters.AddWithValue("@User", My.Settings.Id_user)
            cmd.CommandText = "Insert into hr.Historial (Id_usuario,Accion) values(@User,@Descripcion)"
            cmd.ExecuteNonQuery()

            Return True

            'da.SelectCommand.CommandText = "Select * from HR.Instruccion_relacion  where Id_caracteristica = @id"
            'ds.Tables.Clear()
            'da.Fill(ds, "Instrucciones")

            'If ds.Tables("Instrucciones") IsNot Nothing Then
            '    For Each ro As DataRow In ds.Tables("Instrucciones").Rows
            '        eliminar_instruccion(ro.ItemArray(0))
            '    Next
            'End If
            'If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            'cmd.Parameters.Clear()
            'cmd.Connection = CnMPS
            'cmd.Parameters.AddWithValue("@Id", id)
            'cmd.CommandText = "Delete from HR.Caracteristicas where id = @Id"
            'cmd.ExecuteNonQuery()
            'Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

#End Region
#Region "Programaciones"
    Shared Function Agregar_programacion(ByVal cb_codigo As Integer, ByVal id_caracteristica As Integer, ByVal CU_CODIGO As String, ByVal Fecha As Date, ByVal Calificacion As Integer,
                                         ByVal nivel_requerido As Integer, ByVal id_ponderacion As Integer, ByVal comentario As String)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandText = ""
            cmd.Parameters.AddWithValue("@cb_codigo", cb_codigo)
            cmd.Parameters.AddWithValue("@Fecha", Fecha)
            cmd.Parameters.AddWithValue("@Calificacion", Calificacion)
            cmd.Parameters.AddWithValue("@Nivel_requerido", nivel_requerido)
            cmd.Parameters.AddWithValue("@id_ponderacion", id_ponderacion)
            cmd.Parameters.AddWithValue("@Comentario", comentario)

            If CU_CODIGO = "" Then
                cmd.Parameters.AddWithValue("@Id_categoria", id_caracteristica)
                cmd.CommandText = "Insert into Hr.Programacion (CB_CODIGO,Id_caracteristica,Fecha,Calificacion_esperada,Nivel_requerido,Id_ponderacion,Comentario)
                                    values (@cb_codigo,@Id_categoria,@Fecha,@Calificacion,@Nivel_requerido,@id_ponderacion,@Comentario)"
            Else
                cmd.Parameters.AddWithValue("@cu_codigo", CU_CODIGO)
                cmd.CommandText = "Insert into Hr.Programacion (CB_CODIGO,CU_CODIGO,Fecha,Calificacion_esperada,Nivel_requerido,Id_ponderacion,Comentario)
                                    values (@cb_codigo,@cu_codigo,@Fecha,@Calificacion,@Nivel_requerido,@id_ponderacion,@Comentario)"
            End If

            cmd.ExecuteNonQuery()

            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
#End Region
#Region "Cursos"
    Shared Function relaciones_cursos(ByVal codigo As String, ByVal Optional Solo_activos As Boolean = True)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@CUR", codigo)
            If Solo_activos Then
                da.SelectCommand.CommandText = "Select ir.id, ir.Id_caracteristica, ir.Solicitado_por, ir.Por_nivel, ir.Id_nivel, ir.Por_puesto,
                                                ir.Escalona, ir.Hereda, Str(ir.PU_INICIA) + '-'+ pu.PU_DESCRIP as PU_INICIA,
                                                Str(ir.PU_FINAL) + '-'+ puu.PU_DESCRIP as PU_FINAL,Activo,Por_empleado, cb_codigo  from Hr.Instruccion_relacion ir 
                                                Left() join hr.Puesto pu on ir.PU_INICIA = pu.PU_CODIGO
                                                Left join hr.Puesto puu on ir.PU_FINAL = puu.PU_CODIGO
                                                where activo = 1 and  CU_CODIGO = @CUR"
            Else
                da.SelectCommand.CommandText = "select ir.Id,case 
when Por_nivel = 1 then 'Nivel'
when Escalona = 1 then 'Puesto escalonado'
when Hereda = 1 then 'Puesto heredado'
when Por_puesto = 1 then 'Solo empleado'
when Por_empleado = 1 then 'Directo a empleado'
else 'No definido' end as 'Tipo', Solicitado_por, Por_nivel,ir.Id_nivel,Por_puesto,Escalona,Hereda,ir.PU_INICIA + ' -- '+ pu.PU_DESCRIP as PU_INICIA,
ir.PU_FINAL + ' -- '+ puu.PU_DESCRIP as PU_FINAL,Activo,Por_empleado,ir.CB_CODIGO, co.PRETTYNAME from hr.Instruccion_relacion ir 
left join hr.Puesto pu on ir.PU_INICIA = pu.PU_CODIGO
left join hr.Puesto puu on ir.PU_FINAL = puu.PU_CODIGO
left join tress.dbo.COLABORA co on ir.CB_CODIGO = co.CB_CODIGO
where CU_CODIGO = @CUR"
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
    Shared Function datos_cursos(ByVal codigo As String)
        Try

            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@Codigo", codigo)
            da.SelectCommand.CommandText = "Select * from Hr.Cursos_detalles where CU_CODIGO = @Codigo"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Datos")
            Return ds.Tables("Datos")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function agregar_detalles_CURSOS(ByVal codigo As String, ByVal Ingles As String, ByVal detalles As String)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Connection = CnMPS
            cmd.Parameters.AddWithValue("@CU_CODIGO", codigo)
            cmd.CommandText = "Select * from HR.Cursos_detalles where CU_CODIGO = @CU_CODIGO "
            Dim ra = cmd.ExecuteScalar

            cmd.Parameters.AddWithValue("@Ingles", Ingles)
            cmd.Parameters.AddWithValue("@Detalles", detalles)

            If ra IsNot Nothing Then
                cmd.CommandText = "Update Hr.Cursos_detalles set Ingles = @Ingles, Detalles = @Detalles where CU_CODIGO = @CU_CODIGO"
                cmd.ExecuteNonQuery()
            Else
                cmd.CommandText = "Insert into HR.Cursos_detalles (CU_CODIGO,Ingles,Detalles)VALUES(@CU_CODIGO,@Ingles,@Detalles)"
                cmd.ExecuteNonQuery()

            End If
            Return 1

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return -1
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

#Region "Relaciones"
    Shared Function agregar_relacion_curso(ByVal CU_CODIGO As String, ByVal Solicitado As String, ByVal Por_empleado As Boolean, ByVal Por_nivel As Boolean, ByVal Id_nivel As Integer,
                                     ByVal Por_puesto As Boolean, ByVal Escalona As Boolean, ByVal Hereda As Boolean, ByVal Puesto_inicial As String, ByVal Puesto_final As String, ByVal Activo As Boolean,
                                     ByVal Nuevo As Boolean, ByVal Optional Id As Integer = 0, ByVal Optional cb_codigo As Integer = Nothing, ByVal Optional Id_ponderacion As Integer = Nothing)

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
            cmd.Parameters.AddWithValue("@CU_CODIGO", CU_CODIGO)
            cmd.Parameters.AddWithValue("@SOL", Solicitado)
            cmd.Parameters.AddWithValue("@PNI", Por_nivel)
            cmd.Parameters.AddWithValue("@PPU", Por_puesto)
            cmd.Parameters.AddWithValue("@ACT", Activo)
            cmd.Parameters.AddWithValue("@PEMP", Por_empleado)
            cmd.Parameters.AddWithValue("@Ponderacion", Id_ponderacion)
         
            'LA RELACION ES NUEVA O ES UNA ACTUALIZACION***************************************************
            If Nuevo Then


#Region "Por nivel"
                If Por_nivel = True Then
                    'RELACION NUEVA POR NIVEL DE EMPLEADO------------------------------------------------------------------------



                    cmd.Parameters.AddWithValue("@INI", Id_nivel)
                    cmd.CommandType = CommandType.Text


                    'Revisar si existe una relacion identica **********************************************************************
                    cmd.CommandText = "Select id from HR.Instruccion_relacion where CU_CODIGO = @CU_CODIGO and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Id_nivel = @INI"
                    Dim ask = cmd.ExecuteScalar
                    If ask Is Nothing Then

                        'Revisar si existe una relacion que involucre los puestos requeridos para la caracteristica en cuestion********************************************************************************
                        cmd.CommandText = "Select id from HR.Instruccion_relacion where CU_CODIGO = @CU_CODIGO and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Id_nivel < @INI"
                        ask = cmd.ExecuteScalar
                        If ask Is Nothing Then

                            'Agregar nueva caracteristica y guardar valor en ID **************************************************************************************
                            cmd.CommandText = "Insert into HR.Instruccion_relacion (CU_CODIGO,Solicitado_por,Por_nivel,Por_puesto,Id_nivel,Activo,Por_empleado,Id_ponderacion)
                                   Values(@CU_CODIGO,@SOL,@PNI,@PPU,@INI,@ACT,@PEMP,@Ponderacion);SELECT @@IDENTITY"
                            Id = cmd.ExecuteScalar
                        Else
                            MsgBox("Ya existe una relacion que involucra los niveles de empleados solicitados", MsgBoxStyle.Critical)
                            Return 0
                        End If

                    Else
                        MsgBox("La relacion ingresada ya existe en el sistema", MsgBoxStyle.Critical)
                        Return 0
                    End If


                    CnMPS.Close()
                    If Activo = True Then
                        exec_instruccion_curso(Id)
                    End If
#End Region

                ElseIf Por_puesto Then 'Else if por nivel

                    'Relacion nueva por puesto--------------------------------------------------------------------------
                    cmd.Parameters.AddWithValue("@ESC", Escalona)
                    cmd.Parameters.AddWithValue("@HERE", Hereda)
                    cmd.Parameters.AddWithValue("@PUINI", Puesto_inicial)
                    cmd.CommandType = CommandType.Text


                    'Revisar si existe una relacion identica ***********************************************************************************************

#Region "Se escalona o se hereda"
                    If Escalona Or Hereda Then
                        If Puesto_final Is Nothing Then
                            cmd.CommandText = "Select  id from Hr.Instruccion_relacion where CU_CODIGO = @CU_CODIGO and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Escalona = @ESC and Hereda = @HERE and
                                        PU_INICIA = @PUINI and PU_FINAL is NULL"
                        Else
                            cmd.Parameters.AddWithValue("@PUFIN", Puesto_final)
                            cmd.CommandText = "Select  id from Hr.Instruccion_relacion where CU_CODIGO = @CU_CODIGO and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Escalona = @ESC and Hereda = @HERE and
                                        PU_INICIA = @PUINI and PU_FINAL = @PUFIN"
                        End If
                        Dim ask = cmd.ExecuteScalar
                        If ask Is Nothing Then
                            If Puesto_final Is Nothing Then
                                cmd.CommandText = "Insert into HR.Instruccion_relacion(CU_CODIGO, Solicitado_por,Por_nivel,Por_puesto,Escalona,Hereda,PU_INICIA,PU_FINAL,Activo,Por_empleado,Id_ponderacion)
                                       Values(@CU_CODIGO,@SOL,@PNI,@PPU,@ESC,@HERE,@PUINI,NULL,@ACT,0,@Ponderacion);SELECT @@IDENTITY"
                            Else
                                cmd.CommandText = "Insert into HR.Instruccion_relacion(CU_CODIGO, Solicitado_por,Por_nivel,Por_puesto,Escalona,Hereda,PU_INICIA,PU_FINAL,Activo,Por_empleado,Id_ponderacion)
                                       Values(@CU_CODIGO,@SOL,@PNI,@PPU,@ESC,@HERE,@PUINI,@PUFIN,@ACT,0,@Ponderacion);SELECT @@IDENTITY"
                            End If
                            Id = cmd.ExecuteScalar
                            CnMPS.Close()
                            If Activo = True Then
                                exec_instruccion_curso(Id)
                            End If
                        Else
                            MsgBox("La relacion ingresada ya existe en el sistema", MsgBoxStyle.Critical)
                            Return 0
                        End If
#End Region

                    Else
                        'Solo puesto

                        If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                        cmd.Parameters("@PUINI").Value = Puesto_inicial
                        If Puesto_final Is Nothing Then
                            cmd.CommandText = "Select  id from Hr.Instruccion_relacion where CU_CODIGO = @CU_CODIGO and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Escalona = @ESC and Hereda = @HERE and
                                        PU_INICIA = @PUINI and PU_FINAL is NULL"
                        Else
                            cmd.Parameters.AddWithValue("@PUFIN", Puesto_final)
                            cmd.CommandText = "Select  id from Hr.Instruccion_relacion where CU_CODIGO = @CU_CODIGO and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Escalona = @ESC and Hereda = @HERE and
                                        PU_INICIA = @PUINI and PU_FINAL = @PUFIN"
                        End If
                        Dim ask = cmd.ExecuteScalar
                        If ask Is Nothing Then

                            If Puesto_final Is Nothing Then
                                cmd.CommandText = "Insert into HR.Instruccion_relacion(CU_CODIGO, Solicitado_por,Por_nivel,Por_puesto,Escalona,Hereda,PU_INICIA,PU_FINAL,Activo,Id_ponderacion)
                                       Values(@CU_CODIGO,@SOL,@PNI,@PPU,@ESC,@HERE,@PUINI,NULL,@ACT,@Ponderacion);SELECT @@IDENTITY"
                            Else
                                cmd.CommandText = "Insert into HR.Instruccion_relacion(CU_CODIGO, Solicitado_por,Por_nivel,Por_puesto,Escalona,Hereda,PU_INICIA,PU_FINAL,Activo,Id_ponderacion)
                                       Values(@CU_CODIGO,@SOL,@PNI,@PPU,@ESC,@HERE,@PUINI,@PUFIN,@ACT,@Ponderacion);SELECT @@IDENTITY"
                            End If
                            Id = cmd.ExecuteScalar
                            CnMPS.Close()
                            If Activo = True Then
                                exec_instruccion_curso(Id)
                            End If
                        Else
                            MsgBox("Ya existe una relacion identica", MsgBoxStyle.Critical)
                            Return 0
                        End If

                    End If
                ElseIf Por_empleado Then
                    If CnMPS.State = ConnectionState.Closed Then
                        CnMPS.ConnectionString = constringMPS()
                        CnMPS.Open()
                    End If
                    cmd.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
                    cmd.CommandText = "Select id from HR.Instruccion_relacion where CU_CODIGO = @CU_CODIGO and Solicitado_por = @SOL and Por_nivel = @PNI and Por_puesto = @PPU and Por_empleado = @PEMP and Id_ponderacion = @Ponderacion and CB_CODIGO = @CB_CODIGO"
                    Dim ask = cmd.ExecuteScalar
                    If ask Is Nothing Then
                        cmd.CommandText = "Insert into Hr.Instruccion_relacion(CU_CODIGO,Solicitado_por,Por_nivel,Por_puesto,Activo,Por_empleado,CB_CODIGO,Id_ponderacion)
                                            Values(@CU_CODIGO,@SOL,@PNI,@PPU,@ACT,@PEMP,@CB_CODIGO,@Ponderacion); SELECT @@IDENTITY"
                        Id = cmd.ExecuteScalar
                        CnMPS.Close()
                        If Activo = True Then
                            exec_instruccion_curso(Id)
                        End If
                    Else
                        MsgBox("Ya existe una relacion identica", MsgBoxStyle.Critical)
                        Return 0
                    End If
                End If ' End if por nivel
            Else   'Else if nuevo
                'Actualizar relacion*****************************************************************************
                If Por_nivel = True Then
                    'Actualizar por nivel-------------------------------------------------------------
                Else
                    'Actualizar por puesto ------------------------------------------------------------------
                End If
            End If ' End if nuevo

            Return 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function agregar_relacion_multiple_curso(ByVal CU_CODIGO As String, ByVal Solicitado As String, ByVal Por_empleado As Boolean,
                                     ByVal Por_puesto As Boolean, ByVal Puestos_lista As List(Of Puesto_descripcion), ByVal Empleados_lista As List(Of empleados), ByVal Activo As Boolean,
                                     ByVal Nuevo As Boolean, ByVal Id_ponderacion As Integer)
        Try

            Dim puestos_a_calificar As New List(Of Puesto_descripcion)
            Dim empleados_a_calificar As New List(Of empleados)

            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            ds.Tables.Clear()
            cmd.Parameters.AddWithValue("@CU_CODIGO", CU_CODIGO)
            cmd.Parameters.AddWithValue("@SOL", Solicitado)
            cmd.Parameters.AddWithValue("@PPU", Por_puesto)
            cmd.Parameters.AddWithValue("@ACT", Activo)
            cmd.Parameters.AddWithValue("@PEMP", Por_empleado)
            cmd.Parameters.AddWithValue("@Ponderacion", Id_ponderacion)
            Dim instrucciones As New List(Of Integer)
            'LA RELACION ES NUEVA O ES UNA ACTUALIZACION***************************************************
            If Nuevo Then
                If CnMPS.State = ConnectionState.Closed Then
                    CnMPS.ConnectionString = constringMPS()
                    CnMPS.Open()
                End If
                If Por_puesto Then 'Else if por nivel


                    'Relacion nueva por puesto--------------------------------------------------------------------------
                    cmd.Parameters.Add("@PUINI", SqlDbType.VarChar)
                    For Each pues As Puesto_descripcion In Puestos_lista
                        cmd.Parameters("@PUINI").Value = pues.pu_codigo
                        cmd.CommandType = CommandType.Text
                        'Revisar si existe una relacion identica ***********************************************************************************************
                        cmd.CommandText = "Select  id from Hr.Instruccion_relacion where CU_CODIGO = @CU_CODIGO and Solicitado_por = @SOL and Por_nivel = 0 and Por_puesto = 1 and Escalona = 0 and Hereda = 0 and
                                        PU_INICIA = @PUINI and PU_FINAL is NULL"
                        Dim ask = cmd.ExecuteScalar
                        If ask Is Nothing Then
                            cmd.CommandText = "Insert into HR.Instruccion_relacion(CU_CODIGO, Solicitado_por,Por_puesto,PU_INICIA,Activo,Id_ponderacion)
                                       Values(@CU_CODIGO,@SOL,1,@PUINI,@ACT,@Ponderacion);SELECT @@IDENTITY"
                            Dim Id = cmd.ExecuteScalar
                            instrucciones.Add(Id)
                            puestos_a_calificar.Add(pues)
                        End If
                    Next

                ElseIf Por_empleado Then
                    cmd.Parameters.Add("@CB_CODIGO", SqlDbType.Int)
                    For Each emp As empleados In Empleados_lista
                        cmd.Parameters("@CB_CODIGO").Value = emp.cb_codigo
                        cmd.CommandText = "Select id from HR.Instruccion_relacion where CU_CODIGO = @CU_CODIGO and Solicitado_por = @SOL and Por_nivel = 0 and Por_puesto = 0 and Por_empleado = 1 and Id_ponderacion = @Ponderacion and CB_CODIGO = @CB_CODIGO"
                        Dim ask = cmd.ExecuteScalar
                        If ask Is Nothing Then
                            cmd.CommandText = "Insert into Hr.Instruccion_relacion(CU_CODIGO,Solicitado_por,Activo,Por_empleado,CB_CODIGO,Id_ponderacion)
                                            Values(@CU_CODIGO,@SOL,@ACT,1,@CB_CODIGO,@Ponderacion); SELECT @@IDENTITY"
                            Dim id = cmd.ExecuteScalar
                            instrucciones.Add(id)
                            empleados_a_calificar.Add(emp)
                        End If
                    Next
                End If
            Else
            End If
            If instrucciones.Count > 0 Then
                exec_instruccion_multiple_curso(CU_CODIGO, instrucciones, puestos_a_calificar, empleados_a_calificar, Por_puesto, Id_ponderacion)
            End If
            Return 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function eliminar_instruccion_curso(ByVal id_instruccion As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()

            'ELIMINAR RELACIONRES_PTO_CARAC
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Delete from [HR].[Relaciones_pto_carac] where id_relacion = @Id_rel"
            cmd.Parameters.AddWithValue("@Id_rel", id_instruccion)
            cmd.ExecuteNonQuery()


            'ELIMINAR RELACIONES_REPETIDAS DONDE ID_INSTRUCCION SEA SECUNDARIO
            cmd.CommandText = "Delete from [HR].[Relaciones_repetidas] where id_relacion_repetido = @Id_rel"
            cmd.ExecuteNonQuery()



            'EJECUTAR INSTRUCCIONES DONDE ID_INSTRUCCION SEA PRINCIPAL
            Console.Write("")
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@Id_instruccion", id_instruccion)
            da.SelectCommand.CommandText = "Select * from HR.Relaciones_repetidas where Id_relacion_principal = @Id_instruccion Order by Id_relacion_repetido"
            If ds.Tables("ElPRI") IsNot Nothing Then
                ds.Tables.Remove("ElPRI")
            End If
            da.Fill(ds, "ElPRI")
            For Each ro As DataRow In ds.Tables("ElPRI").Rows
                Console.WriteLine("")
                exec_instruccion(ro.ItemArray(2))
            Next

            'ELIMINAR RELACIONES_REPETIDAS
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Id_rel", id_instruccion)
            cmd.CommandText = "Delete from [HR].[Relaciones_repetidas] where id_relacion_principal = @Id_rel"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "Delete from [HR].[Instruccion_relacion] where id = @Id_rel"
            cmd.ExecuteNonQuery()

            'ELIMINAR DE INSTRUCCIONES


            'da.SelectCommand.CommandText = "Select * from Hr.Relaciones_repetidas where Id_relacion_repetido = @Id_instruccion"
            'da.Fill(ds, "A quien pasaba")
            'Console.WriteLine("")

            'If ds.Tables("Heredar").Rows.Count > 0 Then
            '    If ds.Tables("A quien pasaba").Rows.Count > 0 Then
            '        'Caso 2 y 3
            '        cmd.Parameters.Clear()
            '        cmd.Parameters.AddWithValue("@id_rel", id_instruccion)
            '        cmd.CommandType = CommandType.Text
            '        cmd.CommandText = "Delete from HR.Relaciones_pto_carac where id_relacion = @id_rel"
            '        cmd.ExecuteNonQuery()
            '        For Each ro As DataRow In ds.Tables("Heredar").Rows
            '        Next
            '    Else
            '        'Caso 1
            '        cmd.Parameters.Clear()
            '        cmd.Parameters.AddWithValue("@id_rel", id_instruccion)
            '        cmd.CommandType = CommandType.Text
            '        cmd.CommandText = "Delete From Hr.Relaciones_pto_carac where id_relacion = @id_rel"
            '        Dim r = cmd.ExecuteNonQuery()
            '        For Each ro As DataRow In ds.Tables("Heredar").Rows
            '            exec_instruccion(ro.ItemArray(0))
            '        Next
            '        cmd.CommandText = "Delete * from HR.Relaciones_repetidas where id_relacion_principal = @id_rel "
            '        r = cmd.ExecuteNonQuery()
            '    End If
            'Else
            '    If ds.Tables("A quien pasaba").Rows.Count > 0 Then
            '        'Caso 4

            '    Else
            '        'Caso 5
            '        cmd.CommandType = CommandType.Text
            '        cmd.Parameters.Clear()
            '        cmd.Parameters.AddWithValue("@id_rel", id_instruccion)
            '        cmd.CommandText = "Delete * from HR.Relaciones_pto_carac where id_relacion = @id_rel"
            '        Dim r = cmd.ExecuteNonQuery
            '    End If
            'End If
            Return True

        Catch ex As Exception
            Return False
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function exec_instruccion_curso(ByVal id_instruccion As Integer) As Integer
        Try

#Region "Configuracion inicial"
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.AddWithValue("@Id", id_instruccion)

#Region "Eliminar tablas"
            If ds.Tables("relac") IsNot Nothing Then
                ds.Tables.Remove("relac")
            End If
            If ds.Tables("Her") IsNot Nothing Then
                ds.Tables.Remove("Her")
            End If
            If ds.Tables("HerEsc") IsNot Nothing Then
                ds.Tables.Remove("HerEsc")
            End If
            If ds.Tables("Repetidas") IsNot Nothing Then
                ds.Tables.Remove("Repetidas")
            End If
            If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                ds.Tables.Remove("Relaciones_repetidas")
            End If
            If ds.Tables("Otras_carac") IsNot Nothing Then
                ds.Tables.Remove("Otras_carac")
            End If

#End Region
#Region "Cargar tablas"
            da.SelectCommand.CommandText = "Select * from HR.Instruccion_relacion where id = @Id"

            da.Fill(ds, "relac")

            da.SelectCommand.CommandText = "Select * from HR.Relaciones_repetidas where Id_relacion_principal = @Id"
            da.Fill(ds, "Her")

            da.SelectCommand.CommandText = "Select * from Hr.Relaciones_repetidas where Id_relacion_repetido = @Id"
            da.Fill(ds, "HerEsc")

            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@CU_CO", ds.Tables("relac").Rows(0).Item("CU_CODIGO"))
            da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO = @CU_CO) Or 
            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO = @CU_CO)"
            da.Fill(ds, "Relaciones_repetidas")

            da.SelectCommand.CommandText = "Select * from Hr.Cursos_detalles where CU_CODIGO = @CU_CO"
            da.Fill(ds, "Otras_carac")

            da.SelectCommand.CommandText = "Select * from TRESS.DBO.CURSO where CU_CODIGO = @CU_CO"
            da.Fill(ds, "Tipo")
#End Region


            'SI HAY DATOS COMENZAMOS A TRABAJAR
            If ds.Tables("relac").Rows.Count > 0 Then


                Dim CU_CODIGO As String = ds.Tables("relac").Rows(0).Item("CU_CODIGO")
                Dim nivel_compt As Integer = 0
                Dim solicitado_por = ds.Tables("relac").Rows(0).Item("Solicitado_por")
                Dim id_nivel = ds.Tables("relac").Rows(0).Item("Id_nivel")
                Dim Hereda = ds.Tables("relac").Rows(0).Item("Hereda")
                Dim Escalona = ds.Tables("relac").Rows(0).Item("Escalona")
                Dim Puesto_inicial = ""
                Puesto_inicial = ds.Tables("relac").Rows(0).Item("PU_INICIA").ToString
                Dim Puesto_final = ""
                Puesto_final = ds.Tables("relac").Rows(0).Item("PU_FINAL").ToString
                Dim cb_codigo = ds.Tables("relac").Rows(0).Item("CB_CODIGO")
                Dim id_ponderacion = ds.Tables("relac").Rows(0).Item("Id_ponderacion")

                If id_nivel.ToString = "" Then id_nivel = 0
                If cb_codigo.ToString = "" Then cb_codigo = 0
                If Puesto_inicial.ToString = "" Then Puesto_inicial = ""
                If Puesto_final.ToString = "" Then Puesto_final = ""

#End Region
#Region "Cargar puestos, relaciones y calificaciones"
                Dim tab As DataTable = Puestos_a_relacionar(ds.Tables("relac").Rows(0).Item("Por_nivel"), ds.Tables("relac").Rows(0).Item("Por_puesto"), ds.Tables("relac").Rows(0).Item("Por_empleado"),
                                       id_nivel, Hereda, Escalona, Puesto_inicial, Puesto_final, cb_codigo).Copy
                tab.TableName = "Puestos"
                If ds.Tables("Puestos") IsNot Nothing Then
                    ds.Tables.Remove("Puestos")
                End If
                ds.Tables.Add(tab)
                Dim Lista_niveles_requeridos
                Dim ri As String = ""
                ri = "Curso"

                If ds.Tables("relac").Rows(0).Item("Por_empleado") = True Then
                    Lista_niveles_requeridos = New List(Of empleados)
                    Lista_niveles_requeridos = calificar_por_empleado_curso(CU_CODIGO, False, nivel_compt, id_ponderacion, "Relaciones", ri)
                Else
                    Lista_niveles_requeridos = New List(Of requerido)


                    Lista_niveles_requeridos = calificar_curso(CU_CODIGO, False, nivel_compt, id_ponderacion, "Relaciones", ri)
                End If


#End Region
#Region "Ejecutar relaciones"

                If CnMPS.State = ConnectionState.Closed Then
                    CnMPS.ConnectionString = constringMPS()
                    CnMPS.Open()
                End If
                For Each ro As DataRow In ds.Tables("Puestos").Rows
                    If ds.Tables("relac").Rows(0).Item("Por_empleado") = False Then
#Region "Por puestos"
                        'PREGUNTAR SI YA EXISTE UNA RELACION PARA CADA PUESTO ************************************************************
                        Dim bu = ds.Tables("Relaciones").Select("PU_CODIGO = '" & ro.ItemArray(1).ToString & "'")
                        If bu.Length > 0 Then

                            'La caracteristica ya esta relacionada con ese puesto
                            If id_instruccion <> bu(0).ItemArray(5) Then 'SABER SI ES LA MISMA RELACION ****************************************

                                'ES UNA RELACION DIFERENTE LA QUE EXISTE
                                If id_instruccion > bu(0).ItemArray(5) Then
                                    'SI LA RELACION ES MAS RECIENTE
                                    Dim r As Integer = 0
                                    If ds.Tables("Relaciones_repetidas").Select("Id_relacion_principal = " & id_instruccion & " and Id_relacion_repetido = " & bu(0).ItemArray(5)).Count > 0 Then
                                        'Actualizar registro
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                                        cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                        cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                        Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido
                                        cmd.Parameters.AddWithValue("@REQ", cal)
                                        cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where CU_CODIGO = @CUR and PU_CODIGO = @PU_CODIGO"
                                        cmd.ExecuteNonQuery()

                                    Else
                                        'crear relacion y actualizar registro
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                                        cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                        cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                        Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido
                                        cmd.Parameters.AddWithValue("@REQ", cal)
                                        cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where CU_CODIGO = @CUR and PU_CODIGO = @PU_CODIGO"
                                        cmd.ExecuteNonQuery()
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@IDold", bu(0).ItemArray(5))
                                        cmd.Parameters.AddWithValue("@IDnew", id_instruccion)
                                        cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido) VALUES(@IDnew,@IDold)"
                                        cmd.ExecuteNonQuery()
                                        If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                            ds.Tables.Remove("Relaciones_repetidas")
                                        End If
                                        da.SelectCommand.Parameters.Clear()
                                        da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("Id_caracteristica"))
                                        da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                        da.Fill(ds, "Relaciones_repetidas")

                                    End If
                                    If r = 0 Then

                                    End If
                                Else
                                    'SI LA RELACION ES ANTIGUA
                                    'BUSCAR ENTRE LAS RELACIONES DE LA ID_INSTRUCCION SI YA EXISTE CONEXION CON LA ACTUAL 
                                    Dim bus = relup(id_instruccion, bu(0).ItemArray(5))
                                    If bus.res = True Then
                                        'SI EXISTE CONEXION
                                        Console.WriteLine()
                                    Else
                                        'SI NO EXISTE RELACION
                                        cmd.Parameters.Clear()
                                        cmd.Connection = CnMPS
                                        cmd.CommandType = CommandType.Text
                                        If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                                        cmd.Parameters.AddWithValue("@Id_rel_pri", bu(0).ItemArray(5))
                                        cmd.Parameters.AddWithValue("@Id_rel_rep", id_instruccion)
                                        cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
                                        cmd.ExecuteNonQuery()
#Region "Recargar tabla de relaciones"
                                        If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                            ds.Tables.Remove("Relaciones_repetidas")
                                        End If
                                        da.SelectCommand.Parameters.Clear()
                                        da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("CU_CODIGO"))
                                        da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                        da.Fill(ds, "Relaciones_repetidas")

#End Region
                                    End If
                                End If
                            Else
                                'NO ES NECESARIO REALIZAR UNA RELACION****************************************
                            End If

                        Else
                            'REALIZAR RELACION NUEVA *********************************************************

                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                            cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)

                            Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido

                            cmd.Parameters.AddWithValue("@Nivreq", cal)
                            cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                            cmd.CommandType = CommandType.Text
                            cmd.Connection = CnMPS
                            cmd.CommandText = "Insert Into HR.Relaciones_pto_carac (CU_CODIGO,PU_CODIGO,Nivel_requerido,Id_relacion) VALUES ( @CUR,@PU_CODIGO,@Nivreq,@IDREL)"
                            cmd.ExecuteNonQuery()
                        End If
#End Region
                    Else
#Region "Por empleado"
                        Dim bu = ds.Tables("Relaciones").Select("CB_CODIGO = '" & ro.ItemArray(0).ToString & "'")
                        If bu.Length > 0 Then
                            If id_instruccion <> bu(0).ItemArray(5) Then
                                'ES UNA RELACION DIFERENTE LA QUE EXISTE
                                If id_instruccion > bu(0).ItemArray(5) Then
                                    'SI LA RELACION ES MAS RECIENTE
                                    Dim r As Integer = 0
                                    If ds.Tables("Relaciones_repetidas").Select("Id_relacion_principal = " & id_instruccion & " and Id_relacion_repetido = " & bu(0).ItemArray(5)).Count > 0 Then
                                        'Actualizar registro
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                                        cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                        cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                        Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                                        cmd.Parameters.AddWithValue("@REQ", cal)
                                        cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where CU_CODIGO = @CUR and PU_CODIGO = @PU_CODIGO"
                                        cmd.ExecuteNonQuery()

                                    Else
                                        'crear relacion y actualizar registro
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                                        cmd.Parameters.AddWithValue("@CB_CODIGO", ro.ItemArray(0))
                                        cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                        Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                                        cmd.Parameters.AddWithValue("@REQ", cal)
                                        cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where CU_CODIGO = @CUR and CB_CODIGO = @CB_CODIGO"
                                        cmd.ExecuteNonQuery()
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("@IDold", bu(0).ItemArray(5))
                                        cmd.Parameters.AddWithValue("@IDnew", id_instruccion)
                                        cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido) VALUES(@IDnew,@IDold)"
                                        cmd.ExecuteNonQuery()
                                        If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                            ds.Tables.Remove("Relaciones_repetidas")
                                        End If
                                        da.SelectCommand.Parameters.Clear()
                                        da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("CU_CODIGO"))
                                        da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                        da.Fill(ds, "Relaciones_repetidas")

                                    End If
                                    If r = 0 Then

                                    End If
                                Else
                                    'SI LA RELACION ES ANTIGUA
                                    'BUSCAR ENTRE LAS RELACIONES DE LA ID_INSTRUCCION SI YA EXISTE CONEXION CON LA ACTUAL 
                                    Dim bus = relup(id_instruccion, bu(0).ItemArray(5))
                                    If bus.res = True Then
                                        'SI EXISTE CONEXION
                                        Console.WriteLine()
                                    Else
                                        'SI NO EXISTE RELACION
                                        cmd.Parameters.Clear()
                                        cmd.Connection = CnMPS
                                        cmd.CommandType = CommandType.Text
                                        If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                                        cmd.Parameters.AddWithValue("@Id_rel_pri", bu(0).ItemArray(5))
                                        cmd.Parameters.AddWithValue("@Id_rel_rep", id_instruccion)
                                        cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
                                        cmd.ExecuteNonQuery()
#Region "Recargar tabla de relaciones"
                                        If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                            ds.Tables.Remove("Relaciones_repetidas")
                                        End If
                                        da.SelectCommand.Parameters.Clear()
                                        da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("CU_CODIGO"))
                                        da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where Id_caracteristica = @Id)"
                                        da.Fill(ds, "Relaciones_repetidas")

#End Region
                                    End If
                                End If
                            End If
                        Else

                            cmd.CommandType = CommandType.Text
                            cmd.Connection = CnMPS
                            cmd.Parameters.Clear()
                            cmd.CommandText = "Insert into HR.Relaciones_pto_carac (CU_CODIGO,PU_CODIGO,CB_CODIGO,Nivel_requerido,Id_relacion)Values(@CUR,NULL,@CB_CODIGO,@NR,@IDREL)"
                            cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                            cmd.Parameters.AddWithValue("@CB_CODIGO", ro.ItemArray(0))
                            Dim cal As Integer = CType(Lista_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                            cmd.Parameters.AddWithValue("@NR", cal) 'FALTA PREGRUNTAR POR EL NIVEL REQUERIDO
                            cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                            cmd.ExecuteNonQuery()


                        End If
#End Region
                    End If
                Next
#End Region
            End If

            Return 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function exec_instruccion_multiple_curso(ByVal CU_CODIGO As String, ByVal Instrucciones As List(Of Integer), ByVal Puestoss As List(Of Puesto_descripcion), ByVal Empleadoss As List(Of empleados), ByVal ESPuesto As Boolean, ByVal Id_ponderacion As Integer)
        Try
#Region "Configuracion inicial"
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If CnMPS.State = ConnectionState.Closed Then CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Connection = CnMPS
            Dim Filtro As String = "(0,"
            For Each i As Integer In Instrucciones
                Filtro = Filtro & " " & i & ","
            Next
            Filtro = Filtro & " -1)"
            '  da.SelectCommand.Parameters.AddWithValue("@Id", Filtro)

#Region "Eliminar tablas"
            If ds.Tables("relac") IsNot Nothing Then
                ds.Tables.Remove("relac")
            End If
            If ds.Tables("Her") IsNot Nothing Then
                ds.Tables.Remove("Her")
            End If
            If ds.Tables("HerEsc") IsNot Nothing Then
                ds.Tables.Remove("HerEsc")
            End If
            If ds.Tables("Repetidas") IsNot Nothing Then
                ds.Tables.Remove("Repetidas")
            End If
            If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                ds.Tables.Remove("Relaciones_repetidas")
            End If
            If ds.Tables("Otras_carac") IsNot Nothing Then
                ds.Tables.Remove("Otras_carac")
            End If

#End Region
#Region "Cargar tablas"
            da.SelectCommand.CommandText = "Select * from HR.Instruccion_relacion where id in " & Filtro

            da.Fill(ds, "relac")

            da.SelectCommand.CommandText = "Select * from HR.Relaciones_repetidas where Id_relacion_principal in " & Filtro
            da.Fill(ds, "Her")

            da.SelectCommand.CommandText = "Select * from Hr.Relaciones_repetidas where Id_relacion_repetido in " & Filtro
            da.Fill(ds, "HerEsc")

            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("CU_CODIGO"))
            da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO =@Id) Or 
            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO =@Id)"
            da.Fill(ds, "Relaciones_repetidas")

            da.SelectCommand.CommandText = "Select * from Hr.Cursos_detalles where CU_CODIGO = @Id"
            da.Fill(ds, "Otras_carac")
            da.SelectCommand.CommandText = "Select * from TRESS.DBO.CURSO where CU_CODIGO = @Id"
            da.Fill(ds, "Tipo")

#End Region


            'SI HAY DATOS COMENZAMOS A TRABAJAR
            If ds.Tables("relac").Rows.Count > 0 Then

                Dim nivel_compt As Integer = 0
#End Region

#Region "Cargar puestos, relaciones y calificaciones"
                Dim tab As New DataTable

                If ESPuesto Then

                    tab.Columns.Add("Id")
                    tab.Columns.Add("PU_CODIGO")
                    tab.Columns.Add("PU_DESCRIP")
                    tab.Columns.Add("PU_PARENT")
                    tab.Columns.Add("Id_Nivel")
                    tab.Columns.Add("PU_ACTIVO")
                    For Each pu As Puesto_descripcion In Puestoss
                        Dim tab2 As DataTable = Puestos_a_relacionar(0, 1, 0, Nothing, 0, 0, pu.pu_codigo, Nothing, 0).Copy
                        tab.ImportRow(tab2.Rows(0))
                        Console.WriteLine("")
                    Next
                Else
                    tab.Columns.Add("Numero de empleado")
                    tab.Columns.Add("Nombre")
                    tab.Columns.Add("Departamento")
                    tab.Columns.Add("Puesto")
                    tab.Columns.Add("Id_Nivel")
                    For Each co As empleados In Empleadoss
                        Dim tab2 As DataTable = Puestos_a_relacionar(0, 0, 1, Nothing, 0, 0, Nothing, Nothing, co.cb_codigo)
                        tab.ImportRow(tab2.Rows(0))
                    Next


                End If




                tab.TableName = "Puestos"
                If ds.Tables("Puestos") IsNot Nothing Then
                    ds.Tables.Remove("Puestos")
                End If
                ds.Tables.Add(tab)
                Dim LIsta_niveles_requeridos
                Dim ri As String = "Curso"

                If ESPuesto Then
                    LIsta_niveles_requeridos = New List(Of requerido)
                    LIsta_niveles_requeridos = calificar_curso(CU_CODIGO, False, nivel_compt, Id_ponderacion, "Relaciones", ri)
                Else
                    LIsta_niveles_requeridos = New List(Of empleados)
                    LIsta_niveles_requeridos = calificar_por_empleado_curso(CU_CODIGO, False, nivel_compt, Id_ponderacion, "Relaciones", ri, True)
                End If



#End Region

#Region "Ejecutar relaciones"

                If CnMPS.State = ConnectionState.Closed Then
                    CnMPS.ConnectionString = constringMPS()
                    CnMPS.Open()
                End If
                Dim id_instruccion As Integer = 0

                If ESPuesto Then
                    If ds.Tables("Puestos") IsNot Nothing Then
                        For Each ro As DataRow In ds.Tables("Puestos").Rows
                            If ds.Tables("relac").Select("PU_INICIA = '" & ro.ItemArray(1).ToString & "'").Length > 0 Then
                                id_instruccion = ds.Tables("relac").Select("PU_INICIA = '" & ro.ItemArray(1).ToString & "'")(0).ItemArray(0)
                                Dim bu = ds.Tables("Relaciones").Select("PU_CODIGO = '" & ro.ItemArray(1).ToString & "'")
                                If bu.Length > 0 Then
                                    If id_instruccion <> bu(0).ItemArray(5) Then

                                        If id_instruccion > bu(0).ItemArray(5) Then
                                            Dim r As Integer = 0
                                            If ds.Tables("Relaciones_repetidas").Select("Id_relacion_principal = " & id_instruccion & " and Id_relacion_repetido = " & bu(0).ItemArray(5)).Count > 0 Then
                                                'Actualizar registro
                                                cmd.Parameters.Clear()
                                                cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                                                cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                                cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                                Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido
                                                cmd.Parameters.AddWithValue("@REQ", cal)
                                                cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where CU_CODIGO = @CUR and PU_CODIGO = @PU_CODIGO"
                                                cmd.ExecuteNonQuery()

                                            Else
                                                'crear relacion y actualizar registro
                                                cmd.Parameters.Clear()
                                                cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                                                cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                                cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                                Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido
                                                cmd.Parameters.AddWithValue("@REQ", cal)
                                                cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where CU_CODIGO = @CUR and PU_CODIGO = @PU_CODIGO"
                                                cmd.ExecuteNonQuery()
                                                cmd.Parameters.Clear()
                                                cmd.Parameters.AddWithValue("@IDold", bu(0).ItemArray(5))
                                                cmd.Parameters.AddWithValue("@IDnew", id_instruccion)
                                                cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido) VALUES(@IDnew,@IDold)"
                                                cmd.ExecuteNonQuery()
                                                If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                                    ds.Tables.Remove("Relaciones_repetidas")
                                                End If
                                                da.SelectCommand.Parameters.Clear()
                                                da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("CU_CODIGO"))
                                                da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO= @Id)"
                                                da.Fill(ds, "Relaciones_repetidas")
                                            End If
                                        Else
                                            'SI LA RELACION ES ANTIGUA
                                            'BUSCAR ENTRE LAS RELACIONES DE LA ID_INSTRUCCION SI YA EXISTE CONEXION CON LA ACTUAL 
                                            Dim bus = relup(id_instruccion, bu(0).ItemArray(5))
                                            If bus.res = True Then
                                                'SI EXISTE CONEXION
                                                Console.WriteLine()
                                            Else
                                                'SI NO EXISTE RELACION
                                                cmd.Parameters.Clear()
                                                cmd.Connection = CnMPS
                                                cmd.CommandType = CommandType.Text
                                                If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                                                cmd.Parameters.AddWithValue("@Id_rel_pri", bu(0).ItemArray(5))
                                                cmd.Parameters.AddWithValue("@Id_rel_rep", id_instruccion)
                                                cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
                                                cmd.ExecuteNonQuery()
#Region "Recargar tabla de relaciones"
                                                If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                                    ds.Tables.Remove("Relaciones_repetidas")
                                                End If
                                                da.SelectCommand.Parameters.Clear()
                                                da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("CU_CODIGO"))
                                                da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO= @Id)"
                                                da.Fill(ds, "Relaciones_repetidas")

#End Region
                                            End If



                                        End If
                                    End If
                                Else

                                    cmd.Parameters.Clear()
                                    cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                                    cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)

                                    Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of requerido)).Find(Function(z) z.pu_codigo = ro.ItemArray(1).ToString).requerido

                                    cmd.Parameters.AddWithValue("@Nivreq", cal)
                                    cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                    cmd.CommandType = CommandType.Text
                                    cmd.Connection = CnMPS
                                    cmd.CommandText = "Insert Into HR.Relaciones_pto_carac (CU_CODIGO,PU_CODIGO,Nivel_requerido,Id_relacion) VALUES ( @CUR,@PU_CODIGO,@Nivreq,@IDREL)"
                                    cmd.ExecuteNonQuery()
                                End If
                            End If
                        Next
                    End If
                Else

                    ' Por empleado
                    If ds.Tables("Puestos") IsNot Nothing Then
                        For Each ro As DataRow In ds.Tables("Puestos").Rows
                            id_instruccion = ds.Tables("relac").Select("CB_CODIGO = " & ro.ItemArray(0))(0).ItemArray(0)
                            Dim bu = ds.Tables("Relaciones").Select("CB_CODIGO = '" & ro.ItemArray(0).ToString & "'")
                            If bu.Length > 0 Then
                                If id_instruccion <> bu(0).ItemArray(5) Then
                                    'ES UNA RELACION DIFERENTE LA QUE EXISTE
                                    If id_instruccion > bu(0).ItemArray(5) Then
                                        'SI LA RELACION ES MAS RECIENTE
                                        Dim r As Integer = 0
                                        If ds.Tables("Relaciones_repetidas").Select("Id_relacion_principal = " & id_instruccion & " and Id_relacion_repetido = " & bu(0).ItemArray(5)).Count > 0 Then
                                            'Actualizar registro
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                                            cmd.Parameters.AddWithValue("@PU_CODIGO", ro.ItemArray(1).ToString)
                                            cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                            Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                                            cmd.Parameters.AddWithValue("@REQ", cal)
                                            cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where CU_CODIGO = @CUR and PU_CODIGO = @PU_CODIGO"
                                            cmd.ExecuteNonQuery()

                                        Else
                                            'crear relacion y actualizar registro
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                                            cmd.Parameters.AddWithValue("@CB_CODIGO", ro.ItemArray(0))
                                            cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                            Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                                            cmd.Parameters.AddWithValue("@REQ", cal)
                                            cmd.CommandText = "Update HR.Relaciones_pto_carac SET Id_relacion = @IDREL, Nivel_requerido = @REQ  where CU_CODIGO = @CUR and CB_CODIGO = @CB_CODIGO"
                                            cmd.ExecuteNonQuery()
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.AddWithValue("@IDold", bu(0).ItemArray(5))
                                            cmd.Parameters.AddWithValue("@IDnew", id_instruccion)
                                            cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido) VALUES(@IDnew,@IDold)"
                                            cmd.ExecuteNonQuery()
                                            If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                                ds.Tables.Remove("Relaciones_repetidas")
                                            End If
                                            da.SelectCommand.Parameters.Clear()
                                            da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("CU_CODIGO"))
                                            da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO = @Id)"
                                            da.Fill(ds, "Relaciones_repetidas")

                                        End If
                                        If r = 0 Then

                                        End If
                                    Else
                                        'SI LA RELACION ES ANTIGUA
                                        'BUSCAR ENTRE LAS RELACIONES DE LA ID_INSTRUCCION SI YA EXISTE CONEXION CON LA ACTUAL 
                                        Dim bus = relup(id_instruccion, bu(0).ItemArray(5))
                                        If bus.res = True Then
                                            'SI EXISTE CONEXION
                                            Console.WriteLine()
                                        Else
                                            'SI NO EXISTE RELACION
                                            cmd.Parameters.Clear()
                                            cmd.Connection = CnMPS
                                            cmd.CommandType = CommandType.Text
                                            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
                                            cmd.Parameters.AddWithValue("@Id_rel_pri", bu(0).ItemArray(5))
                                            cmd.Parameters.AddWithValue("@Id_rel_rep", id_instruccion)
                                            cmd.CommandText = "Insert into HR.Relaciones_repetidas (Id_relacion_principal,Id_relacion_repetido)Values(@Id_rel_pri,@Id_rel_rep)"
                                            cmd.ExecuteNonQuery()
#Region "Recargar tabla de relaciones"
                                            If ds.Tables("Relaciones_repetidas") IsNot Nothing Then
                                                ds.Tables.Remove("Relaciones_repetidas")
                                            End If
                                            da.SelectCommand.Parameters.Clear()
                                            da.SelectCommand.Parameters.AddWithValue("@Id", ds.Tables("relac").Rows(0).Item("CU_CODIGO"))
                                            da.SelectCommand.CommandText = "select * from hr.Relaciones_repetidas where 
                            Id_relacion_principal in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO = @Id) Or 
                            Id_relacion_repetido in (Select distinct Id from hr.Instruccion_relacion where CU_CODIGO = @Id)"
                                            da.Fill(ds, "Relaciones_repetidas")

#End Region
                                        End If
                                    End If
                                End If
                            Else

                                cmd.CommandType = CommandType.Text
                                cmd.Connection = CnMPS
                                cmd.Parameters.Clear()
                                cmd.CommandText = "Insert into HR.Relaciones_pto_carac (CU_CODIGO,PU_CODIGO,CB_CODIGO,Nivel_requerido,Id_relacion)Values(@CUR,NULL,@CB_CODIGO,@NR,@IDREL)"
                                cmd.Parameters.AddWithValue("@CUR", CU_CODIGO)
                                cmd.Parameters.AddWithValue("@CB_CODIGO", ro.ItemArray(0))
                                Dim cal As Integer = CType(LIsta_niveles_requeridos, List(Of empleados)).Find(Function(z) z.cb_codigo = ro.ItemArray(0).ToString).calif
                                cmd.Parameters.AddWithValue("@NR", cal) 'FALTA PREGRUNTAR POR EL NIVEL REQUERIDO
                                cmd.Parameters.AddWithValue("@IDREL", id_instruccion)
                                cmd.ExecuteNonQuery()


                            End If


                        Next
                    End If


#End Region
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

        End Try
    End Function
    Shared Function calificar_curso(ByVal CU_CODIGO As String, ByVal Competencia As Boolean, ByVal nivel_competencias As Integer, ByVal id_ponderacion As Integer, ByVal Nombre_tabla_relacionesExistentes As String, ByVal tipo As String, ByVal Optional Por_puesto As Boolean = True) As List(Of requerido)
        Try
            Dim a As New Nivel_requerido
            a.d = ds.Tables("Puestos").Copy
            a.nombre = Nombre_curso(CU_CODIGO)
            Relaciones_repetidas_curso(CU_CODIGO, Nombre_tabla_relacionesExistentes)
            a.califs = ds.Tables(Nombre_tabla_relacionesExistentes).Copy
            a.Sin_nombre_empleado = True
            a.Es_competencia = Competencia
            a.CU_CODIGO = CU_CODIGO
            If Competencia Then
                a.calificar_maximo = My.Settings.Com_nivreq
            ElseIf tipo = "Habilidad" Then
                a.calificar_maximo = My.Settings.Hab_nivreq
            ElseIf tipo = "Conocimiento" Then
                a.calificar_maximo = My.Settings.Con_nivreq
            ElseIf tipo = "Curso" Then
                a.calificar_maximo = My.Settings.Cur_nivreq
            End If
            a.Nivel_competencia = nivel_competencias
            a.Id_ponderacion = id_ponderacion
            a.ShowDialog()


            Dim r As List(Of requerido)
            r = a.qw
            Return r
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Shared Function calificar_por_empleado_curso(ByVal CU_CODIGO As String, ByVal Competencia As Boolean, ByVal nivel_competencias As Integer, ByVal id_ponderacion As Integer, ByVal Nombre_tabla_relacionesExistentes As String, ByVal tipo As String, ByVal Optional Por_puesto As Boolean = True) As List(Of empleados)
        Try
            Dim a As New Nivel_requerido
            a.d = ds.Tables("Puestos").Copy
            a.nombre = Nombre_curso(CU_CODIGO)
            Relaciones_repetidas_curso(CU_CODIGO, Nombre_tabla_relacionesExistentes)
            a.califs = ds.Tables(Nombre_tabla_relacionesExistentes).Copy
            a.Sin_nombre_empleado = False
            a.Es_competencia = Competencia
            a.CU_CODIGO = CU_CODIGO
            If Competencia Then
                a.calificar_maximo = My.Settings.Com_nivreq
            ElseIf tipo = "Habilidad" Then
                a.calificar_maximo = My.Settings.Hab_nivreq
            ElseIf tipo = "Conocimiento" Then
                a.calificar_maximo = My.Settings.Con_nivreq
            ElseIf tipo = "Curso" Then
                a.calificar_maximo = My.Settings.Cur_nivreq
            End If
            a.Nivel_competencia = nivel_competencias
            a.Id_ponderacion = id_ponderacion
            a.ShowDialog()
            Dim r As List(Of empleados)
            r = a.qw_empleado
            Return r
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

#End Region

#End Region

#Region "Organigrama"
    Shared Function puestos_Organigrama(ByVal Optional Todos As Boolean = False) As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If Todos Then
                da.SelectCommand.CommandText = "select * From [HR].[Puesto] Order by PU_DESCRIP"
            Else
                da.SelectCommand.CommandText = "select * From [HR].[Puesto] where PU_ACTIVO = 'S' Order by PU_DESCRIP"
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
    Shared Function puestos_Organigrama_parents(ByVal pu_codigo As String) As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            da.SelectCommand.Parameters.Clear()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.CommandText = "HR.Puestos_padre"
            da.SelectCommand.Parameters.AddWithValue("@PU_INICIAL", pu_codigo)
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
    Shared Function Puestos_sin_relacionar(ByVal Optional Inactivos As Boolean = False)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            If Inactivos Then
                da.SelectCommand.CommandText = "SELECT PU_CODIGO,PU_DESCRIP FROM [HR].[Puesto] WHERE
                    PU_PARENT IS NULL and PU_CODIGO <> '264' and PU_ACTIVO = 'n'  Order  by PU_DESCRIP"
            Else
                da.SelectCommand.CommandText = "SELECT PU_CODIGO,PU_DESCRIP FROM [HR].[Puesto] WHERE
                    PU_PARENT IS NULL and PU_CODIGO <> '264' and PU_ACTIVO = 's' Order by PU_DESCRIP"
            End If

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
    Shared Function CambioSuperior(ByVal PU_CODIGO As String, ByVal PU_PARENT As String)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.CommandType = CommandType.Text
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Pu_codigo", PU_CODIGO)
            cmd.Parameters.AddWithValue("@Pu_parent", PU_PARENT)
            cmd.CommandText = "UPDATE HR.PUESTO SET PU_PARENT = @Pu_parent WHERE PU_CODIGO = @Pu_codigo"
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Puestos_AgregarDependiente_Supervisor(ByVal PU_PARENT_PARENT As String, ByVal PU_PARENT As String, ByVal Puestos_hijos As List(Of String))
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.CommandType = CommandType.Text
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@PU_PARENT", PU_PARENT_PARENT)
            cmd.Parameters.AddWithValue("@PU_HIJO", PU_PARENT)
            cmd.CommandText = "Update HR.Puesto Set PU_PARENT = @PU_PARENT where PU_CODIGO = @PU_HIJO"
            cmd.ExecuteNonQuery()
            cmd.Parameters("@PU_PARENT").Value = PU_PARENT
            For Each str As String In Puestos_hijos
                cmd.Parameters("@PU_HIJO").Value = str
                cmd.ExecuteNonQuery()
            Next
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Eliminar_relacion(ByVal PU_CODIGO As String)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.Parameters.AddWithValue("@PU_CODIGO", PU_CODIGO)
            da.SelectCommand.CommandText = "Select * from HR.Puesto where PU_PARENT = @PU_CODIGO"
            ds.Tables.Clear()
            da.Fill(ds, "PU")

            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@PU_CODIGO", PU_CODIGO)
            cmd.CommandText = "Select PU_PARENT from HR.Puesto where PU_CODIGO = @PU_CODIGO"
            Dim papa = cmd.ExecuteScalar

            cmd.CommandText = "Update HR.Puesto SET PU_PARENT = NULL where PU_CODIGO = @PU_CODIGO"
            cmd.ExecuteNonQuery()
            If ds.Tables("PU") IsNot Nothing Then
                If papa.ToString <> "" Then
                    cmd.Parameters.AddWithValue("@PU_PARENT", papa)
                    For Each ro As DataRow In ds.Tables("PU").Rows
                        cmd.Parameters("@PU_CODIGO").Value = ro.ItemArray(1)
                        cmd.CommandText = "UPDATE HR.Puesto SET PU_PARENT = @PU_PARENT WHERE PU_CODIGO = @PU_CODIGO"
                        cmd.ExecuteNonQuery()
                    Next
                Else
                    For Each ro As DataRow In ds.Tables("PU").Rows
                        cmd.Parameters("@PU_CODIGO").Value = ro.ItemArray(1)
                        cmd.CommandText = "UPDATE HR.Puesto SET PU_PARENT = NULL WHERE PU_CODIGO = @PU_CODIGO"
                        cmd.ExecuteNonQuery()
                    Next
                End If
            End If
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Eliminar_relacion_completa(ByVal puestos As List(Of String))
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.Parameters.Add("@PUESTO", SqlDbType.VarChar)
            cmd.CommandText = "UPDATE HR.Puesto set PU_PARENT = NULL where PU_CODIGO = @PUESTO"
            For Each str As String In puestos
                cmd.Parameters("@PUESTO").Value = str
                cmd.ExecuteNonQuery()
            Next
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then
                CnMPS.Close()
            End If
        End Try
    End Function
    Shared Function Cambiar_nivel(ByVal puesto As String, ByVal nivel As Integer)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.Parameters.AddWithValue("@Puesto", puesto)
            cmd.Parameters.AddWithValue("@Nivel", nivel)
            cmd.CommandText = "Update HR.Puesto set Id_Nivel = @nivel where PU_CODIGO = @Puesto"
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then
                CnMPS.Close()
            End If
        End Try
    End Function

#End Region

#Region "Objetivos"
    Shared Function tipos_objetivos() As DataTable
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select * from HR.Objetivos_tipos"
            ds.Tables.Clear()
            da.Fill(ds, "Tipos")
            Return ds.Tables("Tipos")

        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

        End Try
    End Function
    Shared Function agregar_Objetivo(ByVal cb_codigo As Integer, ByVal Descripcion As String, ByVal Observaciones As String, ByVal Objetivo As Double, ByVal Tipo As Integer,
                                     ByVal Condicion As String, ByVal Año As Integer, ByVal Nuevo As Boolean, ByVal Optional Id As Integer = 0)
        Try

            Dim PU_CODIGO As String = puesto(cb_codigo)
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Pu_codigo", PU_CODIGO)
            cmd.Parameters.AddWithValue("@Cb_codigo", cb_codigo)
            cmd.Parameters.AddWithValue("@Desc", Descripcion)
            cmd.Parameters.AddWithValue("@Obs", Observaciones)
            cmd.Parameters.AddWithValue("@Obj", Objetivo)
            cmd.Parameters.AddWithValue("@Tip", Tipo)
            cmd.Parameters.AddWithValue("@Cond", Condicion)
            cmd.Parameters.AddWithValue("@Año", Año)

            cmd.Connection = CnMPS
            If Nuevo Then
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "Insert into Hr.Objetivos_Master (CB_CODIGO,PU_CODIGO,Descripcion,Observaciones,Objetivo,Tipo,Condición,Año,Finalizado)
                                Values(@Cb_codigo,@Pu_codigo,@Desc,@Obs,@Obj,@Tip,@Cond,@Año,0)"
            Else
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@id", Id)
                cmd.CommandText = "Update Hr.Objetivos_Master Set Descripcion=@Desc, Observaciones=@Obs, Objetivo=@Obj, Tipo=@Tip, Condición=@Cond, Año=@Año where id = @id"
            End If

            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function


    Shared Function Objetivo_update(ByVal cb_codigo As Integer, ByVal pu_codigo As String, ByVal Descripcion As String, ByVal Observaciones As String, ByVal Objetivo As Double,
                                 ByVal año As Integer, ByVal Optional Nuevo As Boolean = True, ByVal Optional Id As Integer = 0)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()

            End If
            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text


            cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
            cmd.Parameters.AddWithValue("@Observaciones", Observaciones)
            cmd.Parameters.AddWithValue("@Objetivo", Objetivo)
            If Nuevo Then
                cmd.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
                cmd.Parameters.AddWithValue("@pu_codigo", pu_codigo)
                cmd.Parameters.AddWithValue("@Año", año)
                cmd.CommandText = "Insert into Hr.Objetivos_master(CB_CODIGO,PU_CODIGO,Descripcion,Observaciones,Objetivo,Año)values(@CB_CODIGO,@pu_codigo,@Descripcion,@Observaciones,@Objetivo,@Año)"
            Else
                cmd.Parameters.AddWithValue("@Id", Id)
                cmd.CommandText = "Update Hr.Objetivos_master set Descripcion = @Descripcion, Observaciones = @Observaciones, Objetivo = @Objetivo where id = @Id"
            End If
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Objetivos(ByVal cb_codigo As Integer)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()

            End If

            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select * from Hr.Objetivos_Master where cb_codigo = @CB_CODIGO"

            da.SelectCommand.CommandText = "select ma.id, Descripcion, Observaciones, ma.Objetivo , Tipo, Año,ene.Porcentaje as 'Enero',feb.Porcentaje as 'Febrero',mar.Porcentaje as 'Marzo',abr.Porcentaje as 'Abril',
may.Porcentaje as 'Mayo',jun.Porcentaje as 'Junio',jul.Porcentaje as 'Julio',ago.Porcentaje as 'Agosto',sep.Porcentaje as 'Septiembre',oct.Porcentaje as 'Octubre',nov.Porcentaje as 'Noviembre',dic.Porcentaje as 'Diciembre',ma.Finalizado
from hr.Objetivos_master ma
left join hr.Objetivos_Acciones_Master ene on ma.Id = ene.Id_Objetivo and ene.Mes = 1
left join hr.Objetivos_Acciones_Master feb on ma.Id = feb.Id_Objetivo and feb.Mes = 2
left join hr.Objetivos_Acciones_Master mar on ma.Id = mar.Id_Objetivo and mar.Mes = 3
left join hr.Objetivos_Acciones_Master abr on ma.Id = abr.Id_Objetivo and abr.Mes = 4
left join hr.Objetivos_Acciones_Master may on ma.Id = may.Id_Objetivo and may.Mes = 5
left join hr.Objetivos_Acciones_Master jun on ma.Id = jun.Id_Objetivo and jun.Mes = 6
left join hr.Objetivos_Acciones_Master jul on ma.Id = jul.Id_Objetivo and jul.Mes = 7
left join hr.Objetivos_Acciones_Master ago on ma.Id = ago.Id_Objetivo and ago.Mes = 8
left join hr.Objetivos_Acciones_Master sep on ma.Id = sep.Id_Objetivo and sep.Mes = 9
left join hr.Objetivos_Acciones_Master oct on ma.Id = oct.Id_Objetivo and oct.Mes = 10
left join hr.Objetivos_Acciones_Master nov on ma.Id = nov.Id_Objetivo and nov.Mes = 11
left join hr.Objetivos_Acciones_Master dic on ma.Id = dic.Id_Objetivo and dic.Mes = 12
where CB_CODIGO = @CB_CODIGO"

            da.SelectCommand.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Objetivos")
            Return ds.Tables("Objetivos")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Objetivos_acciones(ByVal id As Integer, ByVal mes As Integer)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@Id", id)
            da.SelectCommand.Parameters.AddWithValue("@Mes", mes)
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select Id, Porcentaje from Hr.Objetivos_Acciones_Master where Id_Objetivo = @Id and Mes = @Mes"
            ds.Tables.Clear()
            da.Fill(ds, "Obj_acciones")
            Return ds.Tables("Obj_acciones")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Objetivos_acciones_detalles(ByVal id_accion As Integer)
        Try
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@Id", id_accion)
            da.SelectCommand.Connection = CnMPS
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select Id, Descripcion from Hr.Objetivos_Acciones_Detalles where Id_Obj_Acc = @Id"
            ds.Tables.Clear()
            da.Fill(ds, "Obj_acciones_detalles")
            Return ds.Tables("Obj_acciones_detalles")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Borrar_objetivo_accion(ByVal id As Integer, ByVal Todo As Boolean)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@Id", id)
            If Todo Then
                cmd.CommandText = "Delete from Hr.Objetivos_Acciones_Master where id = @Id"
            Else
                cmd.CommandText = "Delete from Hr.Objetivos_Acciones_Detalles where id = @Id"
            End If
            cmd.ExecuteNonQuery()
            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Accion_master_update(ByVal id_objetivo As Integer, ByVal mes As Integer, ByVal Porcentaje As Double, ByVal nuevo As Boolean, ByVal Optional id As Integer = 0)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@Porcentaje", Porcentaje)
            Dim RE As Integer = 1
            If nuevo Then
                cmd.Parameters.AddWithValue("@Id", id_objetivo)
                cmd.Parameters.AddWithValue("@Mes", mes)
                cmd.CommandText = "Insert into Hr.Objetivos_Acciones_Master(Id_Objetivo,Mes,Porcentaje) values(@Id,@Mes,@Porcentaje); SELECT @@IDENTITY"
                RE = cmd.ExecuteScalar
            Else
                cmd.Parameters.AddWithValue("@id", id)
                cmd.CommandText = "Update Hr.Objetivos_Acciones_Master set Porcentaje = @Porcentaje where id = @id"
                cmd.ExecuteNonQuery()
            End If

            Return RE

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally

        End Try
    End Function
    Shared Function Accion_DETALLES_update(ByVal Id_OBJ As Integer, ByVal dESCRIP As String, ByVal Nuevo As Boolean, ByVal Optional Id As Integer = 0)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@descri", dESCRIP)

            If Nuevo Then
                cmd.Parameters.AddWithValue("@Id", Id_OBJ)
                cmd.CommandText = "Insert into Hr.Objetivos_Acciones_Detalles (Id_Obj_Acc, Descripcion)values (@Id,@descri)"
            Else
                cmd.Parameters.AddWithValue("@Id", Id)
                cmd.CommandText = "Update Hr.Objetivos_Acciones_Detalles set Descripcion = @descri where id = @Id"
            End If

            cmd.ExecuteNonQuery()

            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function
#End Region


#Region "IDP"
    Shared Function Preferencia(ByVal cb_codigo As Integer, ByVal Optional Periodo As Integer = 0)
        Try
            Dim QW As String = puesto(cb_codigo)
            If Periodo = 0 Then
                Periodo = Periodo_actual()
            End If
            If Periodo = 0 Then Return -1
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()

            End If
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@cb_codigo", cb_codigo)
            da.SelectCommand.Parameters.AddWithValue("@Pu_codigo", QW)
            da.SelectCommand.Parameters.AddWithValue("@Id_periodo", Periodo)
            da.SelectCommand.CommandText = "select rpc.*, ca.Nivel,ca.Descripcion,ev.Id as 'Id_evaluacion',evd.Calif from HR.Relaciones_pto_carac rpc
inner join Hr.Caracteristicas ca on rpc.Id_categoria = ca.Id
left join hr.Evaluacion ev on ev.Id_caracteristica = rpc.Id_categoria and ev.CB_CODIGO = @cb_codigo
left join (select Id_Evaluacion, max(Puntos) as 'Calif' from hr.Evaluacion_detalles where Validado = 1 group by Id_Evaluacion) evd on evd.Id_Evaluacion = ev.Id
where (rpc.CB_CODIGO = @cb_codigo or rpc.PU_CODIGO = @pu_codigo ) and rpc.Id_categoria in (select id from hr.Caracteristicas where Competencia = 1 ) and( Calif < 100 or Calif is null)
order by Nivel,Calif,Id_caracteristica"
            da.SelectCommand.CommandText = "select rpc.Id_categoria,rpc.Nivel_requerido, ca.Nivel,ca.Descripcion,ev.Id as 'Id_evaluacion',evd.Calif,ins.Id_ponderacion,idp.Id as 'Id_progra_idp' from HR.Relaciones_pto_carac rpc
inner join Hr.Caracteristicas ca on rpc.Id_categoria = ca.Id
left join hr.Instruccion_relacion ins on rpc.Id_relacion = ins.Id
left join hr.Evaluacion ev on ev.Id_caracteristica = rpc.Id_categoria and ev.CB_CODIGO = @cb_codigo
left join (select Id_Evaluacion, max(Puntos) as 'Calif' from hr.Evaluacion_detalles where Validado = 1 group by Id_Evaluacion) evd on evd.Id_Evaluacion = ev.Id
left join hr.Programacion_IDP idp on idp.CB_CODIGO = @cb_codigo and Id_competencia = ca.Id and idp.Nivel_requerido = rpc.Nivel_requerido 
and Id_Periodo = @Id_periodo
where (rpc.CB_CODIGO = @cb_codigo or rpc.PU_CODIGO = @pu_codigo ) and rpc.Id_categoria in (select id from hr.Caracteristicas where Competencia = 1 ) and( Calif < 100 or Calif is null) and (idp.id is null)
order by Nivel,Calif,ev.Id_caracteristica"
            If ds.Tables("Preferencia") IsNot Nothing Then
                ds.Tables.Remove("Preferencia")
            End If

            da.Fill(ds, "Preferencia")
            Return ds.Tables("Preferencia")

        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Periodos()
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "Select * from HR.Periodos_IDP"
            ds.Tables.Clear()
            da.Fill(ds, "Periodos")
            Return ds.Tables("Periodos")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
        End Try
    End Function
    Shared Function Programar_IDP(ByVal cb_codigo As Integer, ByVal Id_competencia As Integer, ByVal Actual As String, ByVal Actual_ingles As String, ByVal Fecha_compromiso As Date,
                                  ByVal Nivel_requerido As Integer, ByVal Id_ponderacion As Integer, ByVal Optional Id_periodo As Integer = 0)
        Try
            If Id_periodo = 0 Then
                Id_periodo = Periodo_actual()
            End If
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
            cmd.Parameters.AddWithValue("@Id_competencia", Id_competencia)
            cmd.Parameters.AddWithValue("@Actual", Actual)
            cmd.Parameters.AddWithValue("@AC_IN", Actual_ingles)
            cmd.Parameters.AddWithValue("@Fecha_comp", Fecha_compromiso.Date)
            cmd.Parameters.AddWithValue("@NR", Nivel_requerido)
            cmd.Parameters.AddWithValue("@Id_pond", Id_ponderacion)
            cmd.Parameters.AddWithValue("@Id_periodo", Id_periodo)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Insert into Hr.Programacion_IDP(CB_CODIGO,Id_competencia,Actual,Actual_ingles,Fecha_compromiso,Nivel_requerido, Id_ponderacion,Id_periodo)
                                values(@CB_CODIGO,@Id_competencia,@Actual,@AC_IN,@Fecha_comp,@NR,@Id_pond,@Id_periodo)"
            cmd.ExecuteNonQuery()
            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function Periodo_actual()
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "  select *  from hr.Periodos_IDP where [Fecha inicio] <= GETDATE() and GETDATE() <= [Fecha fin] and Activo = 1"
            Dim re As Integer = 0
            re = cmd.ExecuteScalar
            Return re

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return -1
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

        End Try
    End Function
    Shared Function Programados(ByVal Cb_codigo As Integer, ByVal periodo As Integer)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.AddWithValue("@CB_CODIGO", Cb_codigo)
            da.SelectCommand.Parameters.AddWithValue("@Periodo", periodo)
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select idp.Id, ca.Descripcion,Actual,Fecha_compromiso from Hr.Programacion_IDP idp
                                            left join Hr.Caracteristicas ca on idp.Id_competencia = ca.id                                            
where cb_codigo = @CB_CODIGO and Id_periodo = @Periodo"
            ds.Tables.Clear()
            da.Fill(ds, "Programaciones")
            Return ds.Tables("Programaciones")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
        End Try
    End Function
    Shared Function Remover(ByVal id As Integer, ByVal cb_codigo As Integer)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@Id", id)
            cmd.Parameters.AddWithValue("@Cb_codigo", cb_codigo)
            cmd.CommandText = "Delete from Hr.Programacion_IDP where id = @Id and cb_codigo = @Cb_codigo"
            cmd.ExecuteNonQuery()
            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function IDP_COMPLETO(ByVal cb_codigo As Integer, ByVal Actual As Boolean, ByVal Optional Periodo As Integer = 0)

        Try
            If Actual Then
                Periodo = Periodo_actual()
            End If
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If

            cmd.Parameters.Clear()
            cmd.Connection = CnMPS
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@CB_CODIGO", cb_codigo)
            cmd.Parameters.AddWithValue("@Periodo", Periodo)



            cmd.CommandText = "select count(*) from hr.Programacion_IDP where CB_CODIGO = @CB_CODIGO and Id_Periodo = @Periodo"
            Dim re As Integer = 0
            re = cmd.ExecuteScalar
            If re = 3 Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

        End Try
    End Function
    Shared Function Agregar_periodo(ByVal Descripcion As String, ByVal Fecha_inicio As Date, ByVal Fecha_fin As Date, ByVal Fecha_revision As Date, ByVal Nuevo As Boolean, ByVal Optional Id As Integer = 0)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Desc", Descripcion)
            cmd.Parameters.AddWithValue("@Feci", Fecha_inicio)
            cmd.Parameters.AddWithValue("@Fecf", Fecha_fin)
            cmd.Parameters.AddWithValue("@Fecfr", Fecha_revision)
            cmd.CommandType = CommandType.Text
            If Nuevo Then
                cmd.CommandText = "Insert into Hr.Periodos_IDP (Descripcion,[Fecha inicio],[Fecha fin],[Fecha revision],[Activo])Values(@Desc,@Feci,@Fecf,@Fecfr,1)"
            Else
                cmd.Parameters.AddWithValue("@Id", Id)
                cmd.CommandText = "Update Hr.Periodos_IDP set Descripcion = @Desc, [Fecha inicio]=@Feci, [Fecha fin]= @Fecf, [Fecha revision]=@Fecfr where id = @Id"
            End If
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function Activar_periodo(ByVal Id As Integer, ByVal Activo As Boolean)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@Id", Id)
            cmd.Parameters.AddWithValue("@Activo", Activo)
            cmd.CommandText = "Update Hr.Periodos_IDP set Activo = @Activo where id = @Id"
            cmd.ExecuteNonQuery()

            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function esactivo_periodo(ByVal id As Integer)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@Id", id)
            cmd.CommandText = "Select Activo from  Hr.Periodos_IDP  where id = @Id"
            Dim re = cmd.ExecuteScalar

            Return re

        Catch ex As Exception

            Throw New Exception(ex.Message)
            Return False
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function Eliminar_periodo(ByVal id As Integer)
        Try
            If CnMPS.State = ConnectionState.Closed Then
                CnMPS.ConnectionString = constringMPS()
                CnMPS.Open()
            End If
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@Id", id)
            cmd.CommandText = "Delete From  Hr.Periodos_IDP  where id = @Id"
            cmd.ExecuteNonQuery()
            Return 1

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

#End Region
End Class

