using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IProducto
    {
         int Codigo { get; set; }

         int CodigoBarra { get; set; }

        [Required]
         string Descripcion { get; set; }

         int Stock { get; set; }

    }
}
