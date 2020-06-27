using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Endereco : BaseEntity<Endereco>
    {
        public string Rua { get; set; }
        public  string Numero { get; set; }
        public string Bairro { get; set; }
        public  string Cidade  { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }

        [JsonIgnore]
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

        public override void UpdateInstance(Endereco e)
        {
            VerifyDomainRules.CreateInstance()
                .VerifyRule(String.IsNullOrEmpty(e.Rua) || String.IsNullOrWhiteSpace(e.Rua), ProgramMessages.RuaInvalida)
                .VerifyRule(String.IsNullOrEmpty(e.Numero) || String.IsNullOrWhiteSpace(e.Numero), ProgramMessages.NumeroInvalido)
                .VerifyRule(String.IsNullOrEmpty(e.Bairro) || String.IsNullOrWhiteSpace(e.Bairro), ProgramMessages.BairroInvalido)
                .VerifyRule(String.IsNullOrEmpty(e.Cidade) || String.IsNullOrWhiteSpace(e.Cidade), ProgramMessages.CidadeInvalida)
                .VerifyRule(String.IsNullOrEmpty(e.Estado) || String.IsNullOrWhiteSpace(e.Estado), ProgramMessages.EstadoInvalido)
                .VerifyRule(String.IsNullOrEmpty(e.Cep) || String.IsNullOrWhiteSpace(e.Cep), ProgramMessages.CepInvalido)
                .VerifyRule(e.Usuario == null, ProgramMessages.UsuarioNulo)
                .ThrowExceptionDomain();

            Rua = e.Rua;
            Numero = e.Numero;
            Bairro = e.Bairro;
            Cidade = e.Cidade;
            Estado = e.Estado;
            Cep = e.Cep;
            Complemento = e.Complemento;
            Usuario = e.Usuario;
        }

    }

}
