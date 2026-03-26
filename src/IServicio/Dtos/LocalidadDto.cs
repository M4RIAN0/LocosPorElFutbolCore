using Servicio.Base;

namespace IServicio.Dtos
{
    public class LocalidadGetDto : DtoBase
    {
        public string Nombre { get; set; }
        public int CP { get; set; }
        public int ProvinciaId { get; set; }
    }
}