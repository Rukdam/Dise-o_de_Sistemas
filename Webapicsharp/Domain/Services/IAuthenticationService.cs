using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.ValueObjects;

namespace WebApiCSharp.Domain.Services;

public interface IAuthenticationService
{
    OperationResult Autenticar(string usuario, string clave);
}
