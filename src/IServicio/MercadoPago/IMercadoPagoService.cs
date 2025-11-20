using Dominio.Repositorio.Dtos;
using System.Threading.Tasks;

namespace IServicio.MercadoPago
{
    public interface IMercadoPagoService
    {
        Task<string> CreatePaymentPreference(string externalReferenceId, OrdenCompraGetDto dto);
    }
}
