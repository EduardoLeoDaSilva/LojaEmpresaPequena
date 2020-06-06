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
    public class GetProdutoFoto
    {

        public class GetProdutoFotoContract : IRequest<GetProdutoResponse>
        {
            public IFormFile Foto { get; set; }
            public string Id { get; set; }
        }


        public class GetProdutoResponse
        {
            public string Link { get; set; }
        }

        public class Handler : IRequestHandler<GetProdutoFotoContract, GetProdutoResponse>
        {
            private readonly IProdutoService _produtoService;

            public Handler(IProdutoService produtoService)
            {
                _produtoService = produtoService;
            }

            public async Task<GetProdutoResponse> Handle(GetProdutoFotoContract request, CancellationToken cancellationToken)
            {
                var responseSaveFoto = await _produtoService.SendImageToDropBox(request.Foto, $"produtos/{request.Id}");
                var linkFoto = await _produtoService.GetTemporaryLink(responseSaveFoto.Path_display);
                return new GetProdutoResponse { Link = linkFoto.Link };
            }
        }
    }
}
