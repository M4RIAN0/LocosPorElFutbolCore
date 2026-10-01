using IServicio.Dtos;

namespace IServicio
{
    public interface ICarroComprasService
    {
        void Add(CarroCompraDto dto);
        void Update(CarroCompraPutDto dto);
        void AddItem(int id);
        void SubtractItem(int id);
        void Remove(int id);
        void Removeitem(int id);
        CarroCompraGetDto GetByUserId(string userid);
        bool GetAnyWithProductId(int productId);
    }
}
