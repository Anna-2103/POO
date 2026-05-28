namespace SistemaEscenariosDeportivos.Models
{
    public class ClubDeportivo
    {
        public int IdClub { get; set; }

        public string NombreClub { get; set; } = string.Empty;

        public string Deporte { get; set; } = string.Empty;

        public string Representante { get; set; } = string.Empty;
    }
}