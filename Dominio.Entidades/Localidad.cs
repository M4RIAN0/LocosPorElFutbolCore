namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Localidades")]
    [MetadataType(typeof(ILocalidades))]
    public partial class Localidad: EntidadBase
    {
       
        public string Nombre { get; set; }


        //propiedades de navegacion
        public long Provincia_Id { get; set; }

        public virtual IEnumerable<Envio> Envios { get; set; }

        public virtual Provincia Provincia { get; set; }
    }
}
