using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class Apuestas
    {
        public int apuesta_id { get; set; }
        public int mercado_ref { get; set; }
        public string usuario_ref { get; set; }
        public int dinero { get; set; }

    }
}