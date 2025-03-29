using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class PersonaClienteViewModel
    {
        public required int Codigo { get; set; }

        public required string Apellido { get; set; }

        public required string Nombre { get; set; }

        public required string Dni { get; set; }

        public required string Direccion { get; set; }

        public required string Sexo { get; set; }

        public required string FechaNacimiento { get; set; }

        public required string Celular { get; set; }

        public required string Email { get; set; }
    }

    public class PersonaClientePutViewModel : PersonaClienteViewModel
    {
        public int Id { get; set; }
    }

    public class PersonaClienteGetViewModel : ViewModelBase
    {
        public int Codigo { get; init; }

        public string Apellido { get; init; }

        public string Nombre { get; init; }

        public string Dni { get; init; }

        public string Direccion { get; init; }

        public string Sexo { get; init; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string FechaNacimiento { get; init; }

        public string Celular { get; init; }

        public string Email { get; init; }

        public string PersonaStr => Apellido + " " + Nombre;
    }
}
