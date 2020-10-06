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
        // GET: api/Usuarios/5
        public List<Usuario> Get() //Sobrecargar esto para que al llegarle un id haga el select from y el id con query parametrizada.
        {
            UsuariosRepository repo = new UsuariosRepository();
            List<Usuario> query = repo.Retrieve();

            return query;
        }

    public Usuario Get(int id) //Sobrecargar esto para que al llegarle un id haga el select from y el id con query parametrizada.
        {
            UsuariosRepository repo = new UsuariosRepository();
            List<Usuario> query = repo.Retrieve(id);

            return query;
        }

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
