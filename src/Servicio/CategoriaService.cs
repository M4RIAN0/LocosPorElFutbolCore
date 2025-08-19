using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorio;
using IServicio;
using IServicio.Dtos;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio;

public class CategoriaService : ServicioBase, ICategoriaService
{
    private readonly ICategoriaRepository _repository;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public void Add(CategoriaDto dto)
    {
        var model = ToEntityPost(dto);
        _repository.Add(model);
        _repository.Save();
    }

    public void Update(CategoriaPutDto dto)
    {
        var model = ToEntityPut(dto);
        _repository.Attach(model);
        _repository.Save();

    }

    public void SoftDelete(int id)
    {
        _repository.SoftDelete(id);
        _repository.Save();
    }

    public IEnumerable<CategoriaGetDto> GetAll()
    {
        return [.. _repository.GetAll().Select(x => ToGetDto(x))];
    }

    public IEnumerable<CategoriaGetDto> GetByFilter(string cadenaBuscar)
    {
        return [.. _repository.GetByFilter(x => x.Descripcion.Contains(cadenaBuscar)).Select(x => ToGetDto(x))];
    }

    public CategoriaGetDto GetById(int? id)
    {
        var model = _repository.GetById(id);
        return ToGetDto(model);
    }

    #region Private Mhetods
    private CategoriaGetDto ToGetDto(Categoria model)
    {
        return _mapper.Map<CategoriaGetDto>(model);
    }

    private Categoria ToEntityPost(CategoriaDto dto)
    {
        return _mapper.Map<Categoria>(dto);
    }

    private Categoria ToEntityPut(CategoriaPutDto dto)
    {
        return _mapper.Map<Categoria>(dto);
    }
    #endregion
}
