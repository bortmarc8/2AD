using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class ApuestasRepository
    {
        internal Apuesta Retrieve()
        {
            Apuesta apuesta = new Apuesta(1, 222, 2.5, DateTime.Now, 1, "bortmarc8@gmail.com");
            return apuesta;
        }
    }
}