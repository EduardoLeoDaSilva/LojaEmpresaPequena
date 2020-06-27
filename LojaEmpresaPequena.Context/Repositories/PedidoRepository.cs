using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Enums;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaEmpresaPequena.Context.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(LojaEmpresaPequenaIdentityContext context) :base(context)
        {
 
        }


        public override IQueryable<Pedido> GetAll()
        {
            var pedidos = _dbSet.Include(x => x.DetalhesPedido).Include(x => x.ItemPedidos).ThenInclude(x => x.Produto).ThenInclude(x => x.Fotos).ThenInclude(x => x.Produto).ThenInclude(x => x.ProdutoCategorias);
            return pedidos;
        }

        public Pedido GetCurrentPedido(Usuario usuario)
        {
            var pedido = this.GetAll().Where(x => x.Usuario.Id == usuario.Id && x.StatusPedido == StatusPedido.Carrinho).SingleOrDefault();
            return pedido;
        }
    }
}
