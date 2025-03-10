using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;

namespace Servicio
{
    public class MovimientoServicio : ServicioBase, IMovimientoServicio
    {
        private readonly IMovimientoRepository _movimientoRepositorio;
        private readonly IMapper _mapper;

        public MovimientoServicio(IMovimientoRepository movimientoRepositorio, IMapper mapper)
        {
            _movimientoRepositorio = movimientoRepositorio;
            _mapper = mapper;
        }

        public void Add(MovimientoDto dto)
        {
            var model = ToEntity(dto);

            _movimientoRepositorio.Add(model);
            _movimientoRepositorio.Save();
        }

        public MovimientoGetDto GetById(int? Id)
        {
            var model = _movimientoRepositorio.GetById(Id);

            return ToGetDto(model);
        }

        #region private methods
        private MovimientoGetDto ToGetDto(Movimiento model)
        {
            return _mapper.Map<MovimientoGetDto>(model);
        }

        private Movimiento ToEntity(MovimientoDto dto)
        {
            return _mapper.Map<Movimiento>(dto);
        }
        #endregion
    }
}
