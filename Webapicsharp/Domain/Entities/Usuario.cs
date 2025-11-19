using WebApiCSharp.Domain.Enums;

namespace WebApiCSharp.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public int Cedula { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;

    public string UsuarioLogin { get; set; } = string.Empty;
    public string ClaveHash { get; set; } = string.Empty;

    public TipoUsuario TipoUsuario { get; set; }

    // Navigation properties
    public virtual ICollection<Rol> Roles { get; set; } = new List<Rol>();

    // Extra Operario
    public string? Turno { get; set; }
    public string? Habilidades { get; set; }
}
