using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Models
{
    public class UsuariosRepository
    {
        internal List<Usuario> Retrieve()
        {
            List<Usuario> usuarios = new List<Usuario>();
            List<ArrayList> datos = Common.MasterRepository.Leer("SELECT * FROM usuarios");
            foreach (var item in datos)
            {
                usuarios.Add(new Usuario(item[0].ToString(), item[0].ToString(), item[0].ToString(), item[0].ToString()));
            }
            return usuarios;
        }

        internal Usuario Retrieve(int id)
        {
            Usuario usuario = new Usuario();
            MySqlCommand query = new MySqlCommand("SELECT * FROM usuarios where email_id = @ID");
            query.Parameters.AddWithValue("@ID", id);
            List<ArrayList> datos = Common.MasterRepository.Leer(query);
            foreach (var item in datos)
            {
                usuario = new Usuario(item[0].ToString(), item[1].ToString(), item[2].ToString(), item[3].ToString()));
            }
            return usuario;
        }
    }
}
