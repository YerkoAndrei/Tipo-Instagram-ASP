using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public class Usuario
    {
        private string nick;

        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        private string foto_perfil;

        public string Foto_perfil
        {
            get { return foto_perfil; }
            set { foto_perfil = value; }
        }
    }
}