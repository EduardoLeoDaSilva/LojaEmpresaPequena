using LojaEmpresaPequena.Domain.Enums;
using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public DateTime DataPedido { get; set; }
        public DateTime DataEnvio { get; set; }
        public StatusPedido? StatusPedido { get; set; }
        public StatusEnvio? StatusEnvio { get; set; }

        public Usuario Usuario { get; set; }

        public List<ItemPedido> ItemPedidos{ get; set; }

        public DetalhesPedido DetalhesPedido{ get; set; }

        public Pedido(DateTime dataPedido, DateTime dataEnvio, StatusPedido statusPedido, StatusEnvio statusEnvio, Usuario usuario, List<ItemPedido> itemPedidos, DetalhesPedido detalhesPedido)
        {


            VerifyDomainRules.CreateInstance()
                .VerifyRule(usuario == null, ProgramMessages.UsuarioNulo)
                .VerifyRule(statusEnvio == null,ProgramMessages.StatusEnvioInvalido)
                .VerifyRule(statusPedido == null,ProgramMessages.StatusPedidoInvalido)
                .ThrowExceptionDomain();

            DataPedido = dataPedido;
            DataEnvio = dataEnvio;
            StatusPedido = statusPedido;
            StatusEnvio = statusEnvio;
            Usuario = usuario;
            ItemPedidos = itemPedidos;
            DetalhesPedido = detalhesPedido;
        }

    }

}
