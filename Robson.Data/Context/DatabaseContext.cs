using Microsoft.EntityFrameworkCore;
using Robson.Data.Services;
using Robson.Domain.Entities;

namespace Robson.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Carreira> Carreiras { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Formacao> Formacoes { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            PessoaSeedingService.InicializandoBaseDedDados(this).Wait();
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
