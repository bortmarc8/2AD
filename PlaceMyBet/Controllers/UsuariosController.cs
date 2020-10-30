using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: api/Users
        public List<Usuario> Get()
        {
            return new List<Usuario>();
        }

        // GET: api/Users/5
        public Usuario Get(int id)
        {
            return new Usuario("bortmarc8@gmail.com", "Mark", "Bort Tomás", 19);
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
