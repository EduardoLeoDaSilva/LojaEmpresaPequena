using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Queries.CategoriaMediator
{
    public class GetAllCategorias
    {
        public class GetAllCategoriasContract : IRequest<Result<CategoriasResponse>>
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public string SortOrder { get; set; }
            public string SortField { get; set; }
            public string NomeFilter { get; set; }
        }

        public class CategoriasResponse
        {
            public List<Categoria> Categorias { get; set; }
            public int RowCount { get; set; }
        }

        public class Handler : IRequestHandler<GetAllCategoriasContract, Result<CategoriasResponse>>
        {
            private ICategoriaService _categoriaService;
            public Handler(ICategoriaService categoriaService)
            {
                _categoriaService = categoriaService;
            }
            public async Task<Result<CategoriasResponse>> Handle(GetAllCategoriasContract request, CancellationToken cancellationToken)
            {

                var listFromDb = _categoriaService.GetAll();

                if (!String.IsNullOrEmpty(request.NomeFilter) || !String.IsNullOrWhiteSpace(request.NomeFilter))
                {
                    listFromDb = listFromDb.Where(x => x.Nome.Contains(request.NomeFilter));
                }

                var pagedList = listFromDb.ToPagedList(request.Page, request.PageSize);

                return await Result<CategoriasResponse>.Ok(new CategoriasResponse()
                {
                 Categorias = pagedList.ToList(),
                 RowCount = pagedList.PageCount
                });;


            }
        }

    }
}
