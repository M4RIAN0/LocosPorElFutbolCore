using Servicio.Base;

namespace IServicio.SubRubro.Dto
{
    public class SubRubroDto : DtoBase
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public long RubroId { get; set; }

        public string RubroStr { get; set; }
    }
}
