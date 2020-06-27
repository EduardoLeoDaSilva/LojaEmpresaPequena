using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Commands.UsuarioMediator
{
    public class ChangePassword
    {
        public class ChangePasswordContract : IRequest<Result<string>>
        {
            public Usuario Usuario { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<ChangePasswordContract, Result<string>>
        {
            private readonly IUsuarioService _usuarioService;
            public Handler(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }
            public async Task<Result<string>> Handle(ChangePasswordContract request, CancellationToken cancellationToken)
            {
                if (request.Usuario == null)
                    return  Result<string>.FailToMiddleware(ProgramMessages.UsuarioNulo);

                if (String.IsNullOrEmpty(request.Password) || String.IsNullOrWhiteSpace(request.Password))
                    return  Result<string>.FailToMiddleware(ProgramMessages.SenhaInvalida);

                var result = await _usuarioService.ChangePassword(request.Usuario, request.Password);

                if (result.Succeeded)
                    return await Result<string>.Ok(ProgramMessages.Sucesso);

                if (result.Errors.Count() > 0)
                {
                    return  Result<string>.FailToMiddleware(result.Errors.Select(x => x.Description).ToArray());
                }

                return  Result<string>.FailToMiddleware(ProgramMessages.Falha);

            }
        }
    }
}
