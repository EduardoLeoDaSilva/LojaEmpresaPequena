using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using MediatR;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Queries.ProdutoMediator
{
    public class GetAllProdutos
    {
        public class GetAllProdutosContract : IRequest<Result<ProdutosResponse>>
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public string SortOrder { get; set; }
            public string SortField { get; set; }
            public string NomeFilter { get; set; }
            public double PrecoFilter { get; set; }
        }

        public class ProdutosResponse 
        {
            public IList<Produto> Produtos { get; set; }
            public int ItemsCount { get; set; }
        }


        public class Handler : IRequestHandler<GetAllProdutosContract, Result<ProdutosResponse>>
        {
            private readonly IProdutoService _produtoService;

            public Handler(IProdutoService produtoService)
            {
                _produtoService = produtoService;
            }

            public async Task<Result<ProdutosResponse>> Handle(GetAllProdutosContract request, CancellationToken cancellationToken)
            {
                var listProdFromDb = _produtoService.GetAll();

                if(!String.IsNullOrEmpty(request.NomeFilter) || !String.IsNullOrWhiteSpace(request.NomeFilter))
                {
                    listProdFromDb = listProdFromDb.Where(x => x.Nome.Contains(request.NomeFilter));
                }

                listProdFromDb= listProdFromDb.Where(x => x.DeletedAt == null);
                ///Fazer o preço filter dpois **********
                ///

                var pagedList = listProdFromDb.ToPagedList(request.Page, request.PageSize);

                return await Result<ProdutosResponse>.Ok(
                     new ProdutosResponse()
                     {
                         Produtos = pagedList.ToList(),
                         ItemsCount = pagedList.TotalItemCount
                     }
                    );

               

            }
        }

    }
}
