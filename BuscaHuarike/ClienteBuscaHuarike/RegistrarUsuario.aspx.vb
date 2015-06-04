Public Class RegistrarUsuario
    Inherits System.Web.UI.Page
     Dim HuarikeWS As New ServicioHuarique.Service1SoapClient

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        HuarikeWS.GrabarUsuario(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        Response.Redirect("IniciarSesion.aspx")
    End Sub
End Class