using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class DetalhesPedido : BaseEntity<DetalhesPedido>
    {
        public DateTime? DataAprovacao { get; set; }
        public Pedido Pedido { get; set; }


        public DetalhesPedido()
        {

        }
        public DetalhesPedido(DateTime? dataAprovacao, Pedido pedido)
        {

            VerifyDomainRules.CreateInstance()
                .VerifyRule(pedido == null, ProgramMessages.ProdutoInvalido)
                .ThrowExceptionDomain();
                

            DataAprovacao = dataAprovacao;
            Pedido = pedido;
        }

        public override void UpdateInstance(DetalhesPedido e)
        {
            VerifyDomainRules.CreateInstance()
               .VerifyRule(e.Pedido == null, ProgramMessages.ProdutoInvalido)
               .ThrowExceptionDomain();
            this.Pedido = e.Pedido;
        }

    }


}
