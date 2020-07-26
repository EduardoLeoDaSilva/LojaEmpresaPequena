using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Commands.UsuarioMediator
{
    public class SignOut
    {
        public class SignOutContract : IRequest<Result<string>>
        {

        }

        public class Handler : IRequestHandler<SignOutContract, Result<string>>
        {
            private readonly IUsuarioService _usuarioService;
            public Handler(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }
            public async Task<Result<string>> Handle(SignOutContract request, CancellationToken cancellationToken)
            {

                 await _usuarioService.SignInOut();

                return await Result<string>.Ok(ProgramMessages.Sucesso);

            }
        }
    }
}
