using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.Marca.Dto
{
    public class MarcaDto : DtoBase
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }
    }
}
