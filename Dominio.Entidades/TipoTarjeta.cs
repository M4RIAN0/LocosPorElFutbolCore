using DominioBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("TipoTarjetas")]
    public partial class TipoTarjeta : MasterEntityModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Tipo { get; set; }


        //propiedades de navegacion

        public virtual IEnumerable<Tarjeta> Tarjetas { get; set; }
    }
}
