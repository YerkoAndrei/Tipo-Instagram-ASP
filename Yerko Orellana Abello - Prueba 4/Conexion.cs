using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public class Conexion
    {
        SqlConnection conexion;
        SqlCommand comando;
        private static Conexion instance;
        private Conexion()
        {
            conexion = new SqlConnection();
            string con = "Data Source=SPO_LAB0321\\ADMINISTRADOR; Initial Catalog=finalp4 ;User Id=sa; Password=123456; MultipleActiveResultSets=True";
            //string con = "Data Source=localhost; Initial Catalog=finalp4; Integrated Security = true; MultipleActiveResultSets = true";
            //string con = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=finalp4; Integrated Security = true; MultipleActiveResultSets = true";
            conexion.ConnectionString = con;
            comando = new SqlCommand();
        }
        public static Conexion Instance()
        {
            if (instance == null)
                instance = new Conexion();
            return instance;
        }
        public void abreConexion()
        {
            conexion.Open();
        }
        public void cierraConexion()
        {
            conexion.Close();
        }
        public SqlConnection usaConexion()
        {
            return conexion;
        }
    }
}