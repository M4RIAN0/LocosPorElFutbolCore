using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IMovimiento
    {
         DateTime Fecha { get; set; }

        [Required]
         string Tipo { get; set; }

         decimal Monto { get; set; }

         int Codigo { get; set; }
    }
}
