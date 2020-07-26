using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Enums;
using LojaEmpresaPequena.Domain.Interfaces.Integrations;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Services
{
    public class PedidoService : BaseService<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly UserManager<Usuario> _userManager;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMercadoPagoIntegrationService _mercadoPagoService;
        private readonly IConfiguration _configuration;
        public PedidoService(IPedidoRepository repository, IConfiguration configuration, UserManager<Usuario> userManager, IProdutoRepository produtoRepository, IMercadoPagoIntegrationService mercadoPagoService) : base(repository)
        {
            _repository = repository;
            _userManager = userManager;
            _produtoRepository = produtoRepository;
            _mercadoPagoService = mercadoPagoService;
            _configuration = configuration;
        }


        public Pedido GetCurrentPedido(Usuario usuario)
        {
            return _repository.GetCurrentPedido(usuario);
        }

        public async Task<Pedido> CreatePedidoOrAddItemPedido(Usuario usuario, List<Guid> produtos)
        {
            var pedido = _repository.GetCurrentPedido(usuario);
            //var produtoFromDb = await _produtoRepository.GetById(produto.Id);
            var listaProdutosDb = new List<Produto>();
            foreach (var prodId in produtos)
            {
                var prod = await _produtoRepository.GetById(prodId);
                if (prod != null)
                {
                    listaProdutosDb.Add(prod);
                }
            }

            if (pedido != null)
            {
                foreach (var produto in listaProdutosDb)
                {
                    var existItem = pedido.ItemPedidos.FirstOrDefault(x => x.Produto.Id == produto.Id);
                    if(existItem != null)
                    {
                        pedido.ItemPedidos.FirstOrDefault(x => x.Produto.Id == existItem.Produto.Id).Quantidade += 1;
                    }
                    else
                    {
                    pedido.ItemPedidos.Add(new ItemPedido(1, produto.Preco, pedido, produto));
                    }

                }
                pedido.CalcularTotalPedido();

                await _repository.Update(pedido);
                return pedido;
            }
            else
            {
                var usuarioFromDB = await _userManager.FindByIdAsync(usuario.Id);
                pedido = new Pedido(DateTime.Now, null, StatusPedido.Carrinho, StatusEnvio.EsperandoAprovacao, usuarioFromDB, new List<ItemPedido>(), 0);
                foreach (var produto in listaProdutosDb)
                {
                    pedido.ItemPedidos.Add(new ItemPedido(1, produto.Preco, pedido, produto));
                }
                pedido.CalcularTotalPedido();


                await _repository.Save(pedido);
                return pedido;
            }
        }

        public async Task<Pedido> PayPedido(Usuario usuario, string token, string bandeira = "mastercard", string platform = "SI", string paymentType = "credit_card")
        {
            var pedido = _repository.GetCurrentPedido(usuario);



            /////MUDAR DEPOIS
            var payment = await _mercadoPagoService.PayOrder(usuario, pedido.GetItensPedidoQuanString(), (float)pedido.Total, 1, bandeira, token, paymentType: paymentType);
            //////
            ///
            if (payment != null)
            {
                pedido.CodigoPedido = $"{platform}{payment.Id}";

                if (payment.Status == "approved")
                {
                    pedido.StatusPedido = StatusPedido.Aprovado;
                    pedido.DetalhesPedido.DataAprovacao = DateTime.Now;
                    pedido.StatusEnvio = StatusEnvio.EmPreparacao;
                }
                else if (payment.Status == "rejected")
                {
                    pedido.StatusPedido = StatusPedido.Rejeitado;
                    pedido.StatusEnvio = StatusEnvio.PagamentoRejeitado;
                }
                pedido.StatementDescriptor = payment.Statement_descriptor;
                pedido.StatusDetailed = payment.Status_detail;
            }
            await _repository.Update(pedido);
            return pedido;
        }

        public IQueryable<Pedido> GetPedidosByUsuarioId(string email)
        {
            var pedidosFromDb = _repository.GetByUserName(email);
            return pedidosFromDb;
        }

    }
}
