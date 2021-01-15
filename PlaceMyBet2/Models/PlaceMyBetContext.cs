using Microsoft.EntityFrameworkCore;
using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet2.Models
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public PlaceMyBetContext()
        {

        }

        public PlaceMyBetContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseMySql("Server=localhost;Database=placemybet_v2_EF;Uid=root;Pwd='';SslMode=none");
        }

    }
}