using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.Envio.Dto
{
    public class EnvioDto : DtoBase
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public int LocalidadId { get; set; }
        public int Comprobante_Id { get; set; }
        public string ComprobanteStr { get; set; }
        public string LocalidadeStr { get; set; }
    }
}
