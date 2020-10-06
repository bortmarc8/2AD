using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class Evento
    {
        public int evento_id { get; set; }
        public string local { get; set; }
        public string visitante { get; set; }
        public int mercado1_ref { get; set; }
        public int mercado2_ref { get; set; }
        public int mercado3_ref { get; set; }

    }
}