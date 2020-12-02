using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public List<ApuestaAll> Get()
        {
            ApuestasRepository repo = new ApuestasRepository();
            return repo.Retrieve();
        }

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            ApuestasRepository repo = new ApuestasRepository();
            return repo.Retrieve(id);
        }

        // POST: api/Apuestas
        public bool Post([FromBody]Apuesta apuesta)
        {
            ApuestasRepository repo = new ApuestasRepository();
            return repo.Upload(apuesta);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
