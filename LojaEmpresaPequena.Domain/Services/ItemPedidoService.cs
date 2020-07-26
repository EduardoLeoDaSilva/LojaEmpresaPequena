using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Services
{
    public class ItemPedidoService : BaseService<ItemPedido>, IItemPedidoService
    {
        private readonly IPedidoRepository _pedidorepository;

        public ItemPedidoService(IItemPedidoRepository _repository, IPedidoRepository pedidorepository) :base(_repository)
        {
             _pedidorepository = pedidorepository;
        }

        public  async Task DeleteItemPedidoAndCalculateTotal(Guid id, Usuario usuario)
        {
            await base.Delete(id);
            var pedido = _pedidorepository.GetCurrentPedido(usuario);
            pedido.CalcularTotalPedido();
          
             await _pedidorepository.Update(pedido);
        }


    }
}
