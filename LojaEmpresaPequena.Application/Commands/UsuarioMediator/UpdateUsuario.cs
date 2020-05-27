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
    public class UpdateUsuario
    {
        public class UpdateUsuarioContract : IRequest<Result<string>>
        {
            public Usuario Usuario { get; set; }
        }

        public class Handler : IRequestHandler<UpdateUsuarioContract, Result<string>>
        {
            private IUsuarioService _usuarioService;
            public Handler(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }
            public async Task<Result<string>> Handle(UpdateUsuarioContract request, CancellationToken cancellationToken)
            {

               var result = await _usuarioService.Update(request.Usuario);

                if (result.Succeeded)
                    return await Result<string>.Ok(ProgramMessages.Sucesso);
                else
                    return await Result<string>.Fail(result.Errors.Select(x => x.Description).ToArray());
            }
        }
    }
}
