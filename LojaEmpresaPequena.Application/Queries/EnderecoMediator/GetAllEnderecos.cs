using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using MediatR;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Application.Queries.EnderecoMediator
{
    public class GetAllEnderecos
    {
        public class GetAllEnderecosContract : IRequest<Result<EnderecoResponse>>
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public string SortOrder { get; set; }
            public string SortField { get; set; }
            public string UsuarioNomeFilter { get; set; }
        }

        public class EnderecoResponse
        {
            public List<Endereco> Enderecos { get; set; }
            public int RowCount { get; set; }
        }

        public class Handler : IRequestHandler<GetAllEnderecosContract, Result<EnderecoResponse>>
        {
            private readonly IEnderecoService _enderecoService;
            public Handler(IEnderecoService enderecoService)
            {
                _enderecoService = enderecoService;
            }
            public Task<Result<EnderecoResponse>> Handle(GetAllEnderecosContract request, CancellationToken cancellationToken)
            {
                var listFromDb = _enderecoService.GetAll();

                if(!String.IsNullOrEmpty(request.UsuarioNomeFilter) || !String.IsNullOrWhiteSpace(request.UsuarioNomeFilter))
                {
                    listFromDb = listFromDb.Where(x => x.Usuario.Nome.Contains(request.UsuarioNomeFilter));
                }

                var pagedList = listFromDb.ToPagedList(request.Page, request.PageSize);

                return Result<EnderecoResponse>.Ok(new EnderecoResponse()
                {
                    Enderecos = pagedList.ToList(),
                    RowCount = pagedList.PageCount
                }) ;

            }
        }
    }
}
