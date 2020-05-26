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

namespace LojaEmpresaPequena.Application.ProdutoMediator.Commands
{
    public class SaveProduto
    {
        public class SaveProdutoContract: IRequest<Result<string>>
        {
            public string Nome { get; set; }
            public string Marca { get; set; }
            public double Preco { get; set; }
            public int Quantidade { get; set; }
        }

        public class Handler : IRequestHandler<SaveProdutoContract, Result<string>>
        {
            IProdutoService _produtoService;
            public Handler(IProdutoService produtoService)
            {
                _produtoService = produtoService;
            }
            public async Task<Result<string>> Handle(SaveProdutoContract request, CancellationToken cancellationToken)
            {
                var produto = new Produto(request.Nome, request.Marca, request.Preco,request.Quantidade);

                _produtoService.Save(produto);

                return await Result<string>.Ok(ProgramMessages.CadastroProdSucesso);
            }
        }
    }
}
