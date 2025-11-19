namespace WebApiCSharp.Application.DTOs;

public class IncidenteDto
{
    public string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string Severidad { get; set; } = string.Empty;
}
