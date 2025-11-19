using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net; // no se usa directamente, usamos BCrypt.Net.BCrypt abajo
using WebApiCSharp.Infrastructure.Persistence;
using WebApiCSharp.Domain.Entities; // Asegúrate que todas las entidades estén aquí
using WebApiCSharp.Domain.Enums;

namespace WebApiCSharp.Infrastructure.Persistence
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext ctx)
        {
            // Asegura que la DB y el model estén listos (si ya migraste)
            await ctx.Database.EnsureCreatedAsync();

            //------------------------------------------------------------
            // 1. ROLES
            //------------------------------------------------------------
            if (!await ctx.Roles.AnyAsync())
            {
                ctx.Roles.AddRange(
                    new Rol { Nombre = "ADMIN" },
                    new Rol { Nombre = "SUPERVISOR" },
                    new Rol { Nombre = "OPERARIO" }
                );
                await ctx.SaveChangesAsync();
            }

            //------------------------------------------------------------
            // 2. ACCIONES DEL SISTEMA
            //------------------------------------------------------------
            if (!await ctx.Acciones.AnyAsync())
            {
                var acciones = new List<Accion>
                {
                    new Accion { Nombre = "CREAR_ORDEN" },
                    new Accion { Nombre = "MODIFICAR_ORDEN" },
                    new Accion { Nombre = "CAMBIAR_ESTADO_ORDEN" },
                    new Accion { Nombre = "ELIMINAR_ORDEN" },
                    new Accion { Nombre = "INICIAR_TAREA" },
                    new Accion { Nombre = "FINALIZAR_TAREA" },
                    new Accion { Nombre = "REPORTAR_ESTADO" },
                    new Accion { Nombre = "REGISTRAR_INCIDENTE" },
                    new Accion { Nombre = "VERIFICAR_PRODUCTO" }
                };
                ctx.Acciones.AddRange(acciones);
                await ctx.SaveChangesAsync();
            }

            //------------------------------------------------------------
            // 3. ESTADOS / TIPOS
            // NOTA: tu proyecto actualmente usa ENUMS para estos, por lo que
            // NO cargamos tablas EstadoOrden/EstadoTarea/TipoProducto aquí.
            // Si prefieres que sean tablas, coméntame y adapto el seeder.
            //------------------------------------------------------------

            //------------------------------------------------------------
            // 4. USUARIO ADMIN INICIAL
            //------------------------------------------------------------
            // Ajusta la propiedad de usuario según tu entidad:
            // - aquí asumimos que la entidad Usuario tiene la propiedad 'Usuario' para el login.
            // Si tu propiedad se llama 'UsuarioLogin' o 'Username', cambiala ahí.
            var usernameField = "admin"; // valor para comparar

            bool adminExists = await ctx.Usuarios.AnyAsync(u => u.UsuarioLogin == usernameField);
            if (!adminExists)
            {
                var admin = new Usuario
                {
                    Cedula = 10000001,
                    Nombre = "Administrador",
                    Email = "admin@sistema.com",
                    Telefono = "000000000",
                    UsuarioLogin = "admin",
                    ClaveHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    TipoUsuario = TipoUsuario.Supervisor,
                    Turno = null,
                    Habilidades = null
                };

                ctx.Usuarios.Add(admin);
                await ctx.SaveChangesAsync();
            }

            //------------------------------------------------------------
            // 5. ASIGNACIÓN DE ACCIONES → ROL ADMIN
            //------------------------------------------------------------
            var adminRole = await ctx.Roles.FirstAsync(r => r.Nombre == "ADMIN");
            var accionesTotales = await ctx.Acciones.ToListAsync();

            foreach (var accion in accionesTotales)
            {
                // Corregido para usar el nombre correcto del DbSet: RolAcciones
                var exists = await ctx.RolAcciones
                    .AnyAsync(ra => ra.IdRol == adminRole.Id && ra.IdAccion == accion.Id);

                if (!exists)
                {
                    ctx.RolAcciones.Add(new RolAccion
                    {
                        IdRol = adminRole.Id,
                        IdAccion = accion.Id
                    });
                }
            }

            await ctx.SaveChangesAsync();

            //------------------------------------------------------------
            // 6. ASIGNAR ROL ADMIN → USUARIO admin
            //------------------------------------------------------------
            // Recuperamos el usuario admin (por su login)
            var adminUser = await ctx.Usuarios.FirstAsync(u => u.UsuarioLogin == "admin");
            var alreadyAssigned = await ctx.UsuarioRoles
                .AnyAsync(ur => ur.IdUsuario == adminUser.Id && ur.IdRol == adminRole.Id);

            if (!alreadyAssigned)
            {
                ctx.UsuarioRoles.Add(new UsuarioRol
                {
                    IdUsuario = adminUser.Id,
                    IdRol = adminRole.Id
                });
            }

            await ctx.SaveChangesAsync();
        }
    }
}
