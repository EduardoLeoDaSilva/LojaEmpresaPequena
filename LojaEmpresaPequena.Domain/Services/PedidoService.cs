using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Enums;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using Microsoft.AspNetCore.Identity;
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
        public PedidoService(IPedidoRepository repository, UserManager<Usuario> userManager, IProdutoRepository produtoRepository) :base(repository)
        {
            _repository = repository;
            _userManager = userManager;
            _produtoRepository = produtoRepository;
        }


        public  Pedido GetCurrentPedido(Usuario usuario)
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
                if(prod != null)
                {
                    listaProdutosDb.Add(prod);
                }
            }

            if (pedido != null)
            {
                foreach (var produto in listaProdutosDb)
                {
                pedido.ItemPedidos.Add(new ItemPedido(1, produto.Preco, pedido, produto));
                }

                await _repository.Update(pedido);
                return pedido;
            }
            else
            {
                var usuarioFromDB = await _userManager.FindByIdAsync(usuario.Id);
                pedido = new Pedido(DateTime.Now, null, StatusPedido.Carrinho, StatusEnvio.EsperandoAprovacao, usuarioFromDB,new List<ItemPedido>());
                foreach (var produto in listaProdutosDb)
                {
                pedido.ItemPedidos.Add(new ItemPedido(1, produto.Preco, pedido, produto));
                }

                await _repository.Save(pedido);
                return pedido;
            }
        }

        public async Task PayPedido(Usuario usuario)
        {
            var pedido = _repository.GetCurrentPedido(usuario);

            pedido.StatusPedido = StatusPedido.Aprovado;
            pedido.DetalhesPedido.DataAprovacao = DateTime.Now;
            pedido.StatusEnvio = StatusEnvio.ASerEnviado;
            await _repository.Update(pedido);
        }

    }
}
