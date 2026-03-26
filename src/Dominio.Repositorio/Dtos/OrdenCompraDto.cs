using Servicio.Base;
using System.Collections.Generic;

namespace Dominio.Repositorio.Dtos
{
    public class  OrdenCompraDto
    {
        public string UserId { get; set; }
        public IEnumerable<DetalleOrdenCompraDto> DetalleOrdenCompras { get; set; }
        public decimal Total { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Fecha { get; set; }
        public string Status { get; set; }
    }

    public class OrdenCompraPutDto : DtoDominioBase
    {
        public string UserId { get; set; }
        public IEnumerable<DetalleOrdenCompraPutDto> DetalleOrdenCompras { get; set; }
        public decimal Total { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Fecha { get; set; }
        public string Status { get; set; }
    }

    public class OrdenCompraGetDto : DtoDominioBase
    {
        public string UserId { get; init; }
        public IEnumerable<DetalleOrdenCompraGetDto> DetalleOrdenCompras { get; init; }
        public decimal Total { get; init; }
        public string Nombre { get; init; }
        public string Celular { get; init; }
        public string Email { get; init; }
        public string Fecha { get; init; }
        public string Status { get; init; }
    }
}
