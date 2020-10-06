using PlaceMyBet_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet_1.Controllers
{
    public class ApuestasController : ApiController
    {
        //Maravillas da Jose <3
        public List<Apuesta> Get() => new ApuestasRepository().Retrieve();

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
