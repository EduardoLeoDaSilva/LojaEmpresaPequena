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

namespace LojaEmpresaPequena.Application.Commands.PedidoMediator
{
    public class UpdatePedido
    {
        public class UpdatePedidoContract : IRequest<Result<string>>
        {
            public Pedido Pedido { get; set; }
        }

        public class Handler : IRequestHandler<UpdatePedidoContract, Result<string>> 
        {
            private readonly IPedidoService _pedidoService;
            public Handler(IPedidoService pedidoService)
            {
                _pedidoService = pedidoService;
            }

            public async Task<Result<string>> Handle(UpdatePedidoContract request, CancellationToken cancellationToken)
            {
                if (request.Pedido == null)
                    return  Result<string>.FailToMiddleware(ProgramMessages.PedidoInvalido);

                var pedidoFromDb = _pedidoService.GetCurrentPedido(request.Pedido.Usuario);

                if(pedidoFromDb == null)
                    return  Result<string>.FailToMiddleware(ProgramMessages.PedidoInvalido);

                pedidoFromDb.UpdateInstance(request.Pedido);

               await _pedidoService.Update(pedidoFromDb);

                return await Result<string>.Ok(ProgramMessages.Sucesso);
            }
        }

    }
}
