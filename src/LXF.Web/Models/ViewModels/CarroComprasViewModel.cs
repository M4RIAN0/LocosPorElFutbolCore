namespace LXF.Web.Models.ViewModels
{

    public class CarroComprasViewModel
    {
        public string? UserId { get; set; }
        public IEnumerable<DetalleCarroComprasViewModel> DettalleCarroCompras { get; set; }
        public decimal Total { get; set; }
    }

    public class CarroComprasPutViewModel : CarroComprasViewModel
    {
        public int Id { get; set; }
    }

    public class CarroComprasGetViewModel : ViewModelBase
    {
        public string? UserId { get; init; }
        public IEnumerable<DetalleCarroComprasViewModel> DettalleCarroCompras { get; init; }
        public decimal Total { get; init; }
    }
}

