using Infraestructura;
using System;
using System.Collections.Generic;
using System.Text;

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
