using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    class Pedido
    {
        public int Id { get; set; }
        public string DataPedido { get; set; }
        public string DataEnvio { get; set; }
        public string StatusPedido { get; set; }

        public Pedido(global::System.Int32 id, global::System.String dataPedido, global::System.String dataEnvio, global::System.String statusPedido)
        {
            Id = id;
            DataPedido = dataPedido;
            DataEnvio = dataEnvio;
            StatusPedido = statusPedido;
        }

        public Pedido()
        {
        }
    }

}
