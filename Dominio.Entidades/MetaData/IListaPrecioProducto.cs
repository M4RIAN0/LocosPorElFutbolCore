using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IListaPrecioProducto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        decimal PrecioCosto { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        decimal PrecioPublico { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime FechaActualizacion { get; set; }

    }
}
