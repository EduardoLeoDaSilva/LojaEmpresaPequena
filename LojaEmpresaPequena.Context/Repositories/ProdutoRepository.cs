using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(LojaEmpresaPequenaIdentity context) :base (context)
        {

        }
    }
}
