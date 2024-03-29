﻿using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context.Repositories
{
    public class DetalhesPedidoRepository : BaseRepository<DetalhesPedido>, IDetalhesPedidoRepository
    {
        public DetalhesPedidoRepository(LojaEmpresaPequenaIdentityContext context) : base(context)
        {

        }
    }
}
