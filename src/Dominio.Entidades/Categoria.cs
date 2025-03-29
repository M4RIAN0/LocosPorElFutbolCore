namespace Dominio.Entidades
{
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Categorias")]
    public partial class Categoria : MasterEntityModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Descripcion { get; set; }

        //propiedad de navegacion
        public virtual IEnumerable<Producto> Productos { get; set; }
    }
}
