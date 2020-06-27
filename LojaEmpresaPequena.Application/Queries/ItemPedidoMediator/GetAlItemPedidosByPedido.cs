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

namespace LojaEmpresaPequena.Application.Queries.ItemPedidoMediator
{
    public class GetAlItemPedidosByPedido
    {
        public class GetAlItemPedidosByPedidoContract : IRequest<Result<ItemPedidosResponse>> 
        {
            public Pedido Pedido { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
            public string SortOrder { get; set; }
            public string SortField { get; set; }
        }

        public class ItemPedidosResponse
        {
            public List<ItemPedido> ItensPedido { get; set; }
            public int RowCount { get; set; }
        }

        public class Handler : IRequestHandler<GetAlItemPedidosByPedidoContract, Result<ItemPedidosResponse>>
        {
            private readonly IItemPedidoService _itemPedidoService;
            public Handler(IItemPedidoService itemPedidoService)
            {
                _itemPedidoService = itemPedidoService;
            }

            public async Task<Result<ItemPedidosResponse>> Handle(GetAlItemPedidosByPedidoContract request, CancellationToken cancellationToken)
            {
                
                if (request.Pedido == null)
                    return  Result<ItemPedidosResponse>.FailToMiddleware(ProgramMessages.PedidoInvalido);

                var itensPedidoFromDb = _itemPedidoService.GetAll().Where(x => x.Pedido.Id == request.Pedido.Id);
                var pageList = itensPedidoFromDb.ToPagedList(request.Page, request.PageSize);

                return await Result<ItemPedidosResponse>.Ok(new ItemPedidosResponse()
                {
                    ItensPedido = pageList.ToList(),
                    RowCount = pageList.PageCount
                });

            }
        }

    }
}
