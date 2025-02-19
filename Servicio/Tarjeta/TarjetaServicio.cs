using Dominio.Repositorio;
using IServicio.Tarjeta;
using IServicio.Tarjeta.Dto;
using Servicio.Base;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Tarjeta
{
    public class TarjetaServicio : ServicioBase, ITarjetaServicio
    {
        private readonly ITarjetaRepositorio _tarjetaRepositorio;

        public TarjetaServicio(ITarjetaRepositorio tarjetaRepositorio)
        {
            _tarjetaRepositorio = tarjetaRepositorio;
        }

        public void Add(TarjetaDto Dto)
        {
            var tarjeta = new Dominio.Entidades.Tarjeta
            {
                NombreTitular = Dto.NombreTitular,
                Numero = Dto.Numero,
                DniTitular = Dto.DniTitular,
                CodigoSeguridad = Dto.CodigoSeguridad,
                FechaExpiracion = Dto.FechaExpiracion,
                Cuotas = Dto.Cuotas,
                BancoId = Dto.BancoId,
                TipoTarjetaId = Dto.TipoTarjetaId,

            };

            _tarjetaRepositorio.Add(tarjeta);
            _tarjetaRepositorio.Save();
        }

        public void SoftDelete(int Id)
        {
            //_tarjetaRepositorio.SoftDelete(Id);
            _tarjetaRepositorio.Save();

        }

        //public IEnumerable<TarjetaDto> GetAll()
        //{
        //    return _tarjetaRepositorio.ObtenerTodo()
        //         .Select(x => new TarjetaDto
        //         {
        //             Id = x.ID,
        //             NombreTitular = x.NombreTitular,
        //             Numero = x.Numero,
        //             DniTitular = x.DniTitular,
        //             CodigoSeguridad = x.CodigoSeguridad,
        //             FechaExpiracion = x.FechaExpiracion,
        //             Cuotas = x.Cuotas,
        //             BancoId = x.Banco_Id,
        //             TipoTarjetaId = x.TipoTarjeta_Id

        //         }).ToList();
        //}

        public IEnumerable<TarjetaDto> GetByFilter(string cadenaBuscar)
        {

            var numero = -1;
            int.TryParse(cadenaBuscar, out numero);

            return _tarjetaRepositorio.GetByFilter(x => x.NombreTitular.Contains(cadenaBuscar) || x.Numero == numero)
                .Select(x => new TarjetaDto
                {
                    Id = x.ID,
                    NombreTitular = x.NombreTitular,
                    Numero = x.Numero,
                    DniTitular = x.DniTitular,
                    CodigoSeguridad = x.CodigoSeguridad,
                    FechaExpiracion = x.FechaExpiracion,
                    Cuotas = x.Cuotas,
                    BancoId = x.BancoId,
                    TipoTarjetaId = x.TipoTarjetaId

                }).ToList();
        }

        public TarjetaDto GetById(int? Id)
        {
            var tarjeta = _tarjetaRepositorio.GetById(Id);

            return new TarjetaDto
            {
                Id = tarjeta.ID,
                NombreTitular = tarjeta.NombreTitular,
                Numero = tarjeta.Numero,
                DniTitular = tarjeta.DniTitular,
                CodigoSeguridad = tarjeta.CodigoSeguridad,
                FechaExpiracion = tarjeta.FechaExpiracion,
                Cuotas = tarjeta.Cuotas,
                BancoId = tarjeta.BancoId,
                TipoTarjetaId = tarjeta.TipoTarjetaId
            };
        }

        public void Update(TarjetaDto Dto)
        {
            var tarjeta = _tarjetaRepositorio.GetById(Dto.Id);

            tarjeta.NombreTitular = tarjeta.NombreTitular;
            tarjeta.Numero = tarjeta.Numero;
            tarjeta.DniTitular = tarjeta.DniTitular;
            tarjeta.CodigoSeguridad = tarjeta.CodigoSeguridad;
            tarjeta.FechaExpiracion = tarjeta.FechaExpiracion;
            tarjeta.BancoId = tarjeta.BancoId;
            tarjeta.TipoTarjetaId = tarjeta.TipoTarjetaId;

            _tarjetaRepositorio.Edit(tarjeta);
            _tarjetaRepositorio.Save();

        }
    }
}
