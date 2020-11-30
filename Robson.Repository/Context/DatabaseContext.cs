using Microsoft.EntityFrameworkCore;
using Robson.Domain.Entities;
using Robson.Repository.Services;

namespace Robson.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Carreira> Carreiras { get; set; }

        public DatabaseContext()
        {
            PessoaSeedingService.InicializandoBaseDedDados(this).Wait();
            CarreiraSeedingService.InicializandoBaseDedDados(this).Wait();
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            PessoaSeedingService.InicializandoBaseDedDados(this).Wait();
            CarreiraSeedingService.InicializandoBaseDedDados(this).Wait();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("Robson");
            }
        }
    }
}
