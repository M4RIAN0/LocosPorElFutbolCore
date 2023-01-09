namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Categorias")]
    [MetadataType(typeof(ICategoria))]
    public partial class Categoria: EntidadBase
    {
        public string Descripcion { get; set; }

        //propiedad de navegacion
        public virtual IEnumerable<Producto> Productos { get; set; }
    }
}
