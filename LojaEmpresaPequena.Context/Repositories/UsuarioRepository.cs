using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(LojaEmpresaPequenaIdentity context) : base(context)
        {

        }
    }
}
