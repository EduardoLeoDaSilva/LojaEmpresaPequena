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
    public class CreateUsuarioAdmin
    {

        public class CreateUsuarioAdminContract : IRequest<Result<string>>
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

        public class Handler : IRequestHandler<CreateUsuarioAdminContract, Result<string>>
        {
            private readonly IUsuarioService _usuarioService;
            public Handler(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }
            public async Task<Result<string>> Handle(CreateUsuarioAdminContract request, CancellationToken cancellationToken)
            {
                if (String.IsNullOrEmpty(request.Email) || String.IsNullOrWhiteSpace(request.Email))
                    return await Result<string>.Fail(ProgramMessages.EmailInvalido);

                if (String.IsNullOrEmpty(request.Senha) || String.IsNullOrWhiteSpace(request.Senha))
                    return await Result<string>.Fail(ProgramMessages.SenhaInvalida);

                var listaEndereco = new List<Endereco>();
                listaEndereco.Add(JsonConvert.DeserializeObject<Endereco>(request.Enderecos));
                var usuario = new Usuario
                {
                    Nome = request.Nome,
                    SobreNome = request.Sobrenome,
                    Cpf = request.Cpf,
                    Role = request.Role,
                    Email = request.Email,
                    Enderecos = listaEndereco,
                    Telefone = request.Telefone,
                    CodigoDeArea = request.CodigoDeArea
                };

                var result = await _usuarioService.CreateAdmin(usuario, request.Senha);

                if (result.Succeeded)
                    return await Result<string>.Ok(ProgramMessages.Sucesso);

                if (result.Errors.Count() > 0)
                {
                    return await Result<string>.Fail(result.Errors.Select(x => x.Description).ToArray());
                }

                return await Result<string>.Fail(ProgramMessages.Falha);

            }
        }


    }


}
