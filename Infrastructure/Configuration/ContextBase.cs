using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    //Instalar pacote Nugget Microsoft.EntityFrameworkCore
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<UserPurchase> UserPurchase { get; set; }
        /// <summary>
        /// Método para configuração da conexão com o banco de dados
        /// </summary>
        /// <param name="optionsBuilder">Objeto DbContextOptionsBuilder </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Instalar pacote Nugget Microsoft.EntityFrameworkCore.SqlServer
                optionsBuilder.UseSqlServer(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }

        private string GetConnectionString()
        {
            string strCon = "Server=localhost;Database=EcommerceDDD;Integrated Security=False;Trusted_Connection=True;";
            return strCon;
        }
    }
}
