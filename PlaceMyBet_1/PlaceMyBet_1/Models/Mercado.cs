using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class Mercado
    {
        public Mercado(int mercado_id, double dineroOver, double dineroUnder, double cuotaOver, double cuotaUnder, string tipo)
        {
            this.mercado_id = mercado_id;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.tipo = tipo;
        }

        public int mercado_id { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public string tipo { get; set; }

    }
}