using Microsoft.AspNetCore.Mvc;
using SistemaEscenariosDeportivos.Models;

namespace SistemaEscenariosDeportivos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubesController : ControllerBase
    {
        private static List<ClubDeportivo> clubes = new List<ClubDeportivo>
        {
            new ClubDeportivo
            {
                IdClub = 1,
                NombreClub = "Club Deportivo Rionegro",
                Deporte = "Fútbol",
                Representante = "Carlos Gómez"
            },
            new ClubDeportivo
            {
                IdClub = 2,
                NombreClub = "Club Baloncesto La Ceja",
                Deporte = "Baloncesto",
                Representante = "María López"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<ClubDeportivo>> ObtenerClubes()
        {
            return Ok(clubes);
        }

        [HttpGet("{id}")]
        public ActionResult<ClubDeportivo> ObtenerClubPorId(int id)
        {
            var club = clubes.FirstOrDefault(c => c.IdClub == id);

            if (club == null)
            {
                return NotFound("Club deportivo no encontrado.");
            }

            return Ok(club);
        }

        [HttpPost]
        public ActionResult<ClubDeportivo> CrearClub(ClubDeportivo club)
        {
            club.IdClub = clubes.Count + 1;
            clubes.Add(club);

            return CreatedAtAction(nameof(ObtenerClubPorId), new { id = club.IdClub }, club);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarClub(int id, ClubDeportivo clubActualizado)
        {
            var club = clubes.FirstOrDefault(c => c.IdClub == id);

            if (club == null)
            {
                return NotFound("Club deportivo no encontrado.");
            }

            club.NombreClub = clubActualizado.NombreClub;
            club.Deporte = clubActualizado.Deporte;
            club.Representante = clubActualizado.Representante;

            return Ok(club);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarClub(int id)
        {
            var club = clubes.FirstOrDefault(c => c.IdClub == id);

            if (club == null)
            {
                return NotFound("Club deportivo no encontrado.");
            }

            clubes.Remove(club);

            return Ok("Club deportivo eliminado correctamente.");
        }
    }
}