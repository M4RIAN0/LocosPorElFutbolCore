using Servicio.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace IServicio.Dtos
{
    public class TarjetaDto
    {
        public string Nombre { get; set; }

        public string NombreTitular { get; set; }

        public string Numero { get; set; }

        public string DniTitular { get; set; }

        public string CodigoSeguridad { get; set; }

        public string FechaExpiracion { get; set; }

        public int Cuotas { get; set; }

        public int BancoId { get; set; }

        public int TipoTarjetaId { get; set; }
    }

    public class TarjetaGetDto : DtoBase
    {
        public string Nombre { get; init; }

        public string NombreTitular { get; init; }

        public string Numero { get; init; }

        public string DniTitular { get; init; }

        public int CodigoSeguridad { get; init; }

        [DisplayFormat(DataFormatString = "{0:MM/yy}")]
        public string FechaExpiracion { get; init; }

        public string Cuotas { get; init; }

        public int BancoId { get; init; }

        public string Banco { get; init; }

        public int TipoTarjetaId { get; init; }

        public string TipoTarjeta { get; init; }
    }
}
