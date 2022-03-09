using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface ITarjeta
    {
        [Required]
         string NombreTitular { get; set; }

         int Numero { get; set; }

        [Required]
        [StringLength(8)]
         string DniTitular { get; set; }

         int CodigoSeguridad { get; set; }

         DateTime FechaExpiracion { get; set; }

         int Cuotas { get; set; }

    }
}
