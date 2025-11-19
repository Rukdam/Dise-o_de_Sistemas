using WebApiCSharp.Application.DTOs;
using WebApiCSharp.Application.Interfaces;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.ValueObjects;
using WebApiCSharp.Domain.Enums;
using WebApiCSharp.Domain.Repositories;

namespace WebApiCSharp.Application.Services;

public class OrdenService : IOrdenCommand, IOrdenQuery
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdenService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // =====================
    //      COMMANDS
    // =====================

    public OperationResult CrearOrden(DatosOrdenDto datos, int usuarioId)
    {
        try
        {
            var nuevaOrden = new OrdenProduccion
            {
                NumeroOrden = datos.NumeroOrden,
                FechaIngreso = DateTime.Now,
                FechaProgramada = datos.FechaProgramada,
                CantidadProgramada = datos.CantidadProgramada,
                TiempoEstimadoMin = datos.TiempoEstimadoMin,
                Maquinaria = datos.Maquinaria,
                Estado = EstadoOrden.Registrada,
                CreadoPor = usuarioId
            };

            _unitOfWork.Ordenes.Add(nuevaOrden);
            _unitOfWork.Complete();

            return OperationResult.Ok($"Orden creada con ID: {nuevaOrden.Id}");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Error al crear orden: {ex.Message}");
        }
    }


    public OperationResult ModificarOrden(int id, DatosOrdenDto datos, int usuarioId)
    {
        try
        {
            var orden = _unitOfWork.Ordenes.FindById(id);
            if (orden == null)
                return OperationResult.Fail("Orden no encontrada.");

            orden.NumeroOrden = datos.NumeroOrden;
            orden.FechaProgramada = datos.FechaProgramada;
            orden.CantidadProgramada = datos.CantidadProgramada;
            orden.TiempoEstimadoMin = datos.TiempoEstimadoMin;
            orden.Maquinaria = datos.Maquinaria;
            orden.ActualizadoPor = usuarioId;

            _unitOfWork.Ordenes.Update(orden);
            _unitOfWork.Complete();

            return OperationResult.Ok("Orden actualizada correctamente.");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Error al modificar orden: {ex.Message}");
        }
    }


    public OperationResult EliminarOrden(int id, int usuarioId)
    {
        try
        {
            var orden = _unitOfWork.Ordenes.FindById(id);
            if (orden == null)
                return OperationResult.Fail("Orden no encontrada.");

            // Note: Marking as cancelled instead of deleting
            orden.Estado = EstadoOrden.Cancelada;
            orden.ActualizadoPor = usuarioId;
            
            _unitOfWork.Ordenes.Update(orden);
            _unitOfWork.Complete();

            return OperationResult.Ok("Orden eliminada.");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"No se pudo eliminar: {ex.Message}");
        }
    }


    public OperationResult TransicionarEstado(int id, string accionEstado, int usuarioId)
    {
        try
        {
            var orden = _unitOfWork.Ordenes.FindById(id);
            if (orden == null)
                return OperationResult.Fail("Orden no encontrada.");

            // Simple state transition logic
            orden.Estado = accionEstado.ToLower() switch
            {
                "programar" => EstadoOrden.Programada,
                "iniciar" => EstadoOrden.EnProceso,
                "finalizar" => EstadoOrden.Finalizada,
                "cancelar" => EstadoOrden.Cancelada,
                _ => orden.Estado
            };

            orden.ActualizadoPor = usuarioId;
            _unitOfWork.Ordenes.Update(orden);
            _unitOfWork.Complete();

            return OperationResult.Ok($"Estado actualizado: {orden.Estado}");
        }
        catch (Exception ex)
        {
            return OperationResult.Fail($"Error en transición: {ex.Message}");
        }
    }


    // =====================
    //       QUERIES
    // =====================

    public OrdenProduccion? GetOrdenById(int id)
    {
        return _unitOfWork.Ordenes.FindById(id);
    }

    public IEnumerable<OrdenProduccion> BuscarOrdenes(object filtro)
    {
        return _unitOfWork.Ordenes.Buscar(filtro);
    }
}
