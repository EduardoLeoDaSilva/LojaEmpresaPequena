using LojaEmpresaPequena.Context.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Interfaces.Services.Email;
using LojaEmpresaPequena.Domain.Services;
using LojaEmpresaPequena.Domain.Services.Email;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Ioc
{
    public static class DependencyInjector
    {
        public static void Inject(IServiceCollection services)
        {
            //repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IDetalhesPedidoRepository, DetalhesPedidoRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            //services
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IDetalhesPedidoService, DetalhesPedidoService>();
            services.AddTransient<IEnderecoService, EnderecoService>();
            services.AddTransient<IItemPedidoService, ItemPedidoService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
