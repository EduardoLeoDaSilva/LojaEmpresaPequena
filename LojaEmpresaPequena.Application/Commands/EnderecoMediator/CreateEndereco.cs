using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Commands.EnderecoMediator
{
    public class CreateEndereco 
    {
        public class CreadeEnderecoContract : IRequest<Result<string>> 
        {
            public string Rua { get; set; }
            public string Numero { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
            public string Cep { get; set; }
            public string Complemento { get; set; }
            public Usuario Usuario { get; set; }
        }

        public class Handler : IRequestHandler<CreadeEnderecoContract, Result<string>>
        {
            private IEnderecoService _enderecoService;
            public Handler(IEnderecoService enderecoService)
            {
                _enderecoService = enderecoService;
            }
            public async Task<Result<string>> Handle(CreadeEnderecoContract request, CancellationToken cancellationToken)
            {
                var endereco = new Endereco(request.Rua, request.Numero,request.Bairro,request.Cidade, request.Estado, request.Cep, request.Complemento,request.Usuario);

                return await Result<string>.Ok(ProgramMessages.Sucesso);

            }
        }
    }
}
