using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IListaPrecio
    {
         long Id { get; set; }

         int Codigo { get; set; }

        [Required]
        [StringLength(250)]
         string Descripcion { get; set; }

         bool EstaEliminado { get; set; }

    }
}
