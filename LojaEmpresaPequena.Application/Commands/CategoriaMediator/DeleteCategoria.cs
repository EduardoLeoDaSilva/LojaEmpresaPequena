using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Commands.CategoriaMediator
{
    public class DeleteCategoria
    {
        public class DeleteCategoriaContract : IRequest<Result<string>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<DeleteCategoriaContract, Result<string>>
        {
            private readonly ICategoriaService _categoriaService;
            public Handler(ICategoriaService categoriaService)
            {
                _categoriaService = categoriaService;
            }

            public async Task<Result<string>> Handle(DeleteCategoriaContract request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                    return await Result<string>.Fail(ProgramMessages.IdErro);

                _categoriaService.Delete(request.Id);

                return await Result<string>.Ok(ProgramMessages.Sucesso);

            }
        }

    }
}
