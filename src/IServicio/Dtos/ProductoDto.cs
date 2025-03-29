using Servicio.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace IServicio.Dtos
{
    public class ProductoDto
    {
        public string Nombre { get; set; }

        public int CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int MarcaId { get; set; }

        public int TalleId { get; set; }

        public int CategoriaId { get; set; }

        public string ImagenUrl { get; set; }
    }

    public class ProductoPutDto : ProductoDto
    {
        public int Id { get; set; }
    }

    public class ProductoGetDto : DtoBase
    {
        public string Nombre { get; set; }

        public int CodigoBarra { get; init; }

        public string Descripcion { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; init; }

        public int Stock { get; init; }

        public int CategoriaId { get; init; }

        public string Categoria { get; init; }

        public int MarcaId { get; init; }

        public string Marca { get; init; }

        public int TalleId { get; init; }

        public string Talle { get; init; }

        public string ImagenUrl { get; set; }
    }
}
