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

namespace LojaEmpresaPequena.Application.Queries.ProdutoMediator
{
    public class GetProduto
    {

        public class GetProdutoContract : IRequest<Result<Produto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<GetProdutoContract, Result<Produto>>
        {
            private readonly IProdutoService _produtoService;
            public Handler(IProdutoService produtoService)
            {
                _produtoService = produtoService;
            }
            public async Task<Result<Produto>> Handle(GetProdutoContract request, CancellationToken cancellationToken)
            {
               var prodFromDb = await  _produtoService.GetById(request.Id);

                if(prodFromDb != null)
                {
                    return await Result<Produto>.Ok(prodFromDb);
                }

                return await Result<Produto>.Fail(ProgramMessages.ProdAttempt); ;
            }
        }
    }
}
