using Servicio.Base;

namespace IServicio.Talle.Dto
{
    public class TalleDto : DtoBase
    {
        public int Codigo { get; init; }

        public int Numero { get; init; }

        public string Letra { get; init; }
    }
}
