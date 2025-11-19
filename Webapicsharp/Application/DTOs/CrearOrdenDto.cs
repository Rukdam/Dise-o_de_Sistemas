namespace WebApiCSharp.Application.DTOs;

public class CrearOrdenDto
{
    public DatosOrdenDto Datos { get; set; } = new();
    public int UsuarioId { get; set; }
}
