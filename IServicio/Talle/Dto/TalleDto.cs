using Servicio.Base;

namespace IServicio.Talle.Dto
{
    public class TalleDto : DtoBase
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public int Numero { get; set; }

        public string Letra { get; set; }
    }
}
