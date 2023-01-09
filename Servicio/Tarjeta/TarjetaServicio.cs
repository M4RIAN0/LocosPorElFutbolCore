using Dominio.Repositorio.Tarjeta;
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
                Banco_Id = Dto.BancoId,
                TipoTarjeta_Id = Dto.TipoTarjetaId,

            };

            _tarjetaRepositorio.Agregar(tarjeta);
            _tarjetaRepositorio.Save();
        }

        public void Delete(long Id)
        {
            _tarjetaRepositorio.Eliminar(Id);
            _tarjetaRepositorio.Save();

        }

        //public IEnumerable<TarjetaDto> GetAll()
        //{
        //    return _tarjetaRepositorio.ObtenerTodo()
        //         .Select(x => new TarjetaDto
        //         {
        //             Id = x.Id,
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

            return _tarjetaRepositorio.ObtenerPorFlitro(x => x.NombreTitular.Contains(cadenaBuscar) || x.Numero == numero)
                .Select(x => new TarjetaDto
                {
                    Id = x.Id,
                    NombreTitular = x.NombreTitular,
                    Numero = x.Numero,
                    DniTitular = x.DniTitular,
                    CodigoSeguridad = x.CodigoSeguridad,
                    FechaExpiracion = x.FechaExpiracion,
                    Cuotas = x.Cuotas,
                    BancoId = x.Banco_Id,
                    TipoTarjetaId = x.TipoTarjeta_Id

                }).ToList();
        }

        public TarjetaDto GetById(long? Id)
        {
            var tarjeta = _tarjetaRepositorio.ObtenerPorId(Id);

            return new TarjetaDto
            {
                Id = tarjeta.Id,
                NombreTitular = tarjeta.NombreTitular,
                Numero = tarjeta.Numero,
                DniTitular = tarjeta.DniTitular,
                CodigoSeguridad = tarjeta.CodigoSeguridad,
                FechaExpiracion = tarjeta.FechaExpiracion,
                Cuotas = tarjeta.Cuotas,
                BancoId = tarjeta.Banco_Id,
                TipoTarjetaId = tarjeta.TipoTarjeta_Id
            };
        }

        public void Update(TarjetaDto Dto)
        {
            var tarjeta = _tarjetaRepositorio.ObtenerPorId(Dto.Id);

            tarjeta.NombreTitular = tarjeta.NombreTitular;
            tarjeta.Numero = tarjeta.Numero;
            tarjeta.DniTitular = tarjeta.DniTitular;
            tarjeta.CodigoSeguridad = tarjeta.CodigoSeguridad;
            tarjeta.FechaExpiracion = tarjeta.FechaExpiracion;
            tarjeta.Banco_Id = tarjeta.Banco_Id;
            tarjeta.TipoTarjeta_Id = tarjeta.TipoTarjeta_Id;

            _tarjetaRepositorio.Modificar(tarjeta);
            _tarjetaRepositorio.Save();

        }
    }
}
