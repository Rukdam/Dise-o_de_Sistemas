namespace WebApiCSharp.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUsuarioRepository Usuarios { get; }
    IProductoRepository Productos { get; }
    IOrdenRepository Ordenes { get; }
    ITareaRepository Tareas { get; }
    
    void Begin();
    void Commit();
    void Rollback();
    int Complete();
}
