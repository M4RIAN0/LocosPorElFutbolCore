using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IListaPrecioProducto
    {
         decimal PrecioCosto { get; set; }

         decimal PrecioPublico { get; set; }

         DateTime FechaActualizacion { get; set; }

    }
}
