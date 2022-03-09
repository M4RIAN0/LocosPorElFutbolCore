using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface ITalle
    {
        [Required]
         string Descripcion { get; set; }

         int Numero { get; set; }

        [Required]
         string Letra { get; set; }

    }
}
