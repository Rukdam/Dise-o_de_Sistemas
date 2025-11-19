using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Infrastructure.Persistence;

namespace WebApiCSharp.Infrastructure.Repositories
{
    public class OrdenProductoRepository
    {
        private readonly AppDbContext _context;

        public OrdenProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(OrdenProduccionProducto item)
        {
            _context.OrdenProduccionProductos.Add(item);
        }
    }
}
