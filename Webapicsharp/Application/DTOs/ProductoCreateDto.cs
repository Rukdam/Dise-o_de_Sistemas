namespace WebApiCSharp.Application.DTOs;

public class ProductoCreateDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string UnidadMedida { get; set; } = string.Empty;
    public double CostoUnitario { get; set; }
    public string Tipo { get; set; } = string.Empty;
}
