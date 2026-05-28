using Microsoft.AspNetCore.Mvc;
using SistemaEscenariosDeportivos.Models;

namespace SistemaEscenariosDeportivos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario
            {
                IdUsuario = 1,
                Nombre = "Juan Pérez",
                Correo = "juan@email.com",
                Contrasena = "12345",
                TipoUsuario = "Ciudadano"
            },
            new Usuario
            {
                IdUsuario = 2,
                Nombre = "Administrador Deportes",
                Correo = "admin@email.com",
                Contrasena = "admin123",
                TipoUsuario = "Administrador"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> ObtenerUsuarioPorId(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult<Usuario> CrearUsuario(Usuario usuario)
        {
            usuario.IdUsuario = usuarios.Count + 1;
            usuarios.Add(usuario);

            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, Usuario usuarioActualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Correo = usuarioActualizado.Correo;
            usuario.Contrasena = usuarioActualizado.Contrasena;
            usuario.TipoUsuario = usuarioActualizado.TipoUsuario;

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            usuarios.Remove(usuario);

            return Ok("Usuario eliminado correctamente.");
        }
    }
}