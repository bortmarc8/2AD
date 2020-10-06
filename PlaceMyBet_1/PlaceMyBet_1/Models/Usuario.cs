using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class Usuario
    {
        public Usuario(string email_id, string nombre, string apellido, string edad)
        {
            this.email_id = email_id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }

        public string email_id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string edad { get; set; }

    }
}