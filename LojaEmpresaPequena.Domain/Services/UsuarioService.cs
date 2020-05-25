using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(Usuario usuario, string password)
        {
            //validacao
            VerifyDomainRules.CreateInstance().VerifyRule(String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password), ProgramMessages.SenhaInvalida).ThrowExceptionDomain();
            var role = _roleManager.FindByNameAsync("Cliente");
            var result = await _userManager.CreateAsync(usuario, password);
            return result;

        }

        public async Task<IdentityResult> CreateAdmin(Usuario usuario, string password)
        {
            //validacao
            VerifyDomainRules.CreateInstance().VerifyRule(String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password), ProgramMessages.SenhaInvalida).ThrowExceptionDomain();
            var role = _roleManager.FindByNameAsync("Admin");
            var result = await _userManager.CreateAsync(usuario, password);
            return result;

        }

        public async Task<IdentityResult> ChangePassword(Usuario usuario, string newPassword)
        {
            //validacao
            VerifyDomainRules.CreateInstance().VerifyRule(String.IsNullOrEmpty(newPassword) || String.IsNullOrWhiteSpace(newPassword), ProgramMessages.SenhaInvalida).ThrowExceptionDomain();

            var usuarioFromDb = await _userManager.FindByEmailAsync(usuario.Email);
            var tokenReset = await _userManager.GeneratePasswordResetTokenAsync(usuarioFromDb);
            var result = await _userManager.ResetPasswordAsync(usuarioFromDb, tokenReset, newPassword);
            return result;
        }

        public async Task<SignInResult> SignIn(string email, string password)
        {
            VerifyDomainRules.CreateInstance()
                .VerifyRule(String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password), ProgramMessages.SenhaInvalida)
                .VerifyRule(String.IsNullOrEmpty(email) || String.IsNullOrWhiteSpace(email), ProgramMessages.EmailInvalido)
                .ThrowExceptionDomain();

            var result = await _signInManager.PasswordSignInAsync(email, password, true, false);

            return result;
        }

        public async Task SignInOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
