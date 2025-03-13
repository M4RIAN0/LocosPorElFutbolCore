using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.Dtos
{
    public class LocalidadDto : DtoBase
    {
        public int ProvinciaId { get; set; }

        public string ProvinciaStr { get; set; }
    }
}