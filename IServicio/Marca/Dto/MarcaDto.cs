using Servicio.Base;

namespace IServicio.Marca.Dto
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
