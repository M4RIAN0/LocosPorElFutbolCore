using Dominio.Repositorio.Dtos;

namespace IServicio.Dtos
{
    public class TransactionObjectsDto
    {
        public OrdenCompraDto Orden { get; set; }
        public ComprobanteDto Comprobante { get; set; }
        public int CarroId { get; set; } 
    }
}
