using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Services
{
    public class CategoriaService :BaseService<Categoria>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository _repository) : base(_repository)
        {

        }
    }
}
