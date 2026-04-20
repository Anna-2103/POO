using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fachada
{
    public class Proyector
    {
        public void Encender()
        {
            Console.WriteLine("Proyector encendido");
        }

        public void Apagar()
        {
            Console.WriteLine("Proyector apagado");
        }
    }
}