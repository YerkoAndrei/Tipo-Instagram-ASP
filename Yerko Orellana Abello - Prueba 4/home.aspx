<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Yerko_Orellana_Abello___Prueba_4.home" %>

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
            todos();
            color();
            $("#subirImagen").change(function () {
                $("#ejSubirImagen").attr("src", "img/" + $("#subirImagen").val());
            });
        });
        function color() {
            var sexo = "<%imprimeSexo();%>";
            if (sexo == "m") {
                $("body").css("background-color", "#CEE3F6");
            }
            else {
                $("body").css("background-color", "#E3CEF6");
            }
        };
        function todos() {
            $.get("mostrar.aspx?foto=" + $("#subirImagen").val() + "&texto=" + $("#txtPieFoto").val(), function (data) {
                $("#mostrar").html(data);
            });
        };
        function comentar(id_foto) {
            var actual = window.location;
            window.location.href = "comentar.aspx?idFoto=" + id_foto + "&texto=" + $("#" + id_foto).val() + "&pag=" + actual;
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="head">
        <img id="logo" src="img/logo.png" width="20%"/>
        <div id="subir">
            <h1>¡Sube tu Foto!</h1>
            <table style="margin: 0 auto;">
                <tr>
                    <td>
                        <img id="ejSubirImagen" src="img/camera.png" width="160px"/>
                    </td>
                    <td><asp:TextBox ID="txtPieFoto" runat="server" 
                            placeholder="Escribe un pie de foto..." TextMode="MultiLine"
                            Height="150px" Width="250px"></asp:TextBox>
                    </td>
                    <td><div id="divSubirImagen" class="drop">
                            <input type="file" id="subirImagen" runat="server" class="drop" style="opacity: 0"/>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan=2>
                        <input type="button" class="button" value="Subir" onclick="todos()" style="width:550px; height: 50px; font-size:large;" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="sugerencias">
        <h2>Sugerencias</h2>
        <%
            mostrarUsuarios(); 
        %>
    </div>
    <div id="perfil">
        <h2>Perfil</h2>
        <%
            imprimirPerfil();
        %>
    </div> 
    <div id="mostrar">

    </div>
    </form>
</body>
</html>
<%
    }
    else
        Response.Redirect("index.aspx");
%>