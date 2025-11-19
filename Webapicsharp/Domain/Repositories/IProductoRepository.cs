using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.ValueObjects;
using WebApiCSharp.Application.DTOs;

namespace WebApiCSharp.Domain.Repositories;

public interface IProductoRepository
{
    Producto? ObtenerPorId(int id);
    IEnumerable<Producto> Buscar(FiltroProductoDto filtro);
    void Agregar(Producto producto);
    void Actualizar(Producto producto);
}
