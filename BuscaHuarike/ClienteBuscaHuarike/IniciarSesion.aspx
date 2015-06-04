<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IniciarSesion.aspx.vb" Inherits="ClienteBuscaHuarike.IniciarSesion"%>


<!doctype html>
<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar de Sesión</title>
 <link href="css/style.css" rel="stylesheet">
 <link href="css/stylelogin.css" rel="stylesheet" type="text/css" />
 <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
 <script src="Scripts/login.js" type="text/javascript"></script>
</head>
<body>
     <div id="top-content">
         <div id="bar">
            <!-- Login Starts Here -->
            <div id="loginContainer">
                <a href="#" id="loginButton"><span>Login</span><em></em></a>
                <div style="clear:both"></div>
                <div id="loginBox">                
                    <form id="loginForm" runat="server">
                        <fieldset id="body">
                            <fieldset>
                                <label for="usuario">Usuario</label>
                                <input type="text" name="usuario" id="PStrUsuario" runat="server" />
                            </fieldset>
                            <fieldset>
                                <label for="clave">Clave</label>
                                <input type="password" name="clave" id="PStrClave" runat="server" />
                            </fieldset>
                            <%--<input type="submit" id="login" value="Sign in" />--%>
                              <asp:Button runat="server" ID="btnIngresar" Text="Login"/>
                            <label for="checkbox"><input type="checkbox" id="checkbox" />Recordar credenciales</label>
                        </fieldset>
                        <span><a href="#">Olvido su clave?</a></span>
                        <a href="RegistrarUsuario.aspx">Registrar Usuario</a>
                    </form>
                </div>
            </div>
            <!-- Login Ends Here -->
        </div>
    </div>
    <figure id="main-banner">
            <img src="imagenes/huariques.jpg"/>    
    </figure>
    <div id="bottom-content">
            BuscaHuriques©Derechos Reservados-2015
    </div>
</body>
</html>
