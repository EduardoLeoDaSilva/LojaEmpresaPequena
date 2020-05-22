using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class DetalhesPedido
    {
        public int Id { get; set; }
        public string  TipoPedido { get; set; }
        public string DataAprovacao { get; set; }
        public Pedido Pedido { get; set; }

        public DetalhesPedido(global::System.Int32 id, global::System.String tipoPedido, global::System.String dataAprovacao, Pedido pedido)
        {
            Id = id;
            TipoPedido = tipoPedido;
            DataAprovacao = dataAprovacao;
            Pedido = pedido;
        }

        public DetalhesPedido()
        {
        }
    }


}
