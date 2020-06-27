using LojaEmpresaPequena.Domain.Entities.Api;
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
        public class PayPedidoContract : IRequest<Result<string>>
        {
            public string Email { get; set; }
        }

        public class Handler : IRequestHandler<PayPedidoContract, Result<string>>
        {
            private IPedidoService _pedidoService;
            private IUsuarioService _usuarioService;
            public Handler(IPedidoService pedidoService, IUsuarioService usuarioService)
            {
                _pedidoService = pedidoService;
                _usuarioService = usuarioService;
            }
            public async Task<Result<string>> Handle(PayPedidoContract request, CancellationToken cancellationToken)
            {
                if (String.IsNullOrEmpty(request.Email))
                    return Result<string>.FailToMiddleware(ProgramMessages.EmailInvalido);

                var loggedUser =await  _usuarioService.GetByUsername(request.Email);

                if(loggedUser == null)
                    return Result<string>.FailToMiddleware(ProgramMessages.UsuarioNulo);


                await _pedidoService.PayPedido(loggedUser);

                return await Result<string>.Ok(ProgramMessages.Sucesso);
            }
        }
    }
}
