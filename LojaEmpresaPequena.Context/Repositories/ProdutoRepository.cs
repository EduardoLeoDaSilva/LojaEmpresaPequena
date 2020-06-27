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
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(LojaEmpresaPequenaIdentityContext context) :base (context)
        {
            
         }

        public async override Task<Produto> GetById(Guid id)
        {
            return await _dbSet.Where(x => x.Id == id).Include(x => x.ProdutoCategorias).ThenInclude(x => x.Categoria).Include(x => x.Fotos).SingleOrDefaultAsync();
        }

        public  override IQueryable<Produto> GetAll()
        {
            return  _dbSet.Include(x => x.ProdutoCategorias).ThenInclude(x => x.Categoria).Include(x => x.Fotos);
        }
    }
}
