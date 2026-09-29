using IServicio.Dtos;
using System.Collections.Generic;

namespace IServicio
{
    public interface IVentaService
    {
        void PersistObjects(TransactionObjectsDto dto);
        IEnumerable<ComprobanteGetDto> GetComprobantesByClienteId(int clienteId);
        ComprobanteGetDto GetComprobantebyId(int id);
        bool SendVentaMail(EmailVentaDto dto);


    }
}
