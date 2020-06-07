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
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        
        public CategoriaRepository(LojaEmpresaPequenaIdentityContext _context) :base(_context)
        {

        }

        public async Task<List<Categoria>> GetAllCategoriasList()
        {
            var listaFromdb = await _dbSet.ToListAsync();
            return listaFromdb;
        }
    }
}
