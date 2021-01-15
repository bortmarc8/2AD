using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;

namespace PlaceMyBet.Models
{
    [AllowAnonymous]
    public class ApuestasRepository
    {
        internal MySqlConnection Connect()
        {
            string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet_v2;";
            return new MySqlConnection(connString);

        }

        internal List<ApuestaAll> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT correoUsuario,mercado.Tipo,Cuota,TipoApuesta,Dinero,fecha FROM `apuesta` INNER JOIN mercado on apuesta.idMercado = mercado.idMercado;";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            ApuestaAll apuesta = null;
            List<ApuestaAll> apuestas = new List<ApuestaAll>();

            while (res.Read())
            {
                apuesta = new ApuestaAll(res.GetString(0), res.GetString(1), res.GetDouble(2), res.GetBoolean(3), res.GetDouble(4), res.GetDateTime(5));
                apuestas.Add(apuesta);
            }
            con.Close();
            return apuestas;
        }

        //Funcion de examen: Ejercicio 1
        internal List<Apuesta> Retrieve(double min, double max)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT apuesta.idApuesta, apuesta.Dinero, apuesta.Cuota, apuesta.TipoApuesta, apuesta.fecha, apuesta.idMercado, apuesta.correoUsuario FROM `apuesta` INNER JOIN mercado on apuesta.idMercado = mercado.idMercado where apuesta.cuota > @cuotaMin and apuesta.cuota < @cuotaMax";
            command.Parameters.AddWithValue("@cuotaMin", min);
            command.Parameters.AddWithValue("@cuotaMax", max);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            Apuesta apuesta = null;
            List<Apuesta> apuestas = new List<Apuesta>();

