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
            public string Email { get; set; }
        }

        public class Handler : IRequestHandler<DeleteItemPedidoContract, Result<string>>
        {
            private readonly IItemPedidoService _itemPedidoService;
            private readonly IUsuarioService _usuarioService;
            public Handler(IItemPedidoService itemPedidoService, IUsuarioService usuarioService)
            {
                _itemPedidoService = itemPedidoService;
                _usuarioService = usuarioService;
            }
            public async Task<Result<string>> Handle(DeleteItemPedidoContract request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                    return  Result<string>.FailToMiddleware(ProgramMessages.Falha);

                var currentUser = await _usuarioService.GetByUsername(request.Email);
                await _itemPedidoService.DeleteItemPedidoAndCalculateTotal(request.Id, currentUser);

                return await Result<string>.Ok(ProgramMessages.Sucesso);

            }
        }
    }
}
