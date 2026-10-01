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
        public int ProductoVarianteId { get; set; }
        public virtual OrdenCompra OrdenCompras { get; set; }
        public virtual ProductoVariante ProductoVariante { get; set; }
    }
}
