namespace Dominio.Entidades
{
    using Dominio.Entidades.MetaData;
    using DominioBase;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Usuarios")]
    [MetadataType(typeof(IUsuario))]
    public partial class Usuario: EntidadBase
    {

        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }



        //propiedades de navegacion
        public long Cliente_Id { get; set; }

        public virtual Persona_Cliente Persona_Cliente { get; set; }

        public long Rol_Id { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
