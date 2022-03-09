using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IFactura
    {
         DateTime Fecha { get; set; }

        [Required]
         string Estado { get; set; }

         decimal Total { get; set; }

         int Codigo { get; set; }

    }
}
