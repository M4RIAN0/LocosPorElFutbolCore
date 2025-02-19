using Servicio.Base;

namespace IServicio.Producto.Dto
{
    public class ProductoDto
    {
        public int Codigo { get; set; }

        public int CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public int MarcaId { get; set; }

        public int TalleId { get; set; }

        public int CategoriaId { get; set; }
    }

    public class ProductoPutDto: ProductoDto 
    { 
        public int Id { get; set; }
    }

    public class ProductoGetDto : DtoBase
    {
        public int Codigo { get; init; }

        public int CodigoBarra { get; init; }

        public string Descripcion { get; init; }

        public int Stock { get; init; }

        public string Categoria { get; init; }

        public string Marca { get; set; }

        public string Talle { get; set; }
    }
}
