using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string DataPedido { get; set; }
        public string DataEnvio { get; set; }
        public string StatusPedido { get; set; }


        public List<Usuario> usuarios { get; set; }

        public List<ItemPedido> itemPedidos{ get; set; }

        public DetalhesPedido detalhesPedido{ get; set; }

        public Pedido(global::System.Int32 id, global::System.String dataPedido, global::System.String dataEnvio, global::System.String statusPedido, List<Usuario> usuarios, List<ItemPedido> itemPedidos, DetalhesPedido detalhesPedido)
        {
            Id = id;
            DataPedido = dataPedido;
            DataEnvio = dataEnvio;
            StatusPedido = statusPedido;
            this.usuarios = usuarios;
            this.itemPedidos = itemPedidos;
            this.detalhesPedido = detalhesPedido;
        }

        public Pedido()
{
}
    }

}
