using Dominio.Repositorio.Dtos;
using Servicio.Base;

namespace IServicio.Dtos
{
    public class DetalleCarroCompraDto
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public int ProductoVarianteId { get; set; }
        public int CarroComprasId { get; set; }

    }

    public class DetalleCarroCompraPutDto : DetalleCarroCompraDto
    {
        public int Id { get; set; }
    }

    public class DetalleCarroCompraGetDto : DtoBase
    {
        public int Cantidad { get; init; }
        public decimal Precio { get; init; }
        public decimal SubTotal { get; init; }
        public int ProductoVarianteId { get; init; }
        public int CarroComprasId { get; init; }
        public ProductoVarianteGetDto ProductoVariante { get; init; }
    }
}
