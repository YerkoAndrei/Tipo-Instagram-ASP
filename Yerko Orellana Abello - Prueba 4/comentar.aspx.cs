using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public partial class comentar : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            string nick = (string)Session["nickActual"];
            string id_foto = Request.QueryString["idFoto"];
            string texto = Request.QueryString["texto"];
            string pagina = Request.QueryString["pag"];
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "insert into comentario (id_foto, texto, nick_usuario) values (" + id_foto + ", '" + texto + "', '" + nick + "')";
            comando.CommandText = query;
            if (comando.ExecuteNonQuery() > 0)
            {
                Response.Redirect(pagina);
            }
            else
                Response.Write("Error");
            conexion.cierraConexion();
        }
    }
}