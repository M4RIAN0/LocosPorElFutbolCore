using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.MetaData
{
    public interface ITipoTarjeta
    {
        [Required]
        string Nombre { get; set; }

        [Required]
         string Tipo { get; set; }

    }
}
