using Servicio.Base;
using System.Collections.Generic;

namespace IServicio.Dtos
{
    public class CarroCompraDto
    {
        public string? UserId { get; set; }
        public IEnumerable<DetalleCarroCompraDto> DetalleCarroCompras { get; set; }
        public decimal Total { get; set; }
    }

    public class CarroCompraPutDto: DtoBase
    {
        public string? UserId { get; set; }
        public IEnumerable<DetalleCarroCompraPutDto> DetalleCarroCompras { get; set; }
        public decimal Total { get; set; }
    }

    public class CarroCompraGetDto : DtoBase
    {
        public string? UserId { get; init; }
        public IEnumerable<DetalleCarroCompraGetDto> DetalleCarroCompras { get; init; }
        public decimal Total { get; init; }
    }
}
