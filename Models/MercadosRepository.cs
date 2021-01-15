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

        internal List<MercadoAll> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT Tipo,CuotaOver,CuotaUnder FROM `mercado`;";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            MercadoAll mercado = null;
            List<MercadoAll> mercados = new List<MercadoAll>();

            while (res.Read())
            {
                mercado = new MercadoAll(res.GetString(0),  res.GetDouble(1), res.GetDouble(2));
                mercados.Add(mercado);
            }
            con.Close();
            return mercados;
        }

        internal Mercado Retrieve(int id)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM mercado where idMercado = @id";
            command.Parameters.AddWithValue("@id", id);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            Mercado mercado = null;

            while (res.Read())
            {
                mercado = new Mercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
            }
            con.Close();
            return mercado;

        }

        internal List<Mercado> Retrieve(int id, string tipo)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM mercado where idPartido = @id and Tipo = @tipo ";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@tipo", tipo);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            List<Mercado> mercado = new List<Mercado>();
            
            while (res.Read())
            {
                mercado.Add(new Mercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6)));
            }
            con.Close();
            return mercado;

        }

    }
}