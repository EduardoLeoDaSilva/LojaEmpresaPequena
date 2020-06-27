using LojaEmpresaPequena.Domain.Entities.Interfaces;
using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LojaEmpresaPequena.Domain.Entities
{
   public class Usuario : IdentityUser, IBaseEntity<Usuario>
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public string Role { get; set; }
 
        public List<Endereco> Enderecos { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public string Telefone { get; set; }
        public string CodigoDeArea { get; set; }
       
        [JsonIgnore]
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }
        
        [JsonIgnore]
        public override string ConcurrencyStamp { get => base.ConcurrencyStamp; set => base.ConcurrencyStamp = value; }

        [JsonIgnore]
        public override string SecurityStamp { get => base.SecurityStamp; set => base.SecurityStamp = value; }

        [JsonIgnore]
        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }
       
        [JsonIgnore]
        public override bool TwoFactorEnabled { get => base.TwoFactorEnabled; set => base.TwoFactorEnabled = value; }
        
        [JsonIgnore]
        public override int AccessFailedCount { get => base.AccessFailedCount; set => base.AccessFailedCount = value; }
       
        [JsonIgnore]
        public override bool LockoutEnabled { get => base.LockoutEnabled; set => base.LockoutEnabled = value; }
        
        [JsonIgnore]
        public override DateTimeOffset? LockoutEnd { get => base.LockoutEnd; set => base.LockoutEnd = value; }
        
        [JsonIgnore]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        [JsonIgnore]
        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }
        public Usuario()
        {

        }

        public Usuario(string nome, string cpf, string role, List<Endereco> enderecos, List<Pedido> pedidos, string email)
        {

            VerifyDomainRules.CreateInstance().VerifyRule(String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome), ProgramMessages.NomeInvalido)
                .VerifyRule(String.IsNullOrEmpty(email) || String.IsNullOrWhiteSpace(email), ProgramMessages.EmailInvalido)
                .VerifyRule(String.IsNullOrEmpty(cpf) || String.IsNullOrWhiteSpace(cpf), ProgramMessages.CpfInvalido).ThrowExceptionDomain();
                
            Nome = nome;
            Cpf = cpf;
            Role = role;
            Enderecos = enderecos;
            Pedidos = pedidos;
            Email = email;
        }

        public void UpdateInstance(Usuario e)
        {
            VerifyDomainRules.CreateInstance().VerifyRule(String.IsNullOrEmpty(e.Nome) || String.IsNullOrWhiteSpace(e.Nome), ProgramMessages.NomeInvalido)
                 .VerifyRule(String.IsNullOrEmpty(e.Cpf) || String.IsNullOrWhiteSpace(e.Cpf), ProgramMessages.CpfInvalido).ThrowExceptionDomain();

            Nome = e.Nome;
            Cpf = e.Cpf;
            Role = e.Role;
            Enderecos = e.Enderecos;
            Pedidos = e.Pedidos;
            Telefone = e.Telefone;
            CodigoDeArea = e.CodigoDeArea;

        }
    }
}
