using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IComprobante
    {
         DateTime Fecha { get; set; }

         decimal Total { get; set; }
    }
}
