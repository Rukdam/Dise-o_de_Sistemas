namespace WebApiCSharp.Domain.ValueObjects;

public class FiltroProducto
{
    public string? Nombre { get; set; }
    public string? Tipo { get; set; }
    public int? StockMinimo { get; set; }
    public int? StockMaximo { get; set; }
}
