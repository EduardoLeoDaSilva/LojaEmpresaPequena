using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
   public class Categoria : BaseEntity
    {
        public string Nome { get; set; }
        public List<ProdutoCategoria> ProdutoCategorias { get; set; }

        public Categoria()
        {

        }
        public Categoria(string nome)
        {

            VerifyDomainRules.CreateInstance()
                .VerifyRule(String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome), ProgramMessages.NomeCategoria)
                .ThrowExceptionDomain();

            Nome = nome;

        }

    }
}
