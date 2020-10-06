using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class Mercados
    {
        public int mercado_id { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public string tipo { get; set; }

    }
}