using LojaEmpresaPequena.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context.Mappings
{
    public class EnderecoMappping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuario).WithMany(x => x.Enderecos);
        }
    }
}
