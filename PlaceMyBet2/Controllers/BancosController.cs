using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class BancosController : ApiController
    {
        // GET: api/Bancos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Bancos/5
        public Banco Get(int id)
        {
            BancosRepository repo = new BancosRepository();
            return repo.Retrieve();
        }

        // POST: api/Bancos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bancos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bancos/5
        public void Delete(int id)
        {
        }
    }
}
