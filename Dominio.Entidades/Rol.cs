namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Roles")]
    [MetadataType(typeof(IRol))]
    public partial class Rol: EntidadBase
    {

        public string Descripcion { get; set; }

        
        //propiedades de navegacion
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
