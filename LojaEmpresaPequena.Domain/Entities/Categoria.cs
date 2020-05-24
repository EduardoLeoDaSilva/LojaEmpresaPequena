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

        public Categoria(string nome, List<ProdutoCategoria> produtoCategorias)
        {

            VerifyDomainRules.CreateInstance()
                .VerifyRule(String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome), ProgramMessages.NomeCategoria)
                .ThrowExceptionDomain();

            Nome = nome;
            ProdutoCategorias = produtoCategorias;
        }

    }
}
