Public Class IniciarSesion
    Inherits System.Web.UI.Page
    Dim HuarikeWS As New ServicioHuarique.Service1SoapClient

    Public Sub ObtenerUsuario(ByVal PStrUsuario As String, ByVal PStrClave As String)
        HuarikeWS.ObtenerUsuario(PStrUsuario, PStrClave)
        Response.Redirect("BuscaHuarique.aspx")
    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim PStrUsuario As String = Request.Form("PStrUsuario")
        Dim PStrClave As String = Request.Form("PStrClave")
        ObtenerUsuario(PStrUsuario, PStrClave)
    End Sub
End Class