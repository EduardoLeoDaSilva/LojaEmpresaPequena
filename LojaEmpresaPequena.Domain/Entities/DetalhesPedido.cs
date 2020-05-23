using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class DetalhesPedido : BaseEntity
    {
        public string  TipoPedido { get; set; }
        public string DataAprovacao { get; set; }
        public Pedido Pedido { get; set; }

        public DetalhesPedido(string tipoPedido, string dataAprovacao, Pedido pedido)
        {
            TipoPedido = tipoPedido;
            DataAprovacao = dataAprovacao;
            Pedido = pedido;
        }

        public DetalhesPedido()
        {
        }
    }


}
