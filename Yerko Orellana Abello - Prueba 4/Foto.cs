using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public class Foto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nick_usuario;

        public string Nick_usuario
        {
            get { return nick_usuario; }
            set { nick_usuario = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
    }
}