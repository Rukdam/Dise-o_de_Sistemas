using WebApiCSharp.Domain.Repositories;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WebApiCSharp.Infrastructure.Repositories
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly AppDbContext _context;

        public OrdenRepository(AppDbContext context)
        {
            _context = context;
        }

        public OrdenProduccion? FindById(int id)
        {
            return _context.OrdenesProduccion
                .Include(o => o.Tareas)
                .Include(o => o.Incidentes)
                .Include(o => o.Productos)
                .FirstOrDefault(o => o.Id == id);
        }

        public void Add(OrdenProduccion orden)
        {
            _context.OrdenesProduccion.Add(orden);
        }

        public void Update(OrdenProduccion orden)
        {
            _context.OrdenesProduccion.Update(orden);
        }

        public IEnumerable<OrdenProduccion> Buscar(object filtro)
        {
            return _context.OrdenesProduccion
                .Include(o => o.Tareas)
                .Include(o => o.Productos)
                .ToList();
        }
    }
}
