using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
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
    public class GetAllPedidos
    {
        public class GetAllPedidosContract : IRequest<Result<PedidosResponse>>
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public string SortOrder { get; set; }
            public string SortField { get; set; }
            public string UsuarioNomeFilter { get; set; }
            public string ProdutoNomeFilter { get; set; }
            public string NumeroPedido { get; set; }
        }

        public class PedidosResponse
        {
            public List<Pedido> Pedidos { get; set; }
            public int RowCount { get; set; }
        }

        public class Handler : IRequestHandler<GetAllPedidosContract, Result<PedidosResponse>>
        {
            private readonly IPedidoService _pedidoService;
            public Handler(IPedidoService pedidoService)
            {
                _pedidoService = pedidoService;
            }

            public async Task<Result<PedidosResponse>> Handle(GetAllPedidosContract request, CancellationToken cancellationToken)
            {

                var pedidos = _pedidoService.GetAll();

                if (!String.IsNullOrEmpty(request.UsuarioNomeFilter) && !String.IsNullOrWhiteSpace(request.UsuarioNomeFilter))
                {
                    pedidos = pedidos.Where(x => x.Usuario.Nome == request.UsuarioNomeFilter);
                }

                if (!String.IsNullOrEmpty(request.ProdutoNomeFilter) && !String.IsNullOrWhiteSpace(request.ProdutoNomeFilter))
                {
                    pedidos = pedidos.Where(x => x.ItemPedidos.Where(t => t.Produto.Nome == request.ProdutoNomeFilter).Any());

                }

                ///Criar prop numeroPedido
                //if (String.IsNullOrEmpty(request.NumeroPedido) && String.IsNullOrWhiteSpace(request.NumeroPedido))
                //{
                //    pedidos = pedidos.Where(x => x.ItemPedidos.Where(t => t.Produto.Nome == request.ProdutoNomeFilter).Any());

                //}

                pedidos = pedidos.OrderByDescending(x => x.DataPedido);

                var pagedList = pedidos.ToPagedList(request.Page, request.PageSize);

                return await Result<PedidosResponse>.Ok(
                    new PedidosResponse()
                    {
                        Pedidos = pagedList.ToList(),
                        RowCount = pagedList.PageCount
                    }
                    );
            }
        }
    }
}
