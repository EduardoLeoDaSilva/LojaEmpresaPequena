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
            public Usuario Usuario { get; set; }
            public Produto Produto { get; set; }
        }

        public class Handler : IRequestHandler<CreatePedidoContract, Result<string>>
        {
            private readonly IPedidoService _pedidoService;
            public Handler(IPedidoService pedidoService)
            {
                _pedidoService = pedidoService;
            }

            public async Task<Result<string>> Handle(CreatePedidoContract request, CancellationToken cancellationToken)
            {

                if (request.Usuario == null)
                    return await Result<string>.Fail(ProgramMessages.UsuarioNulo);

                if (request.Produto == null)
                    return await Result<string>.Fail(ProgramMessages.ProdAttempt);

                var pedido = await _pedidoService.CreatePedidoOrAddItemPedido(request.Usuario,request.Produto);


                return await Result<string>.Ok(ProgramMessages.Sucesso);

            }
        }
    }
}
