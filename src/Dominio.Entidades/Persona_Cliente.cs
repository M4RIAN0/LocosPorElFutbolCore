using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("PersonasClientes")]
    public partial class PersonaCliente : Persona
    {
        //propiedades de navegacion
        public virtual IEnumerable<Factura> Facturas { get; set; }
    }
}
