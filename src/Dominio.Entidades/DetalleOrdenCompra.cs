using DominioBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("DetalleOrdenCompras")]

    public partial class DetalleOrdenCompra : MasterEntityModel
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }

        //propiedades de navegacion
        public int OrdenComprasId { get; set; }
        public int ProductoId { get; set; }
        public virtual OrdenCompra OrdenCompras { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
