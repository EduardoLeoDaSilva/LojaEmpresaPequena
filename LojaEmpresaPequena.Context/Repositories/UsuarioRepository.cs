using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Context.Repositories
{
    public class UsuarioRepository :  IUsuarioRepository
    {
        private LojaEmpresaPequenaIdentityContext _context;
        public UsuarioRepository(LojaEmpresaPequenaIdentityContext context)
        {
            _context = context;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public  IQueryable<Usuario> GetAll()
        {
            return _context.Set<Usuario>().Include(x => x.Enderecos);
        }

        public async Task<Usuario> GetById(Guid id)
        {
            return await _context.Set<Usuario>().Where(x => x.Id == id.ToString()).Include(x => x.Enderecos).SingleOrDefaultAsync();
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
