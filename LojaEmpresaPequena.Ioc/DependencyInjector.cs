using LojaEmpresaPequena.Context.Repositories;
using LojaEmpresaPequena.Domain.HttpClients.MercadoPagoIntegration;
using LojaEmpresaPequena.Domain.Interfaces.Integrations;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Interfaces.Services.Email;
using LojaEmpresaPequena.Domain.Interfaces.Services.Jwt;
using LojaEmpresaPequena.Domain.Services;
using LojaEmpresaPequena.Domain.Services.Email;
using LojaEmpresaPequena.Domain.Services.Jwt;
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
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IDetalhesPedidoRepository, DetalhesPedidoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //services
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IDetalhesPedidoService, DetalhesPedidoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IItemPedidoService, ItemPedidoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IMercadoPagoIntegrationService, MercadoPagoIntegrationService>();
        }
    }
}
