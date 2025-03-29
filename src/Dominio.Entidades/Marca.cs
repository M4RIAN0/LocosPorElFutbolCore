using DominioBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Marcas")]
    public partial class Marca: MasterEntityModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(240, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Descripcion { get; set; }


        //propiedades de navegacion
        public virtual IEnumerable<Producto> Productos { get; set; }
    }
}
