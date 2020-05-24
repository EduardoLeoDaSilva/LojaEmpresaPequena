using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
   public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Role { get; set; }
 
        public List<Endereco> Enderecos { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public Usuario(string nome, string cpf, string role, List<Endereco> enderecos, List<Pedido> pedidos)
        {

            VerifyDomainRules.CreateInstance().VerifyRule(String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome), ProgramMessages.NomeInvalido)
                .VerifyRule(String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome), ProgramMessages.CpfInvalido).ThrowExceptionDomain();
                
            Nome = nome;
            Cpf = cpf;
            Role = role;
            Enderecos = enderecos;
            Pedidos = pedidos;
        }

    }
}
