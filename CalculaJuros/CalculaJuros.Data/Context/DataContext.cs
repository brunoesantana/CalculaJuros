using CalculaJuros.Domain;
using Microsoft.EntityFrameworkCore;

namespace CalculaJuros.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Calculo> Calculo { get; set; }
        public DbSet<Projeto> Projeto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("Server=BRUNOPC\\SQLEXPRESS;Database=CalculaJuros;Trusted_Connection=True");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
