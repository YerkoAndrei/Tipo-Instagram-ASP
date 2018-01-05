using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public class Foto_seguimiento
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
        private string nick_seguido;

        public string Nick_seguido
        {
            get { return nick_seguido; }
            set { nick_seguido = value; }
        }
        private string nick_seguidor;

        public string Nick_seguidor
        {
            get { return nick_seguidor; }
            set { nick_seguidor = value; }
        }
    }
}