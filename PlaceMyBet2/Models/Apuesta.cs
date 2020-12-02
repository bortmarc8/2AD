using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int idApuesta, double dinero, double cuota, bool tipoApuesta, DateTime fecha, int idMercado, string correoUsuario)
        {
            IdApuesta = idApuesta;
            Dinero = dinero;
            Cuota = cuota;
            TipoApuesta = tipoApuesta;
            Fecha = fecha;
            IdMercado = idMercado;
            CorreoUsuario = correoUsuario ?? throw new ArgumentNullException(nameof(correoUsuario));
        }

        public int IdApuesta { get; set; }
        public double Dinero { get; set; }
        public double Cuota { get; set; }
        public bool TipoApuesta { get; set; }
        public DateTime Fecha { get; set; }
        public int IdMercado { get; set; }
        public string CorreoUsuario { get; set; }
    }

    public class ApuestaAll
    {
        public ApuestaAll(string correoUsuario, string tipoMercado, double cuota, bool tipoApuesta, double dinero, DateTime fecha)
        {
            CorreoUsuario = correoUsuario ?? throw new ArgumentNullException(nameof(correoUsuario));
            TipoMercado = tipoMercado ?? throw new ArgumentNullException(nameof(tipoMercado));
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            Dinero = dinero;
            Fecha = fecha;
        }

        public string CorreoUsuario { get; set; }
        public string TipoMercado { get; set; }
        public bool TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double Dinero { get; set; }
        public DateTime Fecha { get; set; }

    }
}