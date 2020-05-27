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
    public class CreateUsuarioAdmin 
    {

        public class CreateUsuarioAdminContract : IRequest<Result<string>>
        {
            public Usuario Usuario { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<CreateUsuarioAdminContract, Result<string>>
        {
            private readonly IUsuarioService _usuarioService;
            public Handler(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }
            public async Task<Result<string>> Handle(CreateUsuarioAdminContract request, CancellationToken cancellationToken)
            {
                if (request.Usuario == null)
                    return await Result<string>.Fail(ProgramMessages.UsuarioNulo);

                if (String.IsNullOrEmpty(request.Password) || String.IsNullOrWhiteSpace(request.Password))
                    return await Result<string>.Fail(ProgramMessages.SenhaInvalida);

                var result = await _usuarioService.CreateAdmin(request.Usuario, request.Password);

                if (result.Succeeded)
                    return await Result<string>.Ok(ProgramMessages.Sucesso);

                if(result.Errors.Count() > 0)
                {
                    return await Result<string>.Fail(result.Errors.Select(x => x.Description).ToArray());
                }

                return await Result<string>.Fail(ProgramMessages.Falha);

            }
        }


    }


}
