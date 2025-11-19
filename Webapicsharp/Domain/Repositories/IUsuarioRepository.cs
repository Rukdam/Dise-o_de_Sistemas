using WebApiCSharp.Domain.Entities;

namespace WebApiCSharp.Domain.Repositories;

public interface IUsuarioRepository
{
    Usuario? FindById(int id);
    Usuario? FindByUsername(string username);
    void Add(Usuario usuario);
}
