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

namespace LojaEmpresaPequena.Application.Commands.CategoriaMediator
{
    public class CreateCategoria
    {
        public class CreateCategoriaContract : IRequest<Result<string>>
        {
            public string Nome { get; set; }
        }

        public class Handler : IRequestHandler<CreateCategoriaContract, Result<string>>
        {
            private readonly ICategoriaService _categoriaService;
            public Handler(ICategoriaService categoriaService)
            {
                _categoriaService = categoriaService;
            }

            public async Task<Result<string>> Handle(CreateCategoriaContract request, CancellationToken cancellationToken)
            {
                var categoria = new Categoria(request.Nome);

                await _categoriaService.Save(categoria);

                return await Result<string>.Ok(ProgramMessages.Sucesso);

            }
        }
    }

    
}
