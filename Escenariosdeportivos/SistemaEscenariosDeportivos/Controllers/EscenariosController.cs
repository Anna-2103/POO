using Microsoft.AspNetCore.Mvc;
using SistemaEscenariosDeportivos.Models;

namespace SistemaEscenariosDeportivos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscenariosController : ControllerBase
    {
        private static List<EscenarioDeportivo> escenarios = new List<EscenarioDeportivo>
        {
            new EscenarioDeportivo
            {
                IdEscenario = 1,
                Nombre = "Estadio Alberto Grisales",
                Tipo = "Estadio",
                Ubicacion = "Rionegro",
                Capacidad = 14000,
                Estado = "Disponible",
                IdMunicipio = 1
            },
            new EscenarioDeportivo
            {
                IdEscenario = 2,
                Nombre = "Coliseo Municipal de La Ceja",
                Tipo = "Coliseo",
                Ubicacion = "La Ceja",
                Capacidad = 3000,
                Estado = "Disponible",
                IdMunicipio = 2
            },
            new EscenarioDeportivo
            {
                IdEscenario = 3,
                Nombre = "Cancha Sintética de Marinilla",
                Tipo = "Cancha sintética",
                Ubicacion = "Marinilla",
                Capacidad = 500,
                Estado = "Disponible",
                IdMunicipio = 3
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<EscenarioDeportivo>> ObtenerEscenarios()
        {
            return Ok(escenarios);
        }

        [HttpGet("{id}")]
        public ActionResult<EscenarioDeportivo> ObtenerEscenarioPorId(int id)
        {
            var escenario = escenarios.FirstOrDefault(e => e.IdEscenario == id);

            if (escenario == null)
            {
                return NotFound("Escenario deportivo no encontrado.");
            }

            return Ok(escenario);
        }

        [HttpPost]
        public ActionResult<EscenarioDeportivo> CrearEscenario(EscenarioDeportivo escenario)
        {
            escenario.IdEscenario = escenarios.Count + 1;
            escenarios.Add(escenario);

            return CreatedAtAction(nameof(ObtenerEscenarioPorId), new { id = escenario.IdEscenario }, escenario);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarEscenario(int id, EscenarioDeportivo escenarioActualizado)
        {
            var escenario = escenarios.FirstOrDefault(e => e.IdEscenario == id);

            if (escenario == null)
            {
                return NotFound("Escenario deportivo no encontrado.");
            }

            escenario.Nombre = escenarioActualizado.Nombre;
            escenario.Tipo = escenarioActualizado.Tipo;
            escenario.Ubicacion = escenarioActualizado.Ubicacion;
            escenario.Capacidad = escenarioActualizado.Capacidad;
            escenario.Estado = escenarioActualizado.Estado;
            escenario.IdMunicipio = escenarioActualizado.IdMunicipio;

            return Ok(escenario);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarEscenario(int id)
        {
            var escenario = escenarios.FirstOrDefault(e => e.IdEscenario == id);

            if (escenario == null)
            {
                return NotFound("Escenario deportivo no encontrado.");
            }

            escenarios.Remove(escenario);

            return Ok("Escenario deportivo eliminado correctamente.");
        }
    }
}