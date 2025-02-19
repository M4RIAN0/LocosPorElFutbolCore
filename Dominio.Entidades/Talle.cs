namespace Dominio.Entidades
{
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Talles")]
    public partial class Talle : MasterEntityModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Letra { get; set; }


        //propiedades de navegacion

        public virtual IEnumerable<Producto> Productos { get; set; }
    }
}
