using WebApiCSharp.Domain.Entities;
using WebApiCSharp.Domain.ValueObjects;

namespace WebApiCSharp.Domain.Services;

public interface IAuthorizationService
{
    PermissionResult HasPermission(Usuario usuario, string accion, object? objetivo);
}
