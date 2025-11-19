using WebApiCSharp.Domain.Entities;

namespace WebApiCSharp.Domain.Repositories;

public interface IOrdenRepository
{
    OrdenProduccion? FindById(int id);
    IEnumerable<OrdenProduccion> Buscar(object filtro);
    void Add(OrdenProduccion orden);
    void Update(OrdenProduccion orden);
}
