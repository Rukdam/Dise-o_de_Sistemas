namespace WebApiCSharp.Domain.Entities
{
    public class RolAccion
    {
        public int IdRol { get; set; }
        public int IdAccion { get; set; }

        public Rol Rol { get; set; } = null!;
        public Accion Accion { get; set; } = null!;
    }
}
