using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public  double Preco { get; set; }
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

        public ItemPedido(global::System.Int32 id, global::System.Int32 quantidade, global::System.Double preco, Pedido pedido, Produto produto)
        {
            Id = id;
            Quantidade = quantidade;
            Preco = preco;
            Pedido = pedido;
            Produto = produto;
        }

        public ItemPedido()
        {
        }
    }

}
