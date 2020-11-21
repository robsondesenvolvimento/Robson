using Microsoft.EntityFrameworkCore;
using Robson.Domain.Entities;

namespace Robson.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
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
