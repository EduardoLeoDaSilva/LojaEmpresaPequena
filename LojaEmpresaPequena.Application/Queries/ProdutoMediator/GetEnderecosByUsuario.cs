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

namespace LojaEmpresaPequena.Application.Queries.ProdutoMediator
{
    public class GetEnderecosByUsuario
    {
        public class GetEnderecosByUsuarioContract : IRequest<Result<EnderecoResponse>>
        {
            public Usuario Usuario { get; set; }
        }

        public class EnderecoResponse
        {
            public List<Endereco> Enderecos { get; set; }
            public int RowCount { get; set; }
        }

        public class Handler : IRequestHandler<GetEnderecosByUsuarioContract, Result<EnderecoResponse>>
        {
            private readonly IEnderecoService _enderecoService;
            public Handler(IEnderecoService enderecoService)
            {
                _enderecoService = enderecoService;
            }

            public async Task<Result<EnderecoResponse>> Handle(GetEnderecosByUsuarioContract request, CancellationToken cancellationToken)
            {
                if (request.Usuario == null)
                    return await Result<EnderecoResponse>.Fail(ProgramMessages.UsuarioNulo);

                var enderecosUsuarioFromDb = _enderecoService.GetAll().Where(x => x.Usuario.Id == request.Usuario.Id);

                if(enderecosUsuarioFromDb.Count() < 1)
                    return await Result<EnderecoResponse>.Fail(ProgramMessages.TentarBuscarEnderecoErro);

                return await Result<EnderecoResponse>.Ok(new EnderecoResponse()
                {
                    Enderecos = enderecosUsuarioFromDb.ToList(),
                    RowCount = enderecosUsuarioFromDb.Count()
                });

            }
        }

    }
}
