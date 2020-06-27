using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Interfaces.Services.Jwt;
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
            private readonly IJwtService _jwtService;
            public Handler(IUsuarioService usuarioService, IJwtService jwtService)
            {
                _usuarioService = usuarioService;
                _jwtService = jwtService;
            }
            public async Task<Result<string>> Handle(SignInContract request, CancellationToken cancellationToken)
            {

                if (String.IsNullOrEmpty(request.Email) || String.IsNullOrWhiteSpace(request.Email))
                    return  Result<string>.FailToMiddleware(ProgramMessages.EmailInvalido);

                if (String.IsNullOrEmpty(request.Password) || String.IsNullOrWhiteSpace(request.Password))
                    return  Result<string>.FailToMiddleware(ProgramMessages.SenhaInvalida);

                var result = await _usuarioService.SignIn(request.Email, request.Password);

                if (result.Succeeded)
                {

                    var usuarioFromDb = await _usuarioService.GetByUsername(request.Email);
                    var jwtToken =  _jwtService.GenerateToken(usuarioFromDb);

                    return await Result<string>.Ok(jwtToken);
                }

                return  Result<string>.FailToMiddleware(ProgramMessages.EmailSenha);

            }
        }
    }
}
