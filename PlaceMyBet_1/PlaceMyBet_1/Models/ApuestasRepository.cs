using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class ApuestasRepository
    {
        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            List<ArrayList> datos = Common.MasterRepository.Leer("SELECT * FROM apuestas");
            foreach (var item in datos)
            {
                apuestas.Add(new Apuesta((int)item[0], (int)item[1], item[2].ToString(), (float)item[3]));
            }
            return apuestas;
        } 
    }
}