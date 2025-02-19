using Dominio.Repositorio;
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
                
            };

            _envioRepositorio.Add(envio);
            _envioRepositorio.Save();
        }


        public void Update(EnvioDto Dto)
        {
            var envio = _envioRepositorio.GetById(Dto.Id, "Envio");

            envio.Tipo = Dto.Tipo;
            envio.Monto = Dto.Monto;
            envio.LocalidadId = Dto.LocalidadId;

            _envioRepositorio.Edit(envio);
            _envioRepositorio.Save();
        }

        public void SoftDelete(int Id)
        {
            _envioRepositorio.SoftDelete(Id);
            _envioRepositorio.Save();
        }


        public IEnumerable<EnvioDto> GetAll()
        {
            return _envioRepositorio.GetAll("Envios").Select(x => new EnvioDto()
            {
                Id = x.ID,
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

        public EnvioDto GetById(int? Id)
        {
            var envio = _envioRepositorio.GetById(Id, "Envio");

            return new EnvioDto()
            {
                Id = envio.ID,
                Tipo = envio.Tipo,
                Monto = envio.Monto,
                LocalidadId = envio.LocalidadId,
                //LocalidadeStr = envio.Localidade.Nombre,
            };
        }


    }
}
