using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.Localidad.Dto
{
    public class LocalidadDto : DtoBase
    {
        public long ProvinciaId { get; set; }

        public string ProvinciaStr { get; set; }
    }
}