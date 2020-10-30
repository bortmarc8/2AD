using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Usuario
    {
        public Usuario(string correo, string nombre, string apeliidos, int edad)
        {
            this.correo = correo ?? throw new ArgumentNullException(nameof(correo));
            this.nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.apellidos = apeliidos ?? throw new ArgumentNullException(nameof(apeliidos));
            this.edad = edad;
        }

        internal string correo { get; set; }
        internal string nombre { get; set; }
        internal string apellidos { get; set; }
        internal int edad { get; set; }
    }
}