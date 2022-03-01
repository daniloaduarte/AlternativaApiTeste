using Microsoft.EntityFrameworkCore;
using WebApiDanilo.Domain.Models;

namespace WebApiDanilo.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasOne<Categoria>(s => s.Categoria)
                .WithMany(g => g.Produtos)
                .HasForeignKey(s => s.CategoriaId);
        }
    }
}
