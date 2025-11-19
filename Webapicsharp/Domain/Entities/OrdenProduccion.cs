using WebApiCSharp.Domain.Enums;

namespace WebApiCSharp.Domain.Entities;

public class OrdenProduccion
{
    public int Id { get; set; }
    public int NumeroOrden { get; set; }

    public DateTime FechaIngreso { get; set; }
    public DateTime FechaProgramada { get; set; }

    public EstadoOrden Estado { get; set; }

    public int CantidadProgramada { get; set; }
    public int TiempoEstimadoMin { get; set; }
    public string? Maquinaria { get; set; }

    public int CreadoPor { get; set; }
    public int? ActualizadoPor { get; set; }

    public List<TareaEjecucion> Tareas { get; set; } = new();
    public List<Incidente> Incidentes { get; set; } = new();
    public List<OrdenProduccionProducto> Productos { get; set; } = new();
}
