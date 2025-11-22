using IServicio.Dtos;

namespace IServicio
{
    public interface IMovimientoService
    {
        void Add(MovimientoDto dto);
        MovimientoGetDto GetById(int id);
    }
}
