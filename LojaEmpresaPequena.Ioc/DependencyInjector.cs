using LojaEmpresaPequena.Context.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Services;
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

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IDetalhesPedidoService, DetalhesPedidoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IItemPedidoService, ItemPedidoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
