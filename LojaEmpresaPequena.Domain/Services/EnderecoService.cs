using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Services
{
    public class EnderecoService : BaseService<Endereco>, IEnderecoService
    {
        public EnderecoService(IEnderecoRepository _repository) : base(_repository)
        {

        }
    }
}
