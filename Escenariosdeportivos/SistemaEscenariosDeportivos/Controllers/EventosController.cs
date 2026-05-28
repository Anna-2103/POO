using Microsoft.AspNetCore.Mvc;
using SistemaEscenariosDeportivos.Models;

namespace SistemaEscenariosDeportivos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private static List<EventoDeportivo> eventos = new List<EventoDeportivo>
        {
            new EventoDeportivo
            {
                IdEvento = 1,
                NombreEvento = "Torneo Intermunicipal de Fútbol",
                Fecha = DateTime.Now.Date.AddDays(10),
                Organizador = "Instituto Municipal de Deportes",
                Descripcion = "Evento deportivo con participación de municipios del Oriente Antioqueño.",
                IdEscenario = 1
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<EventoDeportivo>> ObtenerEventos()
        {
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public ActionResult<EventoDeportivo> ObtenerEventoPorId(int id)
        {
            var evento = eventos.FirstOrDefault(e => e.IdEvento == id);

            if (evento == null)
            {
                return NotFound("Evento deportivo no encontrado.");
            }

            return Ok(evento);
        }

        [HttpPost]
        public ActionResult<EventoDeportivo> CrearEvento(EventoDeportivo evento)
        {
            evento.IdEvento = eventos.Count + 1;
            eventos.Add(evento);

            return CreatedAtAction(nameof(ObtenerEventoPorId), new { id = evento.IdEvento }, evento);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarEvento(int id, EventoDeportivo eventoActualizado)
        {
            var evento = eventos.FirstOrDefault(e => e.IdEvento == id);

            if (evento == null)
            {
                return NotFound("Evento deportivo no encontrado.");
            }

            evento.NombreEvento = eventoActualizado.NombreEvento;
            evento.Fecha = eventoActualizado.Fecha;
            evento.Organizador = eventoActualizado.Organizador;
            evento.Descripcion = eventoActualizado.Descripcion;
            evento.IdEscenario = eventoActualizado.IdEscenario;

            return Ok(evento);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarEvento(int id)
        {
            var evento = eventos.FirstOrDefault(e => e.IdEvento == id);

            if (evento == null)
            {
                return NotFound("Evento deportivo no encontrado.");
            }

            eventos.Remove(evento);

            return Ok("Evento deportivo eliminado correctamente.");
        }
    }
}