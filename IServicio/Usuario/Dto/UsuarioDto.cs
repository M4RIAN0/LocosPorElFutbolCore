using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicio.Usuario.Dto
{
    public class UsuarioDto : DtoBase
    {
        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }

        public long Cliente_Id { get; set; }

        public string Personas_ClienteStr { get; set; }
    }
}
