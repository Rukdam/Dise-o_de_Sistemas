using WebApiCSharp.Domain.Enums;

namespace WebApiCSharp.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        public decimal CostoUnitario { get; set; }

        public TipoProducto TipoProducto { get; set; }
        public int CantidadActual { get; set; }
        public int StockMinimo { get; set; }

        // 🔥 Constructor vacío obligatorio para EF
        public Producto() {}

        // (Opcional) Constructor de conveniencia
        public Producto(
            string nombre,
            string? descripcion,
            string unidadMedida,
            decimal costoUnitario,
            TipoProducto tipoProducto)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            UnidadMedida = unidadMedida;
            CostoUnitario = costoUnitario;
            TipoProducto = tipoProducto;
            CantidadActual = 0;
            StockMinimo = 0;
        }

        public void AgregarStock(int cantidad)
        {
            if (cantidad > 0)
                CantidadActual += cantidad;
        }

        public void AjustarStock(int ajuste)
        {
            CantidadActual += ajuste;
            if (CantidadActual < 0)
                CantidadActual = 0;
        }

        public void DefinirStockMinimo(int cantidad)
        {
            if (cantidad >= 0)
                StockMinimo = cantidad;
        }
    }
}
