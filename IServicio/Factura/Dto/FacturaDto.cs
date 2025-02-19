using Servicio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IServicio.Factura.Dto
{
    public class FacturaDto : DtoBase
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }

        public int Codigo { get; set; }

        public int ClienteId { get; set; }

        public int Comprobante_Id { get; set; }

        public int Movimiento_Id { get; set; }

        public string ComprobanteStr { get; set; }

        public string MovimientoStr { get; set; }
    }
}
