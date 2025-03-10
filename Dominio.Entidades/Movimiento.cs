using DominioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Movimientos")]
    public partial class Movimiento : MasterEntityModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateOnly Fecha { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }


        //propiedades de navegacion
        public int FacturaId { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
