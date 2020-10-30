using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace PlaceMyBet.Models
{
    public class UsuariosRepository
    {
        internal Usuario Retrieve()
        {
            Usuario user = new Usuario("bortmarc8@gmail.com", "Mark", "Bort Tomás", 19);
            return user;

        }
    }
}