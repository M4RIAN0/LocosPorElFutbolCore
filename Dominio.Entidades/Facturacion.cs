using DominioBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Facturacion")]
    public class Facturacion : MasterEntityModel
    {
        //Propiedades

        public int CodPostal { get; set; }

        public string Direccion { get; set; }

        //Propiedades de Navegacion

        public long TarjetaId { get; set; }

        public virtual Tarjeta Tarjeta { get; set; }

        public long ProvinciaId { get; set; }

        public virtual Provincia Provincia { get; set; }

        public long LocalidadId { get; set; }

        public virtual Localidad Localidad { get; set; }



    }

}
