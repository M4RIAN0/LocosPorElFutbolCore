using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Provincia.Dto
{
    public class ProvinciaDto : DtoBase
    {
        public string Nombre { get; set; }

        public string CP { get; set; }
    }
}
