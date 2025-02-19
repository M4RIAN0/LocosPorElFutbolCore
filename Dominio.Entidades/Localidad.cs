namespace Dominio.Entidades
{
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Localidades")]
    public partial class Localidad : MasterEntityModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }


        //propiedades de navegacion
        public int ProvinciaId { get; set; }

        public virtual IEnumerable<Envio> Envios { get; set; }

        public virtual Provincia Provincia { get; set; }
    }
}
