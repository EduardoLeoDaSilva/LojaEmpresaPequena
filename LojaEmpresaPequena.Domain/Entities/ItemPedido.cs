using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class ItemPedido : BaseEntity<ItemPedido>
    {
        public int Quantidade { get; set; }
        public  double Preco { get; set; }
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }


        public ItemPedido()
        {

        }
        public ItemPedido(int quantidade, double preco, Pedido pedido, Produto produto)
        {

            VerifyDomainRules.CreateInstance()
                .VerifyRule(quantidade < 1, ProgramMessages.QuantidadeInvalida)
                .VerifyRule(pedido == null, ProgramMessages.PedidoInvalido)
                .VerifyRule(produto == null, ProgramMessages.ProdutoInvalido)
                .ThrowExceptionDomain();


            Quantidade = quantidade;
            Preco = preco;
            Pedido = pedido;
            Produto = produto;
        }

        public override void UpdateInstance(ItemPedido e)
        {
            VerifyDomainRules.CreateInstance()
                .VerifyRule(e.Quantidade < 1, ProgramMessages.QuantidadeInvalida)
                .VerifyRule(e.Pedido == null, ProgramMessages.PedidoInvalido)
                .VerifyRule(e.Produto == null, ProgramMessages.ProdutoInvalido)
                .ThrowExceptionDomain();
            Quantidade = e.Quantidade;
            Preco = e.Preco;
            Pedido = e.Pedido;
            Produto = e.Produto;
        }

    }

}
