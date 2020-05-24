using LojaEmpresaPequena.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context.Mappings
{
    public class ProdutoCategoriaMapping : IEntityTypeConfiguration<ProdutoCategoria>
    {
        public void Configure(EntityTypeBuilder<ProdutoCategoria> builder)
        {

            builder
            .HasKey(x => new { x.ProdutoId, x.CategoriaId });

            builder
            .HasOne(x => x.Produto)
            .WithMany(x => x.ProdutoCategorias)
            .HasForeignKey(x => x.ProdutoId);

            builder
                .HasOne(x => x.Categoria)
                .WithMany(x => x.ProdutoCategorias)
                .HasForeignKey(x => x.CategoriaId);
        }
    }
}
