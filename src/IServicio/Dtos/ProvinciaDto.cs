using Servicio.Base;
using System.Collections.Generic;

namespace IServicio.Dtos
{
    public class ProvinciaGetDto : DtoBase
    {
        public string Nombre { get; init; }

        public IEnumerable<LocalidadGetDto> Localidades { get; init; }
    }
}
