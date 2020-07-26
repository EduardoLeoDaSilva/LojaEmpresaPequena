using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Services
{
    public interface IItemPedidoService:IBaseService<ItemPedido>
    {
        Task DeleteItemPedidoAndCalculateTotal(Guid id, Usuario usuario);
    }
}
