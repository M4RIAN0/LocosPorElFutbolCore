using DominioBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.RepositorioBase
{
    public interface IRepositorio<T> : IRepositorioConsulta<T>, IRepositorioOperaciones<T> where T : EntidadBase
    {
    }
}
