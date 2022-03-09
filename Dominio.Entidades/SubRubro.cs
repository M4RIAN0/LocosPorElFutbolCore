namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SubRubros")]
    [MetadataType(typeof(ISubRubro))]
    public partial class SubRubro: EntidadBase
    {

        public int Codigo { get; set; }

        public string Descripcion { get; set; }



        //propiedades de navegacion
        public long RubroId { get; set; }

        public virtual ICollection<Producto> Productoes { get; set; }

        public virtual Rubro Rubro { get; set; }
    }
}
