using WebApiCSharp.Application.DTOs;
using WebApiCSharp.Application.Interfaces;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.Interfaces;
using WebApiCSharp.Domain.Enums;

namespace WebApiCSharp.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProductoDto>> GetAllAsync()
        {
            // Note: This method needs to be implemented in IProductoRepository
            // For now, returning empty list
            return new List<ProductoDto>();
        }

        public async Task<ProductoDto?> GetByIdAsync(int id)
        {
            // Note: This method needs to be implemented in IProductoRepository
            // For now, returning null
            return null;
        }

        public async Task<int> CreateAsync(ProductoDto dto)
        {
            // Parse tipo from string to enum
            TipoProducto tipoProducto = dto.Tipo.ToUpper() switch
            {
                "MATERIAPRIMA" => TipoProducto.MateriaPrima,
                "INTERMEDIO" => TipoProducto.Intermedio,
                "PRODUCTOFINAL" => TipoProducto.ProductoFinal,
                _ => TipoProducto.MateriaPrima
            };

            var entity = new Producto(
                nombre: dto.Nombre.Trim(),
                descripcion: dto.Descripcion?.Trim(),
                unidadMedida: dto.UnidadMedida.Trim(),
                costoUnitario: (decimal)dto.CostoUnitario,
                tipoProducto: tipoProducto
            );


            // Note: This method needs to be implemented in IProductoRepository
            // For now, returning 0
            return await Task.FromResult(0);
        }

        public async Task<bool> UpdateAsync(int id, ProductoDto dto)
        {
            // Note: This method needs to be implemented in IProductoRepository
            // For now, returning false
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Note: This method needs to be implemented in IProductoRepository
            // For now, returning false
            return await Task.FromResult(false);
        }
    }
}
