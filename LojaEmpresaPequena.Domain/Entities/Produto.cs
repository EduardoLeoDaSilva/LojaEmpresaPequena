using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public  double Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public List<ProdutoCategoria> ProdutoCategorias { get; set; }

        public Produto()
        {

        }
        public Produto(string nome, string marca, double preco, int quantidadeEstoque)
        {

            VerifyDomainRules.CreateInstance()
                .VerifyRule(String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome), ProgramMessages.NomeProdutoInvalido)
                .VerifyRule(String.IsNullOrEmpty(marca) || String.IsNullOrWhiteSpace(marca), ProgramMessages.MarcaProdutoInvalida)
                .ThrowExceptionDomain();

            Nome = nome;
            Marca = marca;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }


    }

}
