using System.ComponentModel.DataAnnotations;

namespace LXF.Web.Models.ViewModels
{
    public class MovimientoViewModel
    {
        public required string Fecha { get; set; }

        public required string Tipo { get; set; }

        public required decimal Monto { get; set; }

        public required int FacturaId { get; set; }
    }

    public class MovimientoGetViewModel : ViewModelBase
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly Fecha { get; init; }

        public string Tipo { get; init; }

        public decimal Monto { get; init; }
    }
}

