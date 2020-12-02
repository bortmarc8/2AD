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

        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }

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

        public int Id { get; set; }
        public int Goles { get; set; }
    }
}