namespace LXF.Web.Models.ViewModels
{

    public class DetalleCarroComprasViewModel
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public int ProductoVarianteId { get; set; }
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
        public decimal SubTotal { get; init; }
        public int ProductoVarianteId { get; init; }
        public int CarroComprasId { get; init; }
        public ProductoVarianteGetViewModel ProductoVariante { get; init; }

    }
}

