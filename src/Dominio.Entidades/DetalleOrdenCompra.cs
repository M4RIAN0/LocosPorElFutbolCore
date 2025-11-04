using DominioBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("DetalleOrdenCompras")]

    public partial class DetalleOrdenCompra : MasterEntityModel
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }

        //propiedades de navegacion
        public int OrdenCompraId { get; set; }
        public int ProductoId { get; set; }
        public virtual OrdenCompra OrdenCompra { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
