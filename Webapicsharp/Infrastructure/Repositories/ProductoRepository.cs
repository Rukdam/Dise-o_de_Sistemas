using Microsoft.EntityFrameworkCore;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.Repositories;
using WebApiCSharp.Infrastructure.Persistence;
using WebApiCSharp.Application.DTOs;

namespace WebApiCSharp.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Producto? ObtenerPorId(int id)
        {
            return _context.Productos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Producto> Buscar(FiltroProductoDto filtro)
        {
            var query = _context.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nombre))
            {
                query = query.Where(p => p.Nombre.Contains(filtro.Nombre));
            }

            if (!string.IsNullOrEmpty(filtro.Tipo))
            {
                query = query.Where(p => p.TipoProducto.ToString() == filtro.Tipo);
            }

            return query.ToList();
        }

        public void Agregar(Producto producto)
        {
            _context.Productos.Add(producto);
        }

        public void Actualizar(Producto producto)
        {
            _context.Productos.Update(producto);
        }
    }
}
