using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class BancosRepository
    {
        internal Banco Retrieve()
        {
            Banco banco = new Banco(1, 500, "Santander", 758600, "bortmarc8@gmail.com");
            return banco;
        }
    }
}