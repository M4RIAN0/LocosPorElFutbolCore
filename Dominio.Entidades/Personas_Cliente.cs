namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PersonasClientes")]
    [MetadataType(typeof(IPersonaCliente))]
    public partial class Persona_Cliente: Persona
    {
        
        public int Codigo { get; set; }


        //propiedades de navegacion
       
        public virtual IEnumerable<Factura> Facturas { get; set; }

        //public virtual Persona Persona { get; set; }

        public virtual IEnumerable<Usuario> Usuarios { get; set; }
    }
}
