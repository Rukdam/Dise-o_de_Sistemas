using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Infrastructure.Persistence;

namespace WebApiCSharp.Infrastructure.Repositories
{
    public class IncidenteRepository
    {
        private readonly AppDbContext _context;

        public IncidenteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Incidente incidente)
        {
            _context.Incidentes.Add(incidente);
        }
    }
}
