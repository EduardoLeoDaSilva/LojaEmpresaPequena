using LojaEmpresaPequena.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Produto);
            builder.HasOne(x => x.Pedido).WithMany(x => x.ItemPedidos);
        }
    }
}
