namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Productos")]
    [MetadataType(typeof(IProducto))]
    public partial class Producto: EntidadBase
    {
       

        public int Codigo { get; set; }

        public int CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }


        //PROPIEDADES DE NAVEGACION
        public long RubroId { get; set; }

        public long MarcaId { get; set; }

        public long TalleId { get; set; }

        public long CategoriaId { get; set; }

        public long SubRubroId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }

        public virtual ICollection<ListaPrecioProducto> ListaPrecioProductos { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual SubRubro SubRubro { get; set; }

        public virtual Talle Talle { get; set; }
    }
}
