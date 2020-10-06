using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class EventosRepository
    {
        internal List<Evento> Retrieve()
        {
            List<Evento> eventos = new List<Evento>();
            List<ArrayList> datos = Common.MasterRepository.Leer("SELECT * FROM eventos");
            foreach (var item in datos)
            {
                eventos.Add(new Evento((int)item[0], item[1].ToString(), item[2].ToString(), (int)item[3], (int)item[4], (int)item[5]));
            }
            return eventos;
        }
    }
}
