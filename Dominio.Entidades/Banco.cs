using System;
using System.Collections.Generic;
using System.Text;
using DominioBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Entidades.MetaData;

namespace Dominio.Entidades
{
    [Table("Bancos")]
    [MetadataType(typeof(IBanco))]
    public class Banco : EntidadBase
    {
        public string Nombre { get; set; }

        //propiedad de navegacion
        public virtual ICollection<Tarjeta> Tarjetas { get; set; }
    }
}
