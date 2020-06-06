using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Services
{
    public class CategoriaService :BaseService<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<Categoria>> GetAllCategoriasList()
        {
            var listaFromdb = await _repository.GetAllCategoriasList();
            return listaFromdb;
        }
    }
}
