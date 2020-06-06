using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using Microsoft.AspNetCore.Http;
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

            public IFormFile Foto { get; set; }

            public List<Categoria> ProdutoCategorias { get; set; }

        }

        public class Handler : IRequestHandler<SaveProdutoContract, Result<string>>
        {
            IProdutoService _produtoService;
            ICategoriaService _categoriaService;
            public Handler(IProdutoService produtoService, ICategoriaService categoriaService)
            {
                _produtoService = produtoService;
                _categoriaService = categoriaService;
            }
            public async Task<Result<string>> Handle(SaveProdutoContract request, CancellationToken cancellationToken)
            {

                var produto = new Produto(request.Nome, request.Marca, request.Preco, request.Quantidade);
                var produtoCategoria = new List<ProdutoCategoria>();


                foreach (var categoria in request.ProdutoCategorias)
                {
                    produtoCategoria.Add(new ProdutoCategoria { CategoriaId = categoria.Id, Categoria = categoria, Produto = produto, ProdutoId = produto.Id });
                }
                produto.ProdutoCategorias = produtoCategoria;
                await _produtoService.Update(produto);

                _produtoService.SaveImagem(request.Foto, $"produtos\\{produto.Id}");


                return await Result<string>.Ok(ProgramMessages.CadastroProdSucesso);
            }
        }
    }
}
