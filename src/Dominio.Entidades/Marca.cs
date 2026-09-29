using DominioBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Marcas")]
    public partial class Marca: MasterEntityModel
    {
        [Required]
        public string Descripcion { get; set; }

        //propiedades de navegacion
        public virtual IEnumerable<Producto> Productos { get; set; }
    }
}
