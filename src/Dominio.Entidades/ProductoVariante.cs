namespace Dominio.Entidades
{
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductosVariantes")]
    public class ProductoVariante : MasterEntityModel
    {
        [Required]
        public string Talle { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string CodigoBarra { get; set; }


        // PROPIEDADES DE NAVEGACION

        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual IEnumerable<DetalleCarroCompra> DetalleCarroCompras { get; set; }
    }
}