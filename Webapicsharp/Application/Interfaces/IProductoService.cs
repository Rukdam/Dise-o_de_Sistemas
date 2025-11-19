using WebApiCSharp.Application.DTOs;

namespace WebApiCSharp.Application.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDto>> GetAllAsync();
        Task<ProductoDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(ProductoDto dto);
        Task<bool> UpdateAsync(int id, ProductoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
