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
        public List<MercadoDTO> Get()
        {
            System.Diagnostics.Debug.WriteLine("Ha entrado en el get");
            var ret = new MercadosRepository();
            List<MercadoDTO> lista = ret.Retrieve();
            System.Diagnostics.Debug.WriteLine(lista.Count());
            
            return new MercadosRepository().Retrieve();
        }

        // GET: api/Mercsdos/5
        public void Get(int id)
        {
            MercadosRepository repo = new MercadosRepository();
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
