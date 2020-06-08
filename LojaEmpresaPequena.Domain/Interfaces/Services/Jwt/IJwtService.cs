using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Interfaces.Services.Jwt
{
    public interface IJwtService
    {
        string GenerateToken(Usuario usuario);
    }
}
