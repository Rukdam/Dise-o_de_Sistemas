using WebApiCSharp.Domain.Repositories;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WebApiCSharp.Infrastructure.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly AppDbContext _context;

        public TareaRepository(AppDbContext context)
        {
            _context = context;
        }

        public TareaEjecucion? FindById(int id)
        {
            return _context.TareasEjecucion.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TareaEjecucion tarea)
        {
            _context.TareasEjecucion.Add(tarea);
        }

        public void Update(TareaEjecucion tarea)
        {
            _context.TareasEjecucion.Update(tarea);
        }

        public IEnumerable<TareaEjecucion> ListarPorOrden(int ordenId)
        {
            return _context.TareasEjecucion
                .Where(t => t.OrdenProduccionId == ordenId)
                .ToList();
        }
    }
}
