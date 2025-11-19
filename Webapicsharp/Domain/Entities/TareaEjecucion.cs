using WebApiCSharp.Domain.Enums;

namespace WebApiCSharp.Domain.Entities;

public class TareaEjecucion
{
    public int Id { get; set; }

    public int OrdenProduccionId { get; set; }
    public DateTime? Inicio { get; set; }
    public DateTime? Fin { get; set; }

    public int? CantidadProducida { get; set; }
    public string? Descripcion { get; set; }

    public EstadoTarea Estado { get; set; }

    public int? OperarioId { get; set; }
}
