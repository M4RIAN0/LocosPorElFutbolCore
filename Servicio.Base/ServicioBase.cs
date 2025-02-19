using Infraestructura;

namespace Servicio.Base
{
    public class ServicioBase
    {
        protected readonly LxfContext Context;

        public ServicioBase()
        {
            Context = new LxfContext();
        }
    }
}
