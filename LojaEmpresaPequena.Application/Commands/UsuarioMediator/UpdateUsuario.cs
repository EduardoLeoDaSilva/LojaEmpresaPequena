using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using MediatR;
using Newtonsoft.Json;
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
            public string Nome { get; set; }
            public string Sobrenome { get; set; }
            public string Cpf { get; set; }
            public string Role { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
            public string Enderecos { get; set; }
            public string Telefone { get; set; }
            public string CodigoDeArea { get; set; }
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
                var listaEndereco = new List<Endereco>();
                listaEndereco.Add(JsonConvert.DeserializeObject<Endereco>(request.Enderecos));
                var usuario = new Usuario
                {
                    Nome = request.Nome,
                    SobreNome = request.Sobrenome,
                    Cpf = request.Cpf,
                    Role = request.Role,
                    Email = request.Email,
                    Telefone = request.Telefone,
                    Enderecos = listaEndereco
                };

               var result = await _usuarioService.Update(usuario);

                if (result.Succeeded)
                    return await Result<string>.Ok(ProgramMessages.Sucesso);
                else
                    return  Result<string>.FailToMiddleware(result.Errors.Select(x => x.Description).ToArray());
            }
        }
    }
}
