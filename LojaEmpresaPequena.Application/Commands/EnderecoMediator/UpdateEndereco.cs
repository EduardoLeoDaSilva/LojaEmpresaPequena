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
    public class UpdateEndereco
    {
        public class UpdateEnderecoContract : IRequest<Result<string>>
        {
            public Guid Id { get; set; }
            public string Rua { get; set; }
            public string Numero { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
            public string Cep { get; set; }
            public string Complemento { get; set; }
            public Usuario Usuario { get; set; }
        }

        public class Handler : IRequestHandler<UpdateEnderecoContract, Result<string>>
        {
            private readonly IEnderecoService _enderecoSevice;
            public Handler(IEnderecoService enderecoSevice)
            {
                _enderecoSevice = enderecoSevice;
            }
            public async Task<Result<string>> Handle(UpdateEnderecoContract request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                    return  Result<string>.FailToMiddleware(ProgramMessages.IdErro);

                var enderecoFromDb =await _enderecoSevice.GetById(request.Id);

                if(enderecoFromDb == null)
                    return  Result<string>.FailToMiddleware(ProgramMessages.EnderecoAttempt);

                enderecoFromDb.UpdateInstance(new Endereco(request.Rua, request.Numero, request.Bairro, request.Cidade, request.Estado, request.Cep, request.Complemento, request.Usuario));

                await _enderecoSevice.Update(enderecoFromDb);

                return await Result<string>.Ok(ProgramMessages.Sucesso);

            }
        }
    }
}
