using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class ItemPedido : BaseEntity
    {
        public int Quantidade { get; set; }
        public  double Preco { get; set; }
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

        public ItemPedido(int quantidade, double preco, Pedido pedido, Produto produto)
        {
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
