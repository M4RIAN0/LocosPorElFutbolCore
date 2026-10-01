namespace Dominio.Entidades
{
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Provincias")]
    public partial class Provincia : MasterEntityModel
    {
        [Required]
        public string Nombre { get; set; }

        //propiedades de navegacion
        public virtual IEnumerable<Localidad> Localidades { get; set; }
    }
}
