using System;

namespace PlaceMyBet.Models
{
    public class Banco
    {
        public Banco()
        {

        }

        public Banco(int bancoId, double saldo, string nombre, int numTarjeta, Usuario usuario, string usuarioId)
        {
            BancoId = bancoId;
            Saldo = saldo;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            NumTarjeta = numTarjeta;
            Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            UsuarioId = usuarioId ?? throw new ArgumentNullException(nameof(usuarioId));
        }

        public int BancoId { get; set; }
        public double Saldo { get; set; }
        public string Nombre { get; set; }
        public int NumTarjeta { get; set; }
        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }

    }
}