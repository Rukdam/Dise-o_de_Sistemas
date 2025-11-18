using Microsoft.AspNetCore.Mvc;
using ApiDiseño.Models;

namespace ApiDiseño.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        // Lista en memoria para simular una base de datos
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario
            {
                Id = 1,
                Nombre = "Admin",
                Email = "admin@example.com",
                Rol = "Administrador",
                Activo = true,
                FechaCreacion = DateTime.Now
            }
        };

        // GET: api/usuarios
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(usuarios);
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado" });
            }

            return Ok(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        public ActionResult<Usuario> CreateUsuario(Usuario usuario)
        {
            usuario.Id = usuarios.Any() ? usuarios.Max(u => u.Id) + 1 : 1;
            usuario.FechaCreacion = DateTime.Now;
            usuarios.Add(usuario);

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, Usuario usuarioActualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado" });
            }

            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Email = usuarioActualizado.Email;
            usuario.Rol = usuarioActualizado.Rol;
            usuario.Activo = usuarioActualizado.Activo;

            return Ok(usuario);
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado" });
            }

            usuarios.Remove(usuario);

            return Ok(new { mensaje = "Usuario eliminado correctamente" });
        }
    }
}
