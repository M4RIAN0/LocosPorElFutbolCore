namespace Dominio.Entidades
{
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Envios")]
    public partial class Envio : MasterEntityModel
    {
        [Required]
        public string Persona { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Celular { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Dni { get; set; }

        [Required]
        public decimal Monto { get; set; }
        public string Estado { get; set; }

        //propiedades de navegacion
        public virtual IEnumerable<Comprobante> Comprobantes { get; set; }
    }
}
