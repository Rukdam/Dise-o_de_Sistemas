using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.ValueObjects;

namespace WebApiCSharp.Domain.Services;

public interface IEstadoTarea
{
    OperationResult Iniciar(TareaEjecucion tarea);
    OperationResult Finalizar(TareaEjecucion tarea);
    OperationResult Cancelar(TareaEjecucion tarea);
    string Nombre { get; }
}
