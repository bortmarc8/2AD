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
    }
}
