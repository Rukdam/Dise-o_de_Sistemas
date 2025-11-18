# 📘 Instrucciones de Ejecución - Sistema de Gestión de Proyectos

Este documento contiene las instrucciones completas para ejecutar tanto la API como el Frontend Blazor.

## 📋 Requisitos Previos

- ✅ .NET 8.0 SDK instalado
- ✅ Visual Studio Code o Visual Studio 2022
- ✅ Navegador web moderno (Chrome, Edge, Firefox)

## 🚀 Pasos para Ejecutar el Sistema Completo

### Paso 1: Ejecutar la API (Backend)

1. Abrir una terminal en la raíz del proyecto

2. Navegar al directorio de la API:
```bash
cd ApiwebDiseño/ApiDiseño
```

3. Ejecutar la API:
```bash
dotnet run
```

4. Verificar que la API esté ejecutándose:
   - La API estará disponible en: `http://localhost:5000`
   - Swagger UI: `http://localhost:5000/swagger`

5. **IMPORTANTE**: Mantener esta terminal abierta con la API ejecutándose

### Paso 2: Ejecutar el Frontend Blazor

1. Abrir una **NUEVA terminal** (no cerrar la anterior)

2. Navegar al directorio del frontend:
```bash
cd FrontEndConBlazor/FrontendBlazor
```

3. Ejecutar el frontend:
```bash
dotnet run
```

4. Abrir el navegador en:
   - `http://localhost:5001` o
   - `https://localhost:5002`

## 🎯 Uso del Sistema

### Dashboard Principal
Al abrir la aplicación, verás:
- Resumen de proyectos, usuarios y tareas
- Estadísticas por estado
- Acceso rápido a cada módulo

### Gestión de Proyectos
1. Click en "Proyectos" en el menú
2. Click en "Nuevo Proyecto" para crear
3. Completar el formulario:
   - Nombre del proyecto
   - Descripción
   - Fecha de inicio y fin
   - Estado (Activo, En Progreso, Completado, Cancelado)
   - Presupuesto
4. Click en "Guardar"

### Gestión de Usuarios
1. Click en "Usuarios" en el menú
2. Click en "Nuevo Usuario" para crear
3. Completar el formulario:
   - Nombre
   - Email
   - Rol (Administrador, Gerente, Desarrollador, Analista, Usuario)
   - Estado (Activo/Inactivo)
4. Click en "Guardar"

### Gestión de Tareas
1. Click en "Tareas" en el menú
2. Click en "Nueva Tarea" para crear
3. Completar el formulario:
   - Título
   - Descripción
   - Seleccionar proyecto
   - Asignar usuario (opcional)
   - Estado (Pendiente, En Progreso, Completada, Cancelada)
   - Prioridad (Baja, Media, Alta, Crítica)
   - Fecha de vencimiento
4. Click en "Guardar"

## 🔧 Configuración de Puertos

### Si los puertos están ocupados:

#### Para la API:
Editar `ApiwebDiseño/ApiDiseño/Properties/launchSettings.json`:
```json
"applicationUrl": "http://localhost:NUEVO_PUERTO"
```

Luego actualizar en el Frontend `FrontEndConBlazor/FrontendBlazor/Program.cs`:
```csharp
client.BaseAddress = new Uri("http://localhost:NUEVO_PUERTO/");
```

#### Para el Frontend:
Editar `FrontEndConBlazor/FrontendBlazor/Properties/launchSettings.json`:
```json
"applicationUrl": "http://localhost:NUEVO_PUERTO"
```

## 🧪 Probar la Integración

### Prueba Básica:
1. Crear un proyecto desde el frontend
2. Crear un usuario desde el frontend
3. Crear una tarea asignada al proyecto y usuario
4. Verificar que todo aparezca en el dashboard

### Verificar API directamente:
1. Abrir `http://localhost:5000/swagger`
2. Probar los endpoints directamente
3. Verificar que los datos coincidan con el frontend

## 🐛 Solución de Problemas Comunes

### Error: "No se puede conectar a la API"
**Solución:**
- Verificar que la API esté ejecutándose en `http://localhost:5000`
- Verificar que no haya firewall bloqueando la conexión
- Revisar la consola de la API para errores

### Error: "CORS policy"
**Solución:**
- La API ya tiene CORS configurado para `http://localhost:5001`
- Si cambias el puerto del frontend, actualiza el CORS en `ApiwebDiseño/ApiDiseño/Program.cs`

### Error: "Puerto ya en uso"
**Solución:**
- Cambiar los puertos según la sección "Configuración de Puertos"
- O detener el proceso que está usando el puerto:
  ```bash
  # Windows
  netstat -ano | findstr :5000
  taskkill /PID <PID> /F
  ```

### La página no carga o está en blanco
**Solución:**
- Limpiar y reconstruir:
  ```bash
  dotnet clean
  dotnet build
  dotnet run
  ```
- Limpiar caché del navegador (Ctrl + Shift + Delete)

## 📊 Estructura de Datos

### Proyecto
```json
{
  "id": 1,
  "nombre": "Proyecto Ejemplo",
  "descripcion": "Descripción del proyecto",
  "fechaInicio": "2024-01-01",
  "fechaFin": "2024-12-31",
  "estado": "Activo",
  "presupuesto": 100000.00
}
```

### Usuario
```json
{
  "id": 1,
  "nombre": "Juan Pérez",
  "email": "juan@example.com",
  "rol": "Desarrollador",
  "activo": true,
  "fechaCreacion": "2024-01-01"
}
```

### Tarea
```json
{
  "id": 1,
  "titulo": "Tarea Ejemplo",
  "descripcion": "Descripción de la tarea",
  "proyectoId": 1,
  "usuarioAsignadoId": 1,
  "estado": "Pendiente",
  "prioridad": "Media",
  "fechaCreacion": "2024-01-01",
  "fechaVencimiento": "2024-01-31"
}
```

## 🔄 Detener la Aplicación

1. En la terminal de la API: `Ctrl + C`
2. En la terminal del Frontend: `Ctrl + C`

## 📝 Notas Adicionales

- Los datos se almacenan en memoria, se perderán al reiniciar la API
- Para persistencia, se debe implementar una base de datos
- El sistema está diseñado para desarrollo y pruebas
- Para producción, se requieren configuraciones adicionales de seguridad

## 🎓 Recursos Adicionales

- [Documentación de .NET](https://docs.microsoft.com/dotnet/)
- [Documentación de Blazor](https://docs.microsoft.com/aspnet/core/blazor/)
- [Documentación de ASP.NET Core](https://docs.microsoft.com/aspnet/core/)

## 📞 Soporte

Si encuentras problemas:
1. Revisar esta guía completa
2. Verificar los logs en las terminales
3. Consultar la documentación en los archivos README.md de cada proyecto
