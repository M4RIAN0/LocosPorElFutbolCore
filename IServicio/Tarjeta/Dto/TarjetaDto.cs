using Servicio.Base;
using System;

namespace IServicio.Tarjeta.Dto
{
    public class TarjetaDto : DtoBase
    {
        public string NombreTitular { get; set; }

        public int Numero { get; set; }

        public string DniTitular { get; set; }

        public int CodigoSeguridad { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public int Cuotas { get; set; }

        public int BancoId { get; set; }

        public int TipoTarjetaId { get; set; }

        public string BancoStr { get; set; }

        public string TipoTarjetaStr { get; set; }
    }
}
