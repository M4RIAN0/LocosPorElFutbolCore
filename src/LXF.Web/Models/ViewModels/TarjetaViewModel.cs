using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class TarjetaViewModel
    {
        public required string Nombre { get; set; }

        public required string NombreTitular { get; set; }

        public required string Numero { get; set; }

        public required string DniTitular { get; set; }

        public required string CodigoSeguridad { get; set; }

        public required string FechaExpiracion { get; set; }

        public required int Cuotas { get; set; }

        public required int BancoId { get; set; }

        public required int TipoTarjetaId { get; set; }
    }

    public class TarjetaGetViewModel : ViewModelBase
    {
        public string Nombre { get; init; }

        public string NombreTitular { get; init; }

        public string Numero { get; init; }

        public string DniTitular { get; init; }

        public int CodigoSeguridad { get; init; }

        [DisplayFormat(DataFormatString = "{0:MM/yy}")]
        public string FechaExpiracion { get; init; }

        public string Cuotas { get; init; }

        public string Banco { get; init; }

        public string TipoTarjeta { get; init; }
    }
}
