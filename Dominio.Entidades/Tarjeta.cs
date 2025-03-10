namespace Dominio.Entidades
{
    using DominioBase;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Tarjetas")]
    public partial class Tarjeta : MasterEntityModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string NombreTitular { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(16, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Numero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(8, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string DniTitular { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(3, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string CodigoSeguridad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:MM/yy}")]
        public DateOnly FechaExpiracion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Cuotas { get; set; }



        //propiedades de navegacion
        public int BancoId { get; set; }

        public int TipoTarjetaId { get; set; }

        public virtual Banco Banco { get; set; }

        public virtual TipoTarjeta TipoTarjeta { get; set; }
    }
}
