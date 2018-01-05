using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public partial class mostrar : System.Web.UI.Page
    {
        Conexion conexion = Conexion.Instance();
        SqlCommand comando = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            conexion.cierraConexion();

            string nick = (string)Session["nickActual"];
            string texto = Request.QueryString["texto"];
            string imagen = Request.QueryString["foto"];
            if (!imagen.Equals(""))
            {
                if (texto.Equals(""))
                {
                    conexion.abreConexion();
                    comando.Connection = conexion.usaConexion();
                    string query = "insert into foto (nick_usuario, direccion) values ('" + nick + "', '" + imagen + "')";
                    comando.CommandText = query;
                    if (comando.ExecuteNonQuery() > 0)
                    {
                        imprimirTodo();
                    }
                    else
                        Response.Write("Error");
                    conexion.cierraConexion();
                }
                else
                {
                    conexion.abreConexion();
                    comando.Connection = conexion.usaConexion();
                    string query = "insert into foto (nick_usuario, direccion) values ('" + nick + "', '" + imagen + "')";
                    comando.CommandText = query;
                    if (comando.ExecuteNonQuery() > 0)
                    {
                        string querySelect = "select top 1 * from foto order by id desc";
                        comando.CommandText = querySelect;
                        SqlDataReader reader = comando.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string query2 = "insert into comentario (id_foto, texto, nick_usuario) values ('" + reader["id"] + "', '" + texto + "', '" + nick + "')";
                            reader.Close();
                            comando.CommandText = query2;
                            if (comando.ExecuteNonQuery() > 0)
                            {
                                imprimirTodo();
                            }
                            else
                                Response.Write("Error");
                            conexion.cierraConexion();
                        }
                    }
                    else
                        Response.Write("Error");
                    conexion.cierraConexion();
                }
            }
            else
                imprimirTodo();
        }

        public void imprimirTodo()
        {
            conexion.cierraConexion();
            string res = "";
            string nick = (string)Session["nickActual"];
            List<Foto> lista = filtrar();
            foreach (Foto f in lista) 
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
            Response.Write(res);
        }

        public List<Comentario> leerComentarios(int id)
        {
            List<Comentario> lista = new List<Comentario>();
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "select * from comentario where id_foto = "+id;
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
            List<Foto> lista = new List<Foto>();
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "select * from foto order by id desc";
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
        public List<Seguimiento> leerSeguimientos()
        {
            string nick = (string)Session["nickActual"];
            List<Seguimiento> lista = new List<Seguimiento>();
            conexion.abreConexion();
            comando.Connection = conexion.usaConexion();
            string query = "select * from seguimiento where nick_seguidor = '" + nick + "'";
            comando.CommandText = query;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Seguimiento s = new Seguimiento();
                s.Nick_seguido = (string)reader["nick_seguido"];
                s.Nick_seguidor = (string)reader["nick_seguidor"];
                lista.Add(s);
            }
            conexion.cierraConexion();
            return lista;
        }

        public List<Foto> filtrar()
        {
            string nick = (string)Session["nickActual"];
            List<Foto> lista = new List<Foto>();
            List<Seguimiento> listaSeguimientos = leerSeguimientos();
            List<Foto> listaFotos = leerFotos();
            foreach (Foto f in listaFotos)
            {
                foreach (Seguimiento s in listaSeguimientos)
                {
                    if (f.Nick_usuario == s.Nick_seguido || f.Nick_usuario == nick)
                    {
                        lista.Add(f);
                    }
                }
                if(listaSeguimientos.Count == 0)
                    if (f.Nick_usuario == nick)
                        lista.Add(f);
            }
            return lista;
        }
    }
}