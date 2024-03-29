﻿using LojaEmpresaPequena.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context.Mappings
{
    public class DetalhesPedidoMapping : IEntityTypeConfiguration<DetalhesPedido>
    {
        public void Configure(EntityTypeBuilder<DetalhesPedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Pedido).WithOne(x => x.DetalhesPedido);
        }
    }
}
