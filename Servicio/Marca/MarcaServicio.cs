using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio.Marca;
using IServicio.Marca.Dto;
using Lxf.Support.BuildingBlocks;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio
{
    public class MarcaServicio : ServicioBase, IMarcaServicio
    {
        private readonly IMarcaRepository _repository;
        private readonly IMapper _mapper;

        public MarcaServicio(IMarcaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Add(MarcaDto dto)
        {
            var model = ToEntityPost(dto);
            _repository.Add(model);
            _repository.Save();
        }

        public void SoftDelete(int id)
        {
            _repository.SoftDelete(id);
            _repository.Save();
        }

        public IEnumerable<MarcaGetDto> GetAll()
        {
            return _repository.GetAll().Select(x => ToGetDto(x)).ToList();
        }

        public IEnumerable<MarcaGetDto> GetByFilter(string cadenaBuscar)
        {
            return _repository.GetByFilter(x => x.Descripcion.Contains(cadenaBuscar))
                  .Select(x => ToGetDto(x)).ToList();
        }

        public MarcaGetDto GetById(int? id)
        {
            var model = _repository.GetById(id);
            return ToGetDto(model);
        }

        public void Update(MarcaPutDto dto)
        {
            var model = ToEntityPut(dto);
            _repository.Edit(model);
            _repository.Save();
        }

        #region Private Methods
        private MarcaGetDto ToGetDto(Marca model)
        {
            return _mapper.Map<MarcaGetDto>(model);
        }

        private Marca ToEntityPost(MarcaDto dto)
        {
            return _mapper.Map<Marca>(dto);
        }

        private Marca ToEntityPut(MarcaPutDto dto)
        {
            return _mapper.Map<Marca>(dto);
        }
        #endregion
    }
}