using PlaceMyBet_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet_1.Controllers
{
    public class UsuariosController : ApiController
    {
        //Maravillas da Jose <3
        public List<Usuario> Get() => new UsuariosRepository().Retrieve();
        public Usuario Get(string id) => new UsuariosRepository().Retrieve(id);

        // POST: api/Usuarios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }
    }
}
