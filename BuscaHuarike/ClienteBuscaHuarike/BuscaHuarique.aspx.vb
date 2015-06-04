Public Class _Default
    Inherits System.Web.UI.Page
    Dim HuarikeWS As New ServicioHuarique.Service1SoapClient
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gvHuarique.DataSource = HuarikeWS.ObtenerHuarike()
            gvHuarique.DataBind()
            Cargar()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        gvHuarique.DataSource = HuarikeWS.ObtenerHuarikesPorDistrito(ddlDistritos.SelectedValue.ToString(), ddlTipo.SelectedValue.ToString())
        gvHuarique.DataBind()
    End Sub

    Public Sub Cargar()
        ddlDistritos.DataSource = HuarikeWS.ObtenerDistritos()
        ddlDistritos.DataValueField = "DESCRIPCION"
        ddlDistritos.DataTextField = "DESCRIPCION"
        ddlDistritos.DataBind()

        ddlTipo.DataSource = HuarikeWS.ObtenerTiposComida()
        ddlTipo.DataValueField = "DESCRIPCION"
        ddlTipo.DataTextField = "DESCRIPCION"
        ddlTipo.DataBind()
    End Sub

End Class