using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace PlaceMyBet.Models
{
    public class UsuariosRepository
    {
        internal MySqlConnection Connect()
        {
            string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet_v2;";
            return new MySqlConnection(connString);
            
        }
        internal List<Usuario> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM usuario";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            Usuario user = null;
            List<Usuario> usuarios = new List<Usuario>();

            while (res.Read())
            {
                user = new Usuario(res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
                usuarios.Add(user);
            }
            con.Close();

            return usuarios;
        }
    }
}