using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.ValueObjects;

namespace WebApiCSharp.Domain.Services;

public interface IEstadoOrden
{
    OperationResult Iniciar(OrdenProduccion orden);
    OperationResult Pausar(OrdenProduccion orden);
    OperationResult Finalizar(OrdenProduccion orden);
    OperationResult Cancelar(OrdenProduccion orden);
    string Nombre { get; }
}
