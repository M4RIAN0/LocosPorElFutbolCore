using Servicio.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Repositorio.Dtos

{
    public class ProductoDto
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int MarcaId { get; set; }

        public int CategoriaId { get; set; }

        public string ImagenUrl { get; set; }

        public string Genero { get; set; }

        public List<ProductoVarianteDto> ProductosVariantes { get; set; } = [];
    }

    public class ProductoPutDto : DtoDominioBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int MarcaId { get; set; }

        public int CategoriaId { get; set; }

        public string ImagenUrl { get; set; }

        public string Genero { get; set; }

        public List<ProductoVariantePutDto> ProductosVariantes { get; set; } = [];
    }

    public class ProductoGetDto : DtoDominioBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; init; }

        public int CategoriaId { get; init; }

        public string Categoria { get; init; }

        public int MarcaId { get; init; }

        public string Marca { get; init; }

        public string ImagenUrl { get; init; }

        public string Genero { get; init; }

        public List<ProductoVarianteGetDto> ProductosVariantes { get; init; } = [];
    }

    public class ProductoResumenDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }
    }
}
