using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LXF.Web.Models.ViewModels
{
    public class FacturaViewModel
    {
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public  string? Fecha { get; set; }
        public  string? Estado { get; set; }
        public  decimal Total { get; set; }
        public  string? TipoPago { get; set; }
        public int ComprobanteId { get; set; }
    }

    public class FacturaGetViewModel : ViewModelBase
    {
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Fecha { get; init; }
        public string Estado { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; init; }
        public string TipoPago { get; init; }
        public int ComprobanteId { get; init; }

    }
}
