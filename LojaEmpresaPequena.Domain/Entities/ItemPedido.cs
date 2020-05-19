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

        public ItemPedido(global::System.Int32 id, global::System.Int32 quantidade, global::System.Double preco)
        {
            Id = id;
            Quantidade = quantidade;
            Preco = preco;
        }

        public ItemPedido()
        {
        }
    }

}
