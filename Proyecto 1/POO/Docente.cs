using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class Docente:Persona
    {
        public Docente() { }
        public int IdPersona { get; set; }
        public int IdDocente { get; set; }

        public string Correo { get; set; }

        public string Facultad { get; set; }

        public string Asignatura { get; set; }

        public int AñosExperiencia { get; set; }

        public string TipoContrato { get; set; }

    }
}