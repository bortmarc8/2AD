using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int idApuesta, double dinero, double cuota, DateTime fecha, int idMercado, string correoUsuario)
        {
            this.idApuesta = idApuesta;
            this.dinero = dinero;
            this.cuota = cuota;
            this.fecha = fecha;
            this.idMercado = idMercado;
            this.correoUsuario = correoUsuario ?? throw new ArgumentNullException(nameof(correoUsuario));
        }

        internal int idApuesta { get; set; }
        internal double dinero { get; set; }
        internal double cuota { get; set; }
        internal DateTime fecha { get; set; }
        internal int idMercado { get; set; }
        internal string correoUsuario { get; set; }
    }
}