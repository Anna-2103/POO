namespace SistemaEscenariosDeportivos.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }

        public DateTime Fecha { get; set; }

        public string HoraInicio { get; set; } = string.Empty;

        public string HoraFin { get; set; } = string.Empty;

        public string Estado { get; set; } = "Pendiente";

        public int IdUsuario { get; set; }

        public int IdEscenario { get; set; }
    }
}