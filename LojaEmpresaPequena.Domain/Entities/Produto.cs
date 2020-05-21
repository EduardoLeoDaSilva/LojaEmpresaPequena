using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public  double Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public ItemPedido itemPedidos { get; set; }
        public List<Categoria> categorias { get; set; }

        public Produto(global::System.Int32 id, global::System.String nome, global::System.String marca, global::System.Double preco, global::System.Int32 quantidadeEstoque, ItemPedido itemPedidos, List<Categoria> categorias)
        {
            Id = id;
            Nome = nome;
            Marca = marca;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            this.itemPedidos = itemPedidos;
            this.categorias = categorias;
        }

        public Produto()
        {
        }
    }

}
