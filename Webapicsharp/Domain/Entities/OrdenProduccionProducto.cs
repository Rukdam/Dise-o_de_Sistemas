namespace WebApiCSharp.Domain.Entities;

public class OrdenProduccionProducto
{
    public int Id { get; set; }

    public int OrdenProduccionId { get; set; }
    public int ProductoId { get; set; }

    public string? Descripcion { get; set; }
}
