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
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Celular { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateOnly Fecha { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public decimal Total { get; set; }

        public string TipoPago { get; set; }


        //propiedades de navegacion
        public virtual IEnumerable<Comprobante> Comprobantes { get; set; }
    }
}
