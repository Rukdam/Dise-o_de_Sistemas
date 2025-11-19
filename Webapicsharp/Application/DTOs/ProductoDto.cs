using WebApiCSharp.Domain.Enums;

namespace WebApiCSharp.Application.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }           // si usas en update/get
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        public decimal CostoUnitario { get; set; }
        public TipoProducto TipoProducto { get; set; }  // <- añadir
        public string Tipo { get; set; } = string.Empty;
        public int CantidadActual { get; set; }         // opcional
        public int StockMinimo { get; set; }            // opcional
    }
}
