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
    public class PersonaClienteService : ServicioBase, IPersonaClienteService
    {

        private readonly IPersonaClienteRepository _repository;
        private readonly IMapper _mapper;

        public PersonaClienteService(IPersonaClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(PersonaClienteDto dto)
        {
            var model = ToEntityPost(dto);
            _repository.Add(model);
            _repository.Save();
        }

        public void Update(PersonaClientePutDto dto)
        {
            var model = ToEntityPut(dto);
            _repository.Attach(model);
            _repository.Save();
        }

        public void SoftDelete(int Id)
        {
            _repository.SoftDelete(Id);
            _repository.Save();
        }

        public IEnumerable<PersonaClienteGetDto> GetAll()
        {
            return [.. _repository.GetAll().Select(x => ToGetDto(x))];

        }

        public IEnumerable<PersonaClienteGetDto> GetByFilter(string cadenaBuscar)
        {
            var codigo = -1;
            _ = int.TryParse(cadenaBuscar, out codigo);

            return [.. _repository.GetByFilter(x => x.Apellido.Contains(cadenaBuscar) || x.Dni == codigo.ToString()).Select(x => ToGetDto(x))];
        }

        public PersonaClienteGetDto GetById(int? id)
        {
            var model = _repository.GetById(id);
            return ToGetDto(model);
        }

        #region Private Mhetods
        private PersonaClienteGetDto ToGetDto(PersonaCliente model)
        {
            return _mapper.Map<PersonaClienteGetDto>(model);
        }

        private PersonaCliente ToEntityPost(PersonaClienteDto dto)
        {
            return _mapper.Map<PersonaCliente>(dto);
        }

        private PersonaCliente ToEntityPut(PersonaClientePutDto dto)
        {
            return _mapper.Map<PersonaCliente>(dto);
        }
        #endregion
    }
}
