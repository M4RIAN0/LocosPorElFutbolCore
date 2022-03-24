using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.TipoTarjeta.Dto
{
    public class TipoTarjetaDto : DtoBase
    {
        public string Nombre { get; set; }

        public string Tipo { get; set; }
    }
}
