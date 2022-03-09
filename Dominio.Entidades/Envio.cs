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

        public decimal Monto { get; set; }


        //propiedades de navegacion
        public long LocalidadId { get; set; }

        public long Comprobante_Id { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual Localidade Localidade { get; set; }
    }
}
