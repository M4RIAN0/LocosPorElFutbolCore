using Dominio.Entidades.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("PersonasClientes")]
    [MetadataType(typeof(IPersonaCliente))]
    public partial class Persona_Cliente: Persona
    {
        public int Codigo { get; set; }


        //propiedades de navegacion
       
        public virtual IEnumerable<Factura> Facturas { get; set; }

        public virtual IEnumerable<Usuario> Usuarios { get; set; }
    }
}
