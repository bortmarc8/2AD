using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Usuario
    {
        public Usuario(string correo, string nombre, string apellidos, int edad)
        {
            this.Correo = correo ?? throw new ArgumentNullException(nameof(correo));
            this.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            this.Edad = edad;
        }

        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
    }
}