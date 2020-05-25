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
        public PedidoService(IPedidoRepository repository, UserManager<Usuario> userManager) :base(repository)
        {
            _repository = repository;
            _userManager = userManager;
        }


    
        public async Task<Pedido> CreatePedido(Usuario usuario)
        {
            var pedido = _repository.GetCurrentPedido(usuario);
            if(pedido != null)
            {
                return pedido;
            }
            else
            {
                var usuarioFromDB = await _userManager.FindByNameAsync(usuario.Cpf);
                pedido = new Pedido(DateTime.Now, null, StatusPedido.Carrinho, StatusEnvio.NaoEnviado, usuarioFromDB,null);
                return pedido;
            }
        }


    }
}
