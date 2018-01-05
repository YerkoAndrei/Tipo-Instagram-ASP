using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public partial class index : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            conexion.cierraConexion();
            this.Session["nickActual"] = "";
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nick = Request.Form["txtNick"];
            string email = Request.Form["txtEmail"];
            string nombre = Request.Form["txtNombre"];
            string sexo = Request.Form["sexo"];
            string pass = Request.Form["txtPass"];
            string pass2 = Request.Form["txtPass2"];

            if (nick.Trim().Equals("") || email.Trim().Equals("") || nombre.Trim().Equals("") || pass.Trim().Equals(""))
                Response.Write("Complete todos los campos");
            else
                if (pass.Equals(pass2))
                {
                    conexion.abreConexion();
                    comando.Connection = conexion.usaConexion();
                    string query = "select * from usuario where nick='" + nick + "'";
                    comando.CommandText = query;
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                        Response.Write("Nombre de usuario existente");
                    else
                    {
                        reader.Close();
                        string query2 = "insert into usuario values ('" + nick + "', '" + email + "', '" + nombre + "', '" + sexo + "', '" + pass + "', '¡Cambia tu estado!...', 'generico.jpg')";
                        comando.CommandText = query2;
                        if (comando.ExecuteNonQuery() > 0)
                        {
                            this.Session["nickActual"] = nick;
                            this.Session["sexoActual"] = sexo;
                            Response.Write("Exito en la creación");
                        }
                        else
                            Response.Write("Error al registrar");
                        conexion.cierraConexion();
                    }
                }
                else
                    Response.Write("Contraseñas distintas");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string login = Request.Form["txtLogin"];
            string loginPass = Request.Form["txtLoginPass"];
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "select * from usuario where nick='" + login + "' and pass='" + loginPass + "'";
            comando.CommandText = query;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                {
                    this.Session["nickActual"] = reader["nick"];
                    this.Session["emailActual"] = reader["email"];
                    this.Session["nombreActual"] = reader["nombre"];
                    this.Session["sexoActual"] = reader["sexo"];
                    this.Session["fotoActual"] = reader["foto_perfil"];
                    this.Session["estadoActual"] = reader["estado"];
                    conexion.cierraConexion();
                    Response.Redirect("home.aspx");
                }
            else
                Response.Write("Usuario invalido");
        }
    }
}