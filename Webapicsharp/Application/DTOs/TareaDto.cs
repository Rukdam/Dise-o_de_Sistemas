namespace WebApiCSharp.Application.DTOs;

public class TareaDto
{
    public string Descripcion { get; set; } = string.Empty;
    public DateTime Inicio { get; set; }
    public DateTime? Fin { get; set; }
    public int CantidadProducida { get; set; }
    public string Estado { get; set; } = string.Empty;
}
