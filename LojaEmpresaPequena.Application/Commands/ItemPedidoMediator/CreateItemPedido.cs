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

namespace LojaEmpresaPequena.Application.Commands.ItemPedidoMediator
{
    public class CreateItemPedido
    {
        public class CreateItemPedidoContract : IRequest<Result<string>>
        {
            public int Quantidade { get; set; }
            public double Preco { get; set; }
            public Pedido Pedido { get; set; }
            public Produto Produto { get; set; }
            public Usuario Usuario { get; set; }
        }

        public class Handler : IRequestHandler<CreateItemPedidoContract, Result<string>>
        {
            private readonly IItemPedidoService _itemPedidoService;
            private readonly IPedidoService _pedidoService;
            private readonly IProdutoService _produtoService;
            public Handler(IItemPedidoService itemPedidoService, IPedidoService pedidoService, IProdutoService produtoService)
            {
                _itemPedidoService = itemPedidoService;
                _pedidoService = pedidoService;
                _produtoService = produtoService;
            }

            public  async Task<Result<string>> Handle(CreateItemPedidoContract request, CancellationToken cancellationToken)
            {
                if (request.Produto == null)
                    return await Result<string>.Fail(ProgramMessages.ProdutoInvalido);

                if (request.Pedido == null)
                    return await Result<string>.Fail(ProgramMessages.PedidoInvalido);

                if (request.Usuario == null)
                    return await Result<string>.Fail(ProgramMessages.UsuarioNulo);

                var currentPedido = _pedidoService.GetCurrentPedido(request.Usuario);
                var produtoFromDb = await _produtoService.GetById(request.Produto.Id);

                var itemPedido = new ItemPedido(request.Quantidade, request.Preco, currentPedido, produtoFromDb);

                _itemPedidoService.Save(itemPedido);

                return await Result<string>.Ok(ProgramMessages.Sucesso);



            }
        }
    }
}
