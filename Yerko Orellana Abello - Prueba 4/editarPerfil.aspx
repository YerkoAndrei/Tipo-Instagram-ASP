<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarPerfil.aspx.cs" Inherits="Yerko_Orellana_Abello___Prueba_4.cambiarContrasena" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%
    if (this.Session["nickActual"] != null)
    { 
%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="estilo.css"/>
    <script src="jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            color();
            $("#exImg").change(function() {
                $("#editaImagen").attr("src", "img/" + $("#exImg").val());
            });
        });
        function color() {
            var sexo = "<%imprimeSexo();%>";
            if (sexo == "m") {
                $("body").css("background-color", "#CEE3F6");
            }
            else if (sexo == "f"){
                $("body").css("background-color", "#E3CEF6");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="edicion" class="edicionPerfil">
            <h1>Edita tu perfil</h1>
            <table>
                <tr>
                    <td>Nombre</td>
                    <td><asp:TextBox ID="txtEditarNombre" runat="server" MaxLength="30"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td><asp:TextBox ID="txtEditarEmail" runat="server" MaxLength="30"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnEditarNormal" runat="server" Text="Editar" class="button" 
                            onclick="btnEditarNormal_Click"/></td>
                </tr>
            </table>
        </div>
        <div id="actualizacion" class="edicionPerfil">
            <h1>¡Actualiza tu perfil!</h1>
            <table>
                <tr>
                    <td><img id="editaImagen" src="img/<%mostrarImagen();%>" width=200px/></td>
                    <td><div class="drop">
                            <input type="file" id="exImg" runat="server" class="drop" style="opacity: 0"/>
                        </div>
                        <asp:Button ID="btnCambiarFoto" runat="server" Text="Cambiar" class="button" onclick="btnCambiarFoto_Click"/>
                    </td>
                </tr>
                <tr>
                    <td>Estado</td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan=2><asp:TextBox ID="txtEstado" runat="server" Height="60px" Width="100%"
                            TextMode="MultiLine" MaxLength="100"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnEditarEstado" runat="server" Text="Editar" class="button" 
                            onclick="btnEditarEstado_Click"/></td>
                    <td></td>
                </tr>
            </table>
        </div>
        <asp:Button ID="btnVolver" runat="server" Text="Volver" class="button" onclick="btnVolver_Click"/>
    </form>
</body>
</html>
<%
    }
    else
        Response.Redirect("index.aspx");
%>