using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Integrations.MercadoPagoModels;
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
    public class PayPedido
    {
        public class PayPedidoContract : IRequest<Result<Pedido>>
        {
            public string Email { get; set; }
            public string Token { get; set; }

            public string Platform { get; set; }
            public string Bandeira { get; set; }

            public string PaymentType { get; set; }
        }

        public class Handler : IRequestHandler<PayPedidoContract, Result<Pedido>>
        {
            private IPedidoService _pedidoService;
            private IUsuarioService _usuarioService;
            public Handler(IPedidoService pedidoService, IUsuarioService usuarioService)
            {
                _pedidoService = pedidoService;
                _usuarioService = usuarioService;
            }
            public async Task<Result<Pedido>> Handle(PayPedidoContract request, CancellationToken cancellationToken)
            {
                if (String.IsNullOrEmpty(request.Email))
                    return Result<Pedido>.FailToMiddleware(ProgramMessages.EmailInvalido);

                var loggedUser = await _usuarioService.GetByUsername(request.Email);

                if (loggedUser == null)
                    return Result<Pedido>.FailToMiddleware(ProgramMessages.UsuarioNulo);

                var pedido = await _pedidoService.PayPedido(loggedUser, request.Token, request.Bandeira, request.Platform, request.PaymentType);
                var error = Errors.GetErrorMsg( pedido.StatusDetailed , nameCobranca: pedido.StatementDescriptor);
                if (pedido.StatementDescriptor == "accredited")
                {
                    var result = await Result<Pedido>.Ok(pedido);
                    result.Msg = error;
                    return result;
                }
                else
                {

                    return new Result<Pedido>(pedido, false, null, error);
                }

            }
        }
    }
}
