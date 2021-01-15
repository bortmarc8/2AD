using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(int idMercado, string tipo, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, int idPartido)
        {
            IdMercado = idMercado;
            Tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            IdPartido = idPartido;
        }

        public int IdMercado { get; set; }
        public string Tipo { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        public int IdPartido { get; set; }
    }

    public class MercadoAll
    {
        public MercadoAll(string tipo, double cuotaOver, double cuotaUnder)
        {
            Tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
        }

        public string Tipo { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }

    }

}