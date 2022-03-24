using Servicio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IServicio.ListaPrecioProducto.Dto
{
    public class ListaPrecioProductoDto : DtoBase
    {
        public decimal PrecioCosto { get; set; }

        public decimal PrecioPublico { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaActualizacion { get; set; }

        public long ListaPrecioId { get; set; }

        public long ProductoId { get; set; }

        public string ListaPrecioStr { get; set; }

        public string ProductoStr { get; set; }

    }
}
