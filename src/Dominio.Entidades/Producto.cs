namespace Dominio.Entidades
{
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Productos")]
    public partial class Producto : MasterEntityModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(150, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(100000, 999999, ErrorMessage = "El campo {0} debe tener 6 dígitos.")]
        public int CodigoBarra { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Stock { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        public string ImagenUrl { get; set; }


        //PROPIEDADES DE NAVEGACION

        public int MarcaId { get; set; }

        public int TalleId { get; set; }

        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual Talle Talle { get; set; }

        public virtual IEnumerable<DetalleComprobante> DetalleComprobantes { get; set; }
    }
}
