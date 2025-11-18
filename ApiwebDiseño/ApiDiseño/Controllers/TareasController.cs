using Microsoft.AspNetCore.Mvc;
using ApiDiseño.Models;

namespace ApiDiseño.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        // Lista en memoria para simular una base de datos
        private static List<Tarea> tareas = new List<Tarea>
        {
            new Tarea
            {
                Id = 1,
                Titulo = "Tarea Demo",
                Descripcion = "Tarea de ejemplo",
                ProyectoId = 1,
                UsuarioAsignadoId = 1,
                Estado = "Pendiente",
                Prioridad = "Media",
                FechaCreacion = DateTime.Now
            }
        };

        // GET: api/tareas
        [HttpGet]
        public ActionResult<IEnumerable<Tarea>> GetTareas()
        {
            return Ok(tareas);
        }

        // GET: api/tareas/5
        [HttpGet("{id}")]
        public ActionResult<Tarea> GetTarea(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
            {
                return NotFound(new { mensaje = "Tarea no encontrada" });
            }

            return Ok(tarea);
        }

        // GET: api/tareas/proyecto/5
        [HttpGet("proyecto/{proyectoId}")]
        public ActionResult<IEnumerable<Tarea>> GetTareasPorProyecto(int proyectoId)
        {
            var tareasProyecto = tareas.Where(t => t.ProyectoId == proyectoId).ToList();
            return Ok(tareasProyecto);
        }

        // POST: api/tareas
        [HttpPost]
        public ActionResult<Tarea> CreateTarea(Tarea tarea)
        {
            tarea.Id = tareas.Any() ? tareas.Max(t => t.Id) + 1 : 1;
            tarea.FechaCreacion = DateTime.Now;
            tareas.Add(tarea);

            return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
        }

        // PUT: api/tareas/5
        [HttpPut("{id}")]
        public IActionResult UpdateTarea(int id, Tarea tareaActualizada)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
            {
                return NotFound(new { mensaje = "Tarea no encontrada" });
            }

            tarea.Titulo = tareaActualizada.Titulo;
            tarea.Descripcion = tareaActualizada.Descripcion;
            tarea.ProyectoId = tareaActualizada.ProyectoId;
            tarea.UsuarioAsignadoId = tareaActualizada.UsuarioAsignadoId;
            tarea.Estado = tareaActualizada.Estado;
            tarea.Prioridad = tareaActualizada.Prioridad;
            tarea.FechaVencimiento = tareaActualizada.FechaVencimiento;

            return Ok(tarea);
        }

        // DELETE: api/tareas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTarea(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
            {
                return NotFound(new { mensaje = "Tarea no encontrada" });
            }

            tareas.Remove(tarea);

            return Ok(new { mensaje = "Tarea eliminada correctamente" });
        }
    }
}
