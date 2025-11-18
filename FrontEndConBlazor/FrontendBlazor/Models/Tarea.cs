namespace FrontendBlazor.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int ProyectoId { get; set; }
        public int? UsuarioAsignadoId { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public string Prioridad { get; set; } = "Media";
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaVencimiento { get; set; }
    }
}
