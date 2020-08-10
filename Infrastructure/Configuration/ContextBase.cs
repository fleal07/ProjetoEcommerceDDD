using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    //Instalar pacote Nuget Microsof.EntityFrameworkCore
    public class ContextBase : IdentityDbContext<ApplicationUser>
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
            string strCon = "Server=localhost;Database=EcommerceDDD;Trusted_Connection=True;";
            return strCon;
        }
    }
}
