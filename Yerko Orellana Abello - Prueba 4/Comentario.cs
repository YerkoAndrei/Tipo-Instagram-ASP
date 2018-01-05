using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public class Comentario
    {
        private int id_foto;

        public int Id_foto
        {
            get { return id_foto; }
            set { id_foto = value; }
        }
        private string texto;

        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
        private string nick_usuario;

        public string Nick_usuario
        {
            get { return nick_usuario; }
            set { nick_usuario = value; }
        }
    }
}