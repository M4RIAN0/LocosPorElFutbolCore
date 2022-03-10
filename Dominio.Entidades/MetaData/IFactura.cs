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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        string Estado { get; set; }

         decimal Total { get; set; }

         int Codigo { get; set; }

    }
}
