using WebApiCSharp.Application.DTOs;
using WebApiCSharp.Domain.ValueObjects;

namespace WebApiCSharp.Application.Interfaces;

public interface IOrdenCommand
{
    OperationResult CrearOrden(DatosOrdenDto datos, int usuarioId);
    OperationResult ModificarOrden(int id, DatosOrdenDto datos, int usuarioId);
    OperationResult EliminarOrden(int id, int usuarioId);
    OperationResult TransicionarEstado(int id, string accionEstado, int usuarioId);
}
