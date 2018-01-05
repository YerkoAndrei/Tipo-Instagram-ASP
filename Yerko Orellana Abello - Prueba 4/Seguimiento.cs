using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yerko_Orellana_Abello___Prueba_4
{
    public class Seguimiento
    {
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