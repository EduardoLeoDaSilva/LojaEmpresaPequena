using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Enums;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
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
    
        public async Task<Pedido> CreatePedidoOrAddItemPedido(Usuario usuario, Produto produto)
        {
            var pedido = _repository.GetCurrentPedido(usuario);
            var produtoFromDb = await _produtoRepository.GetById(produto.Id);

            if (pedido != null)
            {
                pedido.ItemPedidos.Add(new ItemPedido(1, produtoFromDb.Preco, pedido, produtoFromDb));
                await _repository.Update(pedido);
                return pedido;
            }
            else
            {
                var usuarioFromDB = await _userManager.FindByNameAsync(usuario.Cpf);
                pedido = new Pedido(DateTime.Now, null, StatusPedido.Carrinho, StatusEnvio.EsperandoAprovacao, usuarioFromDB,new List<ItemPedido>());
                pedido.ItemPedidos.Add(new ItemPedido(1, produtoFromDb.Preco, pedido, produtoFromDb));
                await _repository.Save(pedido);
                return pedido;
            }
        }


    }
}
