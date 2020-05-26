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

namespace LojaEmpresaPequena.Application.Commands.ProdutoMediator
{
    public class UpdateProduto
    {
        public class UpdateProdutoContract : IRequest<Result<string>>
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Marca { get; set; }
            public double Preco { get; set; }

            public List<ProdutoCategoria> ProdutoCategorias { get; set; }
            public int Quantidade { get; set; }
        }

        public class Handler : IRequestHandler<UpdateProdutoContract, Result<string>>
        {

            private readonly IProdutoService _produtoService;
            public Handler(IProdutoService produtoService)
            {
                _produtoService = produtoService;
            }
            public async Task<Result<string>> Handle(UpdateProdutoContract request, CancellationToken cancellationToken)
            {
                var prodFromDb = await _produtoService.GetById(request.Id);

                if (prodFromDb == null)
                    return await Result<string>.Fail(ProgramMessages.TentarBuscarProdErro);

                prodFromDb.UpdateInstance(new Produto()
                {
                    Marca = request.Marca,
                    Nome = request.Nome,
                    Preco = request.Preco,
                    ProdutoCategorias = request.ProdutoCategorias,
                    QuantidadeEstoque = request.Quantidade
                });

                return await Result<string>.Ok(ProgramMessages.Sucesso);

            }
        }
    }
}
