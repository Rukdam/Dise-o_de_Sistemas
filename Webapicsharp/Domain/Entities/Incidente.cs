namespace WebApiCSharp.Domain.Entities;

public class Incidente
{
    public int Id { get; set; }

    public int OrdenProduccionId { get; set; }

    public string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }

    public string Severidad { get; set; } = string.Empty;
}
