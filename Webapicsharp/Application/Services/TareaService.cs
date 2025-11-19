using WebApiCSharp.Application.DTOs;
using WebApiCSharp.Application.Interfaces;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.Enums;
using WebApiCSharp.Domain.ValueObjects;
using WebApiCSharp.Domain.Repositories;

namespace WebApiCSharp.Application.Services;

public class TareaService : ITareaCommand, ITareaQuery
{
    private readonly IUnitOfWork _unitOfWork;

    public TareaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // =====================
    //      COMMANDS
    // =====================

    public OperationResult IniciarTarea(int ordenId, int tareaId, int usuarioId)
    {
        try
        {
            var orden = _unitOfWork.Ordenes.FindById(ordenId);
            if (orden == null)
                return OperationResult.Fail("Orden no encontrada.");

            var tarea = _unitOfWork.Tareas.FindById(tareaId);
            if (tarea == null || tarea.OrdenProduccionId != ordenId)
                return OperationResult.Fail("Tarea no encontrada en esta orden.");

            tarea.Estado = EstadoTarea.EnEjecucion;
            tarea.Inicio = DateTime.Now;
            tarea.OperarioId = usuarioId;

            _unitOfWork.Tareas.Update(tarea);
            _unitOfWork.Complete();

            return OperationResult.Ok("Tarea iniciada correctamente.");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Error al iniciar la tarea: {ex.Message}");
        }
    }


    public OperationResult FinalizarTarea(int ordenId, int tareaId, int usuarioId, int cantidad)
    {
        try
        {
            var orden = _unitOfWork.Ordenes.FindById(ordenId);
            if (orden == null)
                return OperationResult.Fail("Orden no encontrada.");

            var tarea = _unitOfWork.Tareas.FindById(tareaId);
            if (tarea == null || tarea.OrdenProduccionId != ordenId)
                return OperationResult.Fail("Tarea no encontrada.");

            tarea.Estado = EstadoTarea.Finalizada;
            tarea.Fin = DateTime.Now;
            tarea.CantidadProducida = cantidad;

            _unitOfWork.Tareas.Update(tarea);

            // Check if all tasks are completed
            var todasTareas = _unitOfWork.Tareas.ListarPorOrden(ordenId);
            if (todasTareas.All(t => t.Estado == EstadoTarea.Finalizada))
            {
                orden.Estado = EstadoOrden.Finalizada;
                _unitOfWork.Ordenes.Update(orden);
            }

            _unitOfWork.Complete();

            return OperationResult.Ok("Tarea finalizada correctamente.");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Error al finalizar la tarea: {ex.Message}");
        }
    }


    public OperationResult RegistrarIncidente(int ordenId, IncidenteDto incidente, int usuarioId)
    {
        try
        {
            var orden = _unitOfWork.Ordenes.FindById(ordenId);
            if (orden == null)
                return OperationResult.Fail("Orden no encontrada.");

            var nuevoIncidente = new Incidente
            {
                OrdenProduccionId = ordenId,
                Descripcion = incidente.Descripcion,
                Fecha = incidente.Fecha,
                Severidad = incidente.Severidad
            };

            orden.Incidentes.Add(nuevoIncidente);
            _unitOfWork.Ordenes.Update(orden);
            _unitOfWork.Complete();

            return OperationResult.Ok("Incidente registrado.");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Error al registrar incidente: {ex.Message}");
        }
    }


    // =====================
    //        QUERIES
    // =====================

    public TareaEjecucion? GetTareaById(int id)
    {
        return _unitOfWork.Tareas.FindById(id);
    }

    public IEnumerable<TareaEjecucion> ListarTareasPorOrden(int ordenId)
    {
        return _unitOfWork.Tareas.ListarPorOrden(ordenId);
    }
}
