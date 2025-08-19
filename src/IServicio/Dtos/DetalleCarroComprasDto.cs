using Servicio.Base;

namespace IServicio.Dtos
{
    public class DetalleCarroComprasDto
    {
        public int ProductoId { get; set; }
        public ProductoDto? Producto { get; set; }
        public int Count { get; set; }
        public CarroComprasGetDto? CarroCompras { get; set; }
        public int CarroComprasId { get; set; }
    }

    public class DetalleCarroComprasPutDto : DetalleCarroComprasDto
    {
        public int Id { get; set; }
    }

    public class DetalleCarroComprasGetDto : DtoBase
    {
        public int ProductoId { get; init; }
        public ProductoDto? Producto { get; init; }
        public int Count { get; init; }
        public CarroComprasGetDto? CarroCompras { get; init; }
        public int CarroComprasId { get; init; }
    }
}
