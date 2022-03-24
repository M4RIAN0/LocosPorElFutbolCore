using Servicio.Base;

namespace IServicio.Producto.Dto
{
    public class ProductoDto : DtoBase
    {
        public int Codigo { get; set; }

        public int CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public long RubroId { get; set; }

        public long MarcaId { get; set; }

        public long TalleId { get; set; }

        public long CategoriaId { get; set; }

        public long SubRubroId { get; set; }

        public string CategoriaStr { get; set; }

        public string MarcaStr { get; set; }

        public string SubRubroStr { get; set; }

        public string TalleStr { get; set; }
    }
}
