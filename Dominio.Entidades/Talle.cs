namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Talles")]
    [MetadataType(typeof(ITalle))]
    public partial class Talle: EntidadBase
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public int Numero { get; set; }

        public string Letra { get; set; }


        //propiedades de navegacion
      
        public virtual IEnumerable<Producto> Productos { get; set; }
    }
}
