using IServicio.Dtos;
using System.Threading.Tasks;

namespace IServicio
{
    public interface IVentaService
    {
        void PersistObjects(TransactionObjectsDto dto);
    }
}
