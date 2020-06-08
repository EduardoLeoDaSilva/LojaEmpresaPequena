using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using LojaEmpresaPequena.Domain.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, RoleManager<IdentityRole> roleManager, IUsuarioRepository usuarioRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IdentityResult> CreateUser(Usuario usuario, string password)
        {
            //validacao
            VerifyDomainRules.CreateInstance().VerifyRule(String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password), ProgramMessages.SenhaInvalida).ThrowExceptionDomain();

            var role = await _roleManager.FindByNameAsync("Cliente");
            if(role == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("Cliente"));
            }
            usuario.UserName = usuario.Email;
            var result = await _userManager.CreateAsync(usuario, password);


            if (result.Succeeded)
                await _userManager.AddToRoleAsync(usuario, "Cliente");

            return result;

        }

        public async Task<IdentityResult> CreateAdmin(Usuario usuario, string password)
        {
            //validacao
            VerifyDomainRules.CreateInstance().VerifyRule(String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password), ProgramMessages.SenhaInvalida).ThrowExceptionDomain();
            var role = await _roleManager.FindByNameAsync("Admin");
            if (role == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            usuario.UserName = usuario.Email;
            var result = await _userManager.CreateAsync(usuario, password);

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(usuario, "Admin");
            
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

        public async Task<IdentityResult> Update(Usuario usuario)
        {

            VerifyDomainRules.CreateInstance()
                        .VerifyRule(usuario == null, ProgramMessages.UsuarioNulo)
                        .ThrowExceptionDomain();

            var usuarioFromDb = await _userManager.FindByEmailAsync(usuario.Email);

            VerifyDomainRules.CreateInstance()
                       .VerifyRule(usuarioFromDb == null, ProgramMessages.UsuarioNulo);

            usuarioFromDb.UpdateInstance(usuario);


            return await _userManager.UpdateAsync(usuarioFromDb);

        }

        public async Task SignInOut()
        {
            await _signInManager.SignOutAsync();
        }

        public  IQueryable<Usuario> GetAllUsuariosClientes()
        {
            var usuariosFromDb =  _usuarioRepository.GetAll();
            return usuariosFromDb;

        }

        public async Task<Usuario> GetById(Guid id)
        {
            var usuariosFromDb = await _usuarioRepository.GetById(id);
            return usuariosFromDb;
        }
    }
}
