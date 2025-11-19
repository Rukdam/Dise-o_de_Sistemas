using WebApiCSharp.Application.DTOs;
using WebApiCSharp.Domain.ValueObjects;

namespace WebApiCSharp.Application.Interfaces;

public interface ITareaCommand
{
    OperationResult IniciarTarea(int ordenId, int tareaId, int usuarioId);
    OperationResult FinalizarTarea(int ordenId, int tareaId, int usuarioId, int cantidad);
    OperationResult RegistrarIncidente(int ordenId, IncidenteDto incidente, int usuarioId);
}
