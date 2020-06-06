using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Services
{
    public interface ICategoriaService : IBaseService<Categoria>
    {
        Task<List<Categoria>> GetAllCategoriasList();
    }
}
