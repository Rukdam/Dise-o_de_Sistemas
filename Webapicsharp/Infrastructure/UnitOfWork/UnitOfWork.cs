using WebApiCSharp.Domain.Repositories;
using WebApiCSharp.Infrastructure.Persistence;

namespace WebApiCSharp.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IUsuarioRepository Usuarios { get; }
        public IProductoRepository Productos { get; }
        public IOrdenRepository Ordenes { get; }
        public ITareaRepository Tareas { get; }

        public UnitOfWork(
            AppDbContext context,
            IUsuarioRepository usuarioRepo,
            IProductoRepository productoRepo,
            IOrdenRepository ordenRepo,
            ITareaRepository tareaRepo)
        {
            _context = context;
            Usuarios = usuarioRepo;
            Productos = productoRepo;
            Ordenes = ordenRepo;
            Tareas = tareaRepo;
        }

        public void Begin()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
