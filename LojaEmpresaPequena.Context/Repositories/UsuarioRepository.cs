using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Context.Repositories
{
    public class UsuarioRepository :  IUsuarioRepository
    {

        public UsuarioRepository(LojaEmpresaPequenaIdentityContext context)
        {

        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Save(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public Task Update(Usuario entidade)
        {
            throw new NotImplementedException();
        }
    }
}
