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

namespace LojaEmpresaPequena.Application.Queries.EnderecoMediator
{
    public class GetEndereco
    {
        public class GetEnderecoContract : IRequest<Result<Endereco>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<GetEnderecoContract, Result<Endereco>>
        {
            private readonly IEnderecoService _enderecoService;
            public Handler(IEnderecoService enderecoService)
            {
                _enderecoService = enderecoService;
            }
            public async Task<Result<Endereco>> Handle(GetEnderecoContract request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                    return await Result<Endereco>.Fail(ProgramMessages.IdErro);

                var enderecoFromDb = await _enderecoService.GetById(request.Id);

                if (enderecoFromDb == null)
                    return await Result<Endereco>.Fail(ProgramMessages.EnderecoAttempt);

                return await Result<Endereco>.Ok(enderecoFromDb);


            }
        }
    }
}
