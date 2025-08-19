namespace LXF.Web.Models.ViewModels
{

    public class DetalleCarroComprasViewModel
    {
        public int ProductoId { get; set; }
        public ProductoViewModel? Producto { get; set; }
        public int Count { get; set; }
        public CarroComprasGetViewModel? CarroCompras { get; set; }
        public int CarroComprasId { get; set; }
    }

    public class DetalleCarroComprasPutViewModel : DetalleCarroComprasViewModel
    {
        public int Id { get; set; }
    }

    public class DetalleCarroComprasGetViewModel : ViewModelBase
    {
        public int ProductoId { get; init; }
        public ProductoViewModel? Producto { get; init; }
        public int Count { get; init; }
        public CarroComprasGetViewModel? CarroCompras { get; init; }
        public int CarroComprasId { get; init; }
    }
}

