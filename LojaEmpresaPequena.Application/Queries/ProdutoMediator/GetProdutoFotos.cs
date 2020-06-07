using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Queries.ProdutoMediator
{
    public class GetProdutoFotos
    {

        public class GetProdutoFotoContract : IRequest<List<Foto>>
        {
            public List<IFormFile> Fotos { get; set; }
            public string Id { get; set; }
        }




        public class Handler : IRequestHandler<GetProdutoFotoContract, List<Foto>>
        {
            private readonly IProdutoService _produtoService;

            public Handler(IProdutoService produtoService)
            {
                _produtoService = produtoService;
            }

            public async Task<List<Foto>> Handle(GetProdutoFotoContract request, CancellationToken cancellationToken)
            {
                var list = new List<Foto>();
                foreach (var item in request.Fotos)
                {
                    var responseSaveFoto = await _produtoService.SendImageToDropBox(item, $"produtos");
                    var linkFoto = await _produtoService.GetSharedLink(responseSaveFoto.Path_display);

                    if(linkFoto.Url == null)
                        list.Add(new Foto { Url = $"{linkFoto.Error.Shared_link_already_exists.MetaData.Url}/&raw=1" });
                    else
                    list.Add(new Foto { Url = $"{linkFoto.Url}/&raw=1" });
                }
                return list;
            }
        }
    }
}
