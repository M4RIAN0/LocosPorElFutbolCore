using DominioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("OrdenCompras")]

    public partial class OrdenCompra : MasterEntityModel
    {
        public string? UserId { get; set; }
        public decimal Total { get; set; }
        public string? Nombre { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public DateOnly Fecha { get; set; }
        public string Status { get; set; }

        //propiedades de navegacion
        public virtual IEnumerable<DetalleOrdenCompra> DetalleOrdenCompras { get; set; }
    }
}
