using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public partial class verPerfil : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            conexion.cierraConexion();
        }
        public void imprimirFotos()
        {
            string res = "";
            List<Foto> listaFoto = leerFotos();
            foreach (Foto f in listaFoto)
            {
                List<Comentario> listaComentario = leerComentarios(f.Id);
                res += "<div class='publicacion'>";
                res += "<img src=img/" + f.Direccion + " width=300px />";
                res += "<table style='float:right;'>";
                res += "<tr><td>";
                res += "<div class='comentarios'>";
                foreach (Comentario c in listaComentario)
                {
                    res += "<a style='color:blue' href=verPerfil.aspx?nick=" + c.Nick_usuario + ">" + c.Nick_usuario + "</a>";
                    res += c.Texto + "<br>";
                }
                res += "</div>";
                res += "</td></tr>";
                res += "<tr><td>";
                res += "<textarea id='" + f.Id + "' style='width:98%; float:right;' placeholder='Escribe un comentario...'></textarea>";
                res += "</td><tr>";
                res += "</tr><td>";
                res += "<input style='width:100%; float:right;' type='button' class='button' value='Comentar' onclick='comentar(" + f.Id + ");' />";
                res += "</td></tr>";
                res += "</table>";
                res += "</div>";
            }
            conexion.cierraConexion();
            Response.Write(res);
        }
        public List<Comentario> leerComentarios(int id)
        {
            List<Comentario> lista = new List<Comentario>();
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "select * from comentario where id_foto = " + id;
            comando.CommandText = query;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Comentario c = new Comentario();
                c.Id_foto = (int)reader["id_foto"];
                c.Texto = (string)reader["texto"];
                c.Nick_usuario = (string)reader["nick_usuario"];
                lista.Add(c);
            }
            conexion.cierraConexion();
            return lista;
        }
        public List<Foto> leerFotos()
        {
            string nickFoto = Request.QueryString["nick"];
            List<Foto> lista = new List<Foto>();
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "select * from foto where nick_usuario = '" + nickFoto + "' order by id desc";
            comando.CommandText = query;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Foto f = new Foto();
                f.Id = (int)reader["id"];
                f.Nick_usuario = (string)reader["nick_usuario"];
                f.Direccion = (string)reader["direccion"];
                lista.Add(f);
            }
            conexion.cierraConexion();
            return lista;
        }
        public void imprimeSexo()
        {
            string nickFoto = Request.QueryString["nick"];
            string sexo = "";
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "select * from usuario where nick = '" + nickFoto + "'";
            comando.CommandText = query;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                sexo = (string)reader["sexo"];
            }
            conexion.cierraConexion();
            Response.Write(sexo);
        }
        public void imprimirPerfil()
        {
            string nickFoto = Request.QueryString["nick"];
            string res = "<table style='margin: 0 auto;'>";
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "select * from usuario where nick = '" + nickFoto + "'";
            comando.CommandText = query;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                res += "<tr><td><img width=200 src='img/" + reader["foto_perfil"] + "'></td>";
                res += "<td><h3>" + reader["nick"] + "</h3>";
                res += "<h3>" + reader["estado"] + "</h3>";
                res += "<p>" + reader["email"] + "</p>";
                res += "<p>" + reader["nombre"] + "</p></td></tr>";
            }
            res += "</table>";
            conexion.cierraConexion();
            Response.Write(res);
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}