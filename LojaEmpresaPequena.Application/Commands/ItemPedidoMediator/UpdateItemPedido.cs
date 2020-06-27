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
    public class UpdateItemPedido
    {
        public class UpdateItemPedidoContract : IRequest<Result<string>>
        {
            public Guid Id { get; set; }
            public int Quantidade { get; set; }
        }

        public class Handler : IRequestHandler<UpdateItemPedidoContract, Result<string>>
        {
            private readonly IItemPedidoService _itemPedidoService;
            public Handler(IItemPedidoService itemPedidoService)
            {
                _itemPedidoService = itemPedidoService;
            }

            public async Task<Result<string>> Handle(UpdateItemPedidoContract request, CancellationToken cancellationToken)
            {
                if (request.Id != null)
                    return Result<string>.FailToMiddleware(ProgramMessages.Falha);

                var itemPedidoFromDb = await _itemPedidoService.GetById(request.Id);

                await _itemPedidoService.Update(itemPedidoFromDb);

                return await Result<string>.Ok(ProgramMessages.Sucesso);
            }
        }

    }
}
