namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ListaPrecioProductos")]
    [MetadataType(typeof(IListaPrecioProducto))]
    public partial class ListaPrecioProducto: EntidadBase
    {

        [Column(TypeName = "decimal(18,4)")]
        public decimal PrecioCosto { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal PrecioPublico { get; set; }

        public DateTime FechaActualizacion { get; set; }


        //propiedades de navegacion
        public long ListaPrecio_Id { get; set; }

        public long Producto_Id { get; set; }

        public virtual ListaPrecio ListaPrecio { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
