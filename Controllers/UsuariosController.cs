using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            return new UsuariosRepository().Retrieve();
        }

        // GET: api/Users/5
        public void Get(int id)
        {
            /*var repo = new UsuariosRepository();
            Usuario user = repo.Retrieve();
            return user;*/

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
