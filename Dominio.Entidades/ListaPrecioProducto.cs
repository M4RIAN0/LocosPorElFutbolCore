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

        public decimal PrecioCosto { get; set; }

        public decimal PrecioPublico { get; set; }

        public DateTime FechaActualizacion { get; set; }


        //propiedades de navegacion
        public long ListaPrecioId { get; set; }

        public long ProductoId { get; set; }

        public virtual ListaPrecio ListaPrecio { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
