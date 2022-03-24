using Dominio.Repositorio.Envio;
using IServicio.Envio;
using IServicio.Envio.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Envio
{
    public class EnvioServicio : ServicioBase, IEventoServicio
    {
        private readonly IEnvioRepositorio _envioRepositorio;

        public EnvioServicio(IEnvioRepositorio envioRepositorio)
        {
            _envioRepositorio = envioRepositorio;
        }

        public void Add(EnvioDto Dto)
        {
            var envio = new Dominio.Entidades.Envio()
            {
                Tipo = Dto.Tipo,
                Monto = Dto.Monto,
                LocalidadId = Dto.LocalidadId,
                RowVersion = Dto.RowVersion
            };

            _envioRepositorio.Agregar(envio);
            _envioRepositorio.Save();
        }


        public void Update(EnvioDto Dto)
        {
            var envio = _envioRepositorio.ObtenerPorId(Dto.Id, "Envio");

            envio.Tipo = Dto.Tipo;
            envio.Monto = Dto.Monto;
            envio.LocalidadId = Dto.LocalidadId;

            _envioRepositorio.Modificar(envio);
            _envioRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _envioRepositorio.Eliminar(Id);
            _envioRepositorio.Save();
        }


        public IEnumerable<EnvioDto> GetAll()
        {
            return _envioRepositorio.ObtenerTodo("Envios").Select(x => new EnvioDto()
            {
                Id = x.Id,
                Tipo = x.Tipo,
                Monto = x.Monto,
                LocalidadId = x.LocalidadId,
                //LocalidadeStr = x.Localidades.Nombre, //ver entidad Localidad
            }).ToList();
        }

        public IEnumerable<EnvioDto> GetByFilter(string cadenaBuscar)
        {
            throw new System.NotImplementedException();//ver si se va a usar mas adelante
        }

        public EnvioDto GetById(long? Id)
        {
            var envio = _envioRepositorio.ObtenerPorId(Id, "Envio");

            return new EnvioDto()
            {
                Id = envio.Id,
                Tipo = envio.Tipo,
                Monto = envio.Monto,
                LocalidadId = envio.LocalidadId,
                //LocalidadeStr = envio.Localidade.Nombre,
            };
        }


    }
}
