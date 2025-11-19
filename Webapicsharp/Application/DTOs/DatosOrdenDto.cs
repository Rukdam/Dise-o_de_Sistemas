namespace WebApiCSharp.Application.DTOs;

public class DatosOrdenDto
{
    public int NumeroOrden { get; set; }
    public DateTime FechaProgramada { get; set; }
    public int CantidadProgramada { get; set; }
    public int TiempoEstimadoMin { get; set; }
    public string Maquinaria { get; set; } = string.Empty;
}
