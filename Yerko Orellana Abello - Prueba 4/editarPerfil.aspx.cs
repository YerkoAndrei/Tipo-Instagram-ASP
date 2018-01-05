using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public partial class cambiarContrasena : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            actualizar();
            conexion.cierraConexion();
        }

        protected void btnEditarNormal_Click(object sender, EventArgs e)
        {
            string nick = (string)Session["nickActual"];
            string nuevoNombre = Request.Form["txtEditarNombre"];
            string nuevoEmail = Request.Form["txtEditarEmail"];
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "update usuario set nombre = '"+nuevoNombre+"', email = '"+nuevoEmail+"' where nick = '"+nick+"'";
            comando.CommandText = query;
            if (comando.ExecuteNonQuery() > 0)
            {
                Response.Write("Exito al editar");
                this.Session["nombreActual"] = nuevoNombre;
                this.Session["emailActual"] = nuevoEmail;
                actualizar();
            }
            else
                Response.Write("Error");
            conexion.cierraConexion();
        }

        protected void btnEditarEstado_Click(object sender, EventArgs e)
        {
            string nick = (string)Session["nickActual"];
            string nuevoEstado = Request.Form["txtEstado"];
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "update usuario set estado = '" + nuevoEstado + "' where nick = '" + nick + "'";
            comando.CommandText = query;
            if (comando.ExecuteNonQuery() > 0)
            {
                Response.Write("Exito al editar");
                this.Session["estadoActual"] = nuevoEstado;
                actualizar();
            }
            else
                Response.Write("Error");
            conexion.cierraConexion();
        }

        public void actualizar()
        {
            string nombre = (string)Session["nombreActual"];
            string email = (string)Session["emailActual"];
            string estado = (string)Session["estadoActual"];

            txtEditarNombre.Text = nombre;
            txtEditarEmail.Text = email;
            txtEstado.Text = estado;
        }
        public void imprimeSexo()
        {
            string sexo = (string)Session["sexoActual"];
            Response.Write(sexo);
        }
        public void mostrarImagen()
        {
            string imagen = (string)Session["fotoActual"];
            Response.Write(imagen);
        }

        protected void btnCambiarFoto_Click(object sender, EventArgs e)
        {
            string nick = (string)Session["nickActual"];
            string imagen = exImg.Value;
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "update usuario set foto_perfil = '" + imagen + "' where nick = '" + nick + "'";
            comando.CommandText = query;
            if (comando.ExecuteNonQuery() > 0)
            {
                Response.Write("Exito al editar");
                this.Session["fotoActual"] = imagen;
                actualizar();
            }
            else
                Response.Write("Error");
            conexion.cierraConexion();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}