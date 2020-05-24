using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        
        public CategoriaRepository(LojaEmpresaPequenaIdentity _context) :base(_context)
        {

        }
    }
}
