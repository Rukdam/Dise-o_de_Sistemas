using Microsoft.EntityFrameworkCore;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.Enums;

namespace WebApiCSharp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // TABLAS REALES QUE EF CORE CREARÁ
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; } // Cambiado de Role a Rol para consistencia
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<RolAccion> RolAcciones { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<OrdenProduccion> OrdenesProduccion { get; set; } // Renombrado de Ordenes
        public DbSet<TareaEjecucion> TareasEjecucion { get; set; } // Renombrado de Tareas
        public DbSet<Incidente> Incidentes { get; set; }
        public DbSet<OrdenProduccionProducto> OrdenProduccionProductos { get; set; } // Renombrado de OrdenProductos



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ====================
            //      USUARIOS
            // ====================
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            // ====================
            //      ROLES
            // ====================
            modelBuilder.Entity<Rol>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Rol>()
                .Property(r => r.Nombre)
                .HasMaxLength(100)
                .IsRequired();


            // ====================
            //   TABLAS DE UNIÓN
            // ====================

            // Many-to-many Usuario <-> Rol via UsuarioRol
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Usuarios)
                .UsingEntity<UsuarioRol>(
                    j => j.HasOne(ur => ur.Rol).WithMany().HasForeignKey(ur => ur.IdRol),
                    j => j.HasOne(ur => ur.Usuario).WithMany().HasForeignKey(ur => ur.IdUsuario),
                    j => j.HasKey(ur => new { ur.IdUsuario, ur.IdRol })
                );

            // Clave primaria compuesta para RolAccion
            modelBuilder.Entity<RolAccion>()
                .HasKey(ra => new { ra.IdRol, ra.IdAccion });



            // ====================
            //   ORDEN PRODUCCIÓN
            // ====================
            modelBuilder.Entity<OrdenProduccion>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<OrdenProduccion>()
                .Property(o => o.Estado)
                .HasConversion<string>(); // enum → string

            // Relación Orden → Tareas
            modelBuilder.Entity<OrdenProduccion>()
                .HasMany(o => o.Tareas)
                .WithOne()
                .HasForeignKey(t => t.OrdenProduccionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Orden → Incidentes
            modelBuilder.Entity<OrdenProduccion>()
                .HasMany(o => o.Incidentes)
                .WithOne()
                .HasForeignKey(i => i.OrdenProduccionId)
                .OnDelete(DeleteBehavior.Cascade);


            // ====================
            //       TAREAS
            // ====================
            modelBuilder.Entity<TareaEjecucion>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TareaEjecucion>()
                .Property(t => t.Estado)
                .HasConversion<string>(); // enum → string


            // ====================
            //      INCIDENTES
            // ====================
            modelBuilder.Entity<Incidente>()
                .HasKey(i => i.Id);


            // ====================
            //      PRODUCTOS
            // ====================
            modelBuilder.Entity<Producto>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Producto>()
                .Property(p => p.TipoProducto)
                .HasConversion<string>(); // enum → string


            // ====================
            //   ORDEN-PRODUCTO
            // ====================
            modelBuilder.Entity<OrdenProduccionProducto>()
                .HasKey(op => op.Id);

            modelBuilder.Entity<OrdenProduccionProducto>()
                .HasOne<Producto>()
                .WithMany()
                .HasForeignKey(op => op.ProductoId);

            modelBuilder.Entity<OrdenProduccionProducto>()
                .HasOne<OrdenProduccion>()
                .WithMany(o => o.Productos)
                .HasForeignKey(op => op.OrdenProduccionId);
        }
    }
}
