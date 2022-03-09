namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Localidades")]
    [MetadataType(typeof(ILocalidades))]
    public partial class Localidade: EntidadBase
    {
       
        public string Nombre { get; set; }


        //propiedades de navegacion
        public long ProvinciaId { get; set; }

        public virtual ICollection<Envio> Envios { get; set; }

        public virtual Provincia Provincia { get; set; }
    }
}
