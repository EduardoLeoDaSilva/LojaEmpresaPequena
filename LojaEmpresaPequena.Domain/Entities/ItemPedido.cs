using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class ItemPedido : BaseEntity
    {
        public int Quantidade { get; set; }
        public  double Preco { get; set; }
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

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

    }

}
