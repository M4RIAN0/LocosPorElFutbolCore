namespace Dominio.Entidades
{
    using DominioBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Facturas")]
    public partial class Factura : MasterEntityModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public string TipoPago { get; set; }


        //propiedades de navegacion
        public int ClienteId { get; set; }

        public int ComprobanteId { get; set; }

        public int? TarjetaId { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual PersonaCliente PersonaCliente { get; set; }

        public virtual Tarjeta Tarjeta { get; set; }

        public virtual IEnumerable<Movimiento> Movimientos { get; set; }
    }
}
