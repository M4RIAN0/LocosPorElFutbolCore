using Dominio.Entidades;

namespace LXF.Web.Models.ViewModels
{

    public class DetalleCarroComprasViewModel
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
        public int ProductoId { get; set; }
        public int CarroComprasId { get; set; }
    }

    public class DetalleCarroComprasPutViewModel : DetalleCarroComprasViewModel
    {
        public int Id { get; set; }
    }

    public class  DetalleCarroComprasGetViewModel : ViewModelBase
    {
        public int Cantidad { get; init; }
        public decimal Precio { get; init; }
        public decimal Subtotal { get; init; }
        public int ProductoId { get; init; }
        public int CarroComprasId { get; init; }
        public ProductoGetViewModel Producto { get; init; }

    }
}

