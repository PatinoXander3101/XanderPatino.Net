using Microsoft.EntityFrameworkCore;
using Servicios.Models;

namespace Servicios.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // 🔹 Tablas
        public DbSet<CategoriaServicio> CategoriasServicio { get; set; } = default!;
        public DbSet<ServicioManoObra> ServiciosManoObra { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===================================
            //  CATEGORIA SERVICIO
            // ===================================
            modelBuilder.Entity<CategoriaServicio>(entity =>
            {
                entity.ToTable("CategoriasServicio");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(80);

                entity.Property(e => e.Descripcion)
                      .HasMaxLength(200);

                entity.Property(e => e.Activo)
                      .HasDefaultValue(true);

                entity.Property(e => e.FechaCreacion)
                      .HasColumnType("datetime2");

                entity.Property(e => e.FechaActualizacion)
                      .HasColumnType("datetime2");

                entity.Property(e => e.CreadoPor)
                      .HasMaxLength(100);

                entity.Property(e => e.ActualizadoPor)
                      .HasMaxLength(100);

                // ✅ No repetir nombre de categoría
                entity.HasIndex(e => e.Nombre).IsUnique();
            });

            // ===================================
            //  SERVICIO MANO DE OBRA
            // ===================================
            modelBuilder.Entity<ServicioManoObra>(entity =>
            {
                entity.ToTable("ServiciosManoObra");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Codigo)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(120);

                entity.Property(e => e.Descripcion)
                      .HasMaxLength(500);

                // ✅ FK a CategoriasServicio
                entity.Property(e => e.CategoriaServicioId)
                      .IsRequired();

                entity.HasOne(e => e.CategoriaServicio)
                      .WithMany(c => c.Servicios)
                      .HasForeignKey(e => e.CategoriaServicioId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Horas)
                      .HasPrecision(5, 2);

                entity.Property(e => e.TarifaHora)
                      .HasPrecision(18, 2);

                entity.Property(e => e.DescuentoPorc)
                      .HasPrecision(5, 2);

                entity.Property(e => e.IvaPorc)
                      .HasPrecision(5, 2)
                      .HasDefaultValue(19m);

                entity.Property(e => e.FechaCreacion)
                      .HasColumnType("datetime2");

                entity.Property(e => e.FechaActualizacion)
                      .HasColumnType("datetime2");

                entity.Property(e => e.CreadoPor)
                      .HasMaxLength(100);

                entity.Property(e => e.ActualizadoPor)
                      .HasMaxLength(100);

                entity.Property(e => e.Activo)
                      .HasDefaultValue(true);

                // ✅ No repetir códigos
                entity.HasIndex(e => e.Codigo).IsUnique();

                // Índices útiles para búsquedas (no únicos)
                entity.HasIndex(e => e.Nombre);
                entity.HasIndex(e => new { e.CategoriaServicioId, e.Activo });
            });

            // ===================================
            //  FILTROS GLOBALES (SOFT DELETE)
            // ===================================
            modelBuilder.Entity<CategoriaServicio>()
                        .HasQueryFilter(c => c.Activo);

            modelBuilder.Entity<ServicioManoObra>()
                        .HasQueryFilter(s => s.Activo);
        }
    }
}
