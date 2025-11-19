using WebApiCSharp.Domain.Entities;

namespace WebApiCSharp.Application.Interfaces;

public interface ITareaQuery
{
    TareaEjecucion? GetTareaById(int id);
    IEnumerable<TareaEjecucion> ListarTareasPorOrden(int ordenId);
}
