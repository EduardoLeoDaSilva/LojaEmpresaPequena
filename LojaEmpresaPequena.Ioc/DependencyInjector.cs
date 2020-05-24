using LojaEmpresaPequena.Context.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
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
        }
    }
}
