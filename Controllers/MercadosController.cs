using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercsdos
        public List<MercadoAll> Get()
        {
            return new MercadosRepository().Retrieve();
        }

        // GET: api/Mercsdos/5
        public Mercado Get(int id)
        {
            return new MercadosRepository().Retrieve(id);
        }

        public List<Mercado> Get(int id, string tipo)
        {
            return new MercadosRepository().Retrieve(id, tipo);
        }

        // POST: api/Mercsdos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercsdos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercsdos/5
        public void Delete(int id)
        {
        }
    }
}
