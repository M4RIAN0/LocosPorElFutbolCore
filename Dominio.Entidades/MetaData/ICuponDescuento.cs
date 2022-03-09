using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface ICuponDescuento
    {
        [Required]
         string Descripcion { get; set; }

         decimal Porcentaje { get; set; }

         DateTime FechaEmision { get; set; }

         DateTime FechaCaducidad { get; set; }

    }
}
