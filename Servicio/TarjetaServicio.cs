using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;

namespace Servicio
{
    public class TarjetaServicio : ServicioBase, ITarjetaServicio
    {
        private readonly ITarjetaRepository _repository;
        private readonly IMapper _mapper;

        public TarjetaServicio(ITarjetaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(TarjetaDto dto)
        {
            var model = ToEntity(dto);

            _repository.Add(model);
            _repository.Save();
        }

        public TarjetaGetDto GetById(int? Id)
        {
            var model = _repository.GetById(Id, "Banco,TipoTarjeta");

            return ToGetDto(model);
        }

        #region Private Mhetods
        private TarjetaGetDto ToGetDto(Tarjeta model)
        {
            return _mapper.Map<TarjetaGetDto>(model);
        }

        private Tarjeta ToEntity(TarjetaDto dto)
        {
            return _mapper.Map<Tarjeta>(dto);
        }
        #endregion
    }
}
