using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IEnvio
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
         string Tipo { get; set; }

         decimal Monto { get; set; }

    }
}
