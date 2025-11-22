using Dominio.Repositorio.Dtos;
using System.Threading.Tasks;

namespace Dominio.Repositorio.Gateways
{
    public interface IMercadoPagoGateway
    {
        Task<string> CretePaymentPreference(string  externalReferenceId, OrdenCompraGetDto dto);
    }
}
