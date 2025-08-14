using Microsoft.EntityFrameworkCore;
using SistemaVentasPOS.Models;

namespace SistemaVentasPOS.Data
{
    public class BDContexto : DbContext
    {
        public BDContexto(DbContextOptions<BDContexto> options)
            : base(options)
        {
        }

        // Definimos las propiedades DbSet para cada tabla de nuestra base de datos
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Las propiedades de navegación ya están definidas en los modelos,
            // pero podemos ajustar los nombres de las tablas y las relaciones si fuera necesario.

            // Mapeo explícito a los nombres de las tablas
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Producto>().ToTable("Producto");

            base.OnModelCreating(modelBuilder);
        }
    }
}