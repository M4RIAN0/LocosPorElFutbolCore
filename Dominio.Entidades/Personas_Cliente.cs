namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PersonasClientes")]
    [MetadataType(typeof(IPersonaCliente))]
    public partial class Personas_Cliente: Persona
    {
        
        public int Codigo { get; set; }


        //propiedades de navegacion
       
        public virtual ICollection<Factura> Facturas { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
