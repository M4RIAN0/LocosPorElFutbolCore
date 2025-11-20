using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{

    public class OrdenComprasViewModel
    {
        public string? UserId { get; set; }
        public IEnumerable<DetalleOrdenComprasViewModel> DetalleOrdenCompras { get; set; }
        public decimal Total { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Celular { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Fecha { get; set; }
        public string? Status { get; set; }
    }

    public class OrdenComprasPutViewModel : ViewModelBase
    {
        public string? UserId { get; set; }
        public IEnumerable<DetalleOrdenComprasPutViewModel> DetalleOrdenCompras { get; set; }
        public decimal Total { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Celular { get; set; }
        [Required]
        public string? Email { get; set; }
        public string Fecha { get; set; }
        public string Status { get; set; }
    }

    public class OrdenComprasGetViewModel : ViewModelBase
    {
        public string? UserId { get; init; }
        public IEnumerable<DetalleOrdenComprasGetViewModel> DetalleOrdenCompras { get; init; }
        public decimal Total { get; init; }
        [Required]
        public string? Nombre { get; init; }
        [Required]
        public string? Celular { get; init; }
        [Required]
        public string?  Email { get; init; }
        public string Fecha { get; init; }
        public string Status { get; init; }
    }
}

