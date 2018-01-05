using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public partial class home : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            conexion.cierraConexion();
        }

        public void imprimirPerfil()
        {
            string nick = (string)Session["nickActual"];
            string nombre = (string)Session["nombreActual"];
            string email = (string)Session["emailActual"];
            string imagen = (string)Session["fotoActual"];
            string estado = (string)Session["estadoActual"];

            Response.Write("<ul style='list-style-type:none; text-align:center'>"+
                           "<li><img src='img/"+imagen+"' height=200px /></li>"+
                           "<li><h4>"+nick+"</h4></li>" +
                           "<li><p>" + nombre + "</p></li>" +
                           "<li><p>" + email + "</p></li>" +
                           "<li><h4>" + estado + "</h4></li>" +
                           "<li><a href='editarPerfil.aspx'>Editar Perfil</a></li>" +
                           "<li><a href='index.aspx'>Cerrar Sesión</a></li>" +
                           "</ul>");
        }
        public void imprimeSexo()
        {
            string sexo = (string)Session["sexoActual"];
            Response.Write(sexo);
        }
        public void mostrarUsuarios()
        {
            string nick = (string)Session["nickActual"];
            List<Usuario> lista = new List<Usuario>();
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "select * from usuario";
            comando.CommandText = query;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Usuario u = new Usuario();
                u.Foto_perfil = (string)reader["foto_perfil"];
                u.Nick = (string)reader["nick"];
                lista.Add(u);
            }
            conexion.cierraConexion();
            seguimiento(lista);
        }
        public void seguimiento(List<Usuario> lista)
        {
            string nick = (string)Session["nickActual"];
            string res = "<table style='margin: 0 auto'>";
            foreach (Usuario u in lista)
            {
                if (u.Nick != nick)
                {
                    comando.Connection = conexion.usaConexion();
                    string query = "select * from seguimiento where nick_seguidor = '" + nick + "' and nick_seguido = '" + u.Nick + "'";
                    comando.CommandText = query;
                    conexion.abreConexion();
                    SqlDataReader reader = comando.ExecuteReader();
                    res += "<tr><td><img src='img/" + u.Foto_perfil + "' width=50px/></td>" +
                           "<td><a href=verPerfil.aspx?nick=" + u.Nick + ">" + u.Nick + "</a>";
                    if (reader.HasRows)
                        res += "</td><td><a href=dejarSeguir.aspx?nick=" + u.Nick + "><input type='button' value='Dejar de Seguir' class='button'></a></td></tr>";
                    else
                        res += "</td><td><a href=seguir.aspx?nick=" + u.Nick + "><input type='button' value='Seguir' class='button'></a></td></tr>";
                    conexion.cierraConexion();
                }
            }
            res += "</table>";
            Response.Write(res);
        }
    }
}