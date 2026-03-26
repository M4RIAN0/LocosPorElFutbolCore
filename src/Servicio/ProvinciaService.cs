using AutoMapper;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class ProvinciaService : ServicioBase, IProvinciaService
    {
        private readonly IProvinciaRepository _repository;
        private readonly IMapper _mapper;

        public ProvinciaService(IProvinciaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ProvinciaGetDto> GetAll()
        {
            return [.. _repository.GetAll("Localidades").Select(x => ToGetDto(x))];
        }

        #region Private Methods

        private ProvinciaGetDto ToGetDto(object? obj)
        {
            return _mapper.Map<ProvinciaGetDto>(obj);
        }

        #endregion
    }
}
