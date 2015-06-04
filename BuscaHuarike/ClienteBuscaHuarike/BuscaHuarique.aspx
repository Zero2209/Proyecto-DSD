<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BuscaHuarique.aspx.vb" Inherits="ClienteBuscaHuarike._Default" %>
<!doctype html>
<html>
<head runat="server">
   <link href="css/style.css" rel="stylesheet">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bienvenido a Busca Huariques Limeños</title>
</head>
<body>
   
   <div id="top-content">
       <div class="clear-fix"></div>
       <header id="main-header">
      </header>  <!-- main-header -->
   </div>
    <div id="container">
         <form id="FrmHuariques" runat="server">
            <div>
                  <asp:Label runat="server">Distrito</asp:Label>
                  <asp:DropDownList ID="ddlDistritos" runat="server" CssClass="dropdown"/>
           <%-- </div>
            <div class="dropdown">--%>
                  <asp:Label ID="Label1" runat="server" >Tipo</asp:Label>
                  <asp:DropDownList ID="ddlTipo" runat="server" CssClass="dropdown" />    
            </div> 
            <div>
                 <asp:GridView ID="gvHuarique" runat="server" Width="100%" />
            </div>
            <div>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Visible="False" />
            </div>
         </form>  
        <section id="home-content">
      		<article class="column">
      		    <h3> Eventos </h3>
      		    <img src="imagenes/eventos.png" alt="Eventos" class="img-izq">
      			<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec a elementum quam. In maximus varius purus, eget ullamcorper nibh. Donec mattis ornare est ac porttitor. Fusce condimentum et erat at imperdiet. Nunc ornare blandit velit in fringilla. Fusce pretium nulla eu convallis ullamcorper. Aenean porta congue urna, ut dignissim dui bibendum nec. In elementum, mauris eu </p>
      		</article>

      		<article class="column">
      		    <h3> Noticias </h3>
      		    <img src="imagenes/noticias.png" alt="Noticias" class="img-izq">
      			<p>Morbi eu finibus purus, at tristique lacus. Cras vehicula finibus finibus. Vestibulum vitae nulla ligula. Ut viverra arcu elit. Aliquam laoreet sapien vel auctor volutpat. Aenean tempor semper iaculis. Pellentesque suscipit massa nulla. Maecenas vestibulum sagittis justo tincidunt consequat. Suspendisse metus lectus, ornare ut posuere eu, maximus vel lorem. </p>
      		</article>

      		<article class="column">
      			<h3> Novedades </h3>
      		    <img src="imagenes/novedades.png" alt="Novedades" class="img-izq">
      			<p>In quam nunc, tincidunt ut lacus id, ultricies euismod dolor. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aliquam efficitur nunc vitae tellus <a href="#">tincidunt</a>, et dictum nisl semper. Donec cursus felis vel odio blandit iaculis. Nunc vulputate ullamcorper nisi nec placerat. Donec egestas nisi nec quam lobortis, non dignissim nunc tris </p>
      		</article> <!-- column-->

      </section> <!-- home-content-->
     </div><!-- container -->
     <aside id="home-sidebar">
         <nav id="main-nav" class="jumbotron">
             <ul class="menu">
                 <li><a href="#">Añadir Huarique</a></li>
                 <li><a href="#">Añadir Reseña</a></li>
             </ul>
          </nav>
          <nav class="redes-sociales">
               <ul class="rsocial">
                     <li><a href="#" class="fb"></a></li>
                     <li><a href="#" class="tw"></a></li>
                     <li><a href="#" class="gl"></a></li>
                     <li><a href="#" class="fl"></a></li>
                     <li><a href="#" class="rs"></a></li>
                     <li><a href="#" class="yt"></a></li>
               </ul>
               <div class="clear-fix"></div>
          </nav>
     </aside> 
    <%--<div id="bottom-content">--%>
      <footer id="main-footer">
      		 BuscaHuriques©Derechos Reservados-2015
      </footer><!-- main-footer -->
<%--  </div>--%> 
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="Scripts/js/bootstrap.min.js"></script>

</body>
</html>
