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

namespace LojaEmpresaPequena.Application.Queries.UsuarioMediator
{
    public class GetUsuario
    {
        public class GetUsuarioContract : IRequest<Result<Usuario>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<GetUsuarioContract, Result<Usuario>>
        {
            private readonly IUsuarioService _usuarioService;
            public Handler(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }
            public async Task<Result<Usuario>> Handle(GetUsuarioContract request, CancellationToken cancellationToken)
            {
                var prodFromDb = await _usuarioService.GetById(request.Id);

                if (prodFromDb != null)
                {
                    return await Result<Usuario>.Ok(prodFromDb);
                }

                return await Result<Usuario>.Fail(ProgramMessages.Falha); ;
            }
        }
    }
}
