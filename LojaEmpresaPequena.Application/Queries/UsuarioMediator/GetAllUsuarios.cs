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

namespace LojaEmpresaPequena.Application.Queries.UsuarioMediator
{
    public class GetAllUsuarios
    {

        public class GetAllUsuariosContract : IRequest<Result<UsuarioResponse>>
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public string SortOrder { get; set; }
            public string SortField { get; set; }
            public string NomeFilter { get; set; }
            public string EmailFilter { get; set; }
            public string CpfFilter { get; set; }
        }

        public class UsuarioResponse
        {
            public IList<Usuario> Usuarios { get; set; }
            public int RowCount { get; set; }
        }


        public class Handler : IRequestHandler<GetAllUsuariosContract, Result<UsuarioResponse>>
        {
            private readonly IUsuarioService _usuarioService;

            public Handler(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }

            public Task<Result<UsuarioResponse>> Handle(GetAllUsuariosContract request, CancellationToken cancellationToken)
            {
                var listProdFromDb = _usuarioService.GetAllUsuariosClientes();

                if (!String.IsNullOrEmpty(request.NomeFilter) || !String.IsNullOrWhiteSpace(request.NomeFilter))
                {
                    listProdFromDb = listProdFromDb.Where(x => x.Nome.Contains(request.NomeFilter));
                }

                if (!String.IsNullOrEmpty(request.EmailFilter) || !String.IsNullOrWhiteSpace(request.EmailFilter))
                {
                    listProdFromDb = listProdFromDb.Where(x => x.Email.Contains(request.EmailFilter));
                }

                if (!String.IsNullOrEmpty(request.CpfFilter) || !String.IsNullOrWhiteSpace(request.CpfFilter))
                {
                    listProdFromDb = listProdFromDb.Where(x => x.Cpf.Contains(request.CpfFilter));
                }

                var pagedList = listProdFromDb.ToPagedList(request.Page, request.PageSize);

                return Result<UsuarioResponse>.Ok(
                     new UsuarioResponse()
                     {
                         Usuarios = pagedList.ToList(),
                         RowCount = pagedList.PageCount
                     }
                    );
            }
        }
    }
}
