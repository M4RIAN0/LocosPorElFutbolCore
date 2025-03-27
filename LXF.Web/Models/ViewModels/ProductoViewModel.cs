using System.ComponentModel.DataAnnotations.Schema;

namespace LXF.Web.Models.ViewModels
{
    public class ProductoViewModel
    {
        public required int CodigoBarra { get; set; }
        public required string Descripcion { get; set; }
        public required decimal Precio { get; set; }
        public required int Stock { get; set; }
        public required int MarcaId { get; set; }
        public required int TalleId { get; set; }
        public required int CategoriaId { get; set; }
    }

    public class ProductoPutViewModel : ProductoViewModel
    {
        public int Id { get; set; }
    }

    public class ProductoGetViewModel : ViewModelBase
    {

        public int CodigoBarra { get; init; }

        public string Descripcion { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; init; }

        public int Stock { get; init; }

        public int MarcaId { get; init; }

        public string Marca { get; init; }

        public int TalleId { get; init; }

        public string Talle { get; init; }

        public int CategoriaId { get; init; }

        public string Categoria { get; init; }

    }
       
}
