using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class Evento
    {
        public Evento(int evento_id, string local, string visitante, int mercado1_ref, int mercado2_ref, int mercado3_ref)
        {
            this.evento_id = evento_id;
            this.local = local;
            this.visitante = visitante;
            this.mercado1_ref = mercado1_ref;
            this.mercado2_ref = mercado2_ref;
            this.mercado3_ref = mercado3_ref;
        }

        public int evento_id { get; set; }
        public string local { get; set; }
        public string visitante { get; set; }
        public int mercado1_ref { get; set; }
        public int mercado2_ref { get; set; }
        public int mercado3_ref { get; set; }

    }
}