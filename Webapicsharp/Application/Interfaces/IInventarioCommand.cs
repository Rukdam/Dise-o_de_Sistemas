using WebApiCSharp.Application.DTOs;
using WebApiCSharp.Domain.ValueObjects;

namespace WebApiCSharp.Application.Interfaces;

public interface IInventarioCommand
{
    OperationResult AgregarProducto(ProductoDto prod, int cantidad, int usuarioId);
    OperationResult AjustarStock(int productoId, int ajuste, int usuarioId);
    OperationResult SetStockMin(int productoId, int cantidad, int usuarioId);
}
