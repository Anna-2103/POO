namespace SistemaEscenariosDeportivos.Models
{
    public class EscenarioDeportivo
    {
        public int IdEscenario { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        public string Ubicacion { get; set; } = string.Empty;

        public int Capacidad { get; set; }

        public string Estado { get; set; } = string.Empty;

        public int IdMunicipio { get; set; }
    }
}