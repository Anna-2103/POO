using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fachada
{
    public class CineFacade
    {
        private Luces luces;
        private Proyector proyector;
        private Reproductor reproductor;

        public CineFacade()
        {
            luces = new Luces();
            proyector = new Proyector();
            reproductor = new Reproductor();
        }

        public void VerPelicula()
        {
            luces.Apagar();
            proyector.Encender();
            reproductor.Reproducir();
        }

        public void TerminarPelicula()
        {
            reproductor.Detener();
            proyector.Apagar();
            luces.Encender();
        }
    }
}
