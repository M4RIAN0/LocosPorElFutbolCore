using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("PersonasClientes")]
    public partial class PersonaCliente : Persona
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Codigo { get; set; }

        //propiedades de navegacion
       
        public virtual IEnumerable<Factura> Facturas { get; set; }
    }
}
