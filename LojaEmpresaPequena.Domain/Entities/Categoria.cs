using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LojaEmpresaPequena.Domain.Entities
{
   public class Categoria : BaseEntity<Categoria>
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

        public override void UpdateInstance(Categoria e)
        {
            VerifyDomainRules.CreateInstance()
                .VerifyRule(String.IsNullOrEmpty(e.Nome) || String.IsNullOrWhiteSpace(e.Nome), ProgramMessages.NomeCategoria)
                .ThrowExceptionDomain();
            this.Nome = e.Nome;
        }

    }
}
