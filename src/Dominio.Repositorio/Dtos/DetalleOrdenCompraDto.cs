using Servicio.Base;

namespace Dominio.Repositorio.Dtos
{
    public class DetalleOrdenCompraDto
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public int ProductoId { get; set; }
        public int OrdenComprasId { get; set; }
        public ProductoDto? Producto { get; init; }

    }

    public class DetalleOrdenCompraPutDto : DetalleOrdenCompraDto
    {
        public int Id { get; set; }
    }

    public class DetalleOrdenCompraGetDto : DtoDominioBase
    {
        public int Cantidad { get; init; }
        public decimal Precio { get; init; }
        public decimal SubTotal { get; init; }
        public int ProductoId { get; init; }
        public int OrdenComprasId { get; init; }
        public ProductoGetDto Producto { get; init; }
    }
}
