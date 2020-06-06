using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Produto : BaseEntity<Produto>
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public  double Preco { get; set; }
        public int Quantidade { get; set; }

        public List<ProdutoCategoria> ProdutoCategorias { get; set; }

        public string FotoUrl { get; set; }

        public Produto()
        {

        }
        public Produto(string nome, string marca, double preco, int quantidade)
        {

            VerifyDomainRules.CreateInstance()
                .VerifyRule(String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome), ProgramMessages.NomeProdutoInvalido)
                .VerifyRule(String.IsNullOrEmpty(marca) || String.IsNullOrWhiteSpace(marca), ProgramMessages.MarcaProdutoInvalida)
                .ThrowExceptionDomain();

            Nome = nome;
            Marca = marca;
            Preco = preco;
            Quantidade = quantidade;
        }

        public override void UpdateInstance(Produto e)
        {
            VerifyDomainRules.CreateInstance()
                 .VerifyRule(String.IsNullOrEmpty(e.Nome) || String.IsNullOrWhiteSpace(e.Nome), ProgramMessages.NomeProdutoInvalido)
                 .VerifyRule(String.IsNullOrEmpty(e.Marca) || String.IsNullOrWhiteSpace(e.Marca), ProgramMessages.MarcaProdutoInvalida)
                 .ThrowExceptionDomain();

            Nome = e.Nome;
            Marca = e.Marca;
            Preco = e.Preco;
            Quantidade = e.Quantidade;
            ProdutoCategorias = e.ProdutoCategorias;
            FotoUrl = e.FotoUrl;
        }


    }

}
