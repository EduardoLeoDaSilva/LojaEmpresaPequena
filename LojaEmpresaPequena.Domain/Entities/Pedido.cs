﻿using LojaEmpresaPequena.Domain.Enums;
using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Pedido : BaseEntity<Pedido>
    {
        public DateTime? DataPedido { get; set; }
        public DateTime? DataEnvio { get; set; }
        public StatusPedido? StatusPedido { get; set; }
        public StatusEnvio? StatusEnvio { get; set; }

        public Usuario Usuario { get; set; }

        public List<ItemPedido> ItemPedidos{ get; set; }

        public DetalhesPedido DetalhesPedido{ get; set; }

        public Pedido()
        {

        }
        public Pedido(DateTime? dataPedido, DateTime? dataEnvio, StatusPedido? statusPedido, StatusEnvio? statusEnvio, Usuario usuario, List<ItemPedido> itemPedidos)
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
            DetalhesPedido = new DetalhesPedido(null, this);
        }

        public override void UpdateInstance(Pedido e)
        {
            VerifyDomainRules.CreateInstance()
                .VerifyRule(e.Usuario == null, ProgramMessages.UsuarioNulo)
                .VerifyRule(e.StatusEnvio == null, ProgramMessages.StatusEnvioInvalido)
                .VerifyRule(e.StatusPedido == null, ProgramMessages.StatusPedidoInvalido)
                .ThrowExceptionDomain();
            base.UpdateInstance(e);

            DataPedido = e.DataPedido;
            DataEnvio = e.DataEnvio;
            StatusPedido = e.StatusPedido;
            StatusEnvio = e.StatusEnvio;
            Usuario = e.Usuario;
            ItemPedidos = e.ItemPedidos;
            DetalhesPedido = e.DetalhesPedido;

        }

    }

}
