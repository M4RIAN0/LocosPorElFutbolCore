using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.DetalleComprobante.Dto
{
    public class DetalleComprobanteDto : DtoBase
    {
        public int Cantidad { get; set; }

        public decimal SubTotal { get; set; }

        public int Codigo { get; set; }

        public int CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public long ProductoId { get; set; }

        public long ComprobanteId { get; set; }

        public string ComprobanteStr { get; set; }

        public string ProductoStr { get; set; }
    }
}
