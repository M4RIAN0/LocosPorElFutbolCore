using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{

    public class CarroComprasViewModel
    {
        public string? UserId { get; set; }
        public IEnumerable<DetalleCarroComprasViewModel> DetalleCarroCompras { get; set; }
        public decimal Total { get; set; }
    }

    public class CarroComprasPutViewModel : ViewModelBase
    {
        public string? UserId { get; set; }
        public IEnumerable<DetalleCarroComprasPutViewModel> DetalleCarroCompras { get; set; }
        public decimal Total { get; set; }
    }

    public class CarroComprasGetViewModel : ViewModelBase
    {
        public string? UserId { get; init; }
        public IEnumerable<DetalleCarroComprasGetViewModel> DetalleCarroCompras { get; init; }
        public decimal Total { get; init; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Celular { get; set; }
        [Required]
        public string?  Email { get; set; }
    }
}

