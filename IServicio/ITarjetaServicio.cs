using IServicio.Dtos;

namespace IServicio
{
    public interface ITarjetaServicio
    {
        void Add(TarjetaDto dto);

        TarjetaGetDto GetById(int? id);
    }
}
