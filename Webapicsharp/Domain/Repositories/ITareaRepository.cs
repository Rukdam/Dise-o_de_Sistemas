using WebApiCSharp.Domain.Entities;

namespace WebApiCSharp.Domain.Repositories;

public interface ITareaRepository
{
    TareaEjecucion? FindById(int id);
    IEnumerable<TareaEjecucion> ListarPorOrden(int ordenId);
    void Add(TareaEjecucion tarea);
    void Update(TareaEjecucion tarea);
}
