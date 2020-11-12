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

        internal int IdMercado { get; set; }
        internal string Tipo { get; set; }
        internal double CuotaOver { get; set; }
        internal double CuotaUnder { get; set; }
        internal double DineroOver { get; set; }
        internal double DineroUnder { get; set; }
        internal int IdPartido { get; set; }
    }

    public class MercadoDTO
    {
        public MercadoDTO(string idMercado)
        {
            MercadoTipo = idMercado;
        }

        internal string MercadoTipo { get; set; }
    }

}