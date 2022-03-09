namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Tarjetas")]
    [MetadataType(typeof(ITarjeta))]
    public partial class Tarjeta: EntidadBase
    {

        public string NombreTitular { get; set; }

        public int Numero { get; set; }

        public string DniTitular { get; set; }

        public int CodigoSeguridad { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public int Cuotas { get; set; }



        //propiedades de navegacion
        public long BancoId { get; set; }

        public long TipoTarjetaId { get; set; }

        public virtual Banco Banco { get; set; }

        public virtual TipoTarjeta TipoTarjeta { get; set; }
    }
}
