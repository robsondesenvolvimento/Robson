using Microsoft.EntityFrameworkCore;
using Robson.Domain.Entities;

namespace Robson.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Carreira> Carreiras { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
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
