# Frontend Blazor - Sistema de Gestión de Proyectos

Frontend desarrollado con Blazor Server para consumir la API de gestión de proyectos.

## 🚀 Características

- **Interfaz moderna** con Bootstrap 5
- **Gestión de Proyectos** - CRUD completo
- **Gestión de Usuarios** - CRUD completo
- **Gestión de Tareas** - CRUD completo con asignación a proyectos y usuarios
- **Dashboard interactivo** con estadísticas en tiempo real
- **Comunicación con API** mediante HttpClient

## 📋 Requisitos Previos

- .NET 8.0 SDK o superior
- La API debe estar ejecutándose en `http://localhost:5000`

## 🛠️ Instalación

1. Navegar al directorio del proyecto:
```bash
cd FrontEndConBlazor/FrontendBlazor
```

2. Restaurar dependencias:
```bash
dotnet restore
```

3. Compilar el proyecto:
```bash
dotnet build
```

## ▶️ Ejecución

1. Asegúrate de que la API esté ejecutándose en `http://localhost:5000`

2. Ejecutar el proyecto Blazor:
```bash
dotnet run
```

3. Abrir el navegador en:
   - **HTTP**: `http://localhost:5001`
   - **HTTPS**: `https://localhost:5002`

## 📁 Estructura del Proyecto

```
FrontendBlazor/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor      # Layout principal
│   │   └── NavMenu.razor          # Menú de navegación
│   ├── Pages/
│   │   ├── Home.razor             # Dashboard con estadísticas
│   │   ├── Proyectos.razor        # Gestión de proyectos
│   │   ├── Usuarios.razor         # Gestión de usuarios
│   │   └── Tareas.razor           # Gestión de tareas
│   ├── App.razor                  # Componente raíz
│   └── Routes.razor               # Configuración de rutas
├── Models/
│   ├── Proyecto.cs                # Modelo de Proyecto
│   ├── Usuario.cs                 # Modelo de Usuario
│   └── Tarea.cs                   # Modelo de Tarea
├── Services/
│   ├── ProyectoService.cs         # Servicio para API de Proyectos
│   ├── UsuarioService.cs          # Servicio para API de Usuarios
│   └── TareaService.cs            # Servicio para API de Tareas
├── wwwroot/                       # Archivos estáticos
├── Program.cs                     # Configuración de la aplicación
└── appsettings.json              # Configuración

```

## 🎯 Funcionalidades por Módulo

### Dashboard (Home)
- Resumen de proyectos, usuarios y tareas
- Estadísticas por estado
- Acceso rápido a cada módulo

### Proyectos
- Listar todos los proyectos
- Crear nuevo proyecto
- Editar proyecto existente
- Eliminar proyecto
- Campos: Nombre, Descripción, Fechas, Estado, Presupuesto

### Usuarios
- Listar todos los usuarios
- Crear nuevo usuario
- Editar usuario existente
- Eliminar usuario
- Campos: Nombre, Email, Rol, Estado (Activo/Inactivo)

### Tareas
- Listar todas las tareas
- Crear nueva tarea
- Editar tarea existente
- Eliminar tarea
- Asignar tarea a proyecto
- Asignar tarea a usuario
- Campos: Título, Descripción, Estado, Prioridad, Fechas

## 🔧 Configuración

### Cambiar la URL de la API

Editar `Program.cs` y modificar la URL base:

```csharp
builder.Services.AddHttpClient<ProyectoService>(client =>
{
    client.BaseAddress = new Uri("http://tu-api-url:puerto/");
});
```

## 🎨 Personalización

### Estilos
Los estilos personalizados se encuentran en:
- `wwwroot/app.css` - Estilos globales
- `Components/Layout/*.razor.css` - Estilos de componentes específicos

### Temas
El proyecto utiliza Bootstrap 5. Para cambiar el tema, modifica:
- `wwwroot/bootstrap/bootstrap.min.css`

## 📝 Notas Importantes

1. **Dependencia de la API**: El frontend requiere que la API esté ejecutándose
2. **CORS**: La API debe tener CORS configurado para permitir peticiones desde el frontend
3. **Modo Interactivo**: Las páginas usan `@rendermode InteractiveServer` para interactividad en tiempo real

## 🐛 Solución de Problemas

### Error de conexión con la API
- Verificar que la API esté ejecutándose
- Verificar la URL configurada en `Program.cs`
- Verificar que CORS esté habilitado en la API

### Errores de compilación
```bash
dotnet clean
dotnet restore
dotnet build
```

## 🚀 Próximas Mejoras

- [ ] Autenticación y autorización
- [ ] Paginación en las tablas
- [ ] Filtros y búsqueda avanzada
- [ ] Exportación de datos (Excel, PDF)
- [ ] Notificaciones en tiempo real
- [ ] Modo offline con caché local
- [ ] Gráficos y reportes avanzados

## 📄 Licencia

Este proyecto es parte del sistema de gestión de proyectos para el curso de Diseño de Sistemas.
