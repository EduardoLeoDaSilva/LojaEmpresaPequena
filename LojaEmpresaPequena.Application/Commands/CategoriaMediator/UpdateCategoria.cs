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
        public class UpdateCategoriaContract : IRequest<Result<string>>
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
        }

        public class Handler : IRequestHandler<UpdateCategoriaContract, Result<string>>
        {
            private ICategoriaService _categoriaService;
            public Handler(ICategoriaService categoriaService)
            {
                _categoriaService = categoriaService;
            }
            public async Task<Result<string>> Handle(UpdateCategoriaContract request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                    return  Result<string>.FailToMiddleware(ProgramMessages.IdErro);


                var categoriaFromDb = await _categoriaService.GetById(request.Id);


                if(String.IsNullOrEmpty(request.Nome) || string.IsNullOrWhiteSpace(request.Nome))
                     Result<string>.FailToMiddleware(ProgramMessages.NomeInvalido);

                categoriaFromDb.Nome = request.Nome;

                if(categoriaFromDb == null)
                      Result<string>.FailToMiddleware(ProgramMessages.Falha);

                await _categoriaService.Update(categoriaFromDb);

                return await Result<string>.Ok(ProgramMessages.Sucesso);
            }
        }
    }
}
