using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Queries.ProdutoMediator
{
    public class GetProduto
    {

        public class GetProdutoContract : IRequest<Result<ProdutoResponse>>
        {
            public Guid Id { get; set; }
        }


        public class ProdutoResponse
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Marca { get; set; }
            public double Preco { get; set; }
            public int Quantidade { get; set; }
            public List<Categoria> Categorias { get; set; }
        }


        public class Handler : IRequestHandler<GetProdutoContract, Result<ProdutoResponse>>
        {
            private readonly IProdutoService _produtoService;
            public Handler(IProdutoService produtoService)
            {
                _produtoService = produtoService;
            }
            public async Task<Result<ProdutoResponse>> Handle(GetProdutoContract request, CancellationToken cancellationToken)
            {
                var prodFromDb = await _produtoService.GetById(request.Id);

                //criação objeto response
                var prodResponse = new ProdutoResponse();
                prodResponse.Categorias = prodFromDb.ProdutoCategorias.Select(x => x.Categoria).ToList();
                prodResponse.Categorias.ForEach(x => x.ProdutoCategorias = null);
                prodResponse.Id = prodFromDb.Id;
                prodResponse.Marca = prodFromDb.Marca;
                prodResponse.Nome = prodFromDb.Nome;
                prodResponse.Preco = prodFromDb.Preco;
                prodResponse.Quantidade = prodFromDb.Quantidade;
                prodFromDb.FotoUrl = prodFromDb.FotoUrl;

                if (prodFromDb != null)
                {
                    return await Result<ProdutoResponse>.Ok(prodResponse);
                }

                return await Result<ProdutoResponse>.Fail(ProgramMessages.ProdAttempt); ;
            }
        }
    }
}
