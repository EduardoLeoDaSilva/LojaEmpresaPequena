using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaEmpresaPequena.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository : IBaseRepository<Pedido> 
    {
         Pedido GetCurrentPedido(Usuario usuario);
        IQueryable<Pedido> GetByUserName(string email);
    }
}
