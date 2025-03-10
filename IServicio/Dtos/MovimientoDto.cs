using Servicio.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace IServicio.Dtos
{
    public class MovimientoDto
    {
        public string Fecha { get; set; }

        public string Tipo { get; set; }

        public decimal Monto { get; set; }

        public int FacturaId { get; set; }
    }

    public class MovimientoGetDto : DtoBase
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly Fecha { get; init; }

        public string Tipo { get; init; }

        public decimal Monto { get; init; }
    }
}

