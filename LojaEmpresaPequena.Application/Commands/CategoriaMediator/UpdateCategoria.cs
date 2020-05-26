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
    public class UpdateCategoria
    {
        public class UpateCategoriaContract : IRequest<Result<string>>
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
        }

        public class Handler : IRequestHandler<UpateCategoriaContract, Result<string>>
        {
            private ICategoriaService _categoriaService;
            public Handler(ICategoriaService categoriaService)
            {
                _categoriaService = categoriaService;
            }
            public async Task<Result<string>> Handle(UpateCategoriaContract request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                    return await Result<string>.Fail(ProgramMessages.IdErro);


                var categoriaFromDb = await _categoriaService.GetById(request.Id);

                if(categoriaFromDb == null)
                    return await Result<string>.Fail(ProgramMessages.Falha);

                _categoriaService.Update(categoriaFromDb);

                return await Result<string>.Ok(ProgramMessages.Sucesso);
            }
        }
    }
}
