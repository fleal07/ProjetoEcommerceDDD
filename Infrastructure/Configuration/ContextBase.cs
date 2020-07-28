using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Infrastructure.Configuration
{
    //Instalar pacote Nuget Microsof.EntityFrameworkCore
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }

        /// <summary>
        /// Método para configuração da conexão com o banco de dados
        /// </summary>
        /// <param name="optionsBuilder">Objeto DbContextOptionsBuilder </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Instalar pacote Nuget Microsof.EntityFrameworkCore.SqlServer
                optionsBuilder.UseSqlServer(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }

        private string GetConnectionString()
        {
            string strCon = "Server=tcp:fleal07.database.windows.net,1433;Database=GestaoPomar;User ID=fleal07;Password=ea+apesmna16;";
            return strCon;
        }
    }
}
