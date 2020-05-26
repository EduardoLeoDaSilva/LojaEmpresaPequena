using LojaEmpresaPequena.Domain.Entities.Interfaces;
using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
   public class Usuario : IdentityUser, IBaseEntity<Usuario>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Role { get; set; }
 
        public List<Endereco> Enderecos { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public Usuario()
        {

        }

        public Usuario(string nome, string cpf, string role, List<Endereco> enderecos, List<Pedido> pedidos)
        {

            VerifyDomainRules.CreateInstance().VerifyRule(String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome), ProgramMessages.NomeInvalido)
                .VerifyRule(String.IsNullOrEmpty(cpf) || String.IsNullOrWhiteSpace(cpf), ProgramMessages.CpfInvalido).ThrowExceptionDomain();
                
            Nome = nome;
            Cpf = cpf;
            Role = role;
            Enderecos = enderecos;
            Pedidos = pedidos;
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

        }
    }
}
