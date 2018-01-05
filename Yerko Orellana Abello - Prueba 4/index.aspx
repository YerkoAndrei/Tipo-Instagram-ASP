<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Yerko_Orellana_Abello___Prueba_4.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="estilo.css"/>
    <script src="jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#registrar").hide();
            var ok = "no";
            $("#btnReg").click(function () {
                $("#registrar").fadeIn(500);
                $("#btnReg").hide();
            });
            $("#reg").click(function () {
                $("#registrar").hide();
                $("#btnReg").fadeIn(500);
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <center><div><img src=img/logo.png width="30%"/></div></center>
    <div id="ingreso">
        <h2>Ingreso</h2>
        <table>
            <tr>
                <td>Nombre de usuario</td>
                <td><asp:TextBox ID="txtLogin" runat="server" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Contraseña</td>
                <td><asp:TextBox ID="txtLoginPass" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnIngresar" runat="server" Text="Ingresar" 
                        onclick="btnIngresar_Click" class="button"/></td>
            </tr>
        </table>
    </div>
    <div id="btnReg"><h2>¡Regístrate!</h2></div>
    <div id="registrar">
        <h2 id="reg">Registro</h2>
        <table>
            <tr>
                <td>Nombre de usuario</td>
                <td><asp:TextBox ID="txtNick" runat="server" MaxLength="12"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email</td>
                <td><asp:TextBox ID="txtEmail" runat="server" TextMode="Email" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nombre (Real)</td>
                <td><asp:TextBox ID="txtNombre" runat="server" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Eres:</td>
                <td><select name="sexo"><option value="m">Hombre</option><option value="f">Mujer</option></select></td> 
            </tr>
            <tr> 
                <td>Contraseña</td>
                <td><asp:TextBox ID="txtPass" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Repita Contraseña</td>
                <td><asp:TextBox ID="txtPass2" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" onclick="btnRegistrar_Click" class="button"/></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
