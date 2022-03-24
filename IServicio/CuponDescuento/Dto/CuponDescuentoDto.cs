using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.CuponDescuento.Dto
{
    public class CuponDescuentoDto : DtoBase
    {
        public string Descripcion { get; set; }

        public decimal Porcentaje { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaCaducidad { get; set; }

        public long? ComprobanteId { get; set; }

        public string ComprobanteStr { get; set; }//needs check
    }
}
