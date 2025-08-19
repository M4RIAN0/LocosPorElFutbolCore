using DominioBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("CarroCompras")]
    public partial class CarroCompras : MasterEntityModel
    {
        public string? UserId { get; set; }

        [NotMapped]
        public decimal Total { get; set; }
    }
}
