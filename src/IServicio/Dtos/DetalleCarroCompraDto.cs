using Servicio.Base;

namespace IServicio.Dtos
{
    public class DetalleCarroCompraDto
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
        public int ProductoId { get; set; }
        public int CarroCompraId { get; set; }
       
    }

    public class DetalleCarroCompraPutDto : DetalleCarroCompraDto
    {
        public int Id { get; set; }
    }

    public class DetalleCarroCompraGetDto : DtoBase
    {
        public int Cantidad { get; init; }
        public decimal Precio { get; init; }
        public decimal Subtotal { get; init; }
        public int ProductoId { get; init; }
        public int CarroCompraId { get; init; }
        public ProductoGetDto Producto { get; init; }
    }
}
