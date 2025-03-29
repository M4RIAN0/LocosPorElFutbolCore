using IServicio.Dtos;

namespace IServicio
{
    public interface ITarjetaService
    {
        void Add(TarjetaDto dto);
        TarjetaGetDto GetById(int? id);
    }
}
