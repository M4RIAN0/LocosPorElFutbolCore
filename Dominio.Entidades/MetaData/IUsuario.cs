using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IUsuario
    {
         string NombreUsuario { get; set; }

        [Required]
         string Password { get; set; }

         bool EstaBloqueado { get; set; }
    }
}
