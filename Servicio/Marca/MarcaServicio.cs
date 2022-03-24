using Dominio.Repositorio.Marca;
using IServicio.Marca;
using IServicio.Marca.Dto;
using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Marca
{
    public class MarcaServicio : ServicioBase, IMarcaServicio
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public MarcaServicio(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }
        public void Add(MarcaDto Dto)
        {
            var marca = new Dominio.Entidades.Marca()
            {
                Codigo = Dto.Codigo,
                Descripcion = Dto.Descripcion,
                RowVersion = Dto.RowVersion,
            };

            _marcaRepositorio.Agregar(marca);
            _marcaRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _marcaRepositorio.Eliminar(Id);
            _marcaRepositorio.Save();
        }

        public IEnumerable<MarcaDto> GetAll()
        {
            return _marcaRepositorio.ObtenerTodo("Marca")
                            .Select(x => new MarcaDto()
                            {
                                Id = x.Id,
                                Codigo = x.Codigo,
                                Descripcion = x.Descripcion

                            }).ToList();
        }

        public IEnumerable<MarcaDto> GetByFilter(string cadenaBuscar)
        {
            return _marcaRepositorio.ObtenerPorFlitro(x => x.Descripcion.Contains(cadenaBuscar), "Marca")
                  .Select(x => new MarcaDto()
                  {
                      Id = x.Id,
                      Codigo = x.Codigo,
                      Descripcion = x.Descripcion,
                  }).ToList();
        }

        public MarcaDto GetById(long? Id)
        {
            var marca = _marcaRepositorio.ObtenerPorId(Id, "Marca");

            return new MarcaDto()
            {
                Id = marca.Id,
                Codigo = marca.Codigo,
                Descripcion = marca.Descripcion,

            };
        }

        public void Update(MarcaDto Dto)
        {
            var marca = _marcaRepositorio.ObtenerPorId(Dto.Id, "Marca");

            marca.Codigo = Dto.Codigo;
            marca.Descripcion = Dto.Descripcion;

            _marcaRepositorio.Modificar(marca);
            _marcaRepositorio.Save();
        }
    }
}
