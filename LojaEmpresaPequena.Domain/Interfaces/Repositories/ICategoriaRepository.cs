using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IBaseRepository<Categoria> 
    {
        public Task<List<Categoria>> GetAllCategoriasList();
    }
}
