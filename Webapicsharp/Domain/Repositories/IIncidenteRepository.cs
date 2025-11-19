using WebApiCSharp.Domain.Entities;

namespace WebApiCSharp.Domain.Repositories;

public interface IIncidenteRepository
{
    void Add(Incidente incidente);
}
