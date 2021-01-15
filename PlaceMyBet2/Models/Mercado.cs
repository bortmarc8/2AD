using System;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado()
        { 
        
        }

        public Mercado(int mercadoId, string tipo, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, Evento evento)
        {
            MercadoId = mercadoId;
            Tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            Evento = evento ?? throw new ArgumentNullException(nameof(evento));
        }

        public int MercadoId { get; set; }
        public string Tipo { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        public Evento Evento { get; set; }
        public int EventoId { get; set; }

    }

}