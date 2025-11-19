using WebApiCSharp.Domain.Entities;

namespace WebApiCSharp.Application.Interfaces;

public interface IOrdenQuery
{
    OrdenProduccion? GetOrdenById(int id);
    IEnumerable<OrdenProduccion> BuscarOrdenes(object filtro);
}
