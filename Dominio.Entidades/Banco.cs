using DominioBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Bancos")]
    public class Banco : MasterEntityModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Nombre { get; set; }

        //propiedad de navegacion
        public virtual IEnumerable<Tarjeta> Tarjetas { get; set; }
    }
}
