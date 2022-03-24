namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Provincias")]
    [MetadataType(typeof(IProvincia))]
    public partial class Provincia: EntidadBase
    {
       
        public string Nombre { get; set; }

        public string CP { get; set; }


        //propiedades de navegacion
        public virtual ICollection<Localidad> Localidades { get; set; }
    }
}
