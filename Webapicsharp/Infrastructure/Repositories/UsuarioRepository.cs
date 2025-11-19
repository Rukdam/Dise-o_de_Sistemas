using WebApiCSharp.Domain.Repositories;
using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WebApiCSharp.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public Usuario? FindById(int id)
        {
            return _context.Usuarios
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.Id == id);
        }

        public Usuario? FindByUsername(string username)
        {
            return _context.Usuarios
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.UsuarioLogin == username);
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }
    }
}
