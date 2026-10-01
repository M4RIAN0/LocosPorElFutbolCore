namespace Dominio.Entidades
{
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Categorias")]
    public partial class Categoria : MasterEntityModel
    {
        [Required]
        public string Descripcion { get; set; }

        //propiedad de navegacion
        public virtual IEnumerable<Producto> Productos { get; set; }
    }
}
