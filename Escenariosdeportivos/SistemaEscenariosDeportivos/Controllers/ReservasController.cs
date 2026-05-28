using Microsoft.AspNetCore.Mvc;
using SistemaEscenariosDeportivos.Models;

namespace SistemaEscenariosDeportivos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private static List<Reserva> reservas = new List<Reserva>
        {
            new Reserva
            {
                IdReserva = 1,
                Fecha = DateTime.Now.Date,
                HoraInicio = "08:00",
                HoraFin = "10:00",
                Estado = "Aprobada",
                IdUsuario = 1,
                IdEscenario = 1
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Reserva>> ObtenerReservas()
        {
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public ActionResult<Reserva> ObtenerReservaPorId(int id)
        {
            var reserva = reservas.FirstOrDefault(r => r.IdReserva == id);

            if (reserva == null)
            {
                return NotFound("Reserva no encontrada.");
            }

            return Ok(reserva);
        }

        [HttpPost]
        public ActionResult<Reserva> CrearReserva(Reserva reserva)
        {
            bool existeCruce = reservas.Any(r =>
                r.IdEscenario == reserva.IdEscenario &&
                r.Fecha.Date == reserva.Fecha.Date &&
                r.HoraInicio == reserva.HoraInicio &&
                r.HoraFin == reserva.HoraFin &&
                r.Estado != "Cancelada" &&
                r.Estado != "Rechazada"
            );

            if (existeCruce)
            {
                return BadRequest("El escenario ya tiene una reserva en esa fecha y horario.");
            }

            reserva.IdReserva = reservas.Count + 1;
            reserva.Estado = "Pendiente";
            reservas.Add(reserva);

            return CreatedAtAction(nameof(ObtenerReservaPorId), new { id = reserva.IdReserva }, reserva);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarReserva(int id, Reserva reservaActualizada)
        {
            var reserva = reservas.FirstOrDefault(r => r.IdReserva == id);

            if (reserva == null)
            {
                return NotFound("Reserva no encontrada.");
            }

            reserva.Fecha = reservaActualizada.Fecha;
            reserva.HoraInicio = reservaActualizada.HoraInicio;
            reserva.HoraFin = reservaActualizada.HoraFin;
            reserva.Estado = reservaActualizada.Estado;
            reserva.IdUsuario = reservaActualizada.IdUsuario;
            reserva.IdEscenario = reservaActualizada.IdEscenario;

            return Ok(reserva);
        }

        [HttpPut("{id}/aprobar")]
        public IActionResult AprobarReserva(int id)
        {
            var reserva = reservas.FirstOrDefault(r => r.IdReserva == id);

            if (reserva == null)
            {
                return NotFound("Reserva no encontrada.");
            }

            reserva.Estado = "Aprobada";

            return Ok("Reserva aprobada correctamente.");
        }

        [HttpPut("{id}/rechazar")]
        public IActionResult RechazarReserva(int id)
        {
            var reserva = reservas.FirstOrDefault(r => r.IdReserva == id);

            if (reserva == null)
            {
                return NotFound("Reserva no encontrada.");
            }

            reserva.Estado = "Rechazada";

            return Ok("Reserva rechazada correctamente.");
        }

        [HttpPut("{id}/cancelar")]
        public IActionResult CancelarReserva(int id)
        {
            var reserva = reservas.FirstOrDefault(r => r.IdReserva == id);

            if (reserva == null)
            {
                return NotFound("Reserva no encontrada.");
            }

            reserva.Estado = "Cancelada";

            return Ok("Reserva cancelada correctamente.");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarReserva(int id)
        {
            var reserva = reservas.FirstOrDefault(r => r.IdReserva == id);

            if (reserva == null)
            {
                return NotFound("Reserva no encontrada.");
            }

            reservas.Remove(reserva);

            return Ok("Reserva eliminada correctamente.");
        }
    }
}