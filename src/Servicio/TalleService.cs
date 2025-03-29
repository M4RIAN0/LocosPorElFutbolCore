using AutoMapper;
using Dominio;
using Dominio.Entidades;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class TalleService : ServicioBase, ITalleService
    {
        private readonly ITalleRepository _repository;
        private readonly IMapper _mapper;

        public TalleService(ITalleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<TalleDto> GetAll()
        {
            return [.. _repository.GetAll().Select(x => ToDto(x))];
        }

        public IEnumerable<TalleDto> GetByFilter(string cadenaBuscar)
        {
            var numero = -1;
            _ = int.TryParse(cadenaBuscar, out numero);

            return [.. _repository.GetByFilter(x => x.Letra.Contains(cadenaBuscar)).Select(x => ToDto(x))];
        }

        public TalleDto GetById(int? id)
        {
            var model = _repository.GetById(id);
            return ToDto(model);
        }

        #region Private Mhetods
        private TalleDto ToDto(Talle model)
        {
            return _mapper.Map<TalleDto>(model);
        }
        #endregion
    }

}
