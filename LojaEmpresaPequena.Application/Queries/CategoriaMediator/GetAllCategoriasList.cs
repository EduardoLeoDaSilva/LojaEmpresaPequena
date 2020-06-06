using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Queries.CategoriaMediator
{
    public class GetAllCategoriasList
    {

        public class GetAllCategoriasListContract : IRequest<Result<CategoriasResponse>>
        {

        }

        public class CategoriasResponse
        {
            public List<Categoria> Categorias { get; set; }
        }

        public class Handler : IRequestHandler<GetAllCategoriasListContract, Result<CategoriasResponse>>
        {
            private ICategoriaService _categoriaService;
            public Handler(ICategoriaService categoriaService)
            {
                _categoriaService = categoriaService;
            }
            public async Task<Result<CategoriasResponse>> Handle(GetAllCategoriasListContract request, CancellationToken cancellationToken)
            {
                var listFromDb = await _categoriaService.GetAllCategoriasList();

                return await Result<CategoriasResponse>.Ok(new CategoriasResponse()
                {
                    Categorias = listFromDb

                }); ;


            }
        }
    }
}
