using IServicio.Dtos;

namespace IServicio
{
    public interface IMovimientoServicio
    {
        void Add(MovimientoDto dto);

        MovimientoGetDto GetById(int? Id);
    }
}
