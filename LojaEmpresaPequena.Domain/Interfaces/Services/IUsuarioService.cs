using LojaEmpresaPequena.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<IdentityResult> CreateUser(Usuario usuario, string password);
        Task<IdentityResult> ChangePassword(Usuario usuario, string newPassword);
        Task<SignInResult> SignIn(string email, string password);
        Task SignInOut();
    }
}
