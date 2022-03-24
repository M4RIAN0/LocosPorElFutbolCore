using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServicio.ListaPrecio.Dto
{
    public class ListaPrecioDto : DtoBase
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool EstaEliminado { get; set; }


    }
}
