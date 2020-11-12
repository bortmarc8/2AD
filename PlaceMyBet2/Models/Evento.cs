using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        public Evento(string equipoLocal, string equipoVisitante, DateTime fecha)
        {
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            this.Fecha = fecha;
        }

        internal string EquipoLocal { get; set; }
        internal string EquipoVisitante { get; set; }
        internal DateTime Fecha { get; set; }

    }

    public class EventoAll : Evento 
    {
        public EventoAll(string equipoLocal, string equipoVisitante, DateTime fecha, int id, int goles) : base (equipoLocal, equipoVisitante, fecha)
        {
            EquipoLocal = equipoLocal;
            this.Id = id;
            EquipoVisitante = equipoVisitante;
            this.Goles = goles;
            this.Fecha = fecha;
        }

        internal int Id { get; set; }
        internal int Goles { get; set; }
    }
}