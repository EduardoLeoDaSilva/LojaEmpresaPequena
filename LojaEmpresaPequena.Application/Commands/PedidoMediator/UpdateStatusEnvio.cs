using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Enums;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Commands.PedidoMediator
{
    public class UpdateStatusEnvio
    {
        public class UpdateStatusEnvioContract : IRequest<Result<string>> {
            public Guid Id { get; set; }
            public int StatusEnvio { get; set; }
        }

        public class UpdateStatusHandler : IRequestHandler<UpdateStatusEnvioContract, Result<string>>
        {
            private readonly IPedidoService _pedidoServie;
            public UpdateStatusHandler(IPedidoService pedidoService)
            {
                _pedidoServie = pedidoService;
            }
            public async Task<Result<string>> Handle(UpdateStatusEnvioContract request, CancellationToken cancellationToken)
            {
                var pedidoDb = await  _pedidoServie.GetById(request.Id);

                if (pedidoDb == null)
                    return Result<String>.FailToMiddleware("Ocorreu um erro ao tentar atualizar o pedido");

                pedidoDb.StatusEnvio = (StatusEnvio)request.StatusEnvio;

                _pedidoServie.Update(pedidoDb);

                return  await Result<String>.Ok("Status de envio atualizado");
                  
            }
        }

    }
}
