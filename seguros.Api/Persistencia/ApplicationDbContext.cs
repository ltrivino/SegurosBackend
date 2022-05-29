using Microsoft.EntityFrameworkCore;
using Seguros.Api.Modelos;

namespace Seguros.Api.Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Asegurados> Asegurados { get; set; }
        public DbSet<Modelos.Seguros> Seguros { get; set; }
        public DbSet<AseguradosSeguros> AseguradosSeguros { get; set; }
    }
}
