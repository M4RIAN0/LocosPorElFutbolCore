namespace LXF.Web.Models.ViewModels
{

    public class DetalleOrdenCompraViewModel
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public int ProductoId { get; set; }
        public int OrdenComprasId { get; set; }
        public ProductoViewModel? Producto { get; set; }
    }

    public class DetalleOrdenComprasPutViewModel : DetalleOrdenCompraViewModel
    {
        public int Id { get; set; }
    }

    public class DetalleOrdenCompraGetViewModel : ViewModelBase
    {
        public int Cantidad { get; init; }
        public decimal Precio { get; init; }
        public decimal SubTotal { get; init; }
        public int ProductoId { get; init; }
        public int OrdenComprasId { get; init; }
        public ProductoGetViewModel Producto { get; init; }

    }
}

