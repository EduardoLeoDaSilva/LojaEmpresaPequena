using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Commands.ProdutoMediator
{
    public class DeleteProduto
    {

        public class DeleteProdutoContract : IRequest<Result<string>> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<DeleteProdutoContract, Result<string>>
        {
            private readonly IProdutoService _produtoService;
            public Handler(IProdutoService produtoService)
            {
                _produtoService = produtoService;
            }
            public async Task<Result<string>> Handle(DeleteProdutoContract request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                    return await Result<string>.Fail(ProgramMessages.IdErro);

               await _produtoService.Delete(request.Id);

                return await Result<string>.Ok(ProgramMessages.Sucesso);
            }
        }

    }
}
