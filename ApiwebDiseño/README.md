# API de Diseño de Sistemas

Esta es una API RESTful simple construida con ASP.NET Core para el proyecto de Diseño de Sistemas. Está diseñada para ser fácilmente modificable y extensible.

## Características

- Arquitectura RESTful con controladores
- CORS configurado para frontend Blazor
- Swagger/OpenAPI para documentación
- Almacenamiento en memoria (fácil de cambiar a base de datos)
- Modelos básicos: Proyecto, Usuario, Tarea

## Estructura del Proyecto

```
ApiwebDiseño/
├── ApiDiseño/
│   ├── Controllers/
│   │   ├── ProyectosController.cs
│   │   ├── UsuariosController.cs
│   │   └── TareasController.cs
│   ├── Models/
│   │   ├── Proyecto.cs
│   │   ├── Usuario.cs
│   │   └── Tarea.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── ApiDiseño.csproj
└── README.md
```

## Endpoints Disponibles

### Proyectos
- `GET /api/proyectos` - Obtener todos los proyectos
- `GET /api/proyectos/{id}` - Obtener proyecto por ID
- `POST /api/proyectos` - Crear nuevo proyecto
- `PUT /api/proyectos/{id}` - Actualizar proyecto
- `DELETE /api/proyectos/{id}` - Eliminar proyecto

### Usuarios
- `GET /api/usuarios` - Obtener todos los usuarios
- `GET /api/usuarios/{id}` - Obtener usuario por ID
- `POST /api/usuarios` - Crear nuevo usuario
- `PUT /api/usuarios/{id}` - Actualizar usuario
- `DELETE /api/usuarios/{id}` - Eliminar usuario

### Tareas
- `GET /api/tareas` - Obtener todas las tareas
- `GET /api/tareas/{id}` - Obtener tarea por ID
- `GET /api/tareas/proyecto/{proyectoId}` - Obtener tareas por proyecto
- `POST /api/tareas` - Crear nueva tarea
- `PUT /api/tareas/{id}` - Actualizar tarea
- `DELETE /api/tareas/{id}` - Eliminar tarea

## Cómo Ejecutar

1. Navegar al directorio del proyecto:
   ```bash
   cd ApiwebDiseño/ApiDiseño
   ```

2. Ejecutar la aplicación:
   ```bash
   dotnet run
   ```

3. La API estará disponible en:
   - HTTP: `http://localhost:5000`
   - HTTPS: `https://localhost:5001`
   - Swagger UI: `https://localhost:5001/swagger`

## Configuración CORS

La API está configurada para permitir conexiones desde cualquier origen. Para producción, modifica la política CORS en `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy =>
        {
            policy.WithOrigins("https://tu-dominio-blazor.com")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});
```

## Próximos Pasos

- Agregar autenticación/autorización
- Conectar a base de datos real (SQL Server, PostgreSQL, etc.)
- Agregar validación de modelos
- Implementar logging
- Agregar pruebas unitarias
- Documentación más detallada

## Tecnologías Utilizadas

- ASP.NET Core 8.0
- C# 12
- Swagger/OpenAPI
- CORS
