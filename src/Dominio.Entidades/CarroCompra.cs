using DominioBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("CarroCompras")]
    public partial class CarroCompra : MasterEntityModel
    {
        public string? UserId { get; set; }
        public decimal Total { get; set; }

        //propiedades de navegacion
        public virtual IEnumerable<DetalleCarroCompra> DetalleCarroCompras { get; set; }
    }
}