            while (res.Read())
            {
                apuesta = new Apuesta(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetBoolean(3), res.GetDateTime(4), res.GetInt32(5), res.GetString(6));
                apuestas.Add(apuesta);
            }
            con.Close();
            return apuestas;
        }

        //Funcion de examen: Ejercicio 2
        internal List<Apuesta> Retrieve(int id)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT apuesta.idApuesta, apuesta.Dinero, apuesta.Cuota, apuesta.TipoApuesta, apuesta.fecha, apuesta.idMercado, apuesta.correoUsuario FROM `apuesta` where apuesta.idMercado = @id and apuesta.Dinero > 100;";
            command.Parameters.AddWithValue("@id", id);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            Apuesta apuesta = null;
            List<Apuesta> apuestas = new List<Apuesta>();

            while (res.Read())
            {
                apuesta = new Apuesta(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetBoolean(3), res.GetDateTime(4), res.GetInt32(5), res.GetString(6));
                apuestas.Add(apuesta);
            }
            con.Close();
            return apuestas;
        }

        internal List<ApuestasUsuarioMercado> Retrieve(string user, string tipo)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select mercado.idPartido, apuesta.TipoApuesta, apuesta.Cuota, apuesta.Dinero mercado from apuesta inner join mercado on apuesta.idMercado = mercado.idMercado where apuesta.correoUsuario = @user and mercado.Tipo = @tipo;";
            command.Parameters.AddWithValue("@tipo", tipo);
            command.Parameters.AddWithValue("@user", user);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            List<ApuestasUsuarioMercado> apuestas = new List<ApuestasUsuarioMercado>();

            while (res.Read())
            {
                ApuestasUsuarioMercado apuesta = new ApuestasUsuarioMercado(res.GetInt32(0), res.GetBoolean(1), res.GetDouble(2), res.GetInt32(3));
                apuestas.Add(apuesta);
            }
            con.Close();
            return apuestas;
        }

        internal List<ApuestasUsuarioMercado> Retrieve(string user, int idMercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select mercado.idPartido, apuesta.TipoApuesta, apuesta.Cuota, apuesta.Dinero mercado from apuesta inner join mercado on apuesta.idMercado = mercado.idMercado where apuesta.correoUsuario = @user and mercado.idMercado = @mercadoId;";
            command.Parameters.AddWithValue("@mercadoId", idMercado);
            command.Parameters.AddWithValue("@user", user);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            List<ApuestasUsuarioMercado> apuestas = new List<ApuestasUsuarioMercado>();

            while (res.Read())
            {
                ApuestasUsuarioMercado apuesta = new ApuestasUsuarioMercado(res.GetInt32(0), res.GetBoolean(1), res.GetDouble(2), res.GetInt32(3));
                apuestas.Add(apuesta);
            }
            con.Close();
            return apuestas;
        }



        [Authorize(Roles = "Admin")]
        internal Apuesta Retrieve(Usuario user)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM `apuesta` WHERE correoUsuario = @id;";
            command.Parameters.AddWithValue("@id", user.Correo);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            Apuesta apuesta = null;

            if (res.Read())
            {
                apuesta = new Apuesta(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetBoolean(3), res.GetDateTime(4), res.GetInt32(5), res.GetString(6));
            }
            con.Close();
            return apuesta;
        }

        internal bool Upload(Apuesta obj)
        {
            try
            {
                MySqlConnection con = Connect();
                MySqlCommand dineroMercados = con.CreateCommand();
                double dineroOver = 0, dineroUnder= 0, cuotaOver = 0, cuotaUnder = 0;
                dineroMercados.CommandText = "SELECT DineroOver,DineroUnder from mercado where idMercado = @idMercado";
                dineroMercados.Parameters.AddWithValue("@idMercado", obj.IdMercado);
                con.Open();
                MySqlDataReader res = dineroMercados.ExecuteReader();

                MySqlCommand command = con.CreateCommand();
                command.CommandText = "INSERT INTO `apuesta` (`idApuesta`, `Dinero`, `Cuota`, `TipoApuesta`, `fecha`, `idMercado`, `correoUsuario`) VALUES (NULL, @dinero, @cuota, @tipoApuesta, current_timestamp(), @idMercado, @correoUsuario)";

                if (res.Read())
                {
                    dineroOver = res.GetDouble(0);
                    dineroUnder = res.GetDouble(1);
                    con.Close();

                    if (obj.TipoApuesta)
                    {
                        cuotaOver = (1 / ((dineroOver + obj.Dinero) / (dineroOver + dineroUnder))) * 0.95;
                        cuotaUnder = (1 / (dineroUnder / (dineroOver + dineroUnder))) * 0.95;
                        dineroOver += obj.Dinero;
                        command.Parameters.AddWithValue("@cuota", cuotaOver);
                    }
                    else
                    {
                        cuotaUnder = (1 / ((dineroUnder + obj.Dinero) / (dineroOver + dineroUnder))) * 0.95;
                        cuotaOver = (1 / (dineroOver / (dineroOver + dineroUnder))) * 0.95;
                        dineroUnder += obj.Dinero;
                        command.Parameters.AddWithValue("@cuota", cuotaUnder);
                    }

                    command.Parameters.AddWithValue("@dinero", obj.Dinero);     
                    command.Parameters.AddWithValue("@tipoApuesta", obj.TipoApuesta);
                    command.Parameters.AddWithValue("@idMercado", obj.IdMercado);
                    command.Parameters.AddWithValue("@correoUsuario", obj.CorreoUsuario);
                    con.Open();

                    int retorno = command.ExecuteNonQuery();
                    
                    if (retorno > 0)
                    {
                        con.Close();
                        MySqlCommand updateMercados = con.CreateCommand();
                        updateMercados.CommandText = "UPDATE `mercado` SET `CuotaOver` = @cuotaOver, `CuotaUnder` = @cuotaUnder, `DineroOver` = @dineroOver, `DineroUnder` = @dineroUnder WHERE `mercado`.`idMercado` = @idMercado";
                        updateMercados.Parameters.AddWithValue("@cuotaOver", cuotaOver);
                        updateMercados.Parameters.AddWithValue("@cuotaUnder", cuotaUnder);
                        updateMercados.Parameters.AddWithValue("@dineroOver", dineroOver);
                        updateMercados.Parameters.AddWithValue("@dineroUnder", dineroUnder);
                        updateMercados.Parameters.AddWithValue("@idMercado", obj.IdMercado);

                        con.Open();
                        Debug.WriteLine("No peta antes de la linea 120: " + obj.IdMercado);
                        retorno = updateMercados.ExecuteNonQuery();
                        Debug.WriteLine("No peta antes de la linea 122");
                        if (retorno > 0)
                        {
                            con.Close();
                            return true;
                        }
                        else
                        {
                            con.Close();
                            return false;
                        }    
                    }
                    else
                    {
                        con.Close();
                        return false;
                    }
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}