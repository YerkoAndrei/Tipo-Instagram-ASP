<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verPerfil.aspx.cs" Inherits="Yerko_Orellana_Abello___Prueba_4.verPerfil" %>

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
        });
        function color() {
            var sexo = "<%imprimeSexo();%>";
            if (sexo == "m") {
                $("body").css("background-color", "#CEE3F6");
            }
            else {
                $("body").css("background-color", "#E3CEF6");
            }
        }
        function comentar(id_foto) {
            var actual = window.location;
            window.location.href = "comentar.aspx?idFoto=" + id_foto + "&texto=" + $("#" + id_foto).val() + "&pag="+actual;
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <img id="logo" src="img/logo.png" width="20%"/>
    <div id="verPerfil">
        <% imprimirPerfil();%>
    </div>
    <div id="verFotos">
        <% imprimirFotos();%>
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