using Dominio.Entidades.MetaData;
using DominioBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("TipoTarjetas")]
    [MetadataType(typeof(ITipoTarjeta))]
    public partial class TipoTarjeta: EntidadBase
    {

        public string Nombre { get; set; }

        public string Tipo { get; set; }


        //propiedades de navegacion
      
        public virtual IEnumerable<Tarjeta> Tarjetas { get; set; }
    }
}
