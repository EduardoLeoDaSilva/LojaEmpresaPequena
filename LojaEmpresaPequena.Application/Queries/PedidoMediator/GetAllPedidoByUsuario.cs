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
    public class GetAllPedidoByUsuario
    {
        public class GetAllPedidoByUsuarioContract : IRequest<Result<PedidosResponse>>
        {
            public Usuario Usuario { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
            public string SortOrder { get; set; }
            public string SortField { get; set; }
            public string UsuarioNomeFilter { get; set; }
        }

        public class PedidosResponse
        {
            public List<Pedido> Pedidos { get; set; }
            public int RowCount { get; set; }
        }

        public class Handler : IRequestHandler<GetAllPedidoByUsuarioContract, Result<PedidosResponse>>
        {
            private readonly IPedidoService _pedidoService;
            public Handler(IPedidoService pedidoService)
            {
                _pedidoService = pedidoService;
            }
            public Task<Result<PedidosResponse>> Handle(GetAllPedidoByUsuarioContract request, CancellationToken cancellationToken)
            {
                var listFromDb = _pedidoService.GetAll();

                if (request.Usuario == null)
                    return Result<PedidosResponse>.Fail(ProgramMessages.UsuarioNulo);

                //IMplementar pra esse bloco procura por numero do pedido
                //if (!String.IsNullOrEmpty(request.UsuarioNomeFilter) || !String.IsNullOrWhiteSpace(request.UsuarioNomeFilter))
                //{
                //    listFromDb = listFromDb.Where(x => x.Usuario.Nome.Contains(request.UsuarioNomeFilter));
                //}

                listFromDb = listFromDb.Where(x => x.Usuario.Id == request.Usuario.Id);


                var pagedList = listFromDb.ToPagedList(request.Page, request.PageSize);

                return Result<PedidosResponse>.Ok(new PedidosResponse()
                {
                    Pedidos = pagedList.ToList(),
                    RowCount = pagedList.PageCount
                });

            }
        }
    }
}
