using DominioBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("DetalleCarroCompras")]
    public partial class DetalleCarroCompras : MasterEntityModel
    {
        [NotMapped] // deberia ser Dto
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }
        public int Count { get; set; }


        //propiedades de navegacion
        public virtual CarroCompras CarroCompras { get; set; }
        public int CarroComprasId { get; set; }
    }
}
