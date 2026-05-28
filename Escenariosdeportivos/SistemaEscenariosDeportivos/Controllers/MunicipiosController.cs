using Microsoft.AspNetCore.Mvc;
using SistemaEscenariosDeportivos.Models;

namespace SistemaEscenariosDeportivos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipiosController : ControllerBase
    {
        private static List<Municipio> municipios = new List<Municipio>
        {
            new Municipio
            {
                IdMunicipio = 1,
                NombreMunicipio = "Rionegro"
            },
            new Municipio
            {
                IdMunicipio = 2,
                NombreMunicipio = "La Ceja"
            },
            new Municipio
            {
                IdMunicipio = 3,
                NombreMunicipio = "Marinilla"
            },
            new Municipio
            {
                IdMunicipio = 4,
                NombreMunicipio = "Guarne"
            },
            new Municipio
            {
                IdMunicipio = 5,
                NombreMunicipio = "El Carmen de Viboral"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Municipio>> ObtenerMunicipios()
        {
            return Ok(municipios);
        }

        [HttpGet("{id}")]
        public ActionResult<Municipio> ObtenerMunicipioPorId(int id)
        {
            var municipio = municipios.FirstOrDefault(m => m.IdMunicipio == id);

            if (municipio == null)
            {
                return NotFound("Municipio no encontrado.");
            }

            return Ok(municipio);
        }

        [HttpPost]
        public ActionResult<Municipio> CrearMunicipio(Municipio municipio)
        {
            municipio.IdMunicipio = municipios.Count + 1;
            municipios.Add(municipio);

            return CreatedAtAction(nameof(ObtenerMunicipioPorId), new { id = municipio.IdMunicipio }, municipio);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarMunicipio(int id, Municipio municipioActualizado)
        {
            var municipio = municipios.FirstOrDefault(m => m.IdMunicipio == id);

            if (municipio == null)
            {
                return NotFound("Municipio no encontrado.");
            }

            municipio.NombreMunicipio = municipioActualizado.NombreMunicipio;

            return Ok(municipio);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarMunicipio(int id)
        {
            var municipio = municipios.FirstOrDefault(m => m.IdMunicipio == id);

            if (municipio == null)
            {
                return NotFound("Municipio no encontrado.");
            }

            municipios.Remove(municipio);

            return Ok("Municipio eliminado correctamente.");
        }
    }
}