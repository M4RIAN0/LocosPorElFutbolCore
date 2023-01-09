namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Envios")]
    [MetadataType(typeof(IEnvio))]
    public partial class Envio: EntidadBase
    {
        public string Tipo { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Monto { get; set; }


        //propiedades de navegacion
        public long Localidad_Id { get; set; }

        public long Comprobante_Id { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual Localidad Localidad { get; set; }
    }
}
