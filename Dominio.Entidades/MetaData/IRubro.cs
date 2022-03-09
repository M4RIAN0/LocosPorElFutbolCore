using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.MetaData
{
    public interface IRubro
    {
         int Codigo { get; set; }

        [Required]
         string Descripcion { get; set; }
    }
}
