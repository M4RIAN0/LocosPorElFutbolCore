using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    interface IProvincia
    {
        [Required]
         string Nombre { get; set; }

        [Required]
         string CP { get; set; }
    }
}
