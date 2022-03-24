using Servicio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IServicio.Movimiento.Dto
{
    public class MovimientoDto : DtoBase
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        public string Tipo { get; set; }

        public decimal Monto { get; set; }

        public int Codigo { get; set; }

    }
}

