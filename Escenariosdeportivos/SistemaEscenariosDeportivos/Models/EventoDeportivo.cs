namespace SistemaEscenariosDeportivos.Models
{
    public class EventoDeportivo
    {
        public int IdEvento { get; set; }

        public string NombreEvento { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public string Organizador { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int IdEscenario { get; set; }
    }
}