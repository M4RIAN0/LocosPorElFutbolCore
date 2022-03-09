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
        [Required]
         string Tipo { get; set; }

         decimal Monto { get; set; }

    }
}
