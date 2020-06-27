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

namespace LojaEmpresaPequena.Application.Queries.PedidoMediator
{
    public class GetCurrentPedido 
    {
        public class GetCurrentPedidoContract : IRequest<Result<Pedido>>
        {
            public string Email { get; set; }
        }

        public class Handler : IRequestHandler<GetCurrentPedidoContract, Result<Pedido>>
        {
            private IPedidoService _pedidoService;
            private IUsuarioService _usuarioService;
            public Handler(IPedidoService pedidoService, IUsuarioService usuarioService)
            {
                _pedidoService = pedidoService;
                _usuarioService = usuarioService;
            }
            public async Task<Result<Pedido>> Handle(GetCurrentPedidoContract request, CancellationToken cancellationToken)
            {
                if (String.IsNullOrEmpty(request.Email))
                {
                    return  Result<Pedido>.FailToMiddleware(ProgramMessages.PedidoInvalido);
                }

                var usuarioFromDb = await _usuarioService.GetByUsername(request.Email);

                var pedido = _pedidoService.GetCurrentPedido(usuarioFromDb);

                return await Result<Pedido>.Ok(pedido);
            }
        }
    }
}
