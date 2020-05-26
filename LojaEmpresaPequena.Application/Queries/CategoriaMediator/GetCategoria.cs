using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Queries.CategoriaMediator
{
    public class GetCategoria
    {
        public class GetCategoriaContract : IRequest<Result<Categoria>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<GetCategoriaContract, Result<Categoria>>
        {
            private readonly ICategoriaService _categoriaService;
            public Handler(ICategoriaService categoriaService)
            {
                _categoriaService = categoriaService;
            }
            public async Task<Result<Categoria>> Handle(GetCategoriaContract request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                    return await Result<Categoria>.Fail(ProgramMessages.IdErro);

                var categoria =await _categoriaService.GetById(request.Id);

                if (categoria == null)
                    return await Result<Categoria>.Fail(ProgramMessages.CategoriaAttempt);

                return await Result<Categoria>.Ok(categoria);

            }
        }
    }
}
