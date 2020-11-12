using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class MercadosRepository
    {
        internal MySqlConnection Connect()
        {
            string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet_v2;";
            return new MySqlConnection(connString);

        }

        internal List<MercadoDTO> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM mercado";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            //Mercado mercado = null;
            MercadoDTO mercado = null;
            List<MercadoDTO> mercados = new List<MercadoDTO>();

            while (res.Read())
            {
                System.Diagnostics.Debug.WriteLine("Encontrado: "+res.GetString(1));
                //mercado = new Mercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                mercado = new MercadoDTO(res.GetString(1));
                mercados.Add(mercado);
            }
            con.Close();
            System.Diagnostics.Debug.WriteLine(mercados.Count);
            return mercados;
        }

    }
}