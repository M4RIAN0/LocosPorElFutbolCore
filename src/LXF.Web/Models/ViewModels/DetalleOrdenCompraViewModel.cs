namespace LXF.Web.Models.ViewModels
{

    public class DetalleOrdenCompraViewModel
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public int ProductoVarianteId { get; set; }
        public int OrdenComprasId { get; set; }
        public ProductoVarianteViewModel? Producto { get; set; }
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
        public int ProductoVarianteId { get; init; }
        public int OrdenComprasId { get; init; }
        public ProductoVarianteGetViewModel ProductoVariante { get; set; }

    }
}

