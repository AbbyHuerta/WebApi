using PracticaWebApiSonia.Model;
using Microsoft.EntityFrameworkCore;

namespace PracticaWebApiSonia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo de tabla y esquema
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory", "Production");

            // Clave primaria
            modelBuilder.Entity<ProductCategory>().HasKey(p => p.ProductCategoryID);

            // Propiedades adicionales
            modelBuilder.Entity<ProductCategory>().Property(p => p.Name).HasColumnName("Name");
            modelBuilder.Entity<ProductCategory>().Property(p => p.RowGuid).HasColumnName("rowguid");
            modelBuilder.Entity<ProductCategory>().Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}


