using Dominio.Repositorio.Dtos;
using Dominio.Repositorio.Gateways;
using System.Threading.Tasks;

namespace IServicio.MercadoPago
{
    public class MercadoPagoService : IMercadoPagoService
    {
        private readonly IMercadoPagoGateway _mercadoPagoGateway;

        public MercadoPagoService(IMercadoPagoGateway mercadoPagoGateway)
        {
            _mercadoPagoGateway = mercadoPagoGateway;
        }
        public async Task<string> CreatePaymentPreference(string externalReferenceId, OrdenCompraGetDto dto)
        {
            return await _mercadoPagoGateway.CretePaymentPreference(externalReferenceId, dto);
        }
    }
}
