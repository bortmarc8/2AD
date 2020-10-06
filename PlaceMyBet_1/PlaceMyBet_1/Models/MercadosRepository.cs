using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class MercadosRepository
    {
        internal List<Mercado> Retrieve()
        {
            List<Mercado> mercados = new List<Mercado>();
            List<ArrayList> datos = Common.MasterRepository.Leer("SELECT * FROM mercados");
            foreach (var item in datos)
            {
                mercados.Add(new Mercado((int)item[0], (float)item[1], (float)item[2], (float)item[3], (float       )item[4], item[5].ToString()));
            }
            return mercados;
        }
    }
}
