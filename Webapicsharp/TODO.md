# TODO: Fix .NET Build Errors

## Errors to Fix
- CS1061: Usuario does not contain definition for Roles
- CS1061: AppDbContext does not contain definition for Tareas, Ordenes, OrdenProductos
- CS0234: HashPassword does not exist in BCrypt
- Warnings: Async methods without await in ProductoService

## Steps
1. Add navigation properties to Usuario and Rol entities for many-to-many relationship.
2. Configure the many-to-many relationship in AppDbContext OnModelCreating.
3. Update TareaRepository.cs to use correct DbSet name: TareasEjecucion.
4. Update OrdenRepository.cs to use correct DbSet name: OrdenesProduccion.
5. Read and update OrdenProductoRepository.cs to use correct DbSet name: OrdenProduccionProductos.
6. Fix BCrypt.HashPassword in DataSeeder.cs to use BCrypt.Net.BCrypt.HashPassword.
7. Read ProductoService.cs and fix async methods without await.
8. Run dotnet build to verify fixes.
