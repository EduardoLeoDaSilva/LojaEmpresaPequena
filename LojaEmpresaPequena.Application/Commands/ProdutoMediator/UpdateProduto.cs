using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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

            public string Categorias { get; set; }
            public int Quantidade { get; set; }

            public IFormFile Foto { get; set; }
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
                var categorias = JsonConvert.DeserializeObject<List<Categoria>>(request.Categorias);

                if (prodFromDb == null)
                    return await Result<string>.Fail(ProgramMessages.TentarBuscarProdErro);

                var listProdCate = new List<ProdutoCategoria>();
                foreach (var item in categorias)
                {
                    listProdCate.Add(new ProdutoCategoria { Categoria = null, CategoriaId = item.Id, Produto = null, ProdutoId = prodFromDb.Id });
                }

                var caminhoImagem = "";
                if (request.Foto != null)
                {
                var response =  await _produtoService.SendImageToDropBox(request.Foto, $"produtos/{prodFromDb.Id}");

                }
                    //caminhoImagem = _produtoService.SaveImagem(request.Foto, $"produtos\\{prodFromDb.Id}");

                prodFromDb.UpdateInstance(new Produto()
                {
                    Marca = request.Marca,
                    Nome = request.Nome,
                    Preco = request.Preco,
                    ProdutoCategorias = listProdCate,
                    Quantidade = request.Quantidade,
                    FotoUrl = caminhoImagem
                }); ;

                await _produtoService.Update(prodFromDb);

                return await Result<string>.Ok(ProgramMessages.Sucesso);

            }
        }
    }
}
