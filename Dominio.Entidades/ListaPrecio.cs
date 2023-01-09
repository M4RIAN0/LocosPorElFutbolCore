namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ListaPrecios")]
    [MetadataType(typeof(IListaPrecio))]
    public partial class ListaPrecio: EntidadBase
    {

        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool EstaEliminado { get; set; }

        //propiedades de navegacion
        public virtual IEnumerable<ListaPrecioProducto> ListaPrecioProductos { get; set; }
    }
}
