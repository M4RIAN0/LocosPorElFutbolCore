using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio.Persona;
using IServicio.Persona.Dto;
using IServicio.Producto.Dto;
using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class PersonaServicio : ServicioBase, IPersonaServicio
    {
        private readonly IPersonaRepositorio _repository;
        private readonly IMapper _mapper;

        public PersonaServicio(IPersonaRepositorio repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(PersonaDto dto)
        {
            var model = ToEntity(dto);
            _repository.Add(model);
            _repository.Save();
        }

        public void SoftDelete(int id)
        {
            _repository.SoftDelete(id);
            _repository.Save();
        }

        public IEnumerable<PersonaDto> GetAll()
        {
            return _repository.GetAll()
                .Select(x => ToDto(x)).ToList();
        }

        public IEnumerable<PersonaDto> GetByFilter(string cadenaBuscar)
        {
            return _repository.GetByFilter(x => x.Apellido.Contains(cadenaBuscar))
            .Select(x => ToDto(x)).ToList();
        }

        public PersonaDto GetById(int? id)
        {
            var model = _repository.GetById(id);
            return ToDto(model);
        }

        public void Update(PersonaDto dto)
        {
            var model = ToEntity(dto);
            _repository.Edit(model);
            _repository.Save();
        }

        #region Private Methods
        private PersonaDto ToDto(Persona model)
        {
            return _mapper.Map<PersonaDto>(model);
        }

        private Persona ToEntity(PersonaDto dto)
        {
            return _mapper.Map<Persona>(dto);
        }
        #endregion
    }
}
