using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class PersonaClienteViewModel
    {
        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public required string Apellido { get; set; }
        [Required]
        [StringLength(8)]
        public required string Dni { get; set; }
        [Required]
        public required string FechaNacimiento { get; set; }
        [Required]
        public required string Sexo { get; set; }
        [Required]
        [StringLength(10)]
        public required string Celular { get; set; }
        [Required]
        public required string Direccion { get; set; }
        [Required]
        public required string Email { get; set; }
    }

    public class PersonaClientePutViewModel : PersonaClienteViewModel
    {
        public int Id { get; set; }
    }

    public class PersonaClienteGetViewModel : ViewModelBase
    {
        public string Apellido { get; init; }

        public string Nombre { get; init; }

        public string Dni { get; init; }

        public string Direccion { get; init; }

        public string Sexo { get; init; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string FechaNacimiento { get; init; }

        public string Celular { get; init; }

        public string Email { get; init; }
    }
}
