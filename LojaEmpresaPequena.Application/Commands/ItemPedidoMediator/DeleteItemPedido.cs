using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Commands.ItemPedidoMediator
{
    public class DeleteItemPedido
    {
        public class DeleteItemPedidoContract : IRequest<Result<string>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<DeleteItemPedidoContract, Result<string>>
        {
            private readonly IItemPedidoService _itemPedidoService;
            public Handler(IItemPedidoService itemPedidoService)
            {
                _itemPedidoService = itemPedidoService;
            }
            public async Task<Result<string>> Handle(DeleteItemPedidoContract request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                    return  Result<string>.FailToMiddleware(ProgramMessages.Falha);

                await _itemPedidoService.Delete(request.Id);
                return await Result<string>.Ok(ProgramMessages.Sucesso);

            }
        }
    }
}
