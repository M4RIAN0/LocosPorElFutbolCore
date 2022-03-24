using Dominio.Repositorio.Banco;
using IServicio.Banco;
using IServicio.Banco.Dto;
using Servicio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Banco
{
    public class BancoServicio : ServicioBase, IBancoServicio
    {
        private readonly IBancoRepositorio _bancoRepositorio;

        public void Add(BancoDto Dto)
        {
            throw new NotImplementedException();
        }

        //dsa
        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BancoDto> GetAll(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BancoDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BancoDto> GetByFilter(string cadenaBuscar)
        {
            throw new NotImplementedException();
        }

        public BancoDto GetById(long? Id)
        {
            throw new NotImplementedException();
        }

        public void Update(BancoDto Dto)
        {
            throw new NotImplementedException();
        }
    }
}
