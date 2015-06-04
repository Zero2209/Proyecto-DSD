Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Service1
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function ObtenerDistritos() As DataTable
        Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("VPH").ToString())
            Dim SqlDataAdapter As New SqlDataAdapter("USP_LISTA_DISTRITOS", cn)
            Dim dtDistritos As New DataTable("dtDistritos")
            SqlDataAdapter.Fill(dtDistritos)
            Return dtDistritos
        End Using
    End Function

    <WebMethod()> _
    Public Function ObtenerTiposComida() As DataTable
        Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("VPH").ToString())
            Dim SqlDataAdapter As New SqlDataAdapter("USP_LISTA_TIPO_COMIDAS", cn)
            Dim dtTiposComida As New DataTable("dtTiposComida")
            SqlDataAdapter.Fill(dtTiposComida)
            Return dtTiposComida
        End Using
    End Function


    <WebMethod()> _
    Public Function ObtenerHuarike() As DataTable
        Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("VPH").ToString())
            Dim SqlDataAdapter As New SqlDataAdapter("USP_BUSCA_HUARIQUE", cn)
            Dim DtHuarike As New DataTable("DtHuarike")
            SqlDataAdapter.Fill(DtHuarike)
            Return DtHuarike
        End Using
    End Function

    <WebMethod()> _
    Public Function ObtenerUsuario(ByVal PStrUsuario As String, ByVal PStrClave As String) As DataTable
        Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("VPH").ToString())
            Dim dtUsuario = New DataTable("Usuario")
            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "USP_INICIAR_SESION"

            Dim usuarioParam As New SqlParameter
            usuarioParam.ParameterName = "@USUARIO"
            usuarioParam.SqlDbType = SqlDbType.VarChar
            usuarioParam.Size = 100
            usuarioParam.Direction = ParameterDirection.Input
            usuarioParam.Value = PStrUsuario

            Dim claveParam As New SqlParameter
            claveParam.ParameterName = "@CLAVE"
            claveParam.SqlDbType = SqlDbType.VarChar
            claveParam.Size = 100
            claveParam.Direction = ParameterDirection.Input
            claveParam.Value = PStrClave

            cmd.Parameters.Add(usuarioParam)
            cmd.Parameters.Add(claveParam)
            cmd.Connection.Open()
            Dim dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dtUsuario.Load(dr)
            Return dtUsuario
        End Using
    End Function

    <WebMethod()> _
    Public Function GrabarUsuario(ByVal PStrUsuario As String, ByVal PStrClave As String, PStrNombre As String, PDteFechaRegistro As Date, PIntEstado As Int32) As DataTable
        Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("VPH").ToString())
            Dim dtUsuario = New DataTable("Usuario")
            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "USP_REGISTRAR_USUARIO"

            Dim usuarioParam As New SqlParameter
            usuarioParam.ParameterName = "@USUARIO"
            usuarioParam.SqlDbType = SqlDbType.VarChar
            usuarioParam.Size = 100
            usuarioParam.Direction = ParameterDirection.Input
            usuarioParam.Value = PStrUsuario

            Dim claveParam As New SqlParameter
            claveParam.ParameterName = "@CLAVE"
            claveParam.SqlDbType = SqlDbType.VarChar
            claveParam.Size = 100
            claveParam.Direction = ParameterDirection.Input
            claveParam.Value = PStrClave

            Dim nombreParam As New SqlParameter
            nombreParam.ParameterName = "@NOMBRE"
            nombreParam.SqlDbType = SqlDbType.VarChar
            nombreParam.Size = 100
            nombreParam.Direction = ParameterDirection.Input
            nombreParam.Value = PStrNombre

            Dim frecParam As New SqlParameter
            frecParam.ParameterName = "@FECREGISTRO"
            frecParam.SqlDbType = SqlDbType.VarChar
            frecParam.Size = 100
            frecParam.Direction = ParameterDirection.Input
            frecParam.Value = PDteFechaRegistro

            Dim estadoParam As New SqlParameter
            estadoParam.ParameterName = "@ESTADO"
            estadoParam.SqlDbType = SqlDbType.VarChar
            estadoParam.Size = 100
            estadoParam.Direction = ParameterDirection.Input
            estadoParam.Value = PIntEstado


            cmd.Parameters.Add(usuarioParam)
            cmd.Parameters.Add(claveParam)
            cmd.Parameters.Add(nombreParam)
            cmd.Parameters.Add(frecParam)
            cmd.Parameters.Add(estadoParam)
            cmd.Connection.Open()
            Dim dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dtUsuario.Load(dr)
            Return dtUsuario
        End Using
    End Function

    <WebMethod()> _
    Public Function ObtenerHuarikesPorDistrito(ByVal PStrDistrito As String, ByVal PStrTipo As String) As DataTable
        Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("VPH").ToString())
            Dim dtWarike = New DataTable("Warike")
            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "USP_BUSCA_HUARIQUE_POR_DISTRITO"

            Dim distritoParam As New SqlParameter
            distritoParam.ParameterName = "@DISTRITO"
            distritoParam.SqlDbType = SqlDbType.VarChar
            distritoParam.Size = 100
            distritoParam.Direction = ParameterDirection.Input
            distritoParam.Value = PStrDistrito

            Dim tipoParam As New SqlParameter
            tipoParam.ParameterName = "@TIPO"
            tipoParam.SqlDbType = SqlDbType.VarChar
            tipoParam.Size = 100
            tipoParam.Direction = ParameterDirection.Input
            tipoParam.Value = PStrTipo

            cmd.Parameters.Add(distritoParam)
            cmd.Parameters.Add(tipoParam)
            cmd.Connection.Open()
            Dim dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dtWarike.Load(dr)
            Return dtWarike
        End Using
    End Function
   
End Class