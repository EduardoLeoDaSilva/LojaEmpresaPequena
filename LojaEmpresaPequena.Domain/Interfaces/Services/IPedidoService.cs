using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Services
{
    public interface IPedidoService:IBaseService<Pedido>
    {
        Pedido GetCurrentPedido(Usuario usuario);
        //Task<Pedido> CreatePedidoOrAddItemPedido(Usuario usuario, Produto produto);
        Task<Pedido> CreatePedidoOrAddItemPedido(Usuario usuario, List<Guid> produtos);
        Task<Pedido> PayPedido(Usuario usuario, string token, string bandeira = "mastercard", string platform = "SI", string paymentType = "credit-card");

        IQueryable<Pedido> GetPedidosByUsuarioId(string email);
    }
}
