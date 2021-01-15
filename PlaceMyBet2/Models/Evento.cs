using System;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        public Evento()
        {

        }

        public Evento(int eventoId, string equipoLocal, string equipoVisitante, int goles, DateTime fecha)
        {
            EventoId = eventoId;
            EquipoLocal = equipoLocal ?? throw new ArgumentNullException(nameof(equipoLocal));
            EquipoVisitante = equipoVisitante ?? throw new ArgumentNullException(nameof(equipoVisitante));
            Goles = goles;
            Fecha = fecha;
        }

        public int EventoId { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public int Goles { get; set; }
        public DateTime Fecha { get; set; }

    }
}