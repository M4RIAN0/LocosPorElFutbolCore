using Dominio.Entidades.MetaData;
using DominioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Movimientos")]
    [MetadataType(typeof(IMovimiento))]
    public partial class Movimiento: EntidadBase
    {
       
        public DateTime Fecha { get; set; }

        public string Tipo { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Monto { get; set; }

        public int Codigo { get; set; }


        //propiedades de navegacion
        public virtual IEnumerable<CuponDescuento> Facturas { get; set; }
    }
}
