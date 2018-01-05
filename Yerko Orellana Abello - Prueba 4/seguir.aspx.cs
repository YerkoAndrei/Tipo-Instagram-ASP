using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public partial class seguir : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            conexion.cierraConexion();
            string nick = (string)Session["nickActual"];
            string nick_seguir = Request.QueryString["nick"];
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "insert into seguimiento (nick_seguidor, nick_seguido) values ('" + nick + "', '" + nick_seguir + "')";
            comando.CommandText = query;
            if (comando.ExecuteNonQuery() > 0)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                Response.Write("Error");
            }
        }
    }
}