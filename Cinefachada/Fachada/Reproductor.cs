using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fachada
{
    public class Reproductor
    {
        public void Reproducir()
        {
            Console.WriteLine("Reproduciendo película");
        }

        public void Detener()
        {
            Console.WriteLine("Película detenida");
        }
    }
}