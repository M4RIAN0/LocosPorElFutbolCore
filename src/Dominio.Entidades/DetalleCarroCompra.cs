using DominioBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("DetalleCarroCompras")]
    public partial class DetalleCarroCompra : MasterEntityModel
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }

        //propiedades de navegacion
        public int CarroCompraId { get; set; }
        public int ProductoId { get; set; }
        public virtual CarroCompra CarroCompra { get; set; }
        public virtual Producto Producto { get; set; }

    }
}
