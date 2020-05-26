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
    public class GetPedido
    {
        public class GetPedidoContract : IRequest<Result<Pedido>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<GetPedidoContract, Result<Pedido>> 
        {
            private readonly IPedidoService _pedidoService;
            public Handler(IPedidoService pedidoService)
            {
                _pedidoService = pedidoService;
            }

            public async Task<Result<Pedido>> Handle(GetPedidoContract request, CancellationToken cancellationToken)
            {
                if (request == null)
                    return await Result<Pedido>.Fail(ProgramMessages.IdErro);

                var pedidoFromDb = await _pedidoService.GetById(request.Id);

                if(pedidoFromDb == null)
                    return await Result<Pedido>.Fail(ProgramMessages.PedidoInvalido);

                return await Result<Pedido>.Ok(pedidoFromDb);

            }
        }

    }
}
