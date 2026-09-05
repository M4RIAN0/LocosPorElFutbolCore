namespace Dominio.Entidades
{
    using DominioBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Comprobantes")]
    public partial class Comprobante : MasterEntityModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateOnly Fecha { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }


        //propiedades de navegacion
        public virtual IEnumerable<DetalleComprobante> DetalleComprobantes { get; set; }
        public int ClienteId { get; set; }
        public virtual PersonaCliente Cliente { get; set; }
        public int FacturaId { get; set; }
        public virtual Factura Factura { get; set; }
        public int EnvioId { get; set; }
        public virtual Envio Envio { get; set; }
    }
}
