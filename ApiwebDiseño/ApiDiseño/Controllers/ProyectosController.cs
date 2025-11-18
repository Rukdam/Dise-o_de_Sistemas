using Microsoft.AspNetCore.Mvc;
using ApiDiseño.Models;

namespace ApiDiseño.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectosController : ControllerBase
    {
        // Lista en memoria para simular una base de datos
        private static List<Proyecto> proyectos = new List<Proyecto>
        {
            new Proyecto
            {
                Id = 1,
                Nombre = "Proyecto Demo",
                Descripcion = "Proyecto de ejemplo",
                FechaInicio = DateTime.Now,
                Estado = "Activo",
                Presupuesto = 50000
            }
        };

        // GET: api/proyectos
        [HttpGet]
        public ActionResult<IEnumerable<Proyecto>> GetProyectos()
        {
            return Ok(proyectos);
        }

        // GET: api/proyectos/5
        [HttpGet("{id}")]
        public ActionResult<Proyecto> GetProyecto(int id)
        {
            var proyecto = proyectos.FirstOrDefault(p => p.Id == id);

            if (proyecto == null)
            {
                return NotFound(new { mensaje = "Proyecto no encontrado" });
            }

            return Ok(proyecto);
        }

        // POST: api/proyectos
        [HttpPost]
        public ActionResult<Proyecto> CreateProyecto(Proyecto proyecto)
        {
            proyecto.Id = proyectos.Any() ? proyectos.Max(p => p.Id) + 1 : 1;
            proyectos.Add(proyecto);

            return CreatedAtAction(nameof(GetProyecto), new { id = proyecto.Id }, proyecto);
        }

        // PUT: api/proyectos/5
        [HttpPut("{id}")]
        public IActionResult UpdateProyecto(int id, Proyecto proyectoActualizado)
        {
            var proyecto = proyectos.FirstOrDefault(p => p.Id == id);

            if (proyecto == null)
            {
                return NotFound(new { mensaje = "Proyecto no encontrado" });
            }

            proyecto.Nombre = proyectoActualizado.Nombre;
            proyecto.Descripcion = proyectoActualizado.Descripcion;
            proyecto.FechaInicio = proyectoActualizado.FechaInicio;
            proyecto.FechaFin = proyectoActualizado.FechaFin;
            proyecto.Estado = proyectoActualizado.Estado;
            proyecto.Presupuesto = proyectoActualizado.Presupuesto;

            return Ok(proyecto);
        }

        // DELETE: api/proyectos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProyecto(int id)
        {
            var proyecto = proyectos.FirstOrDefault(p => p.Id == id);

            if (proyecto == null)
            {
                return NotFound(new { mensaje = "Proyecto no encontrado" });
            }

            proyectos.Remove(proyecto);

            return Ok(new { mensaje = "Proyecto eliminado correctamente" });
        }
    }
}
