using WebApiCSharp.Application.DTOs;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.ValueObjects;

namespace WebApiCSharp.Application.Interfaces;

public interface IInventarioQuery
{
    OperationResult BuscarStock(int productoId);
    IEnumerable<Producto> BuscarProductos(FiltroProductoDto filtro);
}
