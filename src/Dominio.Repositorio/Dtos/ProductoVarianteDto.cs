using Servicio.Base;

namespace Dominio.Repositorio.Dtos
{
    public class ProductoVarianteDto
    {
        public string Talle { get; set; }
        public int Stock { get; set; }
        public int CodigoBarra { get; set; }
        public int ProductoId { get; set; }
    }

    public class ProductoVariantePutDto : ProductoVarianteDto
    {
        public int Id { get; set; }
    }

    public class ProductoVarianteGetDto : DtoDominioBase
    {
        public string Talle { get; init; }
        public int Stock { get; init; }
        public int CodigoBarra { get; init; }
        public int ProductoId { get; init; }
        public ProductoResumenDto Producto { get; init; }
    }
}