using Dominio.Repositorio.Dtos;
using IServicio.Email;

namespace IServicio.Dtos
{
    public class TransactionObjectsDto
    {
        public OrdenCompraDto Orden { get; set; }
        public ComprobanteDto Comprobante { get; set; }
        public FacturaDto Factura { get; set; }
        public EnvioDto Envio { get; set; }
        public int CarroId { get; set; }
        public EmailVentaDto Email { get; set; }
    }
}
