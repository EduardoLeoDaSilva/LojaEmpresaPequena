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
    public class SignIn
    {
        public class SignInContract : IRequest<Result<string>>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<SignInContract, Result<string>>
        {
            private readonly IUsuarioService _usuarioService;
            public Handler(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }
            public async Task<Result<string>> Handle(SignInContract request, CancellationToken cancellationToken)
            {

                if (String.IsNullOrEmpty(request.Email) || String.IsNullOrWhiteSpace(request.Email))
                    return await Result<string>.Fail(ProgramMessages.EmailInvalido);

                if (String.IsNullOrEmpty(request.Password) || String.IsNullOrWhiteSpace(request.Password))
                    return await Result<string>.Fail(ProgramMessages.SenhaInvalida);

                var result = await _usuarioService.SignIn(request.Email, request.Password);

                if (result.Succeeded)
                    return await Result<string>.Ok(ProgramMessages.Sucesso);

                if (result.IsNotAllowed)
                {
                    return await Result<string>.Fail(ProgramMessages.EmailSenha);
                }

                return await Result<string>.Fail(ProgramMessages.Falha);

            }
        }
    }
}
