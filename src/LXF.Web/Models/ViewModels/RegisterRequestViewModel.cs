using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class RegisterRequestViewModel
    {
        [Required(ErrorMessage = "El Email es Obligatorio.")]
        [EmailAddress(ErrorMessage = "El Formato del Correo no es Válido.")]
        public string Email { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El Teléfono Celular es Obligatorio.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El celular Debe Tener Exactamente 10 Dígitos.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El celular Solo Debe Contener Números.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "La Contraseña es Obligatoria.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La Contraseña Debe Tener al Menos 8 Caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "La Contraseña Debe Contener Mayúsculas, Minúsculas, un Número y un Símbolo.")]
        public string Password { get; set; }

        public string? Role { get; set; }

        // Seccion Persona
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El Nombre no Puede Superar los 50 Caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es Obligatorio.")]
        [StringLength(50, ErrorMessage = "El Apellido no Puede Superar los 50 Caracteres.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El DNI es Obligatorio.")]
        [StringLength(8, MinimumLength = 7, ErrorMessage = "El DNI Debe Tener Entre 7 y 8 Dígitos.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El DNI Solo Debe Contener Números.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "La Dirección de Envío es Obligatoria.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Sexo es Obligatorio.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "La Fecha de Nacimiento es Obligatoria.")]
        [DataType(DataType.Date)]
        public string FechaNacimiento { get; set; }
    }
}