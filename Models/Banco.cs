using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Banco
    {
        public Banco(int idBanco, double saldo, string nombre, int numTarjeta, string correoUsuario)
        {
            this.idBanco = idBanco;
            this.saldo = saldo;
            this.nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.numTarjeta = numTarjeta;
            this.correoUsuario = correoUsuario ?? throw new ArgumentNullException(nameof(correoUsuario));
        }

        internal int idBanco { get; set; }
        internal double saldo { get; set; }
        internal string nombre { get; set; }
        internal int numTarjeta { get; set; }
        internal string correoUsuario { get; set; }
    }
}