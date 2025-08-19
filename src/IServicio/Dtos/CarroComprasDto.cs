using Servicio.Base;
using System.Collections.Generic;

namespace IServicio.Dtos
{
    public class CarroComprasDto
    {
        public string? UserId { get; set; }
        public IEnumerable<DetalleCarroComprasDto> DettalleCarroCompras { get; set; }
        public decimal Total { get; set; }
    }

    public class CarroComprasPutDto: CarroComprasDto
    {
        public int Id { get; set; }
    }

    public class CarroComprasGetDto : DtoBase
    {
        public string? UserId { get; init; }
        public IEnumerable<DetalleCarroComprasDto> DettalleCarroCompras { get; init; }
        public decimal Total { get; init; }
    }
}
