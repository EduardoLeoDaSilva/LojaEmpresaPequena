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
    public class DeleteEndereco
    {
        public class DeleteEnderecoContract : IRequest<Result<string>>
        {
            public Guid Id { get; set; }
        }


        public class Handler : IRequestHandler<DeleteEnderecoContract, Result<string>>
        {
            private readonly IEnderecoService _enderecoService;
            public Handler(IEnderecoService enderecoService)
            {
                _enderecoService = enderecoService;
            }

            public async Task<Result<string>> Handle(DeleteEnderecoContract request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                    return  Result<string>.FailToMiddleware(ProgramMessages.IdErro);

                await _enderecoService.Delete(request.Id);

                return await Result<string>.Ok(ProgramMessages.Sucesso);
            }
        }

    }
}
