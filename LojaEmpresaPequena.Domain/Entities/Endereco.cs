using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public string Rua { get; set; }
        public  string Numero { get; set; }
        public string Bairro { get; set; }
        public  string Cidade  { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }

        public Usuario Usuario { get; set; }

        public Endereco()
        {

        }
        public Endereco(string rua, string numero, string bairro, string cidade, string estado, string cep, string complemento, Usuario usuario)
        {

            VerifyDomainRules.CreateInstance()
                .VerifyRule(String.IsNullOrEmpty(rua) || String.IsNullOrWhiteSpace(rua), ProgramMessages.RuaInvalida)
                .VerifyRule(String.IsNullOrEmpty(numero) || String.IsNullOrWhiteSpace(numero), ProgramMessages.NumeroInvalido)
                .VerifyRule(String.IsNullOrEmpty(bairro) || String.IsNullOrWhiteSpace(bairro), ProgramMessages.BairroInvalido)
                .VerifyRule(String.IsNullOrEmpty(cidade) || String.IsNullOrWhiteSpace(cidade), ProgramMessages.CidadeInvalida)
                .VerifyRule(String.IsNullOrEmpty(estado) || String.IsNullOrWhiteSpace(estado), ProgramMessages.EstadoInvalido)
                .VerifyRule(String.IsNullOrEmpty(cep) || String.IsNullOrWhiteSpace(cep), ProgramMessages.CepInvalido)
                .VerifyRule(usuario == null, ProgramMessages.UsuarioNulo)
                .ThrowExceptionDomain();

            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Complemento = complemento;
            Usuario = usuario;
        }
    }

}
