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

        public Produto(string nome, string marca, double preco, int quantidadeEstoque, List<ProdutoCategoria> produtoCategorias)
        {
            Nome = nome;
            Marca = marca;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            ProdutoCategorias = produtoCategorias;
        }

        public Produto()
        {
        }
    }

}
