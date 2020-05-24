using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(LojaEmpresaPequenaIdentity context) :base(context)
        {

        }
    }
}
