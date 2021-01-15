using System;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta()
        {

        }

        public Apuesta(int apuestaId, double dinero, double cuota, bool tipoApuesta, DateTime fecha, Mercado mercado, int mercadoId, Usuario usuario, string usuarioId)
        {
            ApuestaId = apuestaId;
            Dinero = dinero;
            Cuota = cuota;
            TipoApuesta = tipoApuesta;
            Fecha = fecha;
            Mercado = mercado ?? throw new ArgumentNullException(nameof(mercado));
            MercadoId = mercadoId;
            Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            UsuarioId = usuarioId ?? throw new ArgumentNullException(nameof(usuarioId));
        }

        public int ApuestaId { get; set; }
        public double Dinero { get; set; }
        public double Cuota { get; set; }
        public bool TipoApuesta { get; set; }
        public DateTime Fecha { get; set; }
        public Mercado Mercado { get; set; }
        public int MercadoId { get; set; }
        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }

    }

}