using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class EnvioService : ServicioBase, IEnvioService
    {

        private readonly IEnvioRepository _envioRepositorio;
        private readonly IMapper _mapper;

        public EnvioService(IEnvioRepository envioRepositorio, IMapper mapper)
        {
            envioRepositorio = _envioRepositorio;
            _mapper = mapper;
        }

        public void Add(EnvioDto dto)
        {
            var modelEnvio = ToEnvioEntity(dto);
            _envioRepositorio.Add(modelEnvio);
            _envioRepositorio.Save();
        }

        public void SoftDelete(int Id)
        {
            _envioRepositorio.SoftDelete(Id);
            _envioRepositorio.Save();
        }


        public IEnumerable<EnvioGetDto> GetAll()
        {
            return [.. _envioRepositorio.GetAll().Select(x => ToEnvioGetDto(x))];
        }

        public IEnumerable<EnvioGetDto> GetByFilter(string persona)
        {
            return [.. _envioRepositorio.GetByFilter(x => x.Persona.Equals(persona)).Select(x => ToEnvioGetDto(x))];
        }

        public EnvioGetDto GetById(int id)
        {
            return _envioRepositorio.GetByFilter(x => x.ID.Equals(id)).Select(x => ToEnvioGetDto(x)).FirstOrDefault();
        }


        #region Private Methods

        private Envio ToEnvioEntity(object? dto)
        {
            return _mapper.Map<Envio>(dto);
        }

        private EnvioGetDto ToEnvioGetDto(object? model)
        {
            return _mapper.Map<EnvioGetDto>(model);
        }
        #endregion


    }
}
