using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Queries.PedidoMediator
{
    public class GetPedidoByUsername
    {
        public class GetPedidoByUsernameContract : IRequest<Result<PedidosResponse>>
        {
            public string Email { get; set; }

            public int Page { get; set; }
            public int PageSize { get; set; }
            public string SortOrder { get; set; }
            public string SortField { get; set; }
        }

        public class PedidosResponse
        {
            public List<Pedido> Pedidos { get; set; }
            public int RowCount { get; set; }
        }

        public class Handler : IRequestHandler<GetPedidoByUsernameContract, Result<PedidosResponse>>
        {
            private readonly IPedidoService _pedidoService;
            public Handler(IPedidoService pedidoService)
            {
                _pedidoService = pedidoService;
            }
            public async Task<Result<PedidosResponse>> Handle(GetPedidoByUsernameContract request, CancellationToken cancellationToken)
            {
                if (String.IsNullOrEmpty(request.Email))
                    return Result<PedidosResponse>.FailToMiddleware(ProgramMessages.IdErro);

               var pedidos = _pedidoService.GetPedidosByUsuarioId(request.Email).OrderByDescending((x) => x.DataPedido);


                var pagedList = pedidos.ToPagedList(request.Page, request.PageSize);

                return await Result<PedidosResponse>.Ok(new PedidosResponse()
                {
                    Pedidos = pagedList.ToList(),
                    RowCount = pagedList.PageCount
                });
            }
        }
    }
}
