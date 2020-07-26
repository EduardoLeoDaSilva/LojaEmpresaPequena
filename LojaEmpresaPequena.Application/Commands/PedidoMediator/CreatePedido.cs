using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Enums;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Commands.PedidoMediator
{
    public class CreatePedido
    {
        public class CreatePedidoContract : IRequest<Result<string>>
        {
            public string Email { get; set; }
            //public Guid IdProduto { get; set; }
            public List<Guid> IdProdutos { get; set; }

            ///parametro pra identificar em qual plataforma foi feita a requisção //App//WebSite
            public string Platform { get; set; }
        }

        public class Handler : IRequestHandler<CreatePedidoContract, Result<string>>
        {
            private readonly IPedidoService _pedidoService;
            private readonly IProdutoService _produtoService;
            private readonly IUsuarioService _usuarioService;
            public Handler(IPedidoService pedidoService, IProdutoService produtoService, IUsuarioService usuarioService)
            {
                _pedidoService = pedidoService;
                _produtoService = produtoService;
                _usuarioService = usuarioService;
            }

            public async Task<Result<string>> Handle(CreatePedidoContract request, CancellationToken cancellationToken)
            {
                if (String.IsNullOrEmpty(request.Email))
                    return Result<string>.FailToMiddleware(ProgramMessages.EmailInvalido);

                //if (request.IdProduto == null)
                //    return Result<string>.FailToMiddleware(ProgramMessages.ProdAttempt);


                if (request.IdProdutos == null)
                    return Result<string>.FailToMiddleware(ProgramMessages.ProdAttempt);

                var usuario = await _usuarioService.GetByUsername(request.Email);
                //var produto = await _produtoService.GetById(request.IdProduto);

                if (usuario == null)
                    return  Result<string>.FailToMiddleware(ProgramMessages.UsuarioNulo);

                //if (produto == null)
                //    return  Result<string>.FailToMiddleware(ProgramMessages.ProdAttempt);

                var pedido = await _pedidoService.CreatePedidoOrAddItemPedido(usuario, request.IdProdutos);


                return await Result<string>.Ok(ProgramMessages.AdicionadoCarrinho);

            }
        }
    }
}
