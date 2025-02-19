namespace Dominio.Entidades
{
    using DominioBase;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Facturas")]
    public partial class Factura : MasterEntityModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }


        //propiedades de navegacion
        public int ClienteId { get; set; }

        public int ComprobanteId { get; set; }

        public int MovimientoId { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual PersonaCliente PersonasCliente { get; set; }

        public virtual Movimiento Movimiento { get; set; }
    }
}
