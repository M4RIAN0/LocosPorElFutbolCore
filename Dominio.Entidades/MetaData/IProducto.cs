using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IProducto
    {
         int Codigo { get; set; }

         int CodigoBarra { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")] 
        string Descripcion { get; set; }

         int Stock { get; set; }

    }
}
