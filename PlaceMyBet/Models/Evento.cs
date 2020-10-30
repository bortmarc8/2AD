using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        public Evento(int id, string equipoLocal, string equipoVisitante, int goles, DateTime fecha)
        {
            this.id = id;
            EquipoLocal = equipoLocal ?? throw new ArgumentNullException(nameof(equipoLocal));
            EquipoVisitante = equipoVisitante ?? throw new ArgumentNullException(nameof(equipoVisitante));
            this.goles = goles;
            this.fecha = fecha;
        }

        internal int id { get; set; }
        internal string EquipoLocal { get; set; }
        internal string EquipoVisitante { get; set; }
        internal int goles { get; set; }
        internal DateTime fecha { get; set; }
    }
}