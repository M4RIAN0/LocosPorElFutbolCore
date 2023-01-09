namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rubros")]
    [MetadataType(typeof(IRubro))]
    public partial class Rubro: EntidadBase
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }


        //propiedades de navegacion
     
        public virtual IEnumerable<SubRubro> SubRubros { get; set; }
    }
}
