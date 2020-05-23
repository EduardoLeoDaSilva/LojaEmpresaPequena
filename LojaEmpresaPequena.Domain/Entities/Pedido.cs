using LojaEmpresaPequena.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public string DataPedido { get; set; }
        public string DataEnvio { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public StatusEnvio StatusEnvio { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public List<ItemPedido> ItemPedidos{ get; set; }

        public DetalhesPedido DetalhesPedido{ get; set; }

        public Pedido(string dataPedido, string dataEnvio, StatusPedido statusPedido, StatusEnvio statusEnvio, List<Usuario> usuarios, List<ItemPedido> itemPedidos, DetalhesPedido detalhesPedido)
        {
            DataPedido = dataPedido;
            DataEnvio = dataEnvio;
            StatusPedido = statusPedido;
            StatusEnvio = statusEnvio;
            Usuarios = usuarios;
            ItemPedidos = itemPedidos;
            DetalhesPedido = detalhesPedido;
        }

        public Pedido()
        {

        }
    }

}
