namespace Dominio.Entidades
{
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Productos")]
    public partial class Producto : MasterEntityModel
    {
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required]
        public string ImagenUrl { get; set; }

        [Required]
        public string Genero { get; set; }

        // PROPIEDADES DE NAVEGACION
        public int MarcaId { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual ICollection<ProductoVariante> ProductosVariantes { get; set; }
    }
}