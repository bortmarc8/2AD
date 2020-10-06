using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class Apuesta
    {
        public Apuesta(int apuesta_id, int mercado_ref, string usuario_ref, double dinero)
        {
            this.apuesta_id = apuesta_id;
            this.mercado_ref = mercado_ref;
            this.usuario_ref = usuario_ref;
            this.dinero = dinero;
        }

        public int apuesta_id { get; set; }
        public int mercado_ref { get; set; }
        public string usuario_ref { get; set; }
        public double dinero { get; set; }

    }
}