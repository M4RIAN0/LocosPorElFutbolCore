namespace Dominio.Entidades
{
    using DominioBase;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Envios")]
    public partial class Envio : MasterEntityModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }


        //propiedades de navegacion
        public int LocalidadId { get; set; }

        public int ComprobanteId { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual Localidad Localidad { get; set; }
    }
}
