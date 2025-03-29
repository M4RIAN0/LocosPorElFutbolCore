using Servicio.Base;

namespace IServicio.Dtos
{
    public class MarcaDto
    {
        public string Descripcion { get; set; }
    }

    public class MarcaPutDto : DtoBase
    {
        public string Descripcion { get; set; }
    }

    public class MarcaGetDto : DtoBase
    {
        public string Descripcion { get; init; }
    }
}
