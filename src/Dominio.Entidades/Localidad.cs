namespace Dominio.Entidades
{
    using DominioBase;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Localidades")]
    public partial class Localidad : MasterEntityModel
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int CP { get; set; }


        //propiedades de navegacion
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }

    }
}
