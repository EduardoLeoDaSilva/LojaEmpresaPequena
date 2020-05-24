using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class DetalhesPedido : BaseEntity
    {
        public string DataAprovacao { get; set; }
        public Pedido Pedido { get; set; }

        public DetalhesPedido(string dataAprovacao, Pedido pedido)
        {

            VerifyDomainRules.CreateInstance()
                .VerifyRule(pedido == null, ProgramMessages.ProdutoInvalido)
                .ThrowExceptionDomain();
                

            DataAprovacao = dataAprovacao;
            Pedido = pedido;
        }

    }


}
