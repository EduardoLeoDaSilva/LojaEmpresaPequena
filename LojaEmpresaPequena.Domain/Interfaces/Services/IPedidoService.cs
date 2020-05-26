using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Services
{
    public interface IPedidoService:IBaseService<Pedido>
    {
        Pedido GetCurrentPedido(Usuario usuario);
        Task<Pedido> CreatePedido(Usuario usuario);
    }
}
