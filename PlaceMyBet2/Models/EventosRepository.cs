using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class EventosRepository
    {
        internal MySqlConnection Connect()
        {
            string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet_v2;";
            return new MySqlConnection(connString);

        }
        internal List<Evento> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT EquipoLocal,EquipoVisitante,Fecha FROM `partido`";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            Evento evento = new Evento("VLC", "Barcelona", DateTime.Now);
            List<Evento> eventos = new List<Evento>();

            while (res.Read())
            {
                //evento = new Evento(res.GetString(0), res.GetString(1), res.GetMySqlDateTime(2));
                //evento = new Evento("VLC", "Barcelona", DateTime.Now);
                eventos.Add(evento);
            }
            con.Close();

            return eventos;
        }

        internal Evento Retrieve(int id)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM `partido` where id = @id;";
            command.Parameters.AddWithValue("@id", id);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            Evento evento = null;

            if (res.Read())
            {
                evento = new EventoAll(res.GetString(1), res.GetString(2), res.GetDateTime(4), res.GetInt32(0), res.GetInt32(3));
            }
            con.Close();

            return evento;
        }
    }
}