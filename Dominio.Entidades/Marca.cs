using Dominio.Entidades.MetaData;
using DominioBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Marcas")]
    [MetadataType(typeof(IMarca))]
    public partial class Marca: EntidadBase
    {
        
        public int Codigo { get; set; }

        public string Descripcion { get; set; }


        //propiedades de navegacion
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
