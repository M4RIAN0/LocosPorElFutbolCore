using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.Comprobante.Dto
{
    public class ComprobanteDto: DtoBase
    {
        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }
    }
}
