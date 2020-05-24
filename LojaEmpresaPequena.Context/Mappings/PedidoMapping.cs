using LojaEmpresaPequena.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.ItemPedidos).WithOne(x => x.Pedido);
            builder.HasOne(x => x.Usuario).WithMany(x => x.Pedidos);
            builder.HasOne(x => x.DetalhesPedido).WithOne(x => x.Pedido).HasForeignKey<DetalhesPedido>(x => x.Id);
        }
    }
}
