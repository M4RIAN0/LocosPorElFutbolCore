using Servicio.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IServicio.Dtos
{
    public class FacturaDto
    {
        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Direccion { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Fecha { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }

        public string TipoPago { get; set; }


    }

    public class FacturaGetDto : DtoBase
    {
        public string Nombre { get; init; }

        public string Dni { get; init; }

        public string Direccion { get; init; }

        public string Celular { get; init; }

        public string Email { get; init; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Fecha { get; init; }

        public string Estado { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; init; }

        public string TipoPago { get; init; }
    }
}
