using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public partial class dejarSeguir : System.Web.UI.Page
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
            string query = "delete from seguimiento where nick_seguido = '" + nick_seguir + "' and nick_seguidor = '" + nick + "'";
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