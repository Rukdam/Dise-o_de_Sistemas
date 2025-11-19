using WebApiCSharp.Domain.Entities;

namespace WebApiCSharp.Domain.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task<int> CreateAsync(Producto entity);
        Task<bool> UpdateAsync(Producto entity);
        Task<bool> DeleteAsync(int id);
    }
}
