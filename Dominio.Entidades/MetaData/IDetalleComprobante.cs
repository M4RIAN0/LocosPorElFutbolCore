using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IDetalleComprobante
    {

         int Cantidad { get; set; }

         decimal SubTotal { get; set; }

         int Codigo { get; set; }

         int CodigoBarra { get; set; }

        [Required]
        [StringLength(250)]
         string Descripcion { get; set; }

         decimal Precio { get; set; }


    }
}
