namespace LXF.Web.Models.ViewModels
{

    public class DetalleOrdenComprasViewModel
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public int ProductoId { get; set; }
        public int OrdenComprasId { get; set; }
    }

    public class DetalleOrdenComprasPutViewModel : DetalleOrdenComprasViewModel
    {
        public int Id { get; set; }
    }

    public class DetalleOrdenComprasGetViewModel : ViewModelBase
    {
        public int Cantidad { get; init; }
        public decimal Precio { get; init; }
        public decimal SubTotal { get; init; }
        public int ProductoId { get; init; }
        public int OrdenComprasId { get; init; }
        public ProductoGetViewModel Producto { get; set; }

    }
}

