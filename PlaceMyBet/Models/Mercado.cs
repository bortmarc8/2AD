using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(int idMercado, string tipo, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder)
        {
            this.idMercado = idMercado;
            this.tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
        }

        internal int idMercado { get; set; }
        internal string tipo { get; set; }
        internal double cuotaOver { get; set; }
        internal double cuotaUnder { get; set; }
        internal double dineroOver { get; set; }
        internal double dineroUnder { get; set; }
    }
}